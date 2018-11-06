using System;
using System.Collections.Generic;
using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using eSortingByEnum;

namespace SortingFriends_Engine
{
    public class FeaturesEngine
    {
        private const int k_NotInitialized = -1, k_ChangePositions = 1, k_NotChangePosition = -1, k_BestFriendNotFound = -1, k_IndexNotFound = -1;
        private const string k_AppId = "1027335734116799";
        private User m_LoggedInUser;
        private User m_BestFriend;
        private List<User> m_Friends;
        private int m_AlbumPictureIndex = 0;
        private int m_AlbumIndex = 0;

        public void LoginUser()
        {
            LoginResult result = FacebookService.Login(k_AppId, "public_profile", "user_friends", "user_birthday",
                "user_gender", "user_likes", "user_posts", "user_tagged_places");
            if (!string.IsNullOrEmpty(result.AccessToken))
            {
                m_LoggedInUser = result.LoggedInUser;
                fetchFriends();
            }
        }

        public void LogoutUser()
        {
            if (m_LoggedInUser != null)
            {
                FacebookService.Logout(null);
            }
        }

        private void fetchFriends()
        {
            m_Friends = new List<User>();
            foreach (User friend in m_LoggedInUser.Friends)
            {
                m_Friends.Add(friend);
            }

            m_Friends.Add(m_LoggedInUser);
        }

        public List<string> GetFriends()
        {
            List<string> friends = new List<string>();

            foreach (User friend in m_Friends)
            {
                friends.Add($"{friend.FirstName} {friend.LastName}");
            }

            return friends;
        }

        public string GetPictureFromAlbum(int i_FriendIndex)
        {
            string pictureURL = null;
            if(m_Friends[i_FriendIndex].Albums.Count > 0 && m_Friends[i_FriendIndex].Albums[m_AlbumIndex].Photos.Count > 0)
            {
                pictureURL = m_Friends[i_FriendIndex].Albums[m_AlbumIndex].Photos[m_AlbumPictureIndex].Images[0].Source;
            }
            return pictureURL;
        }

        public string GetAlbumName(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].Albums[m_AlbumIndex].Name;
        }

        public string GetPictureTitle(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].Albums[m_AlbumIndex].Photos[m_AlbumPictureIndex].Name;
        }

        public string GetFriendPicture(int i_FriendIndex)
        {
            return m_Friends[i_FriendIndex].PictureLargeURL;
        }

        public void InitialAlbumIndexes()
        {
            m_AlbumPictureIndex = m_AlbumIndex = 0;
        }

        public bool SetNextAlbumIndex(int i_FriendIndex)
        {
            bool setNextAlbumSucceed = false;
            if (m_AlbumIndex + 1 < m_Friends[i_FriendIndex].Albums.Count)
            {
                setNextAlbumSucceed = true;
                m_AlbumIndex++;
                m_AlbumPictureIndex = 0;
            }
            return setNextAlbumSucceed;
        }

        public bool SetPrevAlbumIndex()
        {
            bool setPrevAlbumSucceed = false;
            if(m_AlbumIndex - 1 >= 0)
            {
                setPrevAlbumSucceed = true;
                m_AlbumIndex--;
                m_AlbumPictureIndex = 0;
            }
            return setPrevAlbumSucceed;
        }

        public bool SetPrevPictureAlbumIndex()
        {
            bool setPrevPictureInAlbumSucceed = false;
            if (m_AlbumPictureIndex - 1 >= 0)
            {
                setPrevPictureInAlbumSucceed = true;
                m_AlbumPictureIndex--;
            }
            return setPrevPictureInAlbumSucceed;
        }

        public bool SetNextPictureAlbumIndex(int i_FriendIndex)
        {
            bool setNextPictureInAlbumSucceed = false;
            if (m_AlbumPictureIndex + 1 < m_Friends[i_FriendIndex].Albums[m_AlbumIndex].Photos.Count)
            {
                setNextPictureInAlbumSucceed = true;
                m_AlbumPictureIndex++;
            }
            return setNextPictureInAlbumSucceed;

        }

        public string GetFriendBirthdayOrAgeAttribute(int i_FriendIndex, int i_SortingBySelectedIndex)
        {
            eSortingBy sortingOption = (eSortingBy)i_SortingBySelectedIndex;
            string returnValue = null;

            if (i_FriendIndex != k_IndexNotFound)
            {
                if (sortingOption == eSortingBy.Birthday)
                {
                    returnValue = $"Birthday Date: {m_Friends[i_FriendIndex].Birthday}";
                }
                else if (sortingOption == eSortingBy.Age)
                {
                    string birthday = m_Friends[i_FriendIndex].Birthday;
                    DateTime birthdayDate = new DateTime(
                         int.Parse(birthday.Substring(6, 4)),
                         int.Parse(birthday.Substring(0, 2)),
                         int.Parse(birthday.Substring(3, 2)));
                    returnValue = $"Age: {calculateAge(birthdayDate)}";
                }
            }

            return returnValue;
        }

        public void SortFriends(int i_ComparisonIndex)
        {
            eSortingBy comparisonBy = (eSortingBy)i_ComparisonIndex;

            switch (comparisonBy)
            {
                case eSortingBy.Default:
                    {
                        fetchFriends();
                        break;
                    }

                case eSortingBy.FirstName:
                    {
                        m_Friends.Sort(firstNameComparison);
                        break;
                    }

                case eSortingBy.LastName:
                    {
                        m_Friends.Sort(lastNameComparison);
                        break;
                    }

                case eSortingBy.Birthday:
                    {
                        m_Friends.Sort(birthDayComparison);
                        break;
                    }

                case eSortingBy.Age:
                    {
                        m_Friends.Sort(ageComparison);
                        break;
                    }
                case eSortingBy.MostPosts:
                    {
                        m_Friends.Sort(postsComparison);
                        break;
                    }
                case eSortingBy.MostCheckIns:
                    {
                        m_Friends.Sort(checkInsComparison);
                        break;
                    }
                case eSortingBy.MostTags:
                    {
                        m_Friends.Sort(tagsComparison);
                        break;
                    }
                case eSortingBy.MostAlbums:
                    {
                        m_Friends.Sort(albumsComparison);
                        break;
                    }
            }
        }

        private int firstNameComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.FirstName.CompareTo(i_SecondPerson.FirstName);
        }

        private int lastNameComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.LastName.CompareTo(i_SecondPerson.LastName);
        }

        private int birthDayComparison(User i_FirstPerson, User i_SecondPerson)
        {
            int returnValue, firstPersonMonth, secondPersonMonth, firstPersonDay, secondPersonDay;
            int.TryParse(i_FirstPerson.Birthday.Substring(0, 2), out firstPersonMonth);
            int.TryParse(i_SecondPerson.Birthday.Substring(0, 2), out secondPersonMonth);

            if (firstPersonMonth == secondPersonMonth)
            {
                int.TryParse(i_FirstPerson.Birthday.Substring(3, 2), out firstPersonDay);
                int.TryParse(i_SecondPerson.Birthday.Substring(3, 2), out secondPersonDay);
                returnValue = firstPersonDay < secondPersonDay ? k_NotChangePosition : k_ChangePositions;
            }
            else
            {
                returnValue = firstPersonMonth < secondPersonMonth ? k_NotChangePosition : k_ChangePositions;
            }

            return returnValue;
        }

        private int ageComparison(User i_FirstPerson, User i_SecondPerson)
        {
            DateTime firstPersonBirthday = new DateTime(
                 int.Parse(i_FirstPerson.Birthday.Substring(6, 4)),
                 int.Parse(i_FirstPerson.Birthday.Substring(0, 2)),
                 int.Parse(i_FirstPerson.Birthday.Substring(3, 2)));
            DateTime secondPersonBirthday = new DateTime(
                 int.Parse(i_SecondPerson.Birthday.Substring(6, 4)),
                 int.Parse(i_SecondPerson.Birthday.Substring(0, 2)),
                 int.Parse(i_SecondPerson.Birthday.Substring(3, 2)));
            int firstPersonAge = calculateAge(firstPersonBirthday);
            int secondPersonAge = calculateAge(secondPersonBirthday);

            return firstPersonAge < secondPersonAge ? k_NotChangePosition : k_ChangePositions;
        }

        private int PostsComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.WallPosts.Count.CompareTo(i_SecondPerson.WallPosts.Count);
        }

        private int checkInsComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.Checkins.Count.CompareTo(i_SecondPerson.Checkins.Count);
        }

        private int tagsComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.PhotosTaggedIn.Count.CompareTo(i_SecondPerson.PhotosTaggedIn.Count);
        }

        private int albumsComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.Albums.Count.CompareTo(i_SecondPerson.Albums.Count);
        }

        private int postsComparison(User i_FirstPerson, User i_SecondPerson)
        {
            return i_FirstPerson.WallPosts.Count.CompareTo(i_SecondPerson.WallPosts.Count);
        }

        private int calculateAge(DateTime i_Birthday)
        {
            DateTime now = DateTime.Now;
            int age = now.Year - i_Birthday.Year;

            if ((now.Month == i_Birthday.Month && now.Day < i_Birthday.Day) || now.Month < i_Birthday.Month)
            {
                age--;
            }

            return age;
        }

        public bool UserConnected()
        {
            return m_LoggedInUser != null;
        }

        public int FindBestFriend()
        {
            int bestFriendIndex = k_BestFriendNotFound;
            int index = 0;
            int bestFriendcommonFriendsAmount = 0;
            Dictionary<User, int> likedMyPosts = new Dictionary<User, int>();
            foreach (User friend in m_Friends)
            {
                foreach (Post currentPost in friend.Posts)
                {
                    try
                    {
                        foreach (User currentUser in currentPost.LikedBy)
                        {
                            if (likedMyPosts.ContainsKey(friend))
                            {
                                likedMyPosts[friend]++;
                            }
                            else if (currentUser.Name == m_LoggedInUser.Name)
                            {
                                likedMyPosts.Add(friend, 1);
                            }
                        }
                    }
                    catch (FacebookOAuthException)
                    {
                        /// the likedByUsers can not be supplied in some posts
                    }
                }
            }

            foreach (User friend in m_Friends)
            {
                if (likedMyPosts.ContainsKey(friend))
                {
                    DateTime friendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(friend.Birthday.Substring(0, 2)), int.Parse(friend.Birthday.Substring(3, 2)));
                    if (birthdayMonthInRange(friendBirthdayDate))
                    {

                        if (likedMyPosts[friend] > bestFriendcommonFriendsAmount)
                        {
                            m_BestFriend = friend;
                            bestFriendcommonFriendsAmount = likedMyPosts[friend];
                            bestFriendIndex = index;
                        }
                        else if (likedMyPosts[friend] == bestFriendcommonFriendsAmount)
                        {
                            m_BestFriend = getEalierBirthdayFriend(friend, m_BestFriend);
                            if (m_BestFriend == friend)
                            {
                                bestFriendIndex = index;
                            }
                        }
                    }
                }
                index++;
            }

            return bestFriendIndex;
        }

        private User getEalierBirthdayFriend(User i_FirstFriend, User i_SecondFriend)
        {
            DateTime firstFriendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(i_FirstFriend.Birthday.Substring(0, 2)), int.Parse(i_FirstFriend.Birthday.Substring(3, 2)));
            DateTime secondFriendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(i_SecondFriend.Birthday.Substring(0, 2)), int.Parse(i_SecondFriend.Birthday.Substring(3, 2)));

            return firstFriendBirthdayDate < secondFriendBirthdayDate ? i_FirstFriend : i_SecondFriend;
        }

        private bool birthdayMonthInRange(DateTime i_FriendBirthdayDate)
        {
            return (i_FriendBirthdayDate - DateTime.Now).TotalDays <= 200;
        }

        public string GetBestFriendFullName()
        {
            return $"{m_BestFriend.FirstName} {m_BestFriend.LastName}";
        }

        public string GetBestFriendBirthdayDate()
        {
            return m_BestFriend.Birthday;
        }

        public bool IsBestFriendExist()
        {
            return m_BestFriend != null;
        }

        public bool CreateEvent(string i_Description, string i_Location)
        {
            bool createEventSuccessed = true;
            DateTime startTime, endTime;
            int birthdayYearDate = DateTime.Now.Month >= 11 ? DateTime.Now.Year + 1 : DateTime.Now.Year;

            startTime = new DateTime(birthdayYearDate, int.Parse(m_BestFriend.Birthday.Substring(0, 2)), int.Parse(m_BestFriend.Birthday.Substring(3, 2)), 19, 0, 0);
            endTime = new DateTime(birthdayYearDate, int.Parse(m_BestFriend.Birthday.Substring(0, 2)), int.Parse(m_BestFriend.Birthday.Substring(3, 2)), 22, 0, 0);
            try
            {
                m_LoggedInUser.CreateEvent_DeprecatedSinceV2(
                     $"Suprise party to {m_BestFriend.FirstName} ",
                     startTime,
                     endTime,
                     i_Description,
                     i_Location,
                     Event.ePrivacy.Secret);
            }
            catch (FacebookOAuthException)
            {
                createEventSuccessed = false;
            }

            return createEventSuccessed;
        }

        public string GetBestFriendTopTag()
        {
            User mostTagged = null;
            Dictionary<User, int> taggedUsers = new Dictionary<User, int>();

            foreach (Post currentPost in m_BestFriend.WallPosts)
            {
                try
                {
                    foreach (User currentUser in currentPost.TaggedUsers)
                    {
                        if (taggedUsers.ContainsKey(currentUser))
                        {
                            taggedUsers[currentUser]++;
                        }
                        else
                        {
                            taggedUsers.Add(currentUser, 1);
                        }
                    }
                }
                catch (Exception)
                {
                    /// the tagged users can not be supplied in some posts
                }
            }

            foreach (User currentUser in taggedUsers.Keys)
            {
                try
                {
                    if (mostTagged == null)
                    {
                        mostTagged = currentUser;
                    }
                    else if (taggedUsers[currentUser] > taggedUsers[mostTagged])
                    {
                        mostTagged = currentUser;
                    }
                }
                catch (FacebookOAuthException)
                {
                    /// the tagged users can not be supplied in some posts
                }

            }

            return mostTagged == null ? null : mostTagged.Name;
        }

        public string GetBestFriendTopCheckIn()
        {
            string mostTagged = null;
            Dictionary<string, int> checkIns = new Dictionary<string, int>();

            foreach (Checkin currentCheckIn in m_BestFriend.Checkins)
            {
                if (checkIns.ContainsKey(currentCheckIn.Place.Name))
                {
                    checkIns[currentCheckIn.Place.Name]++;
                }
                else
                {
                    checkIns.Add(currentCheckIn.Place.Name, 1);
                }
            }

            foreach (string currentCheckIn in checkIns.Keys)
            {
                if (mostTagged == null)
                {
                    mostTagged = currentCheckIn;
                }
                else if (checkIns[currentCheckIn] > checkIns[mostTagged])
                {
                    mostTagged = currentCheckIn;
                }
            }

            return mostTagged == null ? null : mostTagged;
        }

        public int GetBestFriendAmountOfAlbums()
        {
            return m_BestFriend.Albums.Count;
        }

        public string GetBestFriendGender()
        {
            return m_BestFriend.Gender.ToString();
        }
    }
}
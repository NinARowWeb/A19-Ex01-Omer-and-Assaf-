using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Facebook;
using FacebookWrapper.ObjectModel;
using FacebookWrapper;
using eSortingByEnum;

namespace SortingFriends_Engine
{
     public class SortingFriendsEngine
     {
          private const int k_ChangePositions = 1, k_NotChangePosition = -1, k_BestFriendNotFound = -1;
          private const string k_AppId = "1027335734116799";
          private User m_LoggedInUser;
          private User m_BestFriend;
          private List<User> m_Friends;

          public void LoginUser()
          {
               LoginResult result = FacebookService.Login(k_AppId, "public_profile", "user_friends", "user_birthday");
               if (!string.IsNullOrEmpty(result.AccessToken))
               {
                    m_LoggedInUser = result.LoggedInUser;
                    fetchFriends();
               }
          }

          public void LogoutUser()
          {
               if(m_LoggedInUser != null)
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

          public string GetFriendPicture(int i_FriendIndex)
          {
               return m_Friends[i_FriendIndex].PictureLargeURL;
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

               foreach (User friend in m_Friends)
               {
                    DateTime friendBirthdayDate = new DateTime(DateTime.Now.Year + 1, int.Parse(friend.Birthday.Substring(0, 2)), int.Parse(friend.Birthday.Substring(3, 2)));
                    if (birthdayMonthInRange(friendBirthdayDate))
                    {
                         if (friend.Friends.Count > bestFriendcommonFriendsAmount)
                         {
                              m_BestFriend = friend;
                              bestFriendcommonFriendsAmount = friend.Friends.Count;
                              bestFriendIndex = index;
                         }
                         else if (friend.Friends.Count == bestFriendcommonFriendsAmount)
                         {
                              m_BestFriend = getEalierBirthdayFriend(friend, m_BestFriend);
                              if (m_BestFriend == friend)
                              {
                                   bestFriendIndex = index;
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
               return (i_FriendBirthdayDate - DateTime.Now).TotalDays <= 130;
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
     }
}

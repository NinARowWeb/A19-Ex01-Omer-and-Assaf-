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
     public delegate int ComparisonDelegate(User i_FirstPerson, User i_SecondPerson);

     public class SortingFriendsEngine
     {
          //public event ComparisonDelegate ComparisonNotifier;
          const int k_ChangePositions = 1, k_NotChangePosition = -1;
          User m_LoggedInUser;
          List<User> m_Friends;

          public void LoginUser()
          {
               LoginResult result = FacebookService.Login("1027335734116799", "public_profile", "user_friends");
               if (!(string.IsNullOrEmpty(result.AccessToken)))
               {
                    m_LoggedInUser = result.LoggedInUser;
                    FetchFriends();
               }
          }

          private void FetchFriends()
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
               foreach(User friend in m_Friends)
               {
                    friends.Add($"{friend.FirstName} {friend.LastName}");
               }
               return friends;
          }

          public string GetFriendPicture(int i_FriendIndex)
          {
               return m_Friends[i_FriendIndex].PictureNormalURL;
          }
/*
          private void clearDelegates()
          {
               ComparisonNotifier -= FirstNameComparison;
               ComparisonNotifier -= LastNameComparison;
               ComparisonNotifier -= BirthDayComparison;
               ComparisonNotifier -= AgeComparison;
          }
*/
          public void SortFriends(int i_ComparisonIndex)
          {
               eSortingBy comparisonBy = (eSortingBy)i_ComparisonIndex;
//               clearDelegates();
               switch (comparisonBy)
               {
                    case eSortingBy.DEFAULT:
                         {
                              FetchFriends();
                              break;
                         }
                    case eSortingBy.FIRST_NAME:
                         {
                             // ComparisonNotifier += FirstNameComparison;
                              m_Friends.Sort(FirstNameComparison);
                              //    Sort(m_Friends);
                              break;
                         }
                    case eSortingBy.LAST_NAME:
                         {
                          //    ComparisonNotifier += LastNameComparison;
                              m_Friends.Sort(LastNameComparison);
                              //  Sort(m_Friends);
                              break;
                         }
                    case eSortingBy.BIRTHDAY:
                         {
                            //  ComparisonNotifier += BirthDayComparison;
                              m_Friends.Sort(BirthDayComparison);
                              // Sort(m_Friends);
                              break;
                         }
                    case eSortingBy.AGE:
                         {
                            //  ComparisonNotifier += AgeComparison;
                              m_Friends.Sort(AgeComparison);
                              break;
                         }
               }
          }

          private int FirstNameComparison(User i_FirstPerson, User i_SecondPerson)
          {
               return i_FirstPerson.FirstName.CompareTo(i_SecondPerson.FirstName);
          }

          private int LastNameComparison(User i_FirstPerson, User i_SecondPerson)
          {
               return i_FirstPerson.LastName.CompareTo(i_SecondPerson.LastName);
          }

          private int BirthDayComparison(User i_FirstPerson, User i_SecondPerson)
          {
               int returnValue, firstPersonMonth, secondPersonMonth, firstPersonDay, secondPersonDay;
               Int32.TryParse(i_FirstPerson.Birthday.Substring(0, 2), out firstPersonMonth);
               Int32.TryParse(i_SecondPerson.Birthday.Substring(0, 2), out secondPersonMonth);
               if (firstPersonMonth == secondPersonMonth)
               {
                    Int32.TryParse(i_FirstPerson.Birthday.Substring(3, 2), out firstPersonDay);
                    Int32.TryParse(i_SecondPerson.Birthday.Substring(3, 2), out secondPersonDay);
                    returnValue = firstPersonDay < secondPersonDay ? k_ChangePositions : k_NotChangePosition;
               }
               else
               {
                    returnValue = firstPersonMonth < secondPersonMonth ? k_NotChangePosition : k_ChangePositions;
               }

               return returnValue;
          }

          private int AgeComparison(User i_FirstPerson, User i_SecondPerson)
          {
               DateTime firstPersonBirthday = new DateTime(Int32.Parse(i_FirstPerson.Birthday.Substring(6, 4)),
                    Int32.Parse(i_FirstPerson.Birthday.Substring(0, 2)),
                    Int32.Parse(i_FirstPerson.Birthday.Substring(3, 2)));
               DateTime secondPersonBirthday = new DateTime(Int32.Parse(i_SecondPerson.Birthday.Substring(6, 4)),
                    Int32.Parse(i_SecondPerson.Birthday.Substring(0, 2)),
                    Int32.Parse(i_SecondPerson.Birthday.Substring(3, 2)));
               int firstPersonAge = calculateAge(firstPersonBirthday);
               int secondPersonAge = calculateAge(secondPersonBirthday);
               return firstPersonAge < secondPersonAge ? k_ChangePositions : k_NotChangePosition;
          }

          private int calculateAge(DateTime i_Birthday)
          {
               DateTime now = DateTime.Now;
               return now.CompareTo(i_Birthday);
          }

     }
}

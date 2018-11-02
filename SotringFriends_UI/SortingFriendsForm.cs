using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SortingFriends_Engine;

namespace SotringFriends_UI
{
     public partial class FacebookFeatures : Form
     {
          private const int k_BestFriendNotFoundIndex = -1;
          private SortingFriendsEngine m_SortingEngine = new SortingFriendsEngine();

          public FacebookFeatures()
          {
               InitializeComponent();
               FormClosing += formClosing_Click;
          }

          private void formClosing_Click(object sender, FormClosingEventArgs e)
          {
               m_SortingEngine.LogoutUser();
          }

          private void buttonLogin_Click(object sender, EventArgs e)
          {
               m_SortingEngine.LoginUser();
               if (m_SortingEngine.UserConnected()) /// exception?
               {
                    fetchFriends();
               }
               else
               {
                    MessageBox.Show("Login to facebook failed");
               }
          }

          private void fetchFriends()
          {
               List<string> friendsName = m_SortingEngine.GetFriends();

               FriendsList.Items.Clear();
               foreach (string friendName in friendsName)
               {
                    FriendsList.Items.Add(friendName);
               }
          }

          private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (FriendsList.SelectedItems.Count == 1)
               {
                    string friendImageURL = m_SortingEngine.GetFriendPicture(FriendsList.SelectedIndex);

                    if (friendImageURL != null)
                    {
                         pictureBoxFriend.LoadAsync(friendImageURL);
                    }
                    else
                    {
                         pictureBoxFriend.Image = pictureBoxFriend.ErrorImage;
                    }
               }
               else
               {
                    MessageBox.Show("You can select only one person to show");
               }
          }

          private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
          {
               if (m_SortingEngine.UserConnected())
               {
                    m_SortingEngine.SortFriends(ComboBoxSortingOptions.SelectedIndex);
                    fetchFriends();
               }
               else
               {
                    MessageBox.Show("You need to Log-In to facebook");
               }
          }

          private void buttonFindBestFriend_Click(object sender, EventArgs e)
          {
               if (m_SortingEngine.UserConnected())
               {
                    int bestFriendIndex = m_SortingEngine.FindBestFriend();

                    if (bestFriendIndex != k_BestFriendNotFoundIndex)
                    {
                         BestFriendNameLabel.Visible = true;
                         BestFriendNameLabel.Text = m_SortingEngine.GetBestFriendFullName();
                         BestFriendPictureBox.Visible = true;
                         BestFriendPictureBox.LoadAsync(m_SortingEngine.GetFriendPicture(bestFriendIndex));
                         BirthdayDateLabel.Visible = true;
                         BirthdayDateLabel.Text = m_SortingEngine.GetBestFriendBirthdayDate();
                    }
                    else
                    {
                         MessageBox.Show("You don't have friends that have birthday in two months");
                    }
               }
               else
               {
                    MessageBox.Show("First you need to connect to your facebook account");
               }
          }

          private void buttonCreateBirthdayEvent_Click(object sender, EventArgs e)
          {
               if (m_SortingEngine.UserConnected())
               {
                    if (m_SortingEngine.IsBestFriendExist())
                    {
                         if (string.IsNullOrEmpty(DescirptionTextBox.Text))
                         {
                              MessageBox.Show("The decription can't be empty");
                         }
                         else if (string.IsNullOrEmpty(LocationTextBox.Text))
                         {
                              MessageBox.Show("The location can't be empty");
                         }
                         else
                         {
                              if (!m_SortingEngine.CreateEvent(DescirptionTextBox.Text, LocationTextBox.Text))
                              {
                                   MessageBox.Show("suprise party event should be created. the feature blocked from version 2.0");
                              }
                         }
                    }
                    else
                    {
                         MessageBox.Show("First you need to find your best friend");
                    }
               }
               else
               {
                    MessageBox.Show("First you need to connect to your facebook account");
               }
          }
     }
}

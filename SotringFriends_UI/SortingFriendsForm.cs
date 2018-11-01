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
     public partial class SortingFriendsForm : Form
     {
          public SortingFriendsForm()
          {
               InitializeComponent();
          }
          private SortingFriendsEngine m_SortingEngine = new SortingFriendsEngine();

          private void LoginButton_Click(object sender, EventArgs e)
          {
               m_SortingEngine.LoginUser();
               FetchFriends();
          }

          private void FetchFriends()
          {
               List<string> friendsName = m_SortingEngine.GetFriends();
               FriendsList.Items.Clear();
               foreach(string friendName in friendsName)
               {
                    FriendsList.Items.Add(friendName);
               }
          }

          private void Friends_SelectedIndexChanged(object sender, EventArgs e)
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

          private void SortingOption_SelectedIndexChanged(object sender, EventArgs e)
          {
               m_SortingEngine.SortFriends(SortingOptions.SelectedIndex);
               FetchFriends();
          }

          private void pictureBoxFriend_Click(object sender, EventArgs e)
          {

          }
     }
}

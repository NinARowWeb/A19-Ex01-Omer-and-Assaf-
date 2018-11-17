using System;
using System.Drawing;
using System.Windows.Forms;
using SortingFriends_Engine;

namespace SotringFriends_UI
{
     public partial class FacebookFeaturesForm : Form
     {
          private FeaturesEngine m_FeaturesEngine = new FeaturesEngine();
          private SortingFriendsControl m_SortingFriends;
          private FindBestFriendControl m_FindBestFriend;

          public FacebookFeaturesForm()
          {
               InitializeComponent();
               pictureBoxLoginStatus.BackgroundImage = Properties.Resources.red_light_no_background;
               pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
               m_SortingFriends = new SortingFriendsControl(m_FeaturesEngine);
               m_FindBestFriend = new FindBestFriendControl(m_FeaturesEngine);
          }

          private void loginButton_Click(object sender, EventArgs e)
          {
               const string k_LoginFailedMessage = "Login to facebook failed";
               try
               {
                    m_FeaturesEngine.LoginUser();

                    if (m_FeaturesEngine.UserConnected())
                    {
                         changeButtonMeaning(Properties.Resources.green_circle, logoutButton_Click, loginButton_Click, Properties.Resources.logout);
                         buttonSortingFriends.Click += buttonSortingFriends_Click;
                         buttonFindBestFriend.Click += buttonFindBestFriend_Click;
                         addDefualtControls();
                         labelFirstUserMessage.Text = $"Hi {m_FeaturesEngine.GetLoginUserName()}";
                         labelSecondUserMessage.Text = $"We invite you to select a feature";
                         pictureBoxMainScreen.BackgroundImage = Properties.Resources.Welcome;
                    }
                    else
                    {
                         MessageBox.Show(k_LoginFailedMessage);
                    }
               }
               catch (Exception)
               {
                    MessageBox.Show(Common.sr_FacebookError);
               }
          }

          private void addDefualtControls()
          {
               panelFacebookAppScreen.Controls.Add(labelFirstUserMessage);
               panelFacebookAppScreen.Controls.Add(labelSecondUserMessage);
               panelFacebookAppScreen.Controls.Add(pictureBoxMainScreen);
          }

          private void buttonSortingFriends_Click(object sender, EventArgs e)
          {
               if (m_FeaturesEngine.UserConnected())
               {
                    panelFacebookAppScreen.Controls.Clear();
                    panelFacebookAppScreen.Controls.Add(m_SortingFriends);
               }
               else
               {
                    MessageBox.Show(Common.sr_NoConnectionToFacebook);
               }
          }

          private void buttonFindBestFriend_Click(object sender, EventArgs e)
          {
               if (m_FeaturesEngine.UserConnected())
               {
                    panelFacebookAppScreen.Controls.Clear();
                    panelFacebookAppScreen.Controls.Add(m_FindBestFriend);
               }
               else
               {
                    MessageBox.Show(Common.sr_NoConnectionToFacebook);
               }
          }

          private void logoutButton_Click(object sender, EventArgs e)
          {
               try
               {
                    labelFirstUserMessage.Text = $"Bye {m_FeaturesEngine.GetLoginUserName()}";
                    m_FeaturesEngine.LogoutUser();
                    changeButtonMeaning(Properties.Resources.red_light_no_background, loginButton_Click, logoutButton_Click, Properties.Resources.login);
                    buttonFindBestFriend.Click -= buttonFindBestFriend_Click;
                    buttonSortingFriends.Click -= buttonSortingFriends_Click;
                    panelFacebookAppScreen.Controls.Clear();
                    addDefualtControls();
                    labelSecondUserMessage.Text = $"Hope to see you again!";
                    pictureBoxMainScreen.BackgroundImage = Properties.Resources.bye;
                    pictureBoxMainScreen.BackgroundImageLayout = ImageLayout.Stretch;
               }
               catch (Exception)
               {
                    MessageBox.Show(Common.sr_FacebookError);
               }
          }

          private void changeButtonMeaning(Bitmap i_PictureLight, EventHandler i_EventToAdd, EventHandler i_EventToDelete, Bitmap i_PictureButton)
          {
               pictureBoxLoginStatus.BackgroundImage = i_PictureLight;
               pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
               Common.ClearEvents(buttonLogin);
               buttonLogin.Click += i_EventToAdd;
               buttonLogin.BackgroundImage = i_PictureButton;
          }
     }
}

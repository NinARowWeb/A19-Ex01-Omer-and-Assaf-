using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortingFriends_Engine;

namespace SotringFriends_UI
{
    public partial class FacebookFeatures : Form
    {
        private const int k_BestFriendNotFoundIndex = -1;
        private FeaturesEngine m_FeaturesEngine = new FeaturesEngine();

        public FacebookFeatures()
        {
            InitializeComponent();
        }

        private void disableFirstFeatureControls()
        {
            pictureBoxFriend.Visible = false;
            placeHolderLabel.Visible = false;
            pictureBoxAlbumPhoto.Visible = false;
            labelAlbumName.Visible = false;
            labelPhotoTitle.Visible = false;
            buttonNextAlbum.Visible = false;
            buttonPrevAlbum.Visible = false;
            buttonPrevPicture.Visible = false;
            buttonNextPicture.Visible = false;
        }

        private void disableSecondFeatureControls()
        {
            labelFullName.Visible = false;
            labelBirthdayDate.Visible = false;
            labelGender.Visible = false; 
            labelMostTaggedUser.Visible = false;
            labelMostCommonCheckin.Visible = false; 
            labelAlbums.Visible = false;
            labelBestFriendNameText.Text = "";
            labelBestFriendNameText.Visible = false;
            labelBirthdayDateText.Text = "";
            labelBirthdayDateText.Visible = false;
            labelGenderText.Text = "";
            labelGenderText.Visible = false;
            labelMostTaggedUserText.Text = "";
            labelMostTaggedUserText.Visible = false;
            labelMostTaggedCheckinText.Text = "";
            labelMostTaggedCheckinText.Visible = false;
            labelAlbumsText.Text = "";
            labelAlbumsText.Visible = false;
            pictureBoxBestFriendPicture.Visible = false;


        }

        private void disableControls()
        {
            disableFirstFeatureControls();
            disableSecondFeatureControls();
        }
        private void buttonLogout_Click(object sender, EventArgs e)
        {
            m_FeaturesEngine.LogoutUser();
            fetchFriends();
            disableControls();
            changeButtonMeaning(buttonFaceBookLogin,"Login",buttonLogin_Click,buttonLogout_Click);
            changeButtonMeaning(buttonLogin, "Login", buttonLogin_Click, buttonLogout_Click);

        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_FeaturesEngine.LoginUser();

            if (m_FeaturesEngine.UserConnected()) /// exception?
            {
                fetchFriends();
                changeButtonMeaning(buttonFaceBookLogin, "Logout", buttonLogout_Click, buttonLogin_Click);
                changeButtonMeaning(buttonLogin, "Logout", buttonLogout_Click, buttonLogin_Click);
            }
            else
            {
                MessageBox.Show("Login to facebook failed");
            }
        }

        private void changeButtonMeaning (Button i_Button, string i_TextButton, EventHandler i_EventToAdd, EventHandler i_EventToDelete)
        {
            i_Button.Text = i_TextButton;
            i_Button.Click += i_EventToAdd;
            i_Button.Click -= i_EventToDelete;
        }

        private void fetchFriends()
        {
            List<string> friendsName = m_FeaturesEngine.GetFriends();

            listBoxFriends.Items.Clear();
            foreach (string friendName in friendsName)
            {
                listBoxFriends.Items.Add(friendName);
            }
        }

        private string getAlbumDetails()
        {
            string photoFromAlbum = m_FeaturesEngine.GetPictureFromAlbum(listBoxFriends.SelectedIndex);
            if (photoFromAlbum != null)
            {
                pictureBoxAlbumPhoto.LoadAsync(photoFromAlbum);
                labelAlbumName.Text = m_FeaturesEngine.GetAlbumName(listBoxFriends.SelectedIndex);
                labelPhotoTitle.Text = m_FeaturesEngine.GetPictureTitle(listBoxFriends.SelectedIndex);
                pictureBoxAlbumPhoto.Visible = true;
                labelAlbumName.Visible = true;
                labelPhotoTitle.Visible = true;
                buttonNextAlbum.Visible = true;
                buttonPrevAlbum.Visible = true;
                buttonPrevPicture.Visible = true;
                buttonNextPicture.Visible = true;
            }
            return photoFromAlbum;
        }

        private void disableAlbum(string i_Error)
        {
            labelAlbumName.Visible = false;
            labelPhotoTitle.Visible = false;
            buttonNextAlbum.Visible = false;
            buttonPrevAlbum.Visible = false;
            buttonPrevPicture.Visible = false;
            buttonNextPicture.Visible = false;
            MessageBox.Show(i_Error);
        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                string friendImageURL = m_FeaturesEngine.GetFriendPicture(listBoxFriends.SelectedIndex);
                if (friendImageURL != null)
                {
                    m_FeaturesEngine.InitialAlbumIndexes();
                    if(getAlbumDetails() == null)
                    {
                        disableAlbum("The user selected doesn't have albums");
                    }
                    pictureBoxFriend.LoadAsync(friendImageURL);
                    pictureBoxFriend.Visible = true;
                }
                else
                {
                    pictureBoxFriend.Image = pictureBoxFriend.ErrorImage;
                }

                setBirthdayOrAgeAttribute();
            }
            else
            {
                MessageBox.Show("You can select only one person to show");
            }
        }

        private void setBirthdayOrAgeAttribute()
        {
            string attribute = m_FeaturesEngine.GetFriendBirthdayOrAgeAttribute(listBoxFriends.SelectedIndex, comboBoxSortingOptions.SelectedIndex);
            if (attribute != null)
            {
                placeHolderLabel.Text = attribute;
                placeHolderLabel.Visible = true;
            }
            else
            {
                placeHolderLabel.Visible = false;
            }
        }

        private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.UserConnected())
            {
                m_FeaturesEngine.SortFriends(comboBoxSortingOptions.SelectedIndex);
                fetchFriends();
                disableFirstFeatureControls();
                setBirthdayOrAgeAttribute();
            }
            else
            {
                MessageBox.Show("You need to Log-In to facebook");
            }
        }

        private void buttonFindBestFriend_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.UserConnected())
            {
                int bestFriendIndex = m_FeaturesEngine.FindBestFriend();

                if (bestFriendIndex != k_BestFriendNotFoundIndex)
                {
                    labelMostCommonCheckin.Visible = true;
                    labelMostTaggedUser.Visible = true;
                    labelFullName.Visible = true;
                    labelBirthdayDate.Visible = true;
                    labelGender.Visible = true;
                    labelAlbums.Visible = true;
                    labelAlbumsText.Visible = true;
                    labelAlbumsText.Text = m_FeaturesEngine.GetBestFriendAmountOfAlbums().ToString();
                    labelGenderText.Visible = true;
                    labelGenderText.Text = m_FeaturesEngine.GetBestFriendGender();
                    labelBestFriendNameText.Visible = true;
                    labelBestFriendNameText.Text = m_FeaturesEngine.GetBestFriendFullName();
                    pictureBoxBestFriendPicture.Visible = true;
                    pictureBoxBestFriendPicture.LoadAsync(m_FeaturesEngine.GetFriendPicture(bestFriendIndex));
                    labelBirthdayDateText.Visible = true;
                    labelBirthdayDateText.Text = m_FeaturesEngine.GetBestFriendBirthdayDate();
                    labelMostTaggedUserText.Visible = true;
                    string bestFriendMostTaggedUser = m_FeaturesEngine.GetBestFriendTopTag();
                    if(bestFriendMostTaggedUser != null)
                    {
                        labelMostTaggedUserText.Text = bestFriendMostTaggedUser;
                    }
                    else
                    {
                        labelMostTaggedUserText.Text = "No tags available";
                    }
                    labelMostTaggedCheckinText.Visible = true;
                    string bestFriendMostTopCheckIn = m_FeaturesEngine.GetBestFriendTopCheckIn();
                    if(bestFriendMostTopCheckIn != null)
                    {
                        labelMostTaggedCheckinText.Text = bestFriendMostTopCheckIn;
                    }
                    else
                    {
                        labelMostTaggedCheckinText.Text = "CheckIn data is not available";
                    }

                }
                else
                {
                    MessageBox.Show("You don't have friends who have birthday in four months");
                }
            }
            else
            {
                MessageBox.Show("First you need to connect to your facebook account");
            }
        }

        private void buttonCreateBirthdayEvent_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.UserConnected())
            {
                if (m_FeaturesEngine.IsBestFriendExist())
                {
                    if (string.IsNullOrEmpty(textBoxDescirption.Text))
                    {
                        MessageBox.Show("The decription can't be empty");
                    }
                    else if (string.IsNullOrEmpty(textBoxLocation.Text))
                    {
                        MessageBox.Show("The location can't be empty");
                    }
                    else
                    {
                        if (!m_FeaturesEngine.CreateEvent(textBoxDescirption.Text, textBoxLocation.Text))
                        {
                            textBoxDescirption.Text = "";
                            textBoxLocation.Text = "";
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

        private void buttonPrevAlbum_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetPrevAlbumIndex())
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show("You are in the first album");
            }
        }

        private void buttonNextAlbum_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetNextAlbumIndex(listBoxFriends.SelectedIndex))
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show("You are in the last album");
            }
        }

        private void buttonPrevPicture_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetPrevPictureAlbumIndex())
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show("You are in the first picture in album");
            }
        }

        private void buttonNextPicture_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetNextPictureAlbumIndex(listBoxFriends.SelectedIndex))
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show("You are in the last picture in album");
            }
        }
    }
}

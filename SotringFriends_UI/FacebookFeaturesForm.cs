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
            FormClosing += formClosing_Click;
        }

        private void formClosing_Click(object sender, FormClosingEventArgs e)
        {
            m_FeaturesEngine.LogoutUser();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            m_FeaturesEngine.LoginUser();

            if (m_FeaturesEngine.UserConnected()) /// exception?
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
            List<string> friendsName = m_FeaturesEngine.GetFriends();

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
                string friendImageURL = m_FeaturesEngine.GetFriendPicture(FriendsList.SelectedIndex);

                if (friendImageURL != null)
                {
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
            string attribute = m_FeaturesEngine.GetFriendBirthdayOrAgeAttribute(FriendsList.SelectedIndex, ComboBoxSortingOptions.SelectedIndex);
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
                m_FeaturesEngine.SortFriends(ComboBoxSortingOptions.SelectedIndex);
                fetchFriends();
                pictureBoxFriend.Visible = false;
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
                    mostCommonCheckinLabel.Visible = true;
                    mostTaggedUserLabel.Visible = true;
                    fullNameLabel.Visible = true;
                    birthdayDate.Visible = true;
                    genderLabel.Visible = true;
                    albumsLabel.Visible = true;
                    albumsText.Visible = true;
                    albumsText.Text = m_FeaturesEngine.GetBestFriendAmountOfAlbums().ToString();
                    genderText.Visible = true;
                    genderText.Text = m_FeaturesEngine.GetBestFriendGender();
                    BestFriendNameLabel.Visible = true;
                    BestFriendNameLabel.Text = m_FeaturesEngine.GetBestFriendFullName();
                    BestFriendPictureBox.Visible = true;
                    BestFriendPictureBox.LoadAsync(m_FeaturesEngine.GetFriendPicture(bestFriendIndex));
                    BirthdayDateLabel.Visible = true;
                    BirthdayDateLabel.Text = m_FeaturesEngine.GetBestFriendBirthdayDate();
                    mostTaggedUser.Visible = true;
                    string bestFriendMostTaggedUser = m_FeaturesEngine.GetBestFriendTopTag();
                    if(bestFriendMostTaggedUser != null)
                    {
                        mostTaggedUser.Text = bestFriendMostTaggedUser;
                    }
                    else
                    {
                        mostTaggedUser.Text = "No tags available";
                    }
                    mostTaggedCheckin.Visible = true;
                    string bestFriendMostTopCheckIn = m_FeaturesEngine.GetBestFriendTopCheckIn();
                    if(bestFriendMostTopCheckIn != null)
                    {
                        mostTaggedCheckin.Text = bestFriendMostTopCheckIn;
                    }
                    else
                    {
                        mostTaggedCheckin.Text = "CheckIn data is not available";
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
                        if (!m_FeaturesEngine.CreateEvent(DescirptionTextBox.Text, LocationTextBox.Text))
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

using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SortingFriends_Engine;
using System.Reflection;
using eSortingByEnum;
using System.ComponentModel;
using System.Drawing;

namespace SotringFriends_UI
{
    public partial class FacebookFeatures : Form
    {
        private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
        private FeaturesEngine m_FeaturesEngine = new FeaturesEngine();

        public FacebookFeatures()
        {
            InitializeComponent();
            pictureBoxLoginStatus.BackgroundImage = Properties.Resources.red_light;
            pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxFacebookLoginStatus.BackgroundImage = Properties.Resources.red_light;
            pictureBoxFacebookLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void disableFirstFeatureControls()
        {
            pictureBoxFriend.Visible = false;
            placeHolderLabel.Visible = false;
            pictureBoxAlbumPhoto.Visible = false;
            labelAttributePlaceHolder.Visible = false;
            labelPhotoTitle.Visible = false;
            buttonNextPlaceHolder.Visible = false;
            buttonPrevPlaceHolder.Visible = false;
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

        private void disableWholeControls()
        {
            disableFirstFeatureControls();
            disableSecondFeatureControls();
        }
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            m_FeaturesEngine.LogoutUser();
            fetchFriends();
            disableWholeControls();
            changeButtonMeaning(pictureBoxLogin, Properties.Resources.red_light, pictureBoxLogin_Click, pictureBoxLogout_Click);
            changeButtonMeaning(pictureBoxFacebookLogin, Properties.Resources.red_light, pictureBoxLogin_Click, pictureBoxLogout_Click);
            comboBoxSortingOptions.SelectedIndex = k_InitialValue;
        }

        private void pictureBoxLogin_Click(object sender, EventArgs e)
        {
            m_FeaturesEngine.LoginUser();

            if (m_FeaturesEngine.UserConnected()) /// exception?
            {
                fetchFriends();
                changeButtonMeaning(pictureBoxLogin, Properties.Resources.green_light, pictureBoxLogout_Click, pictureBoxLogin_Click);
                changeButtonMeaning(pictureBoxFacebookLogin, Properties.Resources.green_light, pictureBoxLogout_Click, pictureBoxLogin_Click);
            }
            else
            {
                MessageBox.Show("Login to facebook failed");
            }
        }

        private void clearEvents(Control i_Control)
        {
            FieldInfo f1 = typeof(Control).GetField("EventClick",
            BindingFlags.Static | BindingFlags.NonPublic);
            object obj = f1.GetValue(i_Control);
            PropertyInfo pi = i_Control.GetType().GetProperty("Events",
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)pi.GetValue(i_Control, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void changeButtonMeaning(PictureBox i_PictureBox, Bitmap i_Picture ,EventHandler i_EventToAdd, EventHandler i_EventToDelete)
        {
            pictureBoxLoginStatus.BackgroundImage = i_Picture;
            pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxFacebookLoginStatus.BackgroundImage = i_Picture;
            pictureBoxFacebookLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
            clearEvents(i_PictureBox);
            i_PictureBox.Click += i_EventToAdd;
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

        private string getPosts()
        {
            string post = m_FeaturesEngine.GetPost(listBoxFriends.SelectedIndex);
            if (post != null)
            {
                labelAttributePlaceHolder.Text = post;
            }
            return post;
        }

        private string getTags()
        {
            string tag = m_FeaturesEngine.GetTag(listBoxFriends.SelectedIndex);
            if (tag != null)
            {
                labelAttributePlaceHolder.Text = tag;
            }
            return tag;
        }

        private string getCheckin()
        {
            string checkin = m_FeaturesEngine.GetCheckin(listBoxFriends.SelectedIndex);
            if (checkin != null)
            {
                labelAttributePlaceHolder.Text = checkin;
            }
            return checkin;
        }

        private string getAlbumDetails()
        {
            string photoFromAlbum = m_FeaturesEngine.GetPictureFromAlbum(listBoxFriends.SelectedIndex);
            if (photoFromAlbum != null)
            {
                pictureBoxAlbumPhoto.LoadAsync(photoFromAlbum);
                labelAttributePlaceHolder.Text = m_FeaturesEngine.GetAlbumName(listBoxFriends.SelectedIndex);
                labelPhotoTitle.Text = m_FeaturesEngine.GetPictureTitle(listBoxFriends.SelectedIndex);
                pictureBoxAlbumPhoto.Visible = true;
                labelAttributePlaceHolder.Visible = true;
                labelPhotoTitle.Visible = true;
                buttonNextPlaceHolder.Visible = true;
                buttonPrevPlaceHolder.Visible = true;
                buttonPrevPicture.Visible = true;
                buttonNextPicture.Visible = true;
            }
            return photoFromAlbum;
        }

        private void clearButtonsEvents(params Button[] i_ListButtons)
        {
            foreach (Button currentButton in i_ListButtons)
            {
                clearEvents(currentButton);
            }
        }

        private void setVisibilityControls(bool i_Visiblity, params Control[] i_ControlsList)
        {
            foreach (Control currentControl in i_ControlsList)
            {
                currentControl.Visible = i_Visiblity;
            }
        }


        private void disableAlbum(string i_Error)
        {
            labelAttributePlaceHolder.Visible = false;
            labelPhotoTitle.Visible = false;
            buttonNextPlaceHolder.Visible = false;
            buttonPrevPlaceHolder.Visible = false;
            buttonPrevPicture.Visible = false;
            buttonNextPicture.Visible = false;
            MessageBox.Show(i_Error);
        }

        private void suitFunctionalityBySelectedIndex()
        {
            m_FeaturesEngine.InitialAlbumIndexes();
            switch ((eSortingBy)comboBoxSortingOptions.SelectedIndex)
            {
                case eSortingBy.Age:
                    {
                        setBirthdayOrAgeAttribute();
                        break;
                    }
                case eSortingBy.Birthday:
                    {
                        setBirthdayOrAgeAttribute();
                        break;
                    }
                case eSortingBy.MostAlbums:
                    {
                        setAlbumsAttributes();
                        break;
                    }
                case eSortingBy.MostPosts:
                    {
                        setPostsAttributes();
                        break;
                    }
                case eSortingBy.MostCheckIns:
                    {
                        setCheckInsAttributes();
                        break;
                    }
                case eSortingBy.MostTags:
                    {
                        setTagsAttributes();
                        break;
                    }
            }

        }

        private void listBoxFriends_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBoxFriends.SelectedItems.Count == 1)
            {
                string friendImageURL = m_FeaturesEngine.GetFriendPicture(listBoxFriends.SelectedIndex);
                if (friendImageURL != null)
                {
                    suitFunctionalityBySelectedIndex();
                    pictureBoxFriend.LoadAsync(friendImageURL);
                    pictureBoxFriend.Visible = true;
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

        private void setTagsAttributes()
        {
            if (getTags() != null)
            {
                buttonPrevPlaceHolder.Text = "Prev Tag";
                buttonNextPlaceHolder.Text = "Next Tag";
                buttonPrevPlaceHolder.Click += buttonPrevTag_Click;
                buttonNextPlaceHolder.Click += buttonNextTag_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show("The user doesn't have Tags");
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }


        private void setCheckInsAttributes()
        {
            if (getCheckin() != null)
            {
                buttonPrevPlaceHolder.Text = "Prev Checkin";
                buttonNextPlaceHolder.Text = "Next Checkin";
                buttonPrevPlaceHolder.Click += buttonPrevCheckIn_Click;
                buttonNextPlaceHolder.Click += buttonNextCheckIn_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show("The user doesn't have checkins");
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void setPostsAttributes()
        {
            if (getPosts() != null)
            {
                buttonPrevPlaceHolder.Text = "Prev Post";
                buttonNextPlaceHolder.Text = "Next Post";
                buttonPrevPlaceHolder.Click += buttonPrevPost_Click;
                buttonNextPlaceHolder.Click += buttonNextPost_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show("The user doesn't have posts");
                setVisibilityControls(false,labelAttributePlaceHolder, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.UserConnected())
            {
                m_FeaturesEngine.SortFriends(comboBoxSortingOptions.SelectedIndex);
                clearButtonsEvents(buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonNextPicture, buttonPrevPicture);
                fetchFriends();
                disableFirstFeatureControls();
            }
            else
            {
                if(comboBoxSortingOptions.SelectedIndex != k_InitialValue)
                {
                    MessageBox.Show("You need to Log-In to facebook");
                }
                comboBoxSortingOptions.SelectedIndex = k_InitialValue;
            }
        }

        private void setAlbumsAttributes()
        {
            if (getAlbumDetails() != null)
            {
                buttonNextPlaceHolder.Text = "Next Album";
                buttonPrevPlaceHolder.Text = "Prev Album";
                buttonPrevPicture.Visible = true;
                buttonNextPicture.Visible = true;
                labelPhotoTitle.Visible = true;
                buttonNextPlaceHolder.Click += buttonNextAlbum_Click;
                buttonPrevPlaceHolder.Click += buttonPrevAlbum_Click;
                buttonNextPicture.Click += buttonNextPicture_Click;
                buttonPrevPicture.Click += buttonPrevPicture_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                disableAlbum("The user selected doesn't have albums");
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
                    if (bestFriendMostTaggedUser != null)
                    {
                        labelMostTaggedUserText.Text = bestFriendMostTaggedUser;
                    }
                    else
                    {
                        labelMostTaggedUserText.Text = "No tags available";
                    }
                    labelMostTaggedCheckinText.Visible = true;
                    string bestFriendMostTopCheckIn = m_FeaturesEngine.GetBestFriendTopCheckIn();
                    if (bestFriendMostTopCheckIn != null)
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
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
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

        private void buttonPrevCheckIn_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getCheckin();
            }
            else
            {
                MessageBox.Show("You are in the first checkin");
            }
        }

        private void buttonNextCheckIn_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetNextCheckinIndex(listBoxFriends.SelectedIndex))
            {
                getCheckin();
            }
            else
            {
                MessageBox.Show("You are in the last checkin");
            }
        }

        private void buttonPrevPost_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getPosts();
            }
            else
            {
                MessageBox.Show("You are in the first post");
            }
        }

        private void buttonNextPost_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetNextPostIndex(listBoxFriends.SelectedIndex))
            {
                getPosts();
            }
            else
            {
                MessageBox.Show("You are in the last post");
            }
        }

        private void buttonPrevTag_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getTags();
            }
            else
            {
                MessageBox.Show("You are in the first tag");
            }
        }

        private void buttonNextTag_Click(object sender, EventArgs e)
        {
            if (m_FeaturesEngine.SetNextTagIndex(listBoxFriends.SelectedIndex))
            {
                getTags();
            }
            else
            {
                MessageBox.Show("You are in the last tag");
            }
        }
    }
}

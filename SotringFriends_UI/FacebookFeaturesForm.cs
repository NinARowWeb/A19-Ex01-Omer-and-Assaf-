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
        private const string k_NoConnectionToFacebook = "First you need to connect to your facebook account";
        private const string k_FacebookError = "facebook Internal Error";
        private FeaturesEngine m_FeaturesEngine = new FeaturesEngine();

        public FacebookFeatures()
        {
            InitializeComponent();
            pictureBoxLoginStatus.BackgroundImage = Properties.Resources.red_light_no_background;
            pictureBoxLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBoxFacebookLoginStatus.BackgroundImage = Properties.Resources.red_light_no_background;
            pictureBoxFacebookLoginStatus.BackgroundImageLayout = ImageLayout.Stretch;
        }

        private void disableFirstFeatureControls()
        {
            setVisibilityControls(false, pictureBoxFriend, placeHolderLabel, pictureBoxAlbumPhoto, labelAttributePlaceHolder, labelPhotoTitle,
                buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonPrevPicture, buttonNextPicture);
        }

        private void disableSecondFeatureControls()
        {
            setVisibilityControls(false, labelFullName, labelBirthdayDate, labelGender, labelMostTaggedUser, labelMostCommonCheckin,
                labelAlbums, labelBestFriendNameText, labelBirthdayDateText, labelGenderText, labelMostTaggedUserText, labelMostTaggedCheckinText,
                labelAlbumsText, pictureBoxBestFriendPicture);
            labelBestFriendNameText.Text = "";
            labelBirthdayDateText.Text = "";
            labelGenderText.Text = "";
            labelMostTaggedUserText.Text = "";
            labelMostTaggedCheckinText.Text = "";
            labelAlbumsText.Text = "";
        }

        private void disableWholeControls()
        {
            disableFirstFeatureControls();
            disableSecondFeatureControls();
        }
        private void pictureBoxLogout_Click(object sender, EventArgs e)
        {
            try
            {
                m_FeaturesEngine.LogoutUser();
                listBoxFriends.Items.Clear();
                disableWholeControls();
                changeButtonMeaning(pictureBoxLogin, Properties.Resources.red_light_no_background, pictureBoxLogin_Click, pictureBoxLogout_Click);
                changeButtonMeaning(pictureBoxFacebookLogin, Properties.Resources.red_light_no_background, pictureBoxLogin_Click, pictureBoxLogout_Click);
                comboBoxSortingOptions.SelectedIndex = k_InitialValue;
            }
            catch (Exception)
            {
                MessageBox.Show(k_FacebookError);
            }
        }

        private void pictureBoxLogin_Click(object sender, EventArgs e)
        {
            const string k_LoginFailedMessage = "Login to facebook failed";
            try
            {
                m_FeaturesEngine.LoginUser();

                if (m_FeaturesEngine.UserConnected())
                {
                    fetchFriends();
                    changeButtonMeaning(pictureBoxLogin, Properties.Resources.green_circle, pictureBoxLogout_Click, pictureBoxLogin_Click);
                    changeButtonMeaning(pictureBoxFacebookLogin, Properties.Resources.green_circle, pictureBoxLogout_Click, pictureBoxLogin_Click);
                }
                else
                {
                    MessageBox.Show(k_LoginFailedMessage);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(k_FacebookError);
            }
        }

        private void clearEvents(Control i_Control)
        {
            const string k_EventClick = "EventClick", k_Events = "Events";

            FieldInfo fieldInfo = typeof(Control).GetField(k_EventClick,
            BindingFlags.Static | BindingFlags.NonPublic);
            object obj = fieldInfo.GetValue(i_Control);
            PropertyInfo property = i_Control.GetType().GetProperty(k_Events,
                BindingFlags.NonPublic | BindingFlags.Instance);
            EventHandlerList list = (EventHandlerList)property.GetValue(i_Control, null);
            list.RemoveHandler(obj, list[obj]);
        }

        private void changeButtonMeaning(PictureBox i_PictureBox, Bitmap i_Picture, EventHandler i_EventToAdd, EventHandler i_EventToDelete)
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
            string picture = null;
            string post = m_FeaturesEngine.GetPost(listBoxFriends.SelectedIndex, ref picture);
            if (post != null)
            {
                labelAttributePlaceHolder.Text = post;
            }
            if (picture != null)
            {
                pictureBoxAlbumPhoto.Visible = true;
                pictureBoxAlbumPhoto.LoadAsync(picture);
            }
            else
            {
                pictureBoxAlbumPhoto.Visible = false;
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
                setVisibilityControls(true, pictureBoxAlbumPhoto, labelAttributePlaceHolder, labelPhotoTitle, buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonPrevPicture, buttonNextPicture);
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
            setVisibilityControls(false, labelAttributePlaceHolder, labelPhotoTitle, buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonPrevPicture, buttonNextPicture);
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
            const string k_MoreThanAPersonSelectedError = "You can select only one person to show";
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
                MessageBox.Show(k_MoreThanAPersonSelectedError);
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
            const string k_TagsWerentFoundMessage = "The user doesn't have Tags";
            const string k_PrevTag = "Prev Tag", k_NextTag = "Next Tag";

            if (getTags() != null)
            {
                buttonPrevPlaceHolder.Text = k_PrevTag;
                buttonNextPlaceHolder.Text = k_NextTag;
                buttonPrevPlaceHolder.Click += buttonPrevTag_Click;
                buttonNextPlaceHolder.Click += buttonNextTag_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show(k_TagsWerentFoundMessage);
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }


        private void setCheckInsAttributes()
        {
            const string k_PrevCheckin = "Prev Checkin", k_NextCheckin = "Next Checkin", k_CheckinsWerentFound = "The user doesn't have checkins";
            if (getCheckin() != null)
            {
                buttonPrevPlaceHolder.Text = k_PrevCheckin;
                buttonNextPlaceHolder.Text = k_NextCheckin;
                buttonPrevPlaceHolder.Click += buttonPrevCheckIn_Click;
                buttonNextPlaceHolder.Click += buttonNextCheckIn_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show(k_CheckinsWerentFound);
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void setPostsAttributes()
        {
            const string k_PrevPost = "Prev Post", k_NextPost = "Next Post", k_PostsWerentFound = "The user doesn't have posts";
            if (getPosts() != null)
            {
                buttonPrevPlaceHolder.Text = k_PrevPost;
                buttonNextPlaceHolder.Text = k_NextPost;
                buttonPrevPlaceHolder.Click += buttonPrevPost_Click;
                buttonNextPlaceHolder.Click += buttonNextPost_Click;
                setVisibilityControls(true, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                MessageBox.Show(k_PostsWerentFound);
                setVisibilityControls(false, labelAttributePlaceHolder, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void setAlbumsAttributes()
        {
            const string prevAlbum = "Prev Album", nextAlbum = "Next Album",
                k_AlbumsWerentFoundMessage = "The user selected doesn't have albums";
            if (getAlbumDetails() != null)
            {
                buttonNextPlaceHolder.Text = prevAlbum;
                buttonPrevPlaceHolder.Text = nextAlbum;
                buttonNextPlaceHolder.Click += buttonNextAlbum_Click;
                buttonPrevPlaceHolder.Click += buttonPrevAlbum_Click;
                buttonNextPicture.Click += buttonNextPicture_Click;
                buttonPrevPicture.Click += buttonPrevPicture_Click;
                setVisibilityControls(true, labelPhotoTitle, buttonNextPicture, buttonPrevPicture, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                disableAlbum(k_AlbumsWerentFoundMessage);
            }
        }

        private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
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
                    if (comboBoxSortingOptions.SelectedIndex != k_InitialValue)
                    {
                        MessageBox.Show(k_NoConnectionToFacebook);
                    }
                    comboBoxSortingOptions.SelectedIndex = k_InitialValue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(k_FacebookError);
            }
        }

        private void buttonFindBestFriend_Click(object sender, EventArgs e)
        {
            const string k_NoExistFriendWithBirthday = "You don't have friends who have birthday in four months";

            if (m_FeaturesEngine.UserConnected())
            {
                int bestFriendIndex = m_FeaturesEngine.FindBestFriend();

                if (bestFriendIndex != k_BestFriendNotFoundIndex)
                {
                    setVisibilityControls(true, labelMostCommonCheckin, labelMostTaggedUser, labelFullName, labelBirthdayDate, labelGender, labelAlbums, labelAlbumsText, labelGenderText, labelBestFriendNameText, pictureBoxBestFriendPicture, labelBirthdayDateText, labelMostTaggedUserText, labelMostTaggedCheckinText);
                    labelAlbumsText.Text = m_FeaturesEngine.GetBestFriendAmountOfAlbums().ToString();
                    labelGenderText.Text = m_FeaturesEngine.GetBestFriendGender();
                    labelBestFriendNameText.Text = m_FeaturesEngine.GetBestFriendFullName();
                    pictureBoxBestFriendPicture.LoadAsync(m_FeaturesEngine.GetFriendPicture(bestFriendIndex));
                    setMostTaggedUserTextLabel();
                    setMostCheckInTextLabel();
                }
                else
                {
                    MessageBox.Show(k_NoExistFriendWithBirthday);
                }
            }
            else
            {
                MessageBox.Show(k_NoConnectionToFacebook);
            }
        }

        private void setMostCheckInTextLabel()
        {
            const string k_NoDataAvailable = "CheckIn data is not available";
            string bestFriendMostTopCheckIn = m_FeaturesEngine.GetBestFriendTopCheckIn();

            if (bestFriendMostTopCheckIn != null)
            {
                labelMostTaggedCheckinText.Text = bestFriendMostTopCheckIn;
            }
            else
            {
                labelMostTaggedCheckinText.Text = k_NoDataAvailable;
            }
        }

        private void setMostTaggedUserTextLabel()
        {
            const string k_NoDataAvailable = "No tags available";
            string bestFriendMostTaggedUser = m_FeaturesEngine.GetBestFriendTopTag();

            if (bestFriendMostTaggedUser != null)
            {
                labelMostTaggedUserText.Text = bestFriendMostTaggedUser;
            }
            else
            {
                labelMostTaggedUserText.Text = k_NoDataAvailable;
            }
        }

        private void buttonCreateBirthdayEvent_Click(object sender, EventArgs e)
        {
            const string k_BestFriendDidntFetchMessage = "First you need to find your best friend";
            if (m_FeaturesEngine.UserConnected())
            {
                if (m_FeaturesEngine.IsBestFriendExist())
                {
                    createBirthdayEvent();

                }
                else
                {
                    MessageBox.Show(k_BestFriendDidntFetchMessage);
                }
            }
            else
            {
                MessageBox.Show(k_NoConnectionToFacebook);
            }
        }

        private void createBirthdayEvent()
        {
            const string k_EventCreatedMessage = "suprise party event should be created. the feature blocked from version 2.0";
            if (!(checkLegalityBirthdayEvent() && m_FeaturesEngine.CreateEvent(textBoxDescirption.Text, textBoxLocation.Text)))
            {
                textBoxDescirption.Text = "";
                textBoxLocation.Text = "";
                MessageBox.Show(k_EventCreatedMessage);
            }
        }

        private bool checkLegalityBirthdayEvent()
        {
            const string k_EmptyDescriptionError = "The description can't be empty", k_EmptyLocationError = "The location can't be empty";
            bool legalInput = true;
            if (string.IsNullOrEmpty(textBoxDescirption.Text))
            {
                legalInput = false;
                MessageBox.Show(k_EmptyDescriptionError);
            }
            else if (string.IsNullOrEmpty(textBoxLocation.Text))
            {
                legalInput = false;
                MessageBox.Show(k_EmptyLocationError);
            }

            return legalInput;
        }

        private void buttonPrevAlbum_Click(object sender, EventArgs e)
        {
            const string k_FirstAlbumError = "You are in the first album";
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show(k_FirstAlbumError);
            }
        }

        private void buttonNextAlbum_Click(object sender, EventArgs e)
        {
            const string k_LastAlbumError = "You are in the last album";
            if (m_FeaturesEngine.SetNextAlbumIndex(listBoxFriends.SelectedIndex))
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show(k_LastAlbumError);
            }
        }

        private void buttonPrevPicture_Click(object sender, EventArgs e)
        {
            const string k_FirstPictureError = "You are in the first picture album";
            if (m_FeaturesEngine.SetPrevPictureAlbumIndex())
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show(k_FirstPictureError);
            }
        }

        private void buttonNextPicture_Click(object sender, EventArgs e)
        {
            const string k_LastPictureError = "You are in the last picture album";
            if (m_FeaturesEngine.SetNextPictureAlbumIndex(listBoxFriends.SelectedIndex))
            {
                getAlbumDetails();
            }
            else
            {
                MessageBox.Show(k_LastPictureError);
            }
        }

        private void buttonPrevCheckIn_Click(object sender, EventArgs e)
        {
            const string k_FirstCheckinError = "You are in the first checkin";
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getCheckin();
            }
            else
            {
                MessageBox.Show(k_FirstCheckinError);
            }
        }

        private void buttonNextCheckIn_Click(object sender, EventArgs e)
        {
            const string k_LastCheckinError = "You are in the last checkin";
            if (m_FeaturesEngine.SetNextCheckinIndex(listBoxFriends.SelectedIndex))
            {
                getCheckin();
            }
            else
            {
                MessageBox.Show(k_LastCheckinError);
            }
        }

        private void buttonPrevPost_Click(object sender, EventArgs e)
        {
            const string k_FirstPostError = "You are in the first post";
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getPosts();
            }
            else
            {
                MessageBox.Show(k_FirstPostError);
            }
        }

        private void buttonNextPost_Click(object sender, EventArgs e)
        {
            const string k_LastPostError = "You are in the last post";
            if (m_FeaturesEngine.SetNextPostIndex(listBoxFriends.SelectedIndex))
            {
                getPosts();
            }
            else
            {
                MessageBox.Show(k_LastPostError);
            }
        }

        private void buttonPrevTag_Click(object sender, EventArgs e)
        {
            const string k_FirstTagError = "You are in the first tag";
            if (m_FeaturesEngine.SetPrevPlaceHolderIndex())
            {
                getTags();
            }
            else
            {
                MessageBox.Show(k_FirstTagError);
            }
        }

        private void buttonNextTag_Click(object sender, EventArgs e)
        {
            const string k_LastTagError = "You are in the last tag";
            if (m_FeaturesEngine.SetNextTagIndex(listBoxFriends.SelectedIndex))
            {
                getTags();
            }
            else
            {
                MessageBox.Show(k_LastTagError);
            }
        }
    }
}

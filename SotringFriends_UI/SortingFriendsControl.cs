using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SortingFriends_Engine;
using System.Reflection;
using eSortingByEnum;

namespace SotringFriends_UI
{
    public partial class SortingFriendsControl : UserControl
    {
        private FeaturesEngine m_FeaturesEngine = null;
        private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
        
        public SortingFriendsControl(FeaturesEngine i_FeaturesEngine)
        {
            InitializeComponent();
            m_FeaturesEngine = i_FeaturesEngine;
            fetchFriends();
        }
      
        private void disableFirstFeatureControls()
        {
            setVisibilityControls(false, pictureBoxFriend, placeHolderLabel, pictureBoxAlbumPhoto, labelAttributePlaceHolder, labelPhotoTitle,
                buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonPrevPicture, buttonNextPicture);
        }

        
        private void disableWholeControls()
        {
            disableFirstFeatureControls();
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
            else
            {
                labelAttributePlaceHolder.Text = " ";
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
            else
            {
                labelAttributePlaceHolder.Text = " ";
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
                CommonEventsWrapper.ClearEvents(currentButton);
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
                clearButtonsEvents(buttonNextPicture, buttonPrevPicture, buttonNextPlaceHolder, buttonPrevPlaceHolder);
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
            else if(listBoxFriends.SelectedItems.Count > 1)
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
            const string k_PrevTag = "Prev Tag", k_NextTag = "Next Tag";
            string tagsWerentFoundMessage = $"{m_FeaturesEngine.GetFriendFirstName(listBoxFriends.SelectedIndex)} doesn't have Tags";

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
                MessageBox.Show(tagsWerentFoundMessage);
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }


        private void setCheckInsAttributes()
        {
            const string k_PrevCheckin = "Prev Checkin", k_NextCheckin = "Next Checkin";
            string checkinsWerentFound = $"{m_FeaturesEngine.GetFriendFirstName(listBoxFriends.SelectedIndex)} doesn't have checkins";
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
                MessageBox.Show(checkinsWerentFound);
                setVisibilityControls(false, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void setPostsAttributes()
        {
            const string k_PrevPost = "Prev Post", k_NextPost = "Next Post";
            string postsWerentFound = $"{m_FeaturesEngine.GetFriendFirstName(listBoxFriends.SelectedIndex)} doesn't have posts";
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
                MessageBox.Show(postsWerentFound);
                setVisibilityControls(false, labelAttributePlaceHolder, buttonPrevPicture, buttonNextPicture);
            }
        }

        private void setAlbumsAttributes()
        {
            const string prevAlbum = "Prev Album", nextAlbum = "Next Album";
            string albumsWerentFoundMessage = $"{m_FeaturesEngine.GetFriendFirstName(listBoxFriends.SelectedIndex)} selected doesn't have albums";
            if (getAlbumDetails() != null)
            {
                buttonNextPlaceHolder.Text = nextAlbum;
                buttonPrevPlaceHolder.Text = prevAlbum;
                buttonNextPlaceHolder.Click += buttonNextAlbum_Click;
                buttonPrevPlaceHolder.Click += buttonPrevAlbum_Click;
                buttonNextPicture.Click += buttonNextPicture_Click;
                buttonPrevPicture.Click += buttonPrevPicture_Click;
                setVisibilityControls(true, labelPhotoTitle, buttonNextPicture, buttonPrevPicture, labelAttributePlaceHolder, buttonPrevPlaceHolder, buttonNextPlaceHolder);
            }
            else
            {
                disableAlbum(albumsWerentFoundMessage);
            }
        }

        private void comboBoxSortingOption_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (m_FeaturesEngine.UserConnected())
                {
                    m_FeaturesEngine.Sort(comboBoxSortingOptions.SelectedIndex);
                    clearButtonsEvents(buttonNextPlaceHolder, buttonPrevPlaceHolder, buttonNextPicture, buttonPrevPicture);
                    fetchFriends();
                    disableFirstFeatureControls();
                }
                else
                {
                    if (comboBoxSortingOptions.SelectedIndex != k_InitialValue)
                    {
                        MessageBox.Show(Consts.k_NoConnectionToFacebook);
                    }
                    comboBoxSortingOptions.SelectedIndex = k_InitialValue;
                }
            }
            catch (Exception)
            {
                MessageBox.Show(Consts.k_FacebookError);
            }
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

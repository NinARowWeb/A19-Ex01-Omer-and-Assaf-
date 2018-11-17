using System;
using System.Windows.Forms;
using SortingFriends_Engine;

namespace SotringFriends_UI
{
     public partial class FindBestFriendControl : UserControl
     {
          private const int k_InitialValue = -1, k_BestFriendNotFoundIndex = -1;
          private FeaturesEngine m_FeaturesEngine = null;

          public FindBestFriendControl(FeaturesEngine i_FeaturesEngine)
          {
               InitializeComponent();
               m_FeaturesEngine = i_FeaturesEngine;
          }

          private void disableSecondFeatureControls()
          {
               setVisibilityControls(
                    false,
                    labelFullName,
                    labelBirthdayDate,
                    labelGender,
                    labelMostTaggedUser,
                    labelMostCommonCheckin,
                    labelAlbums,
                    labelBestFriendNameText,
                    labelBirthdayDateText,
                    labelGenderText,
                    labelMostTaggedUserText,
                    labelMostTaggedCheckinText,
                    labelAlbumsText,
                    pictureBoxBestFriendPicture);
               labelBestFriendNameText.Text = string.Empty;
               labelBirthdayDateText.Text = string.Empty;
               labelGenderText.Text = string.Empty;
               labelMostTaggedUserText.Text = string.Empty;
               labelMostTaggedCheckinText.Text = string.Empty;
               labelAlbumsText.Text = string.Empty;
          }

          private void disableWholeControls()
          {
               disableSecondFeatureControls();
          }

          private void setVisibilityControls(bool i_Visiblity, params Control[] i_ControlsList)
          {
               foreach (Control currentControl in i_ControlsList)
               {
                    currentControl.Visible = i_Visiblity;
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
                    MessageBox.Show(Common.sr_NoConnectionToFacebook);
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
                    MessageBox.Show(Common.sr_NoConnectionToFacebook);
               }
          }

          private void createBirthdayEvent()
          {
               const string k_EventCreatedMessage = "suprise party event should be created. the feature blocked from version 2.0";
               if (!(checkLegalityBirthdayEvent() && m_FeaturesEngine.CreateEvent(textBoxDescirption.Text, textBoxLocation.Text)))
               {
                    textBoxDescirption.Text = string.Empty;
                    textBoxLocation.Text = string.Empty;
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
     }
}

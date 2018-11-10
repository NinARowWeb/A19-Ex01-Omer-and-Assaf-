namespace SotringFriends_UI
{
     partial class FacebookFeatures
     {
          /// <summary>
          /// Required designer variable.
          /// </summary>
          private System.ComponentModel.IContainer components = null;

          /// <summary>
          /// Clean up any resources being used.
          /// </summary>
          /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
          protected override void Dispose(bool disposing)
          {
               if (disposing && (components != null))
               {
                    components.Dispose();
               }
               base.Dispose(disposing);
          }

          #region Windows Form Designer generated code

          /// <summary>
          /// Required method for Designer support - do not modify
          /// the contents of this method with the code editor.
          /// </summary>
          private void InitializeComponent()
          {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FacebookFeatures));
            this.listBoxFriends = new System.Windows.Forms.ListBox();
            this.comboBoxSortingOptions = new System.Windows.Forms.ComboBox();
            this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
            this.labelFriends = new System.Windows.Forms.Label();
            this.Features = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBoxLogin = new System.Windows.Forms.PictureBox();
            this.labelPhotoTitle = new System.Windows.Forms.Label();
            this.buttonNextPlaceHolder = new System.Windows.Forms.Button();
            this.buttonPrevPlaceHolder = new System.Windows.Forms.Button();
            this.buttonNextPicture = new System.Windows.Forms.Button();
            this.buttonPrevPicture = new System.Windows.Forms.Button();
            this.labelAttributePlaceHolder = new System.Windows.Forms.Label();
            this.pictureBoxAlbumPhoto = new System.Windows.Forms.PictureBox();
            this.placeHolderLabel = new System.Windows.Forms.Label();
            this.labelSortBy = new System.Windows.Forms.Label();
            this.BirthdayEvent = new System.Windows.Forms.TabPage();
            this.pictureBoxFacebookLogin = new System.Windows.Forms.PictureBox();
            this.labelAlbumsText = new System.Windows.Forms.Label();
            this.labelAlbums = new System.Windows.Forms.Label();
            this.labelGenderText = new System.Windows.Forms.Label();
            this.labelGender = new System.Windows.Forms.Label();
            this.labelMostCommonCheckin = new System.Windows.Forms.Label();
            this.labelMostTaggedUser = new System.Windows.Forms.Label();
            this.labelBirthdayDate = new System.Windows.Forms.Label();
            this.labelFullName = new System.Windows.Forms.Label();
            this.labelMostTaggedCheckinText = new System.Windows.Forms.Label();
            this.labelMostTaggedUserText = new System.Windows.Forms.Label();
            this.buttonCreateBirthdayEvent = new System.Windows.Forms.Button();
            this.labelBirthdayDateText = new System.Windows.Forms.Label();
            this.labelBestFriendNameText = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBoxBestFriendPicture = new System.Windows.Forms.PictureBox();
            this.labelBestFriend = new System.Windows.Forms.Label();
            this.buttonFindBestFriend = new System.Windows.Forms.Button();
            this.textBoxLocation = new System.Windows.Forms.TextBox();
            this.textBoxDescirption = new System.Windows.Forms.TextBox();
            this.labelLocation = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.pictureBoxLoginStatus = new System.Windows.Forms.PictureBox();
            this.pictureBoxFacebookLoginStatus = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
            this.Features.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumPhoto)).BeginInit();
            this.BirthdayEvent.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLogin)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestFriendPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoginStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLoginStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxFriends
            // 
            this.listBoxFriends.FormattingEnabled = true;
            this.listBoxFriends.Location = new System.Drawing.Point(19, 145);
            this.listBoxFriends.Name = "listBoxFriends";
            this.listBoxFriends.Size = new System.Drawing.Size(181, 355);
            this.listBoxFriends.TabIndex = 51;
            this.listBoxFriends.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
            // 
            // comboBoxSortingOptions
            // 
            this.comboBoxSortingOptions.AccessibleName = "";
            this.comboBoxSortingOptions.FormattingEnabled = true;
            this.comboBoxSortingOptions.Items.AddRange(new object[] {
            "Default",
            "First Name",
            "Last Name",
            "Birthday",
            "Age",
            "Most Posts Amount",
            "Most Tagged Photos Amount",
            "Most CheckIns Amount",
            "Most Albums"});
            this.comboBoxSortingOptions.Location = new System.Drawing.Point(19, 77);
            this.comboBoxSortingOptions.Name = "comboBoxSortingOptions";
            this.comboBoxSortingOptions.Size = new System.Drawing.Size(121, 21);
            this.comboBoxSortingOptions.TabIndex = 50;
            this.comboBoxSortingOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortingOption_SelectedIndexChanged);
            // 
            // pictureBoxFriend
            // 
            this.pictureBoxFriend.Location = new System.Drawing.Point(250, 145);
            this.pictureBoxFriend.Name = "pictureBoxFriend";
            this.pictureBoxFriend.Size = new System.Drawing.Size(315, 280);
            this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxFriend.TabIndex = 49;
            this.pictureBoxFriend.TabStop = false;
            // 
            // labelFriends
            // 
            this.labelFriends.AutoSize = true;
            this.labelFriends.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFriends.Location = new System.Drawing.Point(15, 112);
            this.labelFriends.Name = "labelFriends";
            this.labelFriends.Size = new System.Drawing.Size(69, 20);
            this.labelFriends.TabIndex = 48;
            this.labelFriends.Text = "Friends";
            // 
            // Features
            // 
            this.Features.Controls.Add(this.tabPage1);
            this.Features.Controls.Add(this.BirthdayEvent);
            this.Features.Location = new System.Drawing.Point(2, 0);
            this.Features.Name = "Features";
            this.Features.SelectedIndex = 0;
            this.Features.Size = new System.Drawing.Size(1051, 559);
            this.Features.TabIndex = 52;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.tabPage1.Controls.Add(this.pictureBoxLoginStatus);
            this.tabPage1.Controls.Add(this.pictureBoxLogin);
            this.tabPage1.Controls.Add(this.labelPhotoTitle);
            this.tabPage1.Controls.Add(this.buttonNextPlaceHolder);
            this.tabPage1.Controls.Add(this.buttonPrevPlaceHolder);
            this.tabPage1.Controls.Add(this.buttonNextPicture);
            this.tabPage1.Controls.Add(this.buttonPrevPicture);
            this.tabPage1.Controls.Add(this.labelAttributePlaceHolder);
            this.tabPage1.Controls.Add(this.pictureBoxAlbumPhoto);
            this.tabPage1.Controls.Add(this.placeHolderLabel);
            this.tabPage1.Controls.Add(this.labelSortBy);
            this.tabPage1.Controls.Add(this.pictureBoxFriend);
            this.tabPage1.Controls.Add(this.labelFriends);
            this.tabPage1.Controls.Add(this.comboBoxSortingOptions);
            this.tabPage1.Controls.Add(this.listBoxFriends);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1043, 533);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Sorting Friends";
            // 
            // pictureBoxLogin
            // 
            this.pictureBoxLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogin.BackgroundImage")));
            this.pictureBoxLogin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogin.Image")));
            this.pictureBoxLogin.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLogin.InitialImage")));
            this.pictureBoxLogin.Location = new System.Drawing.Point(20, 13);
            this.pictureBoxLogin.Name = "pictureBoxLogin";
            this.pictureBoxLogin.Size = new System.Drawing.Size(50, 45);
            this.pictureBoxLogin.TabIndex = 61;
            this.pictureBoxLogin.TabStop = false;
            this.pictureBoxLogin.Click += new System.EventHandler(this.pictureBoxLogin_Click);
            // 
            // labelPhotoTitle
            // 
            this.labelPhotoTitle.AutoSize = true;
            this.labelPhotoTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelPhotoTitle.Location = new System.Drawing.Point(640, 449);
            this.labelPhotoTitle.Name = "labelPhotoTitle";
            this.labelPhotoTitle.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelPhotoTitle.Size = new System.Drawing.Size(104, 24);
            this.labelPhotoTitle.TabIndex = 60;
            this.labelPhotoTitle.Text = "PhotoTitle";
            this.labelPhotoTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelPhotoTitle.Visible = false;
            // 
            // buttonNextPlaceHolder
            // 
            this.buttonNextPlaceHolder.Location = new System.Drawing.Point(731, 322);
            this.buttonNextPlaceHolder.Name = "buttonNextPlaceHolder";
            this.buttonNextPlaceHolder.Size = new System.Drawing.Size(75, 23);
            this.buttonNextPlaceHolder.TabIndex = 59;
            this.buttonNextPlaceHolder.UseVisualStyleBackColor = true;
            this.buttonNextPlaceHolder.Visible = false;
            this.buttonNextPlaceHolder.Click += new System.EventHandler(this.buttonNextAlbum_Click);
            // 
            // buttonPrevPlaceHolder
            // 
            this.buttonPrevPlaceHolder.Location = new System.Drawing.Point(585, 322);
            this.buttonPrevPlaceHolder.Name = "buttonPrevPlaceHolder";
            this.buttonPrevPlaceHolder.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevPlaceHolder.TabIndex = 58;
            this.buttonPrevPlaceHolder.UseVisualStyleBackColor = true;
            this.buttonPrevPlaceHolder.Visible = false;
            this.buttonPrevPlaceHolder.Click += new System.EventHandler(this.buttonPrevAlbum_Click);
            // 
            // buttonNextPicture
            // 
            this.buttonNextPicture.Location = new System.Drawing.Point(731, 402);
            this.buttonNextPicture.Name = "buttonNextPicture";
            this.buttonNextPicture.Size = new System.Drawing.Size(75, 23);
            this.buttonNextPicture.TabIndex = 57;
            this.buttonNextPicture.Text = "Next Picture";
            this.buttonNextPicture.UseVisualStyleBackColor = true;
            this.buttonNextPicture.Visible = false;
            this.buttonNextPicture.Click += new System.EventHandler(this.buttonNextPicture_Click);
            // 
            // buttonPrevPicture
            // 
            this.buttonPrevPicture.Location = new System.Drawing.Point(585, 402);
            this.buttonPrevPicture.Name = "buttonPrevPicture";
            this.buttonPrevPicture.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevPicture.TabIndex = 56;
            this.buttonPrevPicture.Text = "Prev Picture";
            this.buttonPrevPicture.UseVisualStyleBackColor = true;
            this.buttonPrevPicture.Visible = false;
            this.buttonPrevPicture.Click += new System.EventHandler(this.buttonPrevPicture_Click);
            // 
            // labelAttributePlaceHolder
            // 
            this.labelAttributePlaceHolder.AutoSize = true;
            this.labelAttributePlaceHolder.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAttributePlaceHolder.Location = new System.Drawing.Point(585, 362);
            this.labelAttributePlaceHolder.Name = "labelAttributePlaceHolder";
            this.labelAttributePlaceHolder.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.labelAttributePlaceHolder.Size = new System.Drawing.Size(202, 24);
            this.labelAttributePlaceHolder.TabIndex = 55;
            this.labelAttributePlaceHolder.Text = "AttributePlaceHolder";
            this.labelAttributePlaceHolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.labelAttributePlaceHolder.Visible = false;
            // 
            // pictureBoxAlbumPhoto
            // 
            this.pictureBoxAlbumPhoto.Location = new System.Drawing.Point(585, 145);
            this.pictureBoxAlbumPhoto.Name = "pictureBoxAlbumPhoto";
            this.pictureBoxAlbumPhoto.Size = new System.Drawing.Size(221, 171);
            this.pictureBoxAlbumPhoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAlbumPhoto.TabIndex = 54;
            this.pictureBoxAlbumPhoto.TabStop = false;
            // 
            // placeHolderLabel
            // 
            this.placeHolderLabel.AutoSize = true;
            this.placeHolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.placeHolderLabel.Location = new System.Drawing.Point(340, 449);
            this.placeHolderLabel.Name = "placeHolderLabel";
            this.placeHolderLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.placeHolderLabel.Size = new System.Drawing.Size(125, 24);
            this.placeHolderLabel.TabIndex = 53;
            this.placeHolderLabel.Text = "PlaceHolder";
            this.placeHolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.placeHolderLabel.Visible = false;
            // 
            // labelSortBy
            // 
            this.labelSortBy.AutoSize = true;
            this.labelSortBy.Location = new System.Drawing.Point(16, 61);
            this.labelSortBy.Name = "labelSortBy";
            this.labelSortBy.Size = new System.Drawing.Size(58, 13);
            this.labelSortBy.TabIndex = 52;
            this.labelSortBy.Text = "Sorting By:";
            // 
            // BirthdayEvent
            // 
            this.BirthdayEvent.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.BirthdayEvent.Controls.Add(this.pictureBoxFacebookLoginStatus);
            this.BirthdayEvent.Controls.Add(this.pictureBoxFacebookLogin);
            this.BirthdayEvent.Controls.Add(this.labelAlbumsText);
            this.BirthdayEvent.Controls.Add(this.labelAlbums);
            this.BirthdayEvent.Controls.Add(this.labelGenderText);
            this.BirthdayEvent.Controls.Add(this.labelGender);
            this.BirthdayEvent.Controls.Add(this.labelMostCommonCheckin);
            this.BirthdayEvent.Controls.Add(this.labelMostTaggedUser);
            this.BirthdayEvent.Controls.Add(this.labelBirthdayDate);
            this.BirthdayEvent.Controls.Add(this.labelFullName);
            this.BirthdayEvent.Controls.Add(this.labelMostTaggedCheckinText);
            this.BirthdayEvent.Controls.Add(this.labelMostTaggedUserText);
            this.BirthdayEvent.Controls.Add(this.buttonCreateBirthdayEvent);
            this.BirthdayEvent.Controls.Add(this.labelBirthdayDateText);
            this.BirthdayEvent.Controls.Add(this.labelBestFriendNameText);
            this.BirthdayEvent.Controls.Add(this.label2);
            this.BirthdayEvent.Controls.Add(this.label1);
            this.BirthdayEvent.Controls.Add(this.pictureBoxBestFriendPicture);
            this.BirthdayEvent.Controls.Add(this.labelBestFriend);
            this.BirthdayEvent.Controls.Add(this.buttonFindBestFriend);
            this.BirthdayEvent.Controls.Add(this.textBoxLocation);
            this.BirthdayEvent.Controls.Add(this.textBoxDescirption);
            this.BirthdayEvent.Controls.Add(this.labelLocation);
            this.BirthdayEvent.Controls.Add(this.labelDescription);
            this.BirthdayEvent.Location = new System.Drawing.Point(4, 22);
            this.BirthdayEvent.Name = "BirthdayEvent";
            this.BirthdayEvent.Padding = new System.Windows.Forms.Padding(3);
            this.BirthdayEvent.Size = new System.Drawing.Size(1043, 533);
            this.BirthdayEvent.TabIndex = 1;
            this.BirthdayEvent.Text = "Best Friend Birthday";
            // 
            // pictureBoxFacebookLogin
            // 
            this.pictureBoxFacebookLogin.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebookLogin.BackgroundImage")));
            this.pictureBoxFacebookLogin.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebookLogin.Image")));
            this.pictureBoxFacebookLogin.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxFacebookLogin.InitialImage")));
            this.pictureBoxFacebookLogin.Location = new System.Drawing.Point(21, 8);
            this.pictureBoxFacebookLogin.Name = "pictureBoxFacebookLogin";
            this.pictureBoxFacebookLogin.Size = new System.Drawing.Size(50, 42);
            this.pictureBoxFacebookLogin.TabIndex = 73;
            this.pictureBoxFacebookLogin.TabStop = false;
            // 
            // labelAlbumsText
            // 
            this.labelAlbumsText.AutoSize = true;
            this.labelAlbumsText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAlbumsText.Location = new System.Drawing.Point(169, 236);
            this.labelAlbumsText.Name = "labelAlbumsText";
            this.labelAlbumsText.Size = new System.Drawing.Size(47, 13);
            this.labelAlbumsText.TabIndex = 72;
            this.labelAlbumsText.Text = "Albums";
            this.labelAlbumsText.Visible = false;
            // 
            // labelAlbums
            // 
            this.labelAlbums.AutoSize = true;
            this.labelAlbums.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelAlbums.Location = new System.Drawing.Point(24, 236);
            this.labelAlbums.Name = "labelAlbums";
            this.labelAlbums.Size = new System.Drawing.Size(51, 13);
            this.labelAlbums.TabIndex = 71;
            this.labelAlbums.Text = "Albums:";
            this.labelAlbums.Visible = false;
            // 
            // labelGenderText
            // 
            this.labelGenderText.AutoSize = true;
            this.labelGenderText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGenderText.Location = new System.Drawing.Point(169, 159);
            this.labelGenderText.Name = "labelGenderText";
            this.labelGenderText.Size = new System.Drawing.Size(48, 13);
            this.labelGenderText.TabIndex = 70;
            this.labelGenderText.Text = "Gender";
            this.labelGenderText.Visible = false;
            // 
            // labelGender
            // 
            this.labelGender.AutoSize = true;
            this.labelGender.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelGender.Location = new System.Drawing.Point(24, 159);
            this.labelGender.Name = "labelGender";
            this.labelGender.Size = new System.Drawing.Size(52, 13);
            this.labelGender.TabIndex = 69;
            this.labelGender.Text = "Gender:";
            this.labelGender.Visible = false;
            // 
            // labelMostCommonCheckin
            // 
            this.labelMostCommonCheckin.AutoSize = true;
            this.labelMostCommonCheckin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMostCommonCheckin.Location = new System.Drawing.Point(24, 210);
            this.labelMostCommonCheckin.Name = "labelMostCommonCheckin";
            this.labelMostCommonCheckin.Size = new System.Drawing.Size(139, 13);
            this.labelMostCommonCheckin.TabIndex = 68;
            this.labelMostCommonCheckin.Text = "Most Common Checkin:";
            this.labelMostCommonCheckin.Visible = false;
            // 
            // labelMostTaggedUser
            // 
            this.labelMostTaggedUser.AutoSize = true;
            this.labelMostTaggedUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMostTaggedUser.Location = new System.Drawing.Point(24, 183);
            this.labelMostTaggedUser.Name = "labelMostTaggedUser";
            this.labelMostTaggedUser.Size = new System.Drawing.Size(115, 13);
            this.labelMostTaggedUser.TabIndex = 67;
            this.labelMostTaggedUser.Text = "Most Tagged User:";
            this.labelMostTaggedUser.Visible = false;
            // 
            // labelBirthdayDate
            // 
            this.labelBirthdayDate.AutoSize = true;
            this.labelBirthdayDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBirthdayDate.Location = new System.Drawing.Point(24, 135);
            this.labelBirthdayDate.Name = "labelBirthdayDate";
            this.labelBirthdayDate.Size = new System.Drawing.Size(57, 13);
            this.labelBirthdayDate.TabIndex = 66;
            this.labelBirthdayDate.Text = "Birthday:";
            this.labelBirthdayDate.Visible = false;
            // 
            // labelFullName
            // 
            this.labelFullName.AutoSize = true;
            this.labelFullName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelFullName.Location = new System.Drawing.Point(24, 112);
            this.labelFullName.Name = "labelFullName";
            this.labelFullName.Size = new System.Drawing.Size(43, 13);
            this.labelFullName.TabIndex = 65;
            this.labelFullName.Text = "Name:";
            this.labelFullName.Visible = false;
            // 
            // labelMostTaggedCheckinText
            // 
            this.labelMostTaggedCheckinText.AutoSize = true;
            this.labelMostTaggedCheckinText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMostTaggedCheckinText.Location = new System.Drawing.Point(169, 210);
            this.labelMostTaggedCheckinText.Name = "labelMostTaggedCheckinText";
            this.labelMostTaggedCheckinText.Size = new System.Drawing.Size(123, 13);
            this.labelMostTaggedCheckinText.TabIndex = 64;
            this.labelMostTaggedCheckinText.Text = "MostTaggedCheckin";
            this.labelMostTaggedCheckinText.Visible = false;
            // 
            // labelMostTaggedUserText
            // 
            this.labelMostTaggedUserText.AutoSize = true;
            this.labelMostTaggedUserText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelMostTaggedUserText.Location = new System.Drawing.Point(169, 183);
            this.labelMostTaggedUserText.Name = "labelMostTaggedUserText";
            this.labelMostTaggedUserText.Size = new System.Drawing.Size(77, 13);
            this.labelMostTaggedUserText.TabIndex = 63;
            this.labelMostTaggedUserText.Text = "MostTagged";
            this.labelMostTaggedUserText.Visible = false;
            // 
            // buttonCreateBirthdayEvent
            // 
            this.buttonCreateBirthdayEvent.Location = new System.Drawing.Point(555, 356);
            this.buttonCreateBirthdayEvent.Name = "buttonCreateBirthdayEvent";
            this.buttonCreateBirthdayEvent.Size = new System.Drawing.Size(130, 23);
            this.buttonCreateBirthdayEvent.TabIndex = 62;
            this.buttonCreateBirthdayEvent.Text = "Create Birthday Event";
            this.buttonCreateBirthdayEvent.UseVisualStyleBackColor = true;
            this.buttonCreateBirthdayEvent.Click += new System.EventHandler(this.buttonCreateBirthdayEvent_Click);
            // 
            // labelBirthdayDateText
            // 
            this.labelBirthdayDateText.AutoSize = true;
            this.labelBirthdayDateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBirthdayDateText.Location = new System.Drawing.Point(169, 135);
            this.labelBirthdayDateText.Name = "labelBirthdayDateText";
            this.labelBirthdayDateText.Size = new System.Drawing.Size(80, 13);
            this.labelBirthdayDateText.TabIndex = 61;
            this.labelBirthdayDateText.Text = "BirthdayDate";
            this.labelBirthdayDateText.Visible = false;
            // 
            // labelBestFriendNameText
            // 
            this.labelBestFriendNameText.AutoSize = true;
            this.labelBestFriendNameText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBestFriendNameText.Location = new System.Drawing.Point(169, 112);
            this.labelBestFriendNameText.Name = "labelBestFriendNameText";
            this.labelBestFriendNameText.Size = new System.Drawing.Size(107, 13);
            this.labelBestFriendNameText.TabIndex = 60;
            this.labelBestFriendNameText.Text = "Best Friend Name";
            this.labelBestFriendNameText.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 338);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 59;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(81, 338);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 58;
            // 
            // pictureBoxBestFriendPicture
            // 
            this.pictureBoxBestFriendPicture.Location = new System.Drawing.Point(27, 265);
            this.pictureBoxBestFriendPicture.Name = "pictureBoxBestFriendPicture";
            this.pictureBoxBestFriendPicture.Size = new System.Drawing.Size(167, 166);
            this.pictureBoxBestFriendPicture.TabIndex = 57;
            this.pictureBoxBestFriendPicture.TabStop = false;
            this.pictureBoxBestFriendPicture.Visible = false;
            // 
            // labelBestFriend
            // 
            this.labelBestFriend.AutoSize = true;
            this.labelBestFriend.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.labelBestFriend.Location = new System.Drawing.Point(16, 87);
            this.labelBestFriend.Name = "labelBestFriend";
            this.labelBestFriend.Size = new System.Drawing.Size(144, 18);
            this.labelBestFriend.TabIndex = 56;
            this.labelBestFriend.Text = "Your Best Friend :";
            // 
            // buttonFindBestFriend
            // 
            this.buttonFindBestFriend.Location = new System.Drawing.Point(19, 55);
            this.buttonFindBestFriend.Name = "buttonFindBestFriend";
            this.buttonFindBestFriend.Size = new System.Drawing.Size(112, 23);
            this.buttonFindBestFriend.TabIndex = 55;
            this.buttonFindBestFriend.Text = "Find Best Friend";
            this.buttonFindBestFriend.UseVisualStyleBackColor = true;
            this.buttonFindBestFriend.Click += new System.EventHandler(this.buttonFindBestFriend_Click);
            // 
            // textBoxLocation
            // 
            this.textBoxLocation.Location = new System.Drawing.Point(555, 75);
            this.textBoxLocation.Name = "textBoxLocation";
            this.textBoxLocation.Size = new System.Drawing.Size(100, 20);
            this.textBoxLocation.TabIndex = 53;
            // 
            // textBoxDescirption
            // 
            this.textBoxDescirption.Location = new System.Drawing.Point(555, 135);
            this.textBoxDescirption.Multiline = true;
            this.textBoxDescirption.Name = "textBoxDescirption";
            this.textBoxDescirption.Size = new System.Drawing.Size(234, 180);
            this.textBoxDescirption.TabIndex = 52;
            // 
            // labelLocation
            // 
            this.labelLocation.AutoSize = true;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelLocation.Location = new System.Drawing.Point(481, 78);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(56, 13);
            this.labelLocation.TabIndex = 50;
            this.labelLocation.Text = "Location";
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDescription.Location = new System.Drawing.Point(481, 138);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(71, 13);
            this.labelDescription.TabIndex = 49;
            this.labelDescription.Text = "Description";
            // 
            // pictureBoxLoginStatus
            // 
            this.pictureBoxLoginStatus.Location = new System.Drawing.Point(90, 26);
            this.pictureBoxLoginStatus.Name = "pictureBoxLoginStatus";
            this.pictureBoxLoginStatus.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxLoginStatus.TabIndex = 62;
            this.pictureBoxLoginStatus.TabStop = false;
            // 
            // pictureBoxFacebookLoginStatus
            // 
            this.pictureBoxFacebookLoginStatus.Location = new System.Drawing.Point(87, 18);
            this.pictureBoxFacebookLoginStatus.Name = "pictureBoxFacebookLoginStatus";
            this.pictureBoxFacebookLoginStatus.Size = new System.Drawing.Size(22, 20);
            this.pictureBoxFacebookLoginStatus.TabIndex = 74;
            this.pictureBoxFacebookLoginStatus.TabStop = false;
            // 
            // FacebookFeatures
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1051, 553);
            this.Controls.Add(this.Features);
            this.Name = "FacebookFeatures";
            this.Text = "Facebook Features";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
            this.Features.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAlbumPhoto)).EndInit();
            this.BirthdayEvent.ResumeLayout(false);
            this.BirthdayEvent.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLogin)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBestFriendPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLoginStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFacebookLoginStatus)).EndInit();
            this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.ListBox listBoxFriends;
          private System.Windows.Forms.ComboBox comboBoxSortingOptions;
          private System.Windows.Forms.PictureBox pictureBoxFriend;
          private System.Windows.Forms.Label labelFriends;
          private System.Windows.Forms.TabControl Features;
          private System.Windows.Forms.TabPage tabPage1;
          private System.Windows.Forms.TabPage BirthdayEvent;
          private System.Windows.Forms.TextBox textBoxLocation;
          private System.Windows.Forms.TextBox textBoxDescirption;
          private System.Windows.Forms.Label labelLocation;
          private System.Windows.Forms.Label labelDescription;
          private System.Windows.Forms.Label labelBestFriend;
          private System.Windows.Forms.Button buttonFindBestFriend;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.PictureBox pictureBoxBestFriendPicture;
          private System.Windows.Forms.Timer timer1;
          private System.Windows.Forms.Label labelBirthdayDateText;
          private System.Windows.Forms.Label labelBestFriendNameText;
          private System.Windows.Forms.Button buttonCreateBirthdayEvent;
        private System.Windows.Forms.Label labelSortBy;
          private System.Windows.Forms.Label placeHolderLabel;
        private System.Windows.Forms.Label labelMostTaggedUserText;
        private System.Windows.Forms.Label labelMostTaggedCheckinText;
        private System.Windows.Forms.Label labelMostCommonCheckin;
        private System.Windows.Forms.Label labelMostTaggedUser;
        private System.Windows.Forms.Label labelBirthdayDate;
        private System.Windows.Forms.Label labelFullName;
        private System.Windows.Forms.Label labelAlbumsText;
        private System.Windows.Forms.Label labelAlbums;
        private System.Windows.Forms.Label labelGenderText;
        private System.Windows.Forms.Label labelGender;
        private System.Windows.Forms.Label labelPhotoTitle;
        private System.Windows.Forms.Button buttonNextPlaceHolder;
        private System.Windows.Forms.Button buttonPrevPlaceHolder;
        private System.Windows.Forms.Button buttonNextPicture;
        private System.Windows.Forms.Button buttonPrevPicture;
        private System.Windows.Forms.Label labelAttributePlaceHolder;
        private System.Windows.Forms.PictureBox pictureBoxAlbumPhoto;
        private System.Windows.Forms.PictureBox pictureBoxLogin;
        private System.Windows.Forms.PictureBox pictureBoxFacebookLogin;
        private System.Windows.Forms.PictureBox pictureBoxLoginStatus;
        private System.Windows.Forms.PictureBox pictureBoxFacebookLoginStatus;
    }
}


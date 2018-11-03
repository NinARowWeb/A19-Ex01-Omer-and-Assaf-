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
               this.FriendsList = new System.Windows.Forms.ListBox();
               this.ComboBoxSortingOptions = new System.Windows.Forms.ComboBox();
               this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
               this.FriendsLabel = new System.Windows.Forms.Label();
               this.LoginButton = new System.Windows.Forms.Button();
               this.Features = new System.Windows.Forms.TabControl();
               this.tabPage1 = new System.Windows.Forms.TabPage();
               this.placeHolderLabel = new System.Windows.Forms.Label();
               this.SortByLabel = new System.Windows.Forms.Label();
               this.BirthdayEvent = new System.Windows.Forms.TabPage();
               this.CreateBirthdayEventButton = new System.Windows.Forms.Button();
               this.BirthdayDateLabel = new System.Windows.Forms.Label();
               this.BestFriendNameLabel = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.label1 = new System.Windows.Forms.Label();
               this.BestFriendPictureBox = new System.Windows.Forms.PictureBox();
               this.BestFriendLabel = new System.Windows.Forms.Label();
               this.FindBestFriendButton = new System.Windows.Forms.Button();
               this.LocationTextBox = new System.Windows.Forms.TextBox();
               this.DescirptionTextBox = new System.Windows.Forms.TextBox();
               this.LocationLabel = new System.Windows.Forms.Label();
               this.DescriptionLabel = new System.Windows.Forms.Label();
               this.ButtonFaceBookLogin = new System.Windows.Forms.Button();
               this.timer1 = new System.Windows.Forms.Timer(this.components);
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
               this.Features.SuspendLayout();
               this.tabPage1.SuspendLayout();
               this.BirthdayEvent.SuspendLayout();
               ((System.ComponentModel.ISupportInitialize)(this.BestFriendPictureBox)).BeginInit();
               this.SuspendLayout();
               // 
               // FriendsList
               // 
               this.FriendsList.FormattingEnabled = true;
               this.FriendsList.Location = new System.Drawing.Point(19, 145);
               this.FriendsList.Name = "FriendsList";
               this.FriendsList.Size = new System.Drawing.Size(181, 355);
               this.FriendsList.TabIndex = 51;
               this.FriendsList.SelectedIndexChanged += new System.EventHandler(this.listBoxFriends_SelectedIndexChanged);
               // 
               // ComboBoxSortingOptions
               // 
               this.ComboBoxSortingOptions.AccessibleName = "";
               this.ComboBoxSortingOptions.FormattingEnabled = true;
               this.ComboBoxSortingOptions.Items.AddRange(new object[] {
            "Default",
            "First Name",
            "Last Name",
            "Birthday",
            "Age"});
               this.ComboBoxSortingOptions.Location = new System.Drawing.Point(19, 77);
               this.ComboBoxSortingOptions.Name = "ComboBoxSortingOptions";
               this.ComboBoxSortingOptions.Size = new System.Drawing.Size(121, 21);
               this.ComboBoxSortingOptions.TabIndex = 50;
               this.ComboBoxSortingOptions.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortingOption_SelectedIndexChanged);
               // 
               // pictureBoxFriend
               // 
               this.pictureBoxFriend.Location = new System.Drawing.Point(417, 39);
               this.pictureBoxFriend.Name = "pictureBoxFriend";
               this.pictureBoxFriend.Size = new System.Drawing.Size(371, 386);
               this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
               this.pictureBoxFriend.TabIndex = 49;
               this.pictureBoxFriend.TabStop = false;
               // 
               // FriendsLabel
               // 
               this.FriendsLabel.AutoSize = true;
               this.FriendsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.FriendsLabel.Location = new System.Drawing.Point(15, 112);
               this.FriendsLabel.Name = "FriendsLabel";
               this.FriendsLabel.Size = new System.Drawing.Size(69, 20);
               this.FriendsLabel.TabIndex = 48;
               this.FriendsLabel.Text = "Friends";
               // 
               // LoginButton
               // 
               this.LoginButton.Location = new System.Drawing.Point(19, 26);
               this.LoginButton.Name = "LoginButton";
               this.LoginButton.Size = new System.Drawing.Size(75, 23);
               this.LoginButton.TabIndex = 47;
               this.LoginButton.Text = "Login";
               this.LoginButton.UseVisualStyleBackColor = true;
               this.LoginButton.Click += new System.EventHandler(this.buttonLogin_Click);
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
               this.Features.Click += new System.EventHandler(this.buttonLogin_Click);
               // 
               // tabPage1
               // 
               this.tabPage1.Controls.Add(this.placeHolderLabel);
               this.tabPage1.Controls.Add(this.SortByLabel);
               this.tabPage1.Controls.Add(this.pictureBoxFriend);
               this.tabPage1.Controls.Add(this.FriendsLabel);
               this.tabPage1.Controls.Add(this.ComboBoxSortingOptions);
               this.tabPage1.Controls.Add(this.LoginButton);
               this.tabPage1.Controls.Add(this.FriendsList);
               this.tabPage1.Location = new System.Drawing.Point(4, 22);
               this.tabPage1.Name = "tabPage1";
               this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
               this.tabPage1.Size = new System.Drawing.Size(1043, 533);
               this.tabPage1.TabIndex = 0;
               this.tabPage1.Text = "Sorting Friends";
               this.tabPage1.UseVisualStyleBackColor = true;
               // 
               // placeHolderLabel
               // 
               this.placeHolderLabel.AutoSize = true;
               this.placeHolderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.placeHolderLabel.Location = new System.Drawing.Point(522, 446);
               this.placeHolderLabel.Name = "placeHolderLabel";
               this.placeHolderLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
               this.placeHolderLabel.Size = new System.Drawing.Size(125, 24);
               this.placeHolderLabel.TabIndex = 53;
               this.placeHolderLabel.Text = "PlaceHolder";
               this.placeHolderLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
               this.placeHolderLabel.Visible = false;
               // 
               // SortByLabel
               // 
               this.SortByLabel.AutoSize = true;
               this.SortByLabel.Location = new System.Drawing.Point(16, 61);
               this.SortByLabel.Name = "SortByLabel";
               this.SortByLabel.Size = new System.Drawing.Size(44, 13);
               this.SortByLabel.TabIndex = 52;
               this.SortByLabel.Text = "Sort By:";
               // 
               // BirthdayEvent
               // 
               this.BirthdayEvent.Controls.Add(this.CreateBirthdayEventButton);
               this.BirthdayEvent.Controls.Add(this.BirthdayDateLabel);
               this.BirthdayEvent.Controls.Add(this.BestFriendNameLabel);
               this.BirthdayEvent.Controls.Add(this.label2);
               this.BirthdayEvent.Controls.Add(this.label1);
               this.BirthdayEvent.Controls.Add(this.BestFriendPictureBox);
               this.BirthdayEvent.Controls.Add(this.BestFriendLabel);
               this.BirthdayEvent.Controls.Add(this.FindBestFriendButton);
               this.BirthdayEvent.Controls.Add(this.LocationTextBox);
               this.BirthdayEvent.Controls.Add(this.DescirptionTextBox);
               this.BirthdayEvent.Controls.Add(this.LocationLabel);
               this.BirthdayEvent.Controls.Add(this.DescriptionLabel);
               this.BirthdayEvent.Controls.Add(this.ButtonFaceBookLogin);
               this.BirthdayEvent.Location = new System.Drawing.Point(4, 22);
               this.BirthdayEvent.Name = "BirthdayEvent";
               this.BirthdayEvent.Padding = new System.Windows.Forms.Padding(3);
               this.BirthdayEvent.Size = new System.Drawing.Size(1043, 533);
               this.BirthdayEvent.TabIndex = 1;
               this.BirthdayEvent.Text = "Best Friend Birthday";
               this.BirthdayEvent.UseVisualStyleBackColor = true;
               // 
               // CreateBirthdayEventButton
               // 
               this.CreateBirthdayEventButton.Location = new System.Drawing.Point(318, 356);
               this.CreateBirthdayEventButton.Name = "CreateBirthdayEventButton";
               this.CreateBirthdayEventButton.Size = new System.Drawing.Size(130, 23);
               this.CreateBirthdayEventButton.TabIndex = 62;
               this.CreateBirthdayEventButton.Text = "Create Birthday Event";
               this.CreateBirthdayEventButton.UseVisualStyleBackColor = true;
               this.CreateBirthdayEventButton.Click += new System.EventHandler(this.buttonCreateBirthdayEvent_Click);
               // 
               // BirthdayDateLabel
               // 
               this.BirthdayDateLabel.AutoSize = true;
               this.BirthdayDateLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.BirthdayDateLabel.Location = new System.Drawing.Point(16, 310);
               this.BirthdayDateLabel.Name = "BirthdayDateLabel";
               this.BirthdayDateLabel.Size = new System.Drawing.Size(80, 13);
               this.BirthdayDateLabel.TabIndex = 61;
               this.BirthdayDateLabel.Text = "BirthdayDate";
               this.BirthdayDateLabel.Visible = false;
               // 
               // BestFriendNameLabel
               // 
               this.BestFriendNameLabel.AutoSize = true;
               this.BestFriendNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.BestFriendNameLabel.Location = new System.Drawing.Point(16, 286);
               this.BestFriendNameLabel.Name = "BestFriendNameLabel";
               this.BestFriendNameLabel.Size = new System.Drawing.Size(107, 13);
               this.BestFriendNameLabel.TabIndex = 60;
               this.BestFriendNameLabel.Text = "Best Friend Name";
               this.BestFriendNameLabel.Visible = false;
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
               // BestFriendPictureBox
               // 
               this.BestFriendPictureBox.Location = new System.Drawing.Point(19, 338);
               this.BestFriendPictureBox.Name = "BestFriendPictureBox";
               this.BestFriendPictureBox.Size = new System.Drawing.Size(167, 166);
               this.BestFriendPictureBox.TabIndex = 57;
               this.BestFriendPictureBox.TabStop = false;
               this.BestFriendPictureBox.Visible = false;
               // 
               // BestFriendLabel
               // 
               this.BestFriendLabel.AutoSize = true;
               this.BestFriendLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.BestFriendLabel.Location = new System.Drawing.Point(16, 261);
               this.BestFriendLabel.Name = "BestFriendLabel";
               this.BestFriendLabel.Size = new System.Drawing.Size(144, 18);
               this.BestFriendLabel.TabIndex = 56;
               this.BestFriendLabel.Text = "Your Best Friend :";
               // 
               // FindBestFriendButton
               // 
               this.FindBestFriendButton.Location = new System.Drawing.Point(19, 55);
               this.FindBestFriendButton.Name = "FindBestFriendButton";
               this.FindBestFriendButton.Size = new System.Drawing.Size(112, 23);
               this.FindBestFriendButton.TabIndex = 55;
               this.FindBestFriendButton.Text = "Find Best Friend";
               this.FindBestFriendButton.UseVisualStyleBackColor = true;
               this.FindBestFriendButton.Click += new System.EventHandler(this.buttonFindBestFriend_Click);
               // 
               // LocationTextBox
               // 
               this.LocationTextBox.Location = new System.Drawing.Point(318, 75);
               this.LocationTextBox.Name = "LocationTextBox";
               this.LocationTextBox.Size = new System.Drawing.Size(100, 20);
               this.LocationTextBox.TabIndex = 53;
               // 
               // DescirptionTextBox
               // 
               this.DescirptionTextBox.Location = new System.Drawing.Point(318, 135);
               this.DescirptionTextBox.Multiline = true;
               this.DescirptionTextBox.Name = "DescirptionTextBox";
               this.DescirptionTextBox.Size = new System.Drawing.Size(234, 180);
               this.DescirptionTextBox.TabIndex = 52;
               // 
               // LocationLabel
               // 
               this.LocationLabel.AutoSize = true;
               this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.LocationLabel.Location = new System.Drawing.Point(244, 78);
               this.LocationLabel.Name = "LocationLabel";
               this.LocationLabel.Size = new System.Drawing.Size(56, 13);
               this.LocationLabel.TabIndex = 50;
               this.LocationLabel.Text = "Location";
               // 
               // DescriptionLabel
               // 
               this.DescriptionLabel.AutoSize = true;
               this.DescriptionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.DescriptionLabel.Location = new System.Drawing.Point(244, 138);
               this.DescriptionLabel.Name = "DescriptionLabel";
               this.DescriptionLabel.Size = new System.Drawing.Size(71, 13);
               this.DescriptionLabel.TabIndex = 49;
               this.DescriptionLabel.Text = "Description";
               // 
               // ButtonFaceBookLogin
               // 
               this.ButtonFaceBookLogin.Location = new System.Drawing.Point(19, 26);
               this.ButtonFaceBookLogin.Name = "ButtonFaceBookLogin";
               this.ButtonFaceBookLogin.Size = new System.Drawing.Size(75, 23);
               this.ButtonFaceBookLogin.TabIndex = 48;
               this.ButtonFaceBookLogin.Text = "Login";
               this.ButtonFaceBookLogin.UseVisualStyleBackColor = true;
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
               this.BirthdayEvent.ResumeLayout(false);
               this.BirthdayEvent.PerformLayout();
               ((System.ComponentModel.ISupportInitialize)(this.BestFriendPictureBox)).EndInit();
               this.ResumeLayout(false);

          }

          #endregion

          private System.Windows.Forms.ListBox FriendsList;
          private System.Windows.Forms.ComboBox ComboBoxSortingOptions;
          private System.Windows.Forms.PictureBox pictureBoxFriend;
          private System.Windows.Forms.Label FriendsLabel;
          private System.Windows.Forms.Button LoginButton;
          private System.Windows.Forms.TabControl Features;
          private System.Windows.Forms.TabPage tabPage1;
          private System.Windows.Forms.TabPage BirthdayEvent;
          private System.Windows.Forms.TextBox LocationTextBox;
          private System.Windows.Forms.TextBox DescirptionTextBox;
          private System.Windows.Forms.Label LocationLabel;
          private System.Windows.Forms.Label DescriptionLabel;
          private System.Windows.Forms.Button ButtonFaceBookLogin;
          private System.Windows.Forms.Label BestFriendLabel;
          private System.Windows.Forms.Button FindBestFriendButton;
          private System.Windows.Forms.Label label2;
          private System.Windows.Forms.Label label1;
          private System.Windows.Forms.PictureBox BestFriendPictureBox;
          private System.Windows.Forms.Timer timer1;
          private System.Windows.Forms.Label BirthdayDateLabel;
          private System.Windows.Forms.Label BestFriendNameLabel;
          private System.Windows.Forms.Button CreateBirthdayEventButton;
        private System.Windows.Forms.Label SortByLabel;
          private System.Windows.Forms.Label placeHolderLabel;
     }
}


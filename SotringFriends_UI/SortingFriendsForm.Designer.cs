namespace SotringFriends_UI
{
     partial class SortingFriendsForm
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
               this.FriendsList = new System.Windows.Forms.ListBox();
               this.SortingOptions = new System.Windows.Forms.ComboBox();
               this.pictureBoxFriend = new System.Windows.Forms.PictureBox();
               this.FriendsLabel = new System.Windows.Forms.Label();
               this.LoginButton = new System.Windows.Forms.Button();
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).BeginInit();
               this.SuspendLayout();
               // 
               // FriendsList
               // 
               this.FriendsList.FormattingEnabled = true;
               this.FriendsList.Location = new System.Drawing.Point(41, 133);
               this.FriendsList.Name = "FriendsList";
               this.FriendsList.Size = new System.Drawing.Size(154, 147);
               this.FriendsList.TabIndex = 51;
               this.FriendsList.SelectedIndexChanged += new System.EventHandler(this.Friends_SelectedIndexChanged);
               // 
               // SortingOptions
               // 
               this.SortingOptions.AccessibleName = "";
               this.SortingOptions.FormattingEnabled = true;
               this.SortingOptions.Items.AddRange(new object[] {
            "Default",
            "First Name",
            "Last Name",
            "Birthday",
            "Age"});
               this.SortingOptions.Location = new System.Drawing.Point(146, 54);
               this.SortingOptions.Name = "SortingOptions";
               this.SortingOptions.Size = new System.Drawing.Size(121, 21);
               this.SortingOptions.TabIndex = 50;
               this.SortingOptions.SelectedIndexChanged += new System.EventHandler(this.SortingOption_SelectedIndexChanged);
               // 
               // pictureBoxFriend
               // 
               this.pictureBoxFriend.Location = new System.Drawing.Point(449, 133);
               this.pictureBoxFriend.Name = "pictureBoxFriend";
               this.pictureBoxFriend.Size = new System.Drawing.Size(169, 156);
               this.pictureBoxFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
               this.pictureBoxFriend.TabIndex = 49;
               this.pictureBoxFriend.TabStop = false;
               this.pictureBoxFriend.Click += new System.EventHandler(this.pictureBoxFriend_Click);
               // 
               // FriendsLabel
               // 
               this.FriendsLabel.AutoSize = true;
               this.FriendsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
               this.FriendsLabel.Location = new System.Drawing.Point(37, 96);
               this.FriendsLabel.Name = "FriendsLabel";
               this.FriendsLabel.Size = new System.Drawing.Size(69, 20);
               this.FriendsLabel.TabIndex = 48;
               this.FriendsLabel.Text = "Friends";
               // 
               // LoginButton
               // 
               this.LoginButton.Location = new System.Drawing.Point(40, 52);
               this.LoginButton.Name = "LoginButton";
               this.LoginButton.Size = new System.Drawing.Size(75, 23);
               this.LoginButton.TabIndex = 47;
               this.LoginButton.Text = "Login";
               this.LoginButton.UseVisualStyleBackColor = true;
               this.LoginButton.Click += new System.EventHandler(this.LoginButton_Click);
               // 
               // SortingFriendsForm
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1051, 553);
               this.Controls.Add(this.FriendsList);
               this.Controls.Add(this.SortingOptions);
               this.Controls.Add(this.pictureBoxFriend);
               this.Controls.Add(this.FriendsLabel);
               this.Controls.Add(this.LoginButton);
               this.Name = "SortingFriendsForm";
               this.Text = "Form1";
               ((System.ComponentModel.ISupportInitialize)(this.pictureBoxFriend)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

          }

          #endregion

          private System.Windows.Forms.ListBox FriendsList;
          private System.Windows.Forms.ComboBox SortingOptions;
          private System.Windows.Forms.PictureBox pictureBoxFriend;
          private System.Windows.Forms.Label FriendsLabel;
          private System.Windows.Forms.Button LoginButton;
     }
}


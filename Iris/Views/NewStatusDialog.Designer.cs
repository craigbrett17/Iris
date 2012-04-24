namespace Iris.Views
{
    partial class NewStatusDialog
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
            this.statusBox = new System.Windows.Forms.TextBox();
            this.locationButton = new System.Windows.Forms.Button();
            this.friendsButton = new System.Windows.Forms.Button();
            this.audienceButton = new System.Windows.Forms.Button();
            this.postButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // statusBox
            // 
            this.statusBox.AcceptsReturn = true;
            this.statusBox.AccessibleDescription = "What\'s on your mind?";
            this.statusBox.AccessibleName = "Status";
            this.statusBox.Location = new System.Drawing.Point(5, 5);
            this.statusBox.Multiline = true;
            this.statusBox.Name = "statusBox";
            this.statusBox.Size = new System.Drawing.Size(280, 50);
            this.statusBox.TabIndex = 0;
            // 
            // locationButton
            // 
            this.locationButton.AccessibleDescription = "Add your location to the status";
            this.locationButton.Enabled = false;
            this.locationButton.Location = new System.Drawing.Point(15, 65);
            this.locationButton.Name = "locationButton";
            this.locationButton.Size = new System.Drawing.Size(75, 23);
            this.locationButton.TabIndex = 1;
            this.locationButton.Text = "&Location";
            this.locationButton.UseVisualStyleBackColor = true;
            this.locationButton.Click += new System.EventHandler(this.locationButton_Click);
            // 
            // friendsButton
            // 
            this.friendsButton.AccessibleDescription = "Tag friends who are with you";
            this.friendsButton.Enabled = false;
            this.friendsButton.Location = new System.Drawing.Point(100, 65);
            this.friendsButton.Name = "friendsButton";
            this.friendsButton.Size = new System.Drawing.Size(75, 23);
            this.friendsButton.TabIndex = 2;
            this.friendsButton.Text = "&Friends";
            this.friendsButton.UseVisualStyleBackColor = true;
            this.friendsButton.Click += new System.EventHandler(this.friendsButton_Click);
            // 
            // audienceButton
            // 
            this.audienceButton.AccessibleDescription = "Select the audience for this post";
            this.audienceButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.audienceButton.Enabled = false;
            this.audienceButton.Location = new System.Drawing.Point(185, 65);
            this.audienceButton.Name = "audienceButton";
            this.audienceButton.Size = new System.Drawing.Size(75, 23);
            this.audienceButton.TabIndex = 3;
            this.audienceButton.Text = "&Audience";
            this.audienceButton.UseVisualStyleBackColor = true;
            this.audienceButton.Click += new System.EventHandler(this.audienceButton_Click);
            // 
            // postButton
            // 
            this.postButton.AccessibleDescription = "Post your status to Facebook";
            this.postButton.Location = new System.Drawing.Point(90, 140);
            this.postButton.Name = "postButton";
            this.postButton.Size = new System.Drawing.Size(75, 23);
            this.postButton.TabIndex = 4;
            this.postButton.Text = "&Post";
            this.postButton.UseVisualStyleBackColor = true;
            this.postButton.Click += new System.EventHandler(this.postButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.closeButton.Location = new System.Drawing.Point(195, 140);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(75, 23);
            this.closeButton.TabIndex = 5;
            this.closeButton.Text = "&Cancel";
            this.closeButton.UseVisualStyleBackColor = true;
            // 
            // NewStatusDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.closeButton;
            this.ClientSize = new System.Drawing.Size(292, 223);
            this.ControlBox = false;
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.postButton);
            this.Controls.Add(this.audienceButton);
            this.Controls.Add(this.friendsButton);
            this.Controls.Add(this.locationButton);
            this.Controls.Add(this.statusBox);
            this.MaximizeBox = false;
            this.Name = "NewStatusDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Iris - New Status";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox statusBox;
        private System.Windows.Forms.Button locationButton;
        private System.Windows.Forms.Button friendsButton;
        private System.Windows.Forms.Button audienceButton;
        private System.Windows.Forms.Button postButton;
        private System.Windows.Forms.Button closeButton;
    }
}
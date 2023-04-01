namespace ContactsApp.View
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.ContactsAppLabel = new System.Windows.Forms.Label();
            this.VersionLabel = new System.Windows.Forms.Label();
            this.AuthorLabel = new System.Windows.Forms.Label();
            this.EmailLabel = new System.Windows.Forms.Label();
            this.GithubLabel = new System.Windows.Forms.Label();
            this.AuthorLastNameFirstNameLabel = new System.Windows.Forms.Label();
            this.AuthorEmailLabel = new System.Windows.Forms.Label();
            this.AuthorGithubLinkLabel = new System.Windows.Forms.LinkLabel();
            this.CopyrightTextBox = new System.Windows.Forms.TextBox();
            this.ImagesFromLabel = new System.Windows.Forms.Label();
            this.Icons8LinkLabel = new System.Windows.Forms.LinkLabel();
            this.ButtonContactAppPanel = new System.Windows.Forms.Panel();
            this.OKButton = new System.Windows.Forms.Button();
            this.ButtonContactAppPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // ContactsAppLabel
            // 
            this.ContactsAppLabel.AutoSize = true;
            this.ContactsAppLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ContactsAppLabel.Location = new System.Drawing.Point(12, 9);
            this.ContactsAppLabel.Name = "ContactsAppLabel";
            this.ContactsAppLabel.Size = new System.Drawing.Size(146, 25);
            this.ContactsAppLabel.TabIndex = 0;
            this.ContactsAppLabel.Text = "ContactsApp";
            // 
            // VersionLabel
            // 
            this.VersionLabel.AutoSize = true;
            this.VersionLabel.Location = new System.Drawing.Point(14, 34);
            this.VersionLabel.Name = "VersionLabel";
            this.VersionLabel.Size = new System.Drawing.Size(31, 13);
            this.VersionLabel.TabIndex = 1;
            this.VersionLabel.Text = "v 1.0";
            // 
            // AuthorLabel
            // 
            this.AuthorLabel.AutoSize = true;
            this.AuthorLabel.Location = new System.Drawing.Point(14, 75);
            this.AuthorLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.AuthorLabel.Name = "AuthorLabel";
            this.AuthorLabel.Size = new System.Drawing.Size(41, 13);
            this.AuthorLabel.TabIndex = 2;
            this.AuthorLabel.Text = "Author:";
            // 
            // EmailLabel
            // 
            this.EmailLabel.AutoSize = true;
            this.EmailLabel.Location = new System.Drawing.Point(14, 98);
            this.EmailLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.EmailLabel.Name = "EmailLabel";
            this.EmailLabel.Size = new System.Drawing.Size(38, 13);
            this.EmailLabel.TabIndex = 3;
            this.EmailLabel.Text = "E-mail:";
            // 
            // GithubLabel
            // 
            this.GithubLabel.AutoSize = true;
            this.GithubLabel.Location = new System.Drawing.Point(14, 121);
            this.GithubLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.GithubLabel.Name = "GithubLabel";
            this.GithubLabel.Size = new System.Drawing.Size(41, 13);
            this.GithubLabel.TabIndex = 4;
            this.GithubLabel.Text = "Github:";
            // 
            // AuthorLastNameFirstNameLabel
            // 
            this.AuthorLastNameFirstNameLabel.AutoSize = true;
            this.AuthorLastNameFirstNameLabel.Location = new System.Drawing.Point(117, 75);
            this.AuthorLastNameFirstNameLabel.Margin = new System.Windows.Forms.Padding(3, 20, 3, 0);
            this.AuthorLastNameFirstNameLabel.Name = "AuthorLastNameFirstNameLabel";
            this.AuthorLastNameFirstNameLabel.Size = new System.Drawing.Size(77, 13);
            this.AuthorLastNameFirstNameLabel.TabIndex = 5;
            this.AuthorLastNameFirstNameLabel.Text = "Anton Fedorov";
            // 
            // AuthorEmailLabel
            // 
            this.AuthorEmailLabel.AutoSize = true;
            this.AuthorEmailLabel.Location = new System.Drawing.Point(117, 98);
            this.AuthorEmailLabel.Margin = new System.Windows.Forms.Padding(3, 10, 3, 0);
            this.AuthorEmailLabel.Name = "AuthorEmailLabel";
            this.AuthorEmailLabel.Size = new System.Drawing.Size(146, 13);
            this.AuthorEmailLabel.TabIndex = 6;
            this.AuthorEmailLabel.Text = "antonfedorov312@gmail.com";
            // 
            // AuthorGithubLinkLabel
            // 
            this.AuthorGithubLinkLabel.AutoSize = true;
            this.AuthorGithubLinkLabel.Location = new System.Drawing.Point(117, 121);
            this.AuthorGithubLinkLabel.Name = "AuthorGithubLinkLabel";
            this.AuthorGithubLinkLabel.Size = new System.Drawing.Size(169, 13);
            this.AuthorGithubLinkLabel.TabIndex = 8;
            this.AuthorGithubLinkLabel.TabStop = true;
            this.AuthorGithubLinkLabel.Text = "https://github.com/antonfedorov1";
            this.AuthorGithubLinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.AuthorGithubLinkLabel_LinkClicked);
            // 
            // CopyrightTextBox
            // 
            this.CopyrightTextBox.Location = new System.Drawing.Point(12, 149);
            this.CopyrightTextBox.Margin = new System.Windows.Forms.Padding(3, 15, 3, 3);
            this.CopyrightTextBox.Multiline = true;
            this.CopyrightTextBox.Name = "CopyrightTextBox";
            this.CopyrightTextBox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.CopyrightTextBox.Size = new System.Drawing.Size(486, 155);
            this.CopyrightTextBox.TabIndex = 9;
            this.CopyrightTextBox.Text = resources.GetString("CopyrightTextBox.Text");
            this.CopyrightTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.CopyrightTextBox_KeyPress);
            // 
            // ImagesFromLabel
            // 
            this.ImagesFromLabel.AutoSize = true;
            this.ImagesFromLabel.Location = new System.Drawing.Point(14, 311);
            this.ImagesFromLabel.Name = "ImagesFromLabel";
            this.ImagesFromLabel.Size = new System.Drawing.Size(182, 13);
            this.ImagesFromLabel.TabIndex = 10;
            this.ImagesFromLabel.Text = "All used images are downloaded from";
            // 
            // Icons8LinkLabel
            // 
            this.Icons8LinkLabel.AutoSize = true;
            this.Icons8LinkLabel.Location = new System.Drawing.Point(193, 311);
            this.Icons8LinkLabel.Name = "Icons8LinkLabel";
            this.Icons8LinkLabel.Size = new System.Drawing.Size(61, 13);
            this.Icons8LinkLabel.TabIndex = 11;
            this.Icons8LinkLabel.TabStop = true;
            this.Icons8LinkLabel.Text = "icons8.com";
            this.Icons8LinkLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Icons8LinkLabel_LinkClicked);
            // 
            // ButtonContactAppPanel
            // 
            this.ButtonContactAppPanel.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ButtonContactAppPanel.Controls.Add(this.OKButton);
            this.ButtonContactAppPanel.Location = new System.Drawing.Point(0, 351);
            this.ButtonContactAppPanel.Name = "ButtonContactAppPanel";
            this.ButtonContactAppPanel.Size = new System.Drawing.Size(511, 45);
            this.ButtonContactAppPanel.TabIndex = 12;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(423, 11);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // AboutForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(510, 396);
            this.Controls.Add(this.ButtonContactAppPanel);
            this.Controls.Add(this.Icons8LinkLabel);
            this.Controls.Add(this.ImagesFromLabel);
            this.Controls.Add(this.CopyrightTextBox);
            this.Controls.Add(this.AuthorGithubLinkLabel);
            this.Controls.Add(this.AuthorEmailLabel);
            this.Controls.Add(this.AuthorLastNameFirstNameLabel);
            this.Controls.Add(this.GithubLabel);
            this.Controls.Add(this.EmailLabel);
            this.Controls.Add(this.AuthorLabel);
            this.Controls.Add(this.VersionLabel);
            this.Controls.Add(this.ContactsAppLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "AboutForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.ButtonContactAppPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ContactsAppLabel;
        private System.Windows.Forms.Label VersionLabel;
        private System.Windows.Forms.Label AuthorLabel;
        private System.Windows.Forms.Label EmailLabel;
        private System.Windows.Forms.Label GithubLabel;
        private System.Windows.Forms.Label AuthorLastNameFirstNameLabel;
        private System.Windows.Forms.Label AuthorEmailLabel;
        private System.Windows.Forms.LinkLabel AuthorGithubLinkLabel;
        private System.Windows.Forms.TextBox CopyrightTextBox;
        private System.Windows.Forms.Label ImagesFromLabel;
        private System.Windows.Forms.LinkLabel Icons8LinkLabel;
        private System.Windows.Forms.Panel ButtonContactAppPanel;
        private System.Windows.Forms.Button OKButton;
    }
}
namespace P5ENVEditor
{
    partial class AboutWindow
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
            appAboutNameText = new Label();
            appAboutVerText = new Label();
            appAboutGithubLink = new LinkLabel();
            okButton = new Button();
            appAboutAuthorText = new Label();
            SuspendLayout();
            // 
            // appAboutNameText
            // 
            appAboutNameText.AutoSize = true;
            appAboutNameText.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            appAboutNameText.Location = new Point(127, 20);
            appAboutNameText.Name = "appAboutNameText";
            appAboutNameText.Size = new Size(130, 25);
            appAboutNameText.TabIndex = 0;
            appAboutNameText.Text = "P5 ENV Editor";
            appAboutNameText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // appAboutVerText
            // 
            appAboutVerText.Font = new Font("Segoe UI", 10F);
            appAboutVerText.Location = new Point(127, 45);
            appAboutVerText.Name = "appAboutVerText";
            appAboutVerText.Size = new Size(130, 19);
            appAboutVerText.TabIndex = 1;
            appAboutVerText.Text = "v0.0.0";
            appAboutVerText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // appAboutGithubLink
            // 
            appAboutGithubLink.Font = new Font("Segoe UI", 10F);
            appAboutGithubLink.Location = new Point(127, 104);
            appAboutGithubLink.Name = "appAboutGithubLink";
            appAboutGithubLink.Size = new Size(130, 19);
            appAboutGithubLink.TabIndex = 2;
            appAboutGithubLink.TabStop = true;
            appAboutGithubLink.Text = "GitHub Repo";
            appAboutGithubLink.TextAlign = ContentAlignment.MiddleCenter;
            appAboutGithubLink.LinkClicked += appAboutGithubLink_LinkClicked;
            // 
            // okButton
            // 
            okButton.FlatStyle = FlatStyle.System;
            okButton.Location = new Point(154, 140);
            okButton.Name = "okButton";
            okButton.Size = new Size(75, 23);
            okButton.TabIndex = 3;
            okButton.Text = "OK";
            okButton.UseVisualStyleBackColor = true;
            okButton.Click += okButton_Click;
            // 
            // appAboutAuthorText
            // 
            appAboutAuthorText.Font = new Font("Segoe UI", 10F);
            appAboutAuthorText.Location = new Point(127, 74);
            appAboutAuthorText.Name = "appAboutAuthorText";
            appAboutAuthorText.Size = new Size(130, 19);
            appAboutAuthorText.TabIndex = 4;
            appAboutAuthorText.Text = "By ARandomGuy";
            appAboutAuthorText.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // AboutWindow
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(384, 176);
            Controls.Add(okButton);
            Controls.Add(appAboutGithubLink);
            Controls.Add(appAboutVerText);
            Controls.Add(appAboutAuthorText);
            Controls.Add(appAboutNameText);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "AboutWindow";
            ShowInTaskbar = false;
            StartPosition = FormStartPosition.CenterParent;
            Text = "About";
            Load += AboutWindow_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label appAboutNameText;
        private Label appAboutVerText;
        private LinkLabel appAboutGithubLink;
        private Button okButton;
        private Label appAboutAuthorText;
    }
}
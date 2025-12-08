namespace Yfitops.Forms
{
    partial class RegistrationForm
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
            textBoxUsername = new TextBox();
            textBoxPassword = new TextBox();
            usernameLabel = new Label();
            passwordLabel = new Label();
            labelTitle = new Label();
            comboBoxRole = new ComboBox();
            labelRole = new Label();
            buttonReg = new Button();
            SuspendLayout();
            // 
            // textBoxUsername
            // 
            textBoxUsername.Location = new Point(328, 174);
            textBoxUsername.Name = "textBoxUsername";
            textBoxUsername.Size = new Size(198, 23);
            textBoxUsername.TabIndex = 0;
            // 
            // textBoxPassword
            // 
            textBoxPassword.Location = new Point(328, 222);
            textBoxPassword.Name = "textBoxPassword";
            textBoxPassword.Size = new Size(198, 23);
            textBoxPassword.TabIndex = 1;
            // 
            // usernameLabel
            // 
            usernameLabel.AutoSize = true;
            usernameLabel.Location = new Point(242, 178);
            usernameLabel.Name = "usernameLabel";
            usernameLabel.Size = new Size(60, 15);
            usernameLabel.TabIndex = 2;
            usernameLabel.Text = "Username";
            // 
            // passwordLabel
            // 
            passwordLabel.AutoSize = true;
            passwordLabel.Location = new Point(245, 225);
            passwordLabel.Name = "passwordLabel";
            passwordLabel.Size = new Size(57, 15);
            passwordLabel.TabIndex = 3;
            passwordLabel.Text = "Password";
            // 
            // labelTitle
            // 
            labelTitle.AutoSize = true;
            labelTitle.Font = new Font("Segoe UI", 48F, FontStyle.Bold, GraphicsUnit.Point, 0);
            labelTitle.Location = new Point(211, 32);
            labelTitle.Name = "labelTitle";
            labelTitle.Size = new Size(403, 86);
            labelTitle.TabIndex = 4;
            labelTitle.Text = "Registration";
            // 
            // comboBoxRole
            // 
            comboBoxRole.AllowDrop = true;
            comboBoxRole.FormattingEnabled = true;
            comboBoxRole.Items.AddRange(new object[] { "User", "Musician" });
            comboBoxRole.Location = new Point(328, 266);
            comboBoxRole.Name = "comboBoxRole";
            comboBoxRole.Size = new Size(121, 23);
            comboBoxRole.TabIndex = 5;
            // 
            // labelRole
            // 
            labelRole.AutoSize = true;
            labelRole.Location = new Point(245, 269);
            labelRole.Name = "labelRole";
            labelRole.Size = new Size(30, 15);
            labelRole.TabIndex = 6;
            labelRole.Text = "Role";
            // 
            // buttonReg
            // 
            buttonReg.BackColor = Color.LightGoldenrodYellow;
            buttonReg.Cursor = Cursors.Hand;
            buttonReg.FlatAppearance.BorderColor = SystemColors.ActiveBorder;
            buttonReg.FlatAppearance.MouseDownBackColor = Color.Lime;
            buttonReg.FlatAppearance.MouseOverBackColor = Color.Lime;
            buttonReg.ForeColor = SystemColors.ActiveCaptionText;
            buttonReg.Location = new Point(374, 331);
            buttonReg.Name = "buttonReg";
            buttonReg.Size = new Size(104, 37);
            buttonReg.TabIndex = 7;
            buttonReg.Text = "Create account";
            buttonReg.UseVisualStyleBackColor = false;
            buttonReg.Click += buttonReg_Click;
            // 
            // RegistrationForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ButtonHighlight;
            ClientSize = new Size(800, 450);
            Controls.Add(buttonReg);
            Controls.Add(labelRole);
            Controls.Add(comboBoxRole);
            Controls.Add(labelTitle);
            Controls.Add(passwordLabel);
            Controls.Add(usernameLabel);
            Controls.Add(textBoxPassword);
            Controls.Add(textBoxUsername);
            Name = "RegistrationForm";
            Text = "RegistrationForm";
            Load += RegistrationForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBoxUsername;
        private TextBox textBoxPassword;
        private Label usernameLabel;
        private Label passwordLabel;
        private Label labelTitle;
        private ComboBox comboBoxRole;
        private Label labelRole;
        private Button buttonReg;
    }
}
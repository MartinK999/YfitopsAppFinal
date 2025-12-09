namespace Yfitops
{
    partial class LoginForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            login = new Button();
            nickname = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            password = new Label();
            label1 = new Label();
            linkLabel1 = new LinkLabel();
            buttonGuest = new Button();
            SuspendLayout();
            // 
            // login
            // 
            login.Location = new Point(257, 293);
            login.Margin = new Padding(3, 2, 3, 2);
            login.Name = "login";
            login.Size = new Size(199, 45);
            login.TabIndex = 0;
            login.Text = "Login";
            login.UseVisualStyleBackColor = true;
            login.Click += login_Click;
            // 
            // nickname
            // 
            nickname.AutoSize = true;
            nickname.Location = new Point(154, 191);
            nickname.Name = "nickname";
            nickname.RightToLeft = RightToLeft.Yes;
            nickname.Size = new Size(61, 15);
            nickname.TabIndex = 1;
            nickname.Text = "Nickname";
            nickname.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(234, 186);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(262, 23);
            textBox1.TabIndex = 2;
            textBox1.Text = "Jozo";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(234, 220);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(262, 23);
            textBox2.TabIndex = 4;
            textBox2.Text = "jozo";
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(154, 225);
            password.Name = "password";
            password.Size = new Size(57, 15);
            password.TabIndex = 3;
            password.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(211, 14);
            label1.Name = "label1";
            label1.Size = new Size(281, 65);
            label1.TabIndex = 5;
            label1.Text = "YfitopsApp";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(285, 260);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(148, 15);
            linkLabel1.TabIndex = 7;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "No account? Register here!";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // buttonGuest
            // 
            buttonGuest.Location = new Point(295, 343);
            buttonGuest.Name = "buttonGuest";
            buttonGuest.Size = new Size(135, 23);
            buttonGuest.TabIndex = 8;
            buttonGuest.Text = "Continue as guest";
            buttonGuest.UseVisualStyleBackColor = true;
            buttonGuest.Click += buttonGuest_Click;
            // 
            // LoginForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightGreen;
            ClientSize = new Size(694, 421);
            Controls.Add(buttonGuest);
            Controls.Add(linkLabel1);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(password);
            Controls.Add(textBox1);
            Controls.Add(nickname);
            Controls.Add(login);
            Margin = new Padding(3, 2, 3, 2);
            Name = "LoginForm";
            Text = "LoginForm";
            Load += LoginForm_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button login;
        private Label nickname;
        private TextBox textBox1;
        private TextBox textBox2;
        private Label password;
        private Label label1;
        private LinkLabel linkLabel1;
        private Button buttonGuest;
    }
}

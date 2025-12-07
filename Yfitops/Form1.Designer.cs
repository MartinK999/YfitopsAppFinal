namespace Yfitops
{
    partial class Form1
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
            label2 = new Label();
            SuspendLayout();
            // 
            // login
            // 
            login.Location = new Point(268, 375);
            login.Name = "login";
            login.Size = new Size(227, 34);
            login.TabIndex = 0;
            login.Text = "Login";
            login.UseVisualStyleBackColor = true;
            login.MouseHover += button1_Hover;
            // 
            // nickname
            // 
            nickname.AutoSize = true;
            nickname.Location = new Point(176, 255);
            nickname.Name = "nickname";
            nickname.RightToLeft = RightToLeft.Yes;
            nickname.Size = new Size(75, 20);
            nickname.TabIndex = 1;
            nickname.Text = "Nickname";
            nickname.TextAlign = ContentAlignment.TopCenter;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(268, 248);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(299, 27);
            textBox1.TabIndex = 2;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(268, 293);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(299, 27);
            textBox2.TabIndex = 4;
            // 
            // password
            // 
            password.AutoSize = true;
            password.Location = new Point(176, 300);
            password.Name = "password";
            password.Size = new Size(70, 20);
            password.TabIndex = 3;
            password.Text = "Password";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 36F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(241, 19);
            label1.Name = "label1";
            label1.Size = new Size(349, 81);
            label1.TabIndex = 5;
            label1.Text = "YfitopsApp";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(364, 112);
            label2.Name = "label2";
            label2.Size = new Size(50, 20);
            label2.TabIndex = 6;
            label2.Text = "Log in";
            label2.Click += label2_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(textBox2);
            Controls.Add(password);
            Controls.Add(textBox1);
            Controls.Add(nickname);
            Controls.Add(login);
            Name = "Form1";
            Text = "Form1";
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
        private Label label2;
    }
}

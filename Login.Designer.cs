namespace Y_S_System
{
    partial class Login
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
            tbUsername = new TextBox();
            pictureBox1 = new PictureBox();
            tbPassword = new TextBox();
            label1 = new Label();
            label2 = new Label();
            btnLogin = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tbUsername
            // 
            tbUsername.Anchor = AnchorStyles.Top;
            tbUsername.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbUsername.ForeColor = SystemColors.WindowText;
            tbUsername.Location = new Point(526, 496);
            tbUsername.Name = "tbUsername";
            tbUsername.Size = new Size(234, 33);
            tbUsername.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.Y_S_Logo1;
            pictureBox1.Location = new Point(350, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(585, 405);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Top;
            tbPassword.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(528, 554);
            tbPassword.Name = "tbPassword";
            tbPassword.Size = new Size(234, 33);
            tbPassword.TabIndex = 2;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(528, 478);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 3;
            label1.Text = "Username";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(528, 536);
            label2.Name = "label2";
            label2.Size = new Size(65, 15);
            label2.TabIndex = 4;
            label2.Text = "Password";
            // 
            // btnLogin
            // 
            btnLogin.Anchor = AnchorStyles.Top;
            btnLogin.BackColor = Color.FromArgb(110, 172, 218);
            btnLogin.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnLogin.BorderColor = Color.Transparent;
            btnLogin.BorderColor1 = Color.Transparent;
            btnLogin.BorderColor2 = Color.Transparent;
            btnLogin.BorderRadius = 10;
            btnLogin.BorderRadius1 = 10;
            btnLogin.BorderRadius2 = 10;
            btnLogin.BorderSize = 0;
            btnLogin.BorderSize1 = 0;
            btnLogin.BorderSize2 = 0;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Popup;
            btnLogin.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnLogin.ForeColor = Color.Black;
            btnLogin.Location = new Point(575, 611);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(133, 34);
            btnLogin.TabIndex = 6;
            btnLogin.Text = "Login";
            btnLogin.TextColor = Color.Black;
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            BackgroundImage = Properties.Resources.Y_S_BACKGROUND;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1264, 681);
            Controls.Add(btnLogin);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(tbPassword);
            Controls.Add(pictureBox1);
            Controls.Add(tbUsername);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Name = "Login";
            Text = "Login";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tbUsername;
        private PictureBox pictureBox1;
        private TextBox tbPassword;
        private Label label1;
        private Label label2;
        private CustomControls.RJControls.RJButton btnLogin;
    }
}
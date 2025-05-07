namespace Y_S_System
{
    partial class Confirmation
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
            pictureBox1 = new PictureBox();
            tbPassword = new TextBox();
            Invalid = new Label();
            btnConfirm = new CustomControls.RJControls.RJButton();
            label1 = new Label();
            btnBack = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)btnBack).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.Top;
            pictureBox1.Image = Properties.Resources.Y_S_Logo1;
            pictureBox1.Location = new Point(84, 31);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(320, 205);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // tbPassword
            // 
            tbPassword.Anchor = AnchorStyles.Left;
            tbPassword.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbPassword.Location = new Point(133, 278);
            tbPassword.Name = "tbPassword";
            tbPassword.PasswordChar = '•';
            tbPassword.Size = new Size(218, 29);
            tbPassword.TabIndex = 1;
            tbPassword.KeyDown += tbPassword_KeyDown;
            // 
            // Invalid
            // 
            Invalid.Anchor = AnchorStyles.Top;
            Invalid.AutoSize = true;
            Invalid.BackColor = Color.Transparent;
            Invalid.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Invalid.ForeColor = Color.Red;
            Invalid.Location = new Point(185, 310);
            Invalid.Name = "Invalid";
            Invalid.Size = new Size(109, 16);
            Invalid.TabIndex = 10;
            Invalid.Text = "Invalid Password";
            Invalid.Visible = false;
            // 
            // btnConfirm
            // 
            btnConfirm.Anchor = AnchorStyles.Top;
            btnConfirm.BackColor = Color.FromArgb(110, 172, 218);
            btnConfirm.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnConfirm.BorderColor = Color.Transparent;
            btnConfirm.BorderColor1 = Color.Transparent;
            btnConfirm.BorderColor2 = Color.Transparent;
            btnConfirm.BorderRadius = 10;
            btnConfirm.BorderRadius1 = 10;
            btnConfirm.BorderRadius2 = 10;
            btnConfirm.BorderSize = 0;
            btnConfirm.BorderSize1 = 0;
            btnConfirm.BorderSize2 = 0;
            btnConfirm.FlatAppearance.BorderSize = 0;
            btnConfirm.FlatStyle = FlatStyle.Popup;
            btnConfirm.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnConfirm.ForeColor = Color.Black;
            btnConfirm.Location = new Point(171, 329);
            btnConfirm.Name = "btnConfirm";
            btnConfirm.Size = new Size(133, 34);
            btnConfirm.TabIndex = 9;
            btnConfirm.Text = "Confirm";
            btnConfirm.TextColor = Color.Black;
            btnConfirm.UseVisualStyleBackColor = false;
            btnConfirm.Click += btnConfirm_Click;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Top;
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(83, 248);
            label1.Name = "label1";
            label1.Size = new Size(324, 16);
            label1.TabIndex = 11;
            label1.Text = "Please enter your Admin PASSWORD for confimation";
            // 
            // btnBack
            // 
            btnBack.Cursor = Cursors.Hand;
            btnBack.Image = Properties.Resources.icons8_back_button_100;
            btnBack.Location = new Point(12, 12);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(40, 38);
            btnBack.SizeMode = PictureBoxSizeMode.Zoom;
            btnBack.TabIndex = 12;
            btnBack.TabStop = false;
            btnBack.Click += btnBack_Click;
            // 
            // Confirmation
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 60);
            ClientSize = new Size(484, 395);
            Controls.Add(btnBack);
            Controls.Add(label1);
            Controls.Add(Invalid);
            Controls.Add(btnConfirm);
            Controls.Add(tbPassword);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Confirmation";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Confirmation";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)btnBack).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox1;
        private TextBox tbPassword;
        private Label Invalid;
        private CustomControls.RJControls.RJButton btnConfirm;
        private Label label1;
        private PictureBox btnBack;
    }
}
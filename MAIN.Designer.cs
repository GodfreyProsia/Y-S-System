namespace Y_S_System
{
    partial class MAIN
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MAIN));
            MainPanel = new Panel();
            SuspendLayout();
            // 
            // MainPanel
            // 
            MainPanel.BackColor = Color.White;
            MainPanel.Dock = DockStyle.Fill;
            MainPanel.Location = new Point(0, 0);
            MainPanel.Name = "MainPanel";
            MainPanel.Size = new Size(1264, 681);
            MainPanel.TabIndex = 0;
            // 
            // MAIN
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(MainPanel);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "MAIN";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Y&S System";
            WindowState = FormWindowState.Maximized;
            Load += MAIN_Load;
            ResumeLayout(false);
        }

        #endregion

        private Panel MainPanel;
    }
}

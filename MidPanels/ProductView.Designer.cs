namespace Y_S_System.MidPanels
{
    partial class ProductView
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
            productPanel = new FlowLayoutPanel();
            label2 = new Label();
            tbtSearch = new TextBox();
            SuspendLayout();
            // 
            // productPanel
            // 
            productPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            productPanel.AutoScroll = true;
            productPanel.Location = new Point(12, 71);
            productPanel.Name = "productPanel";
            productPanel.Size = new Size(645, 598);
            productPanel.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.Transparent;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 30);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 10;
            label2.Text = "Search";
            // 
            // tbtSearch
            // 
            tbtSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbtSearch.Location = new Point(86, 27);
            tbtSearch.Name = "tbtSearch";
            tbtSearch.Size = new Size(197, 27);
            tbtSearch.TabIndex = 9;
            tbtSearch.TextChanged += tbtSearch_TextChanged;
            // 
            // ProductView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
            Controls.Add(label2);
            Controls.Add(tbtSearch);
            Controls.Add(productPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductView";
            Text = "ProductView";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label2;
        private TextBox tbtSearch;
        public FlowLayoutPanel productPanel;
    }
}
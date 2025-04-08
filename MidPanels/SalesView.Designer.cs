namespace Y_S_System.MidPanels
{
    partial class SalesView
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
            label2 = new Label();
            tbtSearch = new TextBox();
            dgvSales = new DataGridView();
            cartesianChart1 = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 22);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 13;
            label2.Text = "Search";
            // 
            // tbtSearch
            // 
            tbtSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbtSearch.Location = new Point(86, 19);
            tbtSearch.Name = "tbtSearch";
            tbtSearch.Size = new Size(197, 27);
            tbtSearch.TabIndex = 12;
            tbtSearch.TextChanged += tbtSearch_TextChanged_1;
            // 
            // dgvSales
            // 
            dgvSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSales.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.GridColor = Color.FromArgb(2, 21, 38);
            dgvSales.Location = new Point(12, 351);
            dgvSales.Name = "dgvSales";
            dgvSales.Size = new Size(645, 318);
            dgvSales.TabIndex = 14;
            dgvSales.CellContentClick += dgvSales_CellContentClick;
            // 
            // cartesianChart1
            // 
            cartesianChart1.Font = new Font("Roboto", 9F);
            cartesianChart1.Location = new Point(12, 49);
            cartesianChart1.MatchAxesScreenDataRatio = false;
            cartesianChart1.Name = "cartesianChart1";
            cartesianChart1.Size = new Size(645, 286);
            cartesianChart1.TabIndex = 15;
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
            Controls.Add(cartesianChart1);
            Controls.Add(dgvSales);
            Controls.Add(label2);
            Controls.Add(tbtSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalesView";
            Text = "SalesView";
            ((System.ComponentModel.ISupportInitialize)dgvSales).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label2;
        private TextBox tbtSearch;
        private DataGridView dgvSales;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart cartesianChart1;
    }
}
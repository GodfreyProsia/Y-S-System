namespace Y_S_System.MidPanels
{
    partial class FinnanceView
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
            dgvFinnance = new DataGridView();
            Date = new DataGridViewTextBoxColumn();
            ProductBarcode = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            ProductPrice = new DataGridViewTextBoxColumn();
            TotalSold = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            lblProdName = new Label();
            tbTotalSales = new TextBox();
            date1 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            date2 = new DateTimePicker();
            tbSearch = new TextBox();
            label6 = new Label();
            salesChart = new LiveChartsCore.SkiaSharpView.WinForms.CartesianChart();
            cbDateRange = new ComboBox();
            cbUnitsOrSales = new ComboBox();
            label1 = new Label();
            label5 = new Label();
            cbSortMode = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)dgvFinnance).BeginInit();
            SuspendLayout();
            // 
            // dgvFinnance
            // 
            dgvFinnance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFinnance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinnance.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvFinnance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinnance.Columns.AddRange(new DataGridViewColumn[] { Date, ProductBarcode, ProductName, ProductPrice, TotalSold, Total });
            dgvFinnance.GridColor = Color.FromArgb(2, 21, 38);
            dgvFinnance.Location = new Point(12, 425);
            dgvFinnance.Name = "dgvFinnance";
            dgvFinnance.ReadOnly = true;
            dgvFinnance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinnance.Size = new Size(645, 244);
            dgvFinnance.TabIndex = 0;
            dgvFinnance.CellClick += dgvFinnance_CellClick;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // ProductBarcode
            // 
            ProductBarcode.HeaderText = "Barcode";
            ProductBarcode.Name = "ProductBarcode";
            ProductBarcode.ReadOnly = true;
            // 
            // ProductName
            // 
            ProductName.HeaderText = "Product";
            ProductName.Name = "ProductName";
            ProductName.ReadOnly = true;
            // 
            // ProductPrice
            // 
            ProductPrice.HeaderText = "Price";
            ProductPrice.Name = "ProductPrice";
            ProductPrice.ReadOnly = true;
            // 
            // TotalSold
            // 
            TotalSold.HeaderText = "Sold";
            TotalSold.Name = "TotalSold";
            TotalSold.ReadOnly = true;
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // lblProdName
            // 
            lblProdName.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(12, 364);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(88, 20);
            lblProdName.TabIndex = 34;
            lblProdName.Text = "Total Sales";
            // 
            // tbTotalSales
            // 
            tbTotalSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbTotalSales.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbTotalSales.Location = new Point(107, 361);
            tbTotalSales.Name = "tbTotalSales";
            tbTotalSales.Size = new Size(279, 26);
            tbTotalSales.TabIndex = 37;
            // 
            // date1
            // 
            date1.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            date1.CustomFormat = "MMM, yyyy";
            date1.Format = DateTimePickerFormat.Custom;
            date1.Location = new Point(171, 12);
            date1.Name = "date1";
            date1.Size = new Size(90, 23);
            date1.TabIndex = 38;
            date1.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            date1.ValueChanged += date1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(89, 25);
            label2.TabIndex = 39;
            label2.Text = "Finance";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(119, 14);
            label3.Name = "label3";
            label3.Size = new Size(46, 20);
            label3.TabIndex = 40;
            label3.Text = "From";
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(273, 14);
            label4.Name = "label4";
            label4.Size = new Size(27, 20);
            label4.TabIndex = 42;
            label4.Text = "To";
            // 
            // date2
            // 
            date2.CalendarFont = new Font("Microsoft Sans Serif", 9F);
            date2.CustomFormat = "MMM, yyyy";
            date2.Format = DateTimePickerFormat.Custom;
            date2.Location = new Point(306, 12);
            date2.Name = "date2";
            date2.Size = new Size(91, 23);
            date2.TabIndex = 41;
            date2.ValueChanged += date2_ValueChanged;
            // 
            // tbSearch
            // 
            tbSearch.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            tbSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.Location = new Point(79, 393);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(307, 26);
            tbSearch.TabIndex = 45;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            label6.AutoEllipsis = true;
            label6.AutoSize = true;
            label6.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(13, 393);
            label6.Name = "label6";
            label6.Size = new Size(60, 20);
            label6.TabIndex = 44;
            label6.Text = "Search";
            // 
            // salesChart
            // 
            salesChart.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            salesChart.Location = new Point(13, 51);
            salesChart.MatchAxesScreenDataRatio = false;
            salesChart.Name = "salesChart";
            salesChart.Size = new Size(644, 294);
            salesChart.TabIndex = 46;
            // 
            // cbDateRange
            // 
            cbDateRange.Font = new Font("Microsoft Sans Serif", 9F);
            cbDateRange.FormattingEnabled = true;
            cbDateRange.Items.AddRange(new object[] { "Weekly", "Monthly", "Yearly" });
            cbDateRange.Location = new Point(412, 12);
            cbDateRange.Name = "cbDateRange";
            cbDateRange.Size = new Size(78, 23);
            cbDateRange.TabIndex = 47;
            cbDateRange.Text = "Weekly";
            cbDateRange.SelectedIndexChanged += cbDateRange_SelectedIndexChanged;
            // 
            // cbUnitsOrSales
            // 
            cbUnitsOrSales.Font = new Font("Microsoft Sans Serif", 9F);
            cbUnitsOrSales.FormattingEnabled = true;
            cbUnitsOrSales.Items.AddRange(new object[] { "Units", "Sales" });
            cbUnitsOrSales.Location = new Point(572, 11);
            cbUnitsOrSales.Name = "cbUnitsOrSales";
            cbUnitsOrSales.Size = new Size(85, 23);
            cbUnitsOrSales.TabIndex = 48;
            cbUnitsOrSales.Text = "Sales";
            cbUnitsOrSales.SelectedIndexChanged += cbUnitsOrSales_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(539, 11);
            label1.Name = "label1";
            label1.Size = new Size(27, 20);
            label1.TabIndex = 49;
            label1.Text = "By";
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(403, 396);
            label5.Name = "label5";
            label5.Size = new Size(27, 20);
            label5.TabIndex = 51;
            label5.Text = "By";
            // 
            // cbSortMode
            // 
            cbSortMode.Font = new Font("Microsoft Sans Serif", 9F);
            cbSortMode.FormattingEnabled = true;
            cbSortMode.Items.AddRange(new object[] { "Product", "Day" });
            cbSortMode.Location = new Point(436, 396);
            cbSortMode.Name = "cbSortMode";
            cbSortMode.Size = new Size(85, 23);
            cbSortMode.TabIndex = 50;
            cbSortMode.Text = "Product";
            cbSortMode.SelectedIndexChanged += cbSortMode_SelectedIndexChanged;
            // 
            // FinnanceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
            Controls.Add(label5);
            Controls.Add(cbSortMode);
            Controls.Add(label1);
            Controls.Add(cbUnitsOrSales);
            Controls.Add(cbDateRange);
            Controls.Add(salesChart);
            Controls.Add(tbSearch);
            Controls.Add(label6);
            Controls.Add(label4);
            Controls.Add(date2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(date1);
            Controls.Add(tbTotalSales);
            Controls.Add(lblProdName);
            Controls.Add(dgvFinnance);
            FormBorderStyle = FormBorderStyle.None;
            Name = "FinnanceView";
            Text = "FinnanceView";
            ((System.ComponentModel.ISupportInitialize)dgvFinnance).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvFinnance;
        private Label lblProdName;
        private TextBox tbTotalSales;
        private DateTimePicker date1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker date2;
        private TextBox tbSearch;
        private Label label6;
        private LiveChartsCore.SkiaSharpView.WinForms.CartesianChart salesChart;
        private ComboBox cbDateRange;
        private ComboBox comboBox1;
        private ComboBox cbUnitsOrSales;
        private Label label1;
        private Label label5;
        private ComboBox cbSortMode;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn ProductBarcode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductPrice;
        private DataGridViewTextBoxColumn TotalSold;
        private DataGridViewTextBoxColumn Total;
    }
}
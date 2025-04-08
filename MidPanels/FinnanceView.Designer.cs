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
            ProductBarcode = new DataGridViewTextBoxColumn();
            ProductName = new DataGridViewTextBoxColumn();
            ProductPrice = new DataGridViewTextBoxColumn();
            TotalSold = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            tbNoSales = new TextBox();
            lblProdName = new Label();
            tbTotalSales = new TextBox();
            label1 = new Label();
            date1 = new DateTimePicker();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            date2 = new DateTimePicker();
            label5 = new Label();
            tbSearch = new TextBox();
            label6 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvFinnance).BeginInit();
            SuspendLayout();
            // 
            // dgvFinnance
            // 
            dgvFinnance.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvFinnance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvFinnance.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvFinnance.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvFinnance.Columns.AddRange(new DataGridViewColumn[] { ProductBarcode, ProductName, ProductPrice, TotalSold, Total });
            dgvFinnance.GridColor = Color.FromArgb(2, 21, 38);
            dgvFinnance.Location = new Point(12, 242);
            dgvFinnance.Name = "dgvFinnance";
            dgvFinnance.ReadOnly = true;
            dgvFinnance.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvFinnance.Size = new Size(645, 427);
            dgvFinnance.TabIndex = 0;
            dgvFinnance.CellClick += dgvFinnance_CellClick;
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
            // tbNoSales
            // 
            tbNoSales.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbNoSales.Location = new Point(145, 103);
            tbNoSales.Name = "tbNoSales";
            tbNoSales.Size = new Size(126, 27);
            tbNoSales.TabIndex = 35;
            // 
            // lblProdName
            // 
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(50, 139);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(89, 19);
            lblProdName.TabIndex = 34;
            lblProdName.Text = "Total Sales";
            // 
            // tbTotalSales
            // 
            tbTotalSales.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbTotalSales.Location = new Point(145, 136);
            tbTotalSales.Name = "tbTotalSales";
            tbTotalSales.Size = new Size(307, 27);
            tbTotalSales.TabIndex = 37;
            // 
            // label1
            // 
            label1.AutoEllipsis = true;
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(50, 106);
            label1.Name = "label1";
            label1.Size = new Size(90, 19);
            label1.TabIndex = 36;
            label1.Text = "No of Sales";
            // 
            // date1
            // 
            date1.Location = new Point(50, 65);
            date1.Name = "date1";
            date1.Size = new Size(200, 23);
            date1.TabIndex = 38;
            date1.Value = new DateTime(2024, 1, 1, 0, 0, 0, 0);
            date1.ValueChanged += date1_ValueChanged;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 9);
            label2.Name = "label2";
            label2.Size = new Size(99, 25);
            label2.TabIndex = 39;
            label2.Text = "Finnance";
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(50, 43);
            label3.Name = "label3";
            label3.Size = new Size(47, 19);
            label3.TabIndex = 40;
            label3.Text = "From";
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(276, 43);
            label4.Name = "label4";
            label4.Size = new Size(28, 19);
            label4.TabIndex = 42;
            label4.Text = "To";
            // 
            // date2
            // 
            date2.Location = new Point(276, 65);
            date2.Name = "date2";
            date2.Size = new Size(200, 23);
            date2.TabIndex = 41;
            date2.ValueChanged += date2_ValueChanged;
            // 
            // label5
            // 
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(7, 174);
            label5.Name = "label5";
            label5.Size = new Size(64, 25);
            label5.TabIndex = 43;
            label5.Text = "Sales";
            // 
            // tbSearch
            // 
            tbSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbSearch.Location = new Point(77, 209);
            tbSearch.Name = "tbSearch";
            tbSearch.Size = new Size(307, 27);
            tbSearch.TabIndex = 45;
            tbSearch.TextChanged += tbSearch_TextChanged;
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.AutoSize = true;
            label6.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(12, 212);
            label6.Name = "label6";
            label6.Size = new Size(59, 19);
            label6.TabIndex = 44;
            label6.Text = "Search";
            // 
            // FinnanceView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
            Controls.Add(tbSearch);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(date2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(date1);
            Controls.Add(tbTotalSales);
            Controls.Add(label1);
            Controls.Add(tbNoSales);
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
        private TextBox tbNoSales;
        private Label lblProdName;
        private TextBox tbTotalSales;
        private Label label1;
        private DateTimePicker date1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker date2;
        private Label label5;
        private TextBox tbSearch;
        private Label label6;
        private DataGridViewTextBoxColumn ProductBarcode;
        private DataGridViewTextBoxColumn ProductName;
        private DataGridViewTextBoxColumn ProductPrice;
        private DataGridViewTextBoxColumn TotalSold;
        private DataGridViewTextBoxColumn Total;
    }
}
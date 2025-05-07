namespace Y_S_System.DetailPanels
{
    partial class FinnanceDetails
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
            lblBarcode = new Label();
            lblTotal = new Label();
            lblStock = new Label();
            lblPrice = new Label();
            lblProdName = new Label();
            pbProdPic = new PictureBox();
            dgvSale = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            SoldDate = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            OrderID = new DataGridViewTextBoxColumn();
            ViewLabel = new Label();
            lblSold = new Label();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).BeginInit();
            SuspendLayout();
            // 
            // lblBarcode
            // 
            lblBarcode.Anchor = AnchorStyles.Top;
            lblBarcode.AutoSize = true;
            lblBarcode.BackColor = Color.FromArgb(2, 21, 38);
            lblBarcode.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBarcode.ForeColor = Color.White;
            lblBarcode.Location = new Point(171, 143);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(69, 20);
            lblBarcode.TabIndex = 46;
            lblBarcode.Text = "Barcode";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoEllipsis = true;
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.FromArgb(2, 21, 38);
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(11, 598);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(44, 20);
            lblTotal.TabIndex = 44;
            lblTotal.Text = "Total";
            // 
            // lblStock
            // 
            lblStock.Anchor = AnchorStyles.Top;
            lblStock.AutoSize = true;
            lblStock.BackColor = Color.FromArgb(2, 21, 38);
            lblStock.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblStock.ForeColor = Color.White;
            lblStock.Location = new Point(171, 176);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(50, 20);
            lblStock.TabIndex = 43;
            lblStock.Text = "Stock";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top;
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.FromArgb(2, 21, 38);
            lblPrice.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(171, 116);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 16);
            lblPrice.TabIndex = 42;
            lblPrice.Text = "Price";
            // 
            // lblProdName
            // 
            lblProdName.Anchor = AnchorStyles.Top;
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.BackColor = Color.FromArgb(2, 21, 38);
            lblProdName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(171, 86);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(55, 20);
            lblProdName.TabIndex = 41;
            lblProdName.Text = "Name:";
            // 
            // pbProdPic
            // 
            pbProdPic.Image = Properties.Resources.TempProdPic;
            pbProdPic.Location = new Point(15, 75);
            pbProdPic.Name = "pbProdPic";
            pbProdPic.Size = new Size(150, 150);
            pbProdPic.SizeMode = PictureBoxSizeMode.Zoom;
            pbProdPic.TabIndex = 40;
            pbProdPic.TabStop = false;
            // 
            // dgvSale
            // 
            dgvSale.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvSale.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSale.Columns.AddRange(new DataGridViewColumn[] { Product, SoldDate, Amount, Price, Total, OrderID });
            dgvSale.GridColor = Color.FromArgb(2, 21, 38);
            dgvSale.Location = new Point(11, 239);
            dgvSale.Name = "dgvSale";
            dgvSale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSale.Size = new Size(367, 314);
            dgvSale.TabIndex = 39;
            dgvSale.CellClick += dgvSale_CellClick;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.Name = "Product";
            Product.Width = 74;
            // 
            // SoldDate
            // 
            SoldDate.HeaderText = "Date";
            SoldDate.Name = "SoldDate";
            SoldDate.Width = 56;
            // 
            // Amount
            // 
            Amount.HeaderText = "Amount";
            Amount.Name = "Amount";
            Amount.Width = 76;
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            Price.Width = 58;
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.Width = 58;
            // 
            // OrderID
            // 
            OrderID.HeaderText = "OrderID";
            OrderID.Name = "OrderID";
            OrderID.Width = 73;
            // 
            // ViewLabel
            // 
            ViewLabel.AutoSize = true;
            ViewLabel.BackColor = Color.FromArgb(2, 21, 38);
            ViewLabel.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ViewLabel.ForeColor = Color.White;
            ViewLabel.Location = new Point(11, 30);
            ViewLabel.Name = "ViewLabel";
            ViewLabel.Size = new Size(288, 39);
            ViewLabel.TabIndex = 38;
            ViewLabel.Text = "Product Statistics";
            // 
            // lblSold
            // 
            lblSold.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblSold.AutoSize = true;
            lblSold.BackColor = Color.FromArgb(2, 21, 38);
            lblSold.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSold.ForeColor = Color.White;
            lblSold.Location = new Point(11, 568);
            lblSold.Name = "lblSold";
            lblSold.Size = new Size(121, 20);
            lblSold.TabIndex = 47;
            lblSold.Text = "Total Units Sold";
            // 
            // FinnanceDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(389, 681);
            Controls.Add(lblSold);
            Controls.Add(lblBarcode);
            Controls.Add(lblTotal);
            Controls.Add(lblStock);
            Controls.Add(lblPrice);
            Controls.Add(lblProdName);
            Controls.Add(pbProdPic);
            Controls.Add(dgvSale);
            Controls.Add(ViewLabel);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FinnanceDetails";
            Text = "FinnanceDetails";
            ((System.ComponentModel.ISupportInitialize)pbProdPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBarcode;
        private Label lblTotal;
        private Label lblStock;
        private Label lblPrice;
        private Label lblProdName;
        private PictureBox pbProdPic;
        private DataGridView dgvSale;
        private Label ViewLabel;
        private Label lblSold;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn SoldDate;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn Total;
    }
}
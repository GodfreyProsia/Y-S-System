namespace Y_S_System.DetailPanels
{
    partial class FinanceDetails
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
            lblAmount = new Label();
            lblPrice = new Label();
            lblProdName = new Label();
            pbProdPic = new PictureBox();
            dgvSale = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            label1 = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).BeginInit();
            SuspendLayout();
            // 
            // lblBarcode
            // 
            lblBarcode.Anchor = AnchorStyles.Top;
            lblBarcode.AutoSize = true;
            lblBarcode.BackColor = Color.FromArgb(2, 21, 38);
            lblBarcode.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBarcode.ForeColor = Color.White;
            lblBarcode.Location = new Point(171, 143);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(68, 19);
            lblBarcode.TabIndex = 46;
            lblBarcode.Text = "Barcode";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lblTotal.AutoEllipsis = true;
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.FromArgb(2, 21, 38);
            lblTotal.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(11, 598);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 19);
            lblTotal.TabIndex = 44;
            lblTotal.Text = "Total";
            // 
            // lblAmount
            // 
            lblAmount.Anchor = AnchorStyles.Top;
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.FromArgb(2, 21, 38);
            lblAmount.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.White;
            lblAmount.Location = new Point(171, 176);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(65, 19);
            lblAmount.TabIndex = 43;
            lblAmount.Text = "Amount";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top;
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.FromArgb(2, 21, 38);
            lblPrice.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(171, 116);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(37, 15);
            lblPrice.TabIndex = 42;
            lblPrice.Text = "Price";
            // 
            // lblProdName
            // 
            lblProdName.Anchor = AnchorStyles.Top;
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.BackColor = Color.FromArgb(2, 21, 38);
            lblProdName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(171, 86);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(55, 19);
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
            dgvSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSale.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSale.Columns.AddRange(new DataGridViewColumn[] { Product, Amount, Price });
            dgvSale.GridColor = Color.FromArgb(2, 21, 38);
            dgvSale.Location = new Point(11, 239);
            dgvSale.Name = "dgvSale";
            dgvSale.Size = new Size(367, 314);
            dgvSale.TabIndex = 39;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.Name = "Product";
            // 
            // Amount
            // 
            Amount.HeaderText = "Amount";
            Amount.Name = "Amount";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.FromArgb(2, 21, 38);
            label1.Font = new Font("Lato", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 30);
            label1.Name = "label1";
            label1.Size = new Size(289, 42);
            label1.TabIndex = 38;
            label1.Text = "Product Statistics";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(2, 21, 38);
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(11, 568);
            label2.Name = "label2";
            label2.Size = new Size(123, 19);
            label2.TabIndex = 47;
            label2.Text = "Total Units Sold";
            // 
            // FinanceDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(389, 681);
            Controls.Add(label2);
            Controls.Add(lblBarcode);
            Controls.Add(lblTotal);
            Controls.Add(lblAmount);
            Controls.Add(lblPrice);
            Controls.Add(lblProdName);
            Controls.Add(pbProdPic);
            Controls.Add(dgvSale);
            Controls.Add(label1);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Name = "FinanceDetails";
            Text = "FinnanceDetails";
            ((System.ComponentModel.ISupportInitialize)pbProdPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblBarcode;
        private Label lblTotal;
        private Label lblAmount;
        private Label lblPrice;
        private Label lblProdName;
        private PictureBox pbProdPic;
        private DataGridView dgvSale;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Price;
        private Label label1;
        private Label label2;
    }
}
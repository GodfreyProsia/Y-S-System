﻿namespace Y_S_System.DetailPanels
{
    partial class SaleDetails
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
            lblChange = new Label();
            lblBarcode = new Label();
            lblCash = new Label();
            lblTotal = new Label();
            lblAmount = new Label();
            lblPrice = new Label();
            lblProdName = new Label();
            pbProdPic = new PictureBox();
            dgvSale = new DataGridView();
            Product = new DataGridViewTextBoxColumn();
            Price = new DataGridViewTextBoxColumn();
            Amount = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Barcode = new DataGridViewTextBoxColumn();
            label1 = new Label();
            lblOCode = new Label();
            btnDeleteProd = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).BeginInit();
            SuspendLayout();
            // 
            // lblChange
            // 
            lblChange.Anchor = AnchorStyles.Bottom;
            lblChange.AutoSize = true;
            lblChange.BackColor = Color.Transparent;
            lblChange.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblChange.ForeColor = Color.White;
            lblChange.Location = new Point(11, 593);
            lblChange.Name = "lblChange";
            lblChange.Size = new Size(65, 20);
            lblChange.TabIndex = 36;
            lblChange.Text = "Change";
            // 
            // lblBarcode
            // 
            lblBarcode.Anchor = AnchorStyles.Top;
            lblBarcode.AutoSize = true;
            lblBarcode.BackColor = Color.Transparent;
            lblBarcode.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBarcode.ForeColor = Color.White;
            lblBarcode.Location = new Point(171, 137);
            lblBarcode.Name = "lblBarcode";
            lblBarcode.Size = new Size(69, 20);
            lblBarcode.TabIndex = 34;
            lblBarcode.Text = "Barcode";
            // 
            // lblCash
            // 
            lblCash.Anchor = AnchorStyles.Bottom;
            lblCash.AutoSize = true;
            lblCash.BackColor = Color.Transparent;
            lblCash.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCash.ForeColor = Color.White;
            lblCash.Location = new Point(11, 560);
            lblCash.Name = "lblCash";
            lblCash.Size = new Size(46, 20);
            lblCash.TabIndex = 31;
            lblCash.Text = "Cash";
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom;
            lblTotal.AutoEllipsis = true;
            lblTotal.AutoSize = true;
            lblTotal.BackColor = Color.Transparent;
            lblTotal.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(224, 560);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(44, 20);
            lblTotal.TabIndex = 29;
            lblTotal.Text = "Total";
            // 
            // lblAmount
            // 
            lblAmount.Anchor = AnchorStyles.Top;
            lblAmount.AutoSize = true;
            lblAmount.BackColor = Color.Transparent;
            lblAmount.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblAmount.ForeColor = Color.White;
            lblAmount.Location = new Point(171, 170);
            lblAmount.Name = "lblAmount";
            lblAmount.Size = new Size(65, 20);
            lblAmount.TabIndex = 26;
            lblAmount.Text = "Amount";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top;
            lblPrice.AutoSize = true;
            lblPrice.BackColor = Color.Transparent;
            lblPrice.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(171, 110);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(38, 16);
            lblPrice.TabIndex = 24;
            lblPrice.Text = "Price";
            // 
            // lblProdName
            // 
            lblProdName.Anchor = AnchorStyles.Top;
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.BackColor = Color.Transparent;
            lblProdName.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(171, 80);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(55, 20);
            lblProdName.TabIndex = 23;
            lblProdName.Text = "Name:";
            // 
            // pbProdPic
            // 
            pbProdPic.Image = Properties.Resources.TempProdPic;
            pbProdPic.Location = new Point(15, 69);
            pbProdPic.Name = "pbProdPic";
            pbProdPic.Size = new Size(150, 150);
            pbProdPic.SizeMode = PictureBoxSizeMode.Zoom;
            pbProdPic.TabIndex = 22;
            pbProdPic.TabStop = false;
            // 
            // dgvSale
            // 
            dgvSale.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvSale.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSale.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvSale.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSale.Columns.AddRange(new DataGridViewColumn[] { Product, Price, Amount, Total, Barcode });
            dgvSale.GridColor = Color.FromArgb(2, 21, 38);
            dgvSale.Location = new Point(11, 225);
            dgvSale.MultiSelect = false;
            dgvSale.Name = "dgvSale";
            dgvSale.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSale.Size = new Size(367, 322);
            dgvSale.TabIndex = 21;
            dgvSale.CellContentClick += dgvSale_CellContentClick;
            // 
            // Product
            // 
            Product.HeaderText = "Product";
            Product.Name = "Product";
            // 
            // Price
            // 
            Price.HeaderText = "Price";
            Price.Name = "Price";
            // 
            // Amount
            // 
            Amount.HeaderText = "Amount";
            Amount.Name = "Amount";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            // 
            // Barcode
            // 
            Barcode.HeaderText = "Barcode";
            Barcode.Name = "Barcode";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 14);
            label1.Name = "label1";
            label1.Size = new Size(202, 39);
            label1.TabIndex = 20;
            label1.Text = "Sale Details";
            // 
            // lblOCode
            // 
            lblOCode.Anchor = AnchorStyles.Bottom;
            lblOCode.AutoSize = true;
            lblOCode.BackColor = Color.Transparent;
            lblOCode.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblOCode.ForeColor = Color.White;
            lblOCode.Location = new Point(12, 626);
            lblOCode.Name = "lblOCode";
            lblOCode.Size = new Size(91, 20);
            lblOCode.TabIndex = 37;
            lblOCode.Text = "Order Code";
            // 
            // btnDeleteProd
            // 
            btnDeleteProd.Anchor = AnchorStyles.Bottom;
            btnDeleteProd.BackColor = Color.FromArgb(110, 172, 218);
            btnDeleteProd.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnDeleteProd.BorderColor = Color.Transparent;
            btnDeleteProd.BorderColor1 = Color.Transparent;
            btnDeleteProd.BorderColor2 = Color.Transparent;
            btnDeleteProd.BorderRadius = 0;
            btnDeleteProd.BorderRadius1 = 0;
            btnDeleteProd.BorderRadius2 = 0;
            btnDeleteProd.BorderSize = 0;
            btnDeleteProd.BorderSize1 = 0;
            btnDeleteProd.BorderSize2 = 0;
            btnDeleteProd.FlatAppearance.BorderSize = 0;
            btnDeleteProd.FlatStyle = FlatStyle.Flat;
            btnDeleteProd.Font = new Font("Microsoft Sans Serif", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteProd.ForeColor = Color.Black;
            btnDeleteProd.Location = new Point(272, 618);
            btnDeleteProd.Name = "btnDeleteProd";
            btnDeleteProd.Size = new Size(106, 27);
            btnDeleteProd.TabIndex = 38;
            btnDeleteProd.Text = "Delete";
            btnDeleteProd.TextColor = Color.Black;
            btnDeleteProd.UseVisualStyleBackColor = false;
            btnDeleteProd.Click += btnDeleteProd_Click;
            // 
            // SaleDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(389, 681);
            Controls.Add(btnDeleteProd);
            Controls.Add(lblOCode);
            Controls.Add(lblChange);
            Controls.Add(lblBarcode);
            Controls.Add(lblCash);
            Controls.Add(lblTotal);
            Controls.Add(lblAmount);
            Controls.Add(lblPrice);
            Controls.Add(lblProdName);
            Controls.Add(pbProdPic);
            Controls.Add(dgvSale);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SaleDetails";
            Text = "SaleDetails";
            ((System.ComponentModel.ISupportInitialize)pbProdPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSale).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblChange;
        private Label lblBarcode;
        private Label lblCash;
        private Label lblTotal;
        private Label lblAmount;
        private Label lblPrice;
        private Label lblProdName;
        private PictureBox pbProdPic;
        private DataGridView dgvSale;
        private Label label1;
        private Label lblOCode;
        private CustomControls.RJControls.RJButton btnDeleteProd;
        private DataGridViewTextBoxColumn Product;
        private DataGridViewTextBoxColumn Price;
        private DataGridViewTextBoxColumn Amount;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Barcode;
    }
}
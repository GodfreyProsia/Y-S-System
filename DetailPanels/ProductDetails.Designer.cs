namespace Y_S_System.DetailPanels
{
    partial class ProductDetails
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
            tbProdName = new TextBox();
            btnDeleteProd = new CustomControls.RJControls.RJButton();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lblProdName = new Label();
            pbProdPic = new PictureBox();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            label1 = new Label();
            tbProdPrice = new TextBox();
            label2 = new Label();
            tbProdID = new TextBox();
            label3 = new Label();
            tbProdStock = new TextBox();
            label6 = new Label();
            cbProdUnit = new ComboBox();
            btnUploadPic = new CustomControls.RJControls.RJButton();
            dgvInventoryHis = new DataGridView();
            btnUpdateProd = new CustomControls.RJControls.RJButton();
            label4 = new Label();
            label5 = new Label();
            btnAddProd = new CustomControls.RJControls.RJButton();
            tbProdCode = new TextBox();
            btnGenerate = new CustomControls.RJControls.RJButton();
            pbBarcode = new PictureBox();
            btnAddStock = new CustomControls.RJControls.RJButton();
            btnClear = new CustomControls.RJControls.RJButton();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryHis).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbBarcode).BeginInit();
            SuspendLayout();
            // 
            // tbProdName
            // 
            tbProdName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbProdName.Location = new Point(69, 232);
            tbProdName.Name = "tbProdName";
            tbProdName.Size = new Size(307, 27);
            tbProdName.TabIndex = 33;
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
            btnDeleteProd.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDeleteProd.ForeColor = Color.Black;
            btnDeleteProd.Location = new Point(270, 619);
            btnDeleteProd.Name = "btnDeleteProd";
            btnDeleteProd.Size = new Size(106, 27);
            btnDeleteProd.TabIndex = 28;
            btnDeleteProd.Text = "Delete";
            btnDeleteProd.TextColor = Color.Black;
            btnDeleteProd.UseVisualStyleBackColor = false;
            // 
            // lblProdName
            // 
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(12, 235);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(51, 19);
            lblProdName.TabIndex = 23;
            lblProdName.Text = "Name";
            // 
            // pbProdPic
            // 
            pbProdPic.Image = Properties.Resources.TempProdPic;
            pbProdPic.Location = new Point(11, 71);
            pbProdPic.Name = "pbProdPic";
            pbProdPic.Size = new Size(150, 150);
            pbProdPic.SizeMode = PictureBoxSizeMode.Zoom;
            pbProdPic.TabIndex = 22;
            pbProdPic.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lato", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(11, 15);
            label1.Name = "label1";
            label1.Size = new Size(256, 42);
            label1.TabIndex = 20;
            label1.Text = "Product Details";
            // 
            // tbProdPrice
            // 
            tbProdPrice.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbProdPrice.Location = new Point(69, 265);
            tbProdPrice.Name = "tbProdPrice";
            tbProdPrice.Size = new Size(96, 27);
            tbProdPrice.TabIndex = 37;
            // 
            // label2
            // 
            label2.AutoEllipsis = true;
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(12, 268);
            label2.Name = "label2";
            label2.Size = new Size(45, 19);
            label2.TabIndex = 36;
            label2.Text = "Price";
            // 
            // tbProdID
            // 
            tbProdID.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbProdID.Location = new Point(69, 298);
            tbProdID.Name = "tbProdID";
            tbProdID.Size = new Size(307, 27);
            tbProdID.TabIndex = 39;
            // 
            // label3
            // 
            label3.AutoEllipsis = true;
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 301);
            label3.Name = "label3";
            label3.Size = new Size(25, 19);
            label3.TabIndex = 38;
            label3.Text = "ID";
            // 
            // tbProdStock
            // 
            tbProdStock.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbProdStock.Location = new Point(70, 331);
            tbProdStock.Name = "tbProdStock";
            tbProdStock.Size = new Size(117, 27);
            tbProdStock.TabIndex = 41;
            // 
            // label6
            // 
            label6.AutoEllipsis = true;
            label6.AutoSize = true;
            label6.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(171, 268);
            label6.Name = "label6";
            label6.Size = new Size(16, 19);
            label6.TabIndex = 44;
            label6.Text = "/";
            // 
            // cbProdUnit
            // 
            cbProdUnit.Font = new Font("Roboto", 12F);
            cbProdUnit.FormattingEnabled = true;
            cbProdUnit.Location = new Point(193, 265);
            cbProdUnit.Name = "cbProdUnit";
            cbProdUnit.Size = new Size(121, 27);
            cbProdUnit.TabIndex = 46;
            // 
            // btnUploadPic
            // 
            btnUploadPic.BackColor = Color.FromArgb(110, 172, 218);
            btnUploadPic.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnUploadPic.BorderColor = Color.Transparent;
            btnUploadPic.BorderColor1 = Color.Transparent;
            btnUploadPic.BorderColor2 = Color.Transparent;
            btnUploadPic.BorderRadius = 0;
            btnUploadPic.BorderRadius1 = 0;
            btnUploadPic.BorderRadius2 = 0;
            btnUploadPic.BorderSize = 0;
            btnUploadPic.BorderSize1 = 0;
            btnUploadPic.BorderSize2 = 0;
            btnUploadPic.FlatAppearance.BorderSize = 0;
            btnUploadPic.FlatStyle = FlatStyle.Flat;
            btnUploadPic.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUploadPic.ForeColor = Color.Black;
            btnUploadPic.Location = new Point(171, 71);
            btnUploadPic.Name = "btnUploadPic";
            btnUploadPic.Size = new Size(97, 27);
            btnUploadPic.TabIndex = 47;
            btnUploadPic.Text = "Upload";
            btnUploadPic.TextColor = Color.Black;
            btnUploadPic.UseVisualStyleBackColor = false;
            btnUploadPic.Click += btnUploadPic_Click;
            // 
            // dgvInventoryHis
            // 
            dgvInventoryHis.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvInventoryHis.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvInventoryHis.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvInventoryHis.GridColor = Color.FromArgb(2, 21, 38);
            dgvInventoryHis.Location = new Point(12, 389);
            dgvInventoryHis.Name = "dgvInventoryHis";
            dgvInventoryHis.Size = new Size(365, 224);
            dgvInventoryHis.TabIndex = 48;
            // 
            // btnUpdateProd
            // 
            btnUpdateProd.Anchor = AnchorStyles.Bottom;
            btnUpdateProd.BackColor = Color.FromArgb(110, 172, 218);
            btnUpdateProd.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnUpdateProd.BorderColor = Color.Transparent;
            btnUpdateProd.BorderColor1 = Color.Transparent;
            btnUpdateProd.BorderColor2 = Color.Transparent;
            btnUpdateProd.BorderRadius = 0;
            btnUpdateProd.BorderRadius1 = 0;
            btnUpdateProd.BorderRadius2 = 0;
            btnUpdateProd.BorderSize = 0;
            btnUpdateProd.BorderSize1 = 0;
            btnUpdateProd.BorderSize2 = 0;
            btnUpdateProd.FlatAppearance.BorderSize = 0;
            btnUpdateProd.FlatStyle = FlatStyle.Flat;
            btnUpdateProd.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnUpdateProd.ForeColor = Color.Black;
            btnUpdateProd.Location = new Point(140, 619);
            btnUpdateProd.Name = "btnUpdateProd";
            btnUpdateProd.Size = new Size(106, 27);
            btnUpdateProd.TabIndex = 49;
            btnUpdateProd.Text = "Update";
            btnUpdateProd.TextColor = Color.Black;
            btnUpdateProd.UseVisualStyleBackColor = false;
            btnUpdateProd.Click += btnUpdateProd_Click;
            // 
            // label4
            // 
            label4.AutoEllipsis = true;
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(12, 334);
            label4.Name = "label4";
            label4.Size = new Size(49, 19);
            label4.TabIndex = 40;
            label4.Text = "Stock";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top;
            label5.AutoEllipsis = true;
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(11, 367);
            label5.Name = "label5";
            label5.Size = new Size(131, 19);
            label5.TabIndex = 50;
            label5.Text = "Inventory History";
            // 
            // btnAddProd
            // 
            btnAddProd.Anchor = AnchorStyles.Bottom;
            btnAddProd.BackColor = Color.FromArgb(110, 172, 218);
            btnAddProd.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnAddProd.BorderColor = Color.Transparent;
            btnAddProd.BorderColor1 = Color.Transparent;
            btnAddProd.BorderColor2 = Color.Transparent;
            btnAddProd.BorderRadius = 0;
            btnAddProd.BorderRadius1 = 0;
            btnAddProd.BorderRadius2 = 0;
            btnAddProd.BorderSize = 0;
            btnAddProd.BorderSize1 = 0;
            btnAddProd.BorderSize2 = 0;
            btnAddProd.FlatAppearance.BorderSize = 0;
            btnAddProd.FlatStyle = FlatStyle.Flat;
            btnAddProd.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddProd.ForeColor = Color.Black;
            btnAddProd.Location = new Point(12, 619);
            btnAddProd.Name = "btnAddProd";
            btnAddProd.Size = new Size(106, 27);
            btnAddProd.TabIndex = 51;
            btnAddProd.Text = "Add";
            btnAddProd.TextColor = Color.Black;
            btnAddProd.UseVisualStyleBackColor = false;
            btnAddProd.Click += btnAddProd_Click;
            // 
            // tbProdCode
            // 
            tbProdCode.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbProdCode.Location = new Point(171, 194);
            tbProdCode.Name = "tbProdCode";
            tbProdCode.Size = new Size(205, 27);
            tbProdCode.TabIndex = 52;
            // 
            // btnGenerate
            // 
            btnGenerate.BackColor = Color.FromArgb(110, 172, 218);
            btnGenerate.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnGenerate.BorderColor = Color.Transparent;
            btnGenerate.BorderColor1 = Color.Transparent;
            btnGenerate.BorderColor2 = Color.Transparent;
            btnGenerate.BorderRadius = 0;
            btnGenerate.BorderRadius1 = 0;
            btnGenerate.BorderRadius2 = 0;
            btnGenerate.BorderSize = 0;
            btnGenerate.BorderSize1 = 0;
            btnGenerate.BorderSize2 = 0;
            btnGenerate.FlatAppearance.BorderSize = 0;
            btnGenerate.FlatStyle = FlatStyle.Flat;
            btnGenerate.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnGenerate.ForeColor = Color.Black;
            btnGenerate.Location = new Point(251, 331);
            btnGenerate.Name = "btnGenerate";
            btnGenerate.Size = new Size(125, 27);
            btnGenerate.TabIndex = 54;
            btnGenerate.Text = "Generate Barcode";
            btnGenerate.TextColor = Color.Black;
            btnGenerate.UseVisualStyleBackColor = false;
            btnGenerate.Click += btnGenerate_Click;
            // 
            // pbBarcode
            // 
            pbBarcode.Location = new Point(171, 104);
            pbBarcode.Name = "pbBarcode";
            pbBarcode.Size = new Size(206, 84);
            pbBarcode.SizeMode = PictureBoxSizeMode.Zoom;
            pbBarcode.TabIndex = 55;
            pbBarcode.TabStop = false;
            // 
            // btnAddStock
            // 
            btnAddStock.BackColor = Color.FromArgb(110, 172, 218);
            btnAddStock.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnAddStock.BorderColor = Color.Transparent;
            btnAddStock.BorderColor1 = Color.Transparent;
            btnAddStock.BorderColor2 = Color.Transparent;
            btnAddStock.BorderRadius = 0;
            btnAddStock.BorderRadius1 = 0;
            btnAddStock.BorderRadius2 = 0;
            btnAddStock.BorderSize = 0;
            btnAddStock.BorderSize1 = 0;
            btnAddStock.BorderSize2 = 0;
            btnAddStock.FlatAppearance.BorderSize = 0;
            btnAddStock.FlatStyle = FlatStyle.Flat;
            btnAddStock.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAddStock.ForeColor = Color.Black;
            btnAddStock.Location = new Point(193, 331);
            btnAddStock.Name = "btnAddStock";
            btnAddStock.Size = new Size(106, 27);
            btnAddStock.TabIndex = 56;
            btnAddStock.Text = "Update";
            btnAddStock.TextColor = Color.Black;
            btnAddStock.UseVisualStyleBackColor = false;
            btnAddStock.Visible = false;
            btnAddStock.Click += btnAddStock_Click;
            // 
            // btnClear
            // 
            btnClear.Anchor = AnchorStyles.Bottom;
            btnClear.BackColor = Color.FromArgb(110, 172, 218);
            btnClear.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnClear.BorderColor = Color.Transparent;
            btnClear.BorderColor1 = Color.Transparent;
            btnClear.BorderColor2 = Color.Transparent;
            btnClear.BorderRadius = 0;
            btnClear.BorderRadius1 = 0;
            btnClear.BorderRadius2 = 0;
            btnClear.BorderSize = 0;
            btnClear.BorderSize1 = 0;
            btnClear.BorderSize2 = 0;
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.FlatStyle = FlatStyle.Flat;
            btnClear.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.Black;
            btnClear.Location = new Point(12, 619);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(106, 27);
            btnClear.TabIndex = 57;
            btnClear.Text = "Clear";
            btnClear.TextColor = Color.Black;
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += btnClear_Click;
            // 
            // ProductDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(389, 681);
            Controls.Add(btnClear);
            Controls.Add(btnAddStock);
            Controls.Add(pbBarcode);
            Controls.Add(btnGenerate);
            Controls.Add(tbProdCode);
            Controls.Add(btnAddProd);
            Controls.Add(label5);
            Controls.Add(btnUpdateProd);
            Controls.Add(dgvInventoryHis);
            Controls.Add(btnUploadPic);
            Controls.Add(cbProdUnit);
            Controls.Add(label6);
            Controls.Add(tbProdStock);
            Controls.Add(label4);
            Controls.Add(tbProdID);
            Controls.Add(label3);
            Controls.Add(tbProdPrice);
            Controls.Add(label2);
            Controls.Add(tbProdName);
            Controls.Add(btnDeleteProd);
            Controls.Add(lblProdName);
            Controls.Add(pbProdPic);
            Controls.Add(label1);
            ForeColor = SystemColors.ControlText;
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProductDetails";
            RightToLeft = RightToLeft.No;
            Text = "ProductDetails";
            ((System.ComponentModel.ISupportInitialize)pbProdPic).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvInventoryHis).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbBarcode).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CustomControls.RJControls.RJButton btnDeleteProd;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblProdName;
        private PictureBox pbProdPic;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label label1;
        private TextBox tbProdPrice;
        private Label label2;
        private TextBox tbProdID;
        private Label label3;
        private TextBox tbProdStock;
        private Label label6;
        private ComboBox cbProdUnit;
        private CustomControls.RJControls.RJButton btnUploadPic;
        private DataGridView dgvInventoryHis;
        private CustomControls.RJControls.RJButton btnUpdateProd;
        private Label label4;
        private Label label5;
        private CustomControls.RJControls.RJButton btnAddProd;
        private TextBox tbProdCode;
        private CustomControls.RJControls.RJButton btnGenerate;
        private PictureBox pbBarcode;
        private CustomControls.RJControls.RJButton btnAddStock;
        private TextBox tbProdName;
        private CustomControls.RJControls.RJButton btnClear;
    }
}
namespace Y_S_System.DetailPanels
{
    partial class OrderDetails
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
            label1 = new Label();
            dgvOrders = new DataGridView();
            pbProdPic = new PictureBox();
            lblProdName = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            lblPrice = new Label();
            tbAmount = new TextBox();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            label2 = new Label();
            btnAdd = new CustomControls.RJControls.RJButton();
            btnDelete = new CustomControls.RJControls.RJButton();
            lblTotal = new Label();
            label3 = new Label();
            tbTotal = new TextBox();
            tbCash = new TextBox();
            label4 = new Label();
            tbBarcode = new TextBox();
            btnSubmit = new CustomControls.RJControls.RJButton();
            tbChange = new TextBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Lato", 26.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(12, 19);
            label1.Name = "label1";
            label1.Size = new Size(223, 42);
            label1.TabIndex = 0;
            label1.Text = "Order Details";
            // 
            // dgvOrders
            // 
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvOrders.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.GridColor = Color.FromArgb(2, 21, 38);
            dgvOrders.Location = new Point(12, 272);
            dgvOrders.MultiSelect = false;
            dgvOrders.Name = "dgvOrders";
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(367, 262);
            dgvOrders.TabIndex = 3;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // pbProdPic
            // 
            pbProdPic.Image = Properties.Resources.TempProdPic;
            pbProdPic.Location = new Point(12, 75);
            pbProdPic.Name = "pbProdPic";
            pbProdPic.Size = new Size(150, 150);
            pbProdPic.SizeMode = PictureBoxSizeMode.Zoom;
            pbProdPic.TabIndex = 4;
            pbProdPic.TabStop = false;
            // 
            // lblProdName
            // 
            lblProdName.Anchor = AnchorStyles.Top;
            lblProdName.AutoEllipsis = true;
            lblProdName.AutoSize = true;
            lblProdName.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblProdName.ForeColor = Color.White;
            lblProdName.Location = new Point(172, 75);
            lblProdName.Name = "lblProdName";
            lblProdName.Size = new Size(55, 19);
            lblProdName.TabIndex = 5;
            lblProdName.Text = "Name:";
            // 
            // lblPrice
            // 
            lblPrice.Anchor = AnchorStyles.Top;
            lblPrice.AutoSize = true;
            lblPrice.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPrice.ForeColor = Color.White;
            lblPrice.Location = new Point(172, 105);
            lblPrice.Name = "lblPrice";
            lblPrice.Size = new Size(37, 15);
            lblPrice.TabIndex = 6;
            lblPrice.Text = "Price";
            // 
            // tbAmount
            // 
            tbAmount.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbAmount.Location = new Point(246, 162);
            tbAmount.Name = "tbAmount";
            tbAmount.Size = new Size(131, 27);
            tbAmount.TabIndex = 7;
            tbAmount.KeyPress += tbAmount_KeyPress;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top;
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(172, 165);
            label2.Name = "label2";
            label2.Size = new Size(65, 19);
            label2.TabIndex = 8;
            label2.Text = "Amount";
            // 
            // btnAdd
            // 
            btnAdd.Anchor = AnchorStyles.Top;
            btnAdd.BackColor = Color.FromArgb(110, 172, 218);
            btnAdd.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnAdd.BorderColor = Color.Transparent;
            btnAdd.BorderColor1 = Color.Transparent;
            btnAdd.BorderColor2 = Color.Transparent;
            btnAdd.BorderRadius = 0;
            btnAdd.BorderRadius1 = 0;
            btnAdd.BorderRadius2 = 0;
            btnAdd.BorderSize = 0;
            btnAdd.BorderSize1 = 0;
            btnAdd.BorderSize2 = 0;
            btnAdd.FlatAppearance.BorderSize = 0;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.Black;
            btnAdd.Location = new Point(172, 195);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(97, 27);
            btnAdd.TabIndex = 9;
            btnAdd.Text = "Add";
            btnAdd.TextColor = Color.Black;
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnDelete
            // 
            btnDelete.Anchor = AnchorStyles.Top;
            btnDelete.BackColor = Color.FromArgb(110, 172, 218);
            btnDelete.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnDelete.BorderColor = Color.Transparent;
            btnDelete.BorderColor1 = Color.Transparent;
            btnDelete.BorderColor2 = Color.Transparent;
            btnDelete.BorderRadius = 0;
            btnDelete.BorderRadius1 = 0;
            btnDelete.BorderRadius2 = 0;
            btnDelete.BorderSize = 0;
            btnDelete.BorderSize1 = 0;
            btnDelete.BorderSize2 = 0;
            btnDelete.FlatAppearance.BorderSize = 0;
            btnDelete.FlatStyle = FlatStyle.Flat;
            btnDelete.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnDelete.ForeColor = Color.Black;
            btnDelete.Location = new Point(271, 239);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(106, 27);
            btnDelete.TabIndex = 10;
            btnDelete.Text = "Delete";
            btnDelete.TextColor = Color.Black;
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // lblTotal
            // 
            lblTotal.Anchor = AnchorStyles.Bottom;
            lblTotal.AutoEllipsis = true;
            lblTotal.AutoSize = true;
            lblTotal.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTotal.ForeColor = Color.White;
            lblTotal.Location = new Point(225, 555);
            lblTotal.Name = "lblTotal";
            lblTotal.Size = new Size(46, 19);
            lblTotal.TabIndex = 11;
            lblTotal.Text = "Total";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Bottom;
            label3.AutoSize = true;
            label3.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(12, 555);
            label3.Name = "label3";
            label3.Size = new Size(45, 19);
            label3.TabIndex = 13;
            label3.Text = "Cash";
            // 
            // tbTotal
            // 
            tbTotal.Anchor = AnchorStyles.Bottom;
            tbTotal.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbTotal.Location = new Point(277, 552);
            tbTotal.Name = "tbTotal";
            tbTotal.Size = new Size(100, 27);
            tbTotal.TabIndex = 12;
            // 
            // tbCash
            // 
            tbCash.Anchor = AnchorStyles.Bottom;
            tbCash.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbCash.Location = new Point(81, 552);
            tbCash.Name = "tbCash";
            tbCash.Size = new Size(100, 27);
            tbCash.TabIndex = 14;
            tbCash.KeyPress += tbCash_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top;
            label4.AutoSize = true;
            label4.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.White;
            label4.Location = new Point(172, 132);
            label4.Name = "label4";
            label4.Size = new Size(68, 19);
            label4.TabIndex = 16;
            label4.Text = "Barcode";
            // 
            // tbBarcode
            // 
            tbBarcode.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbBarcode.Location = new Point(246, 129);
            tbBarcode.Name = "tbBarcode";
            tbBarcode.Size = new Size(131, 27);
            tbBarcode.TabIndex = 15;
            tbBarcode.KeyPress += tbBarcode_KeyPress;
            // 
            // btnSubmit
            // 
            btnSubmit.Anchor = AnchorStyles.Bottom;
            btnSubmit.BackColor = Color.FromArgb(110, 172, 218);
            btnSubmit.BackgroundColor = Color.FromArgb(110, 172, 218);
            btnSubmit.BorderColor = Color.Transparent;
            btnSubmit.BorderColor1 = Color.Transparent;
            btnSubmit.BorderColor2 = Color.Transparent;
            btnSubmit.BorderRadius = 0;
            btnSubmit.BorderRadius1 = 0;
            btnSubmit.BorderRadius2 = 0;
            btnSubmit.BorderSize = 0;
            btnSubmit.BorderSize1 = 0;
            btnSubmit.BorderSize2 = 0;
            btnSubmit.FlatAppearance.BorderSize = 0;
            btnSubmit.FlatStyle = FlatStyle.Flat;
            btnSubmit.Font = new Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSubmit.ForeColor = Color.Black;
            btnSubmit.Location = new Point(225, 624);
            btnSubmit.Name = "btnSubmit";
            btnSubmit.Size = new Size(152, 27);
            btnSubmit.TabIndex = 17;
            btnSubmit.Text = "Submit";
            btnSubmit.TextColor = Color.Black;
            btnSubmit.UseVisualStyleBackColor = false;
            btnSubmit.Click += btnSubmit_Click;
            // 
            // tbChange
            // 
            tbChange.Anchor = AnchorStyles.Bottom;
            tbChange.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbChange.Location = new Point(81, 585);
            tbChange.Name = "tbChange";
            tbChange.Size = new Size(100, 27);
            tbChange.TabIndex = 19;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Bottom;
            label5.AutoSize = true;
            label5.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.White;
            label5.Location = new Point(12, 588);
            label5.Name = "label5";
            label5.Size = new Size(63, 19);
            label5.TabIndex = 18;
            label5.Text = "Change";
            // 
            // OrderDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(389, 681);
            Controls.Add(tbChange);
            Controls.Add(label5);
            Controls.Add(btnSubmit);
            Controls.Add(label4);
            Controls.Add(tbBarcode);
            Controls.Add(tbCash);
            Controls.Add(label3);
            Controls.Add(tbTotal);
            Controls.Add(lblTotal);
            Controls.Add(btnDelete);
            Controls.Add(btnAdd);
            Controls.Add(label2);
            Controls.Add(tbAmount);
            Controls.Add(lblPrice);
            Controls.Add(lblProdName);
            Controls.Add(pbProdPic);
            Controls.Add(dgvOrders);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "OrderDetails";
            Text = "OrderDetails";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ((System.ComponentModel.ISupportInitialize)pbProdPic).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvOrders;
        private PictureBox pbProdPic;
        private Label lblProdName;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Label lblPrice;
        private TextBox tbAmount;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label label2;
        private CustomControls.RJControls.RJButton btnAdd;
        private CustomControls.RJControls.RJButton btnDelete;
        private Label lblTotal;
        private Label label3;
        private TextBox tbTotal;
        private TextBox tbCash;
        private Label label4;
        private TextBox tbBarcode;
        private CustomControls.RJControls.RJButton btnSubmit;
        private TextBox tbChange;
        private Label label5;
    }
}
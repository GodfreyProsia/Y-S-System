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
            OrderID = new DataGridViewTextBoxColumn();
            Date = new DataGridViewTextBoxColumn();
            Cash = new DataGridViewTextBoxColumn();
            Change = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvSales).BeginInit();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(14, 17);
            label2.Name = "label2";
            label2.Size = new Size(60, 20);
            label2.TabIndex = 13;
            label2.Text = "Search";
            // 
            // tbtSearch
            // 
            tbtSearch.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbtSearch.Location = new Point(79, 14);
            tbtSearch.Name = "tbtSearch";
            tbtSearch.Size = new Size(197, 26);
            tbtSearch.TabIndex = 12;
            tbtSearch.TextChanged += tbtSearch_TextChanged_1;
            // 
            // dgvSales
            // 
            dgvSales.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvSales.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSales.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvSales.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSales.Columns.AddRange(new DataGridViewColumn[] { OrderID, Date, Cash, Change, Total });
            dgvSales.GridColor = Color.FromArgb(2, 21, 38);
            dgvSales.Location = new Point(12, 51);
            dgvSales.MultiSelect = false;
            dgvSales.Name = "dgvSales";
            dgvSales.ReadOnly = true;
            dgvSales.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSales.Size = new Size(645, 618);
            dgvSales.TabIndex = 16;
            dgvSales.CellClick += dgvSales_CellClick;
            // 
            // OrderID
            // 
            OrderID.HeaderText = "OrderID";
            OrderID.Name = "OrderID";
            OrderID.ReadOnly = true;
            // 
            // Date
            // 
            Date.HeaderText = "Date";
            Date.Name = "Date";
            Date.ReadOnly = true;
            // 
            // Cash
            // 
            Cash.HeaderText = "Cash";
            Cash.Name = "Cash";
            Cash.ReadOnly = true;
            // 
            // Change
            // 
            Change.HeaderText = "Change";
            Change.Name = "Change";
            Change.ReadOnly = true;
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            Total.ReadOnly = true;
            // 
            // SalesView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
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
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn Date;
        private DataGridViewTextBoxColumn Cash;
        private DataGridViewTextBoxColumn Change;
        private DataGridViewTextBoxColumn Total;
    }
}
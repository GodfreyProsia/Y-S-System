namespace Y_S_System.MidPanels
{
    partial class AdminOrderView
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
            components = new System.ComponentModel.Container();
            dgvOrders = new DataGridView();
            OrderID = new DataGridViewTextBoxColumn();
            Cash = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            Change = new DataGridViewTextBoxColumn();
            label2 = new Label();
            tbtSearch = new TextBox();
            updateTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)dgvOrders).BeginInit();
            SuspendLayout();
            // 
            // dgvOrders
            // 
            dgvOrders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvOrders.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvOrders.BackgroundColor = Color.FromArgb(3, 52, 110);
            dgvOrders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrders.Columns.AddRange(new DataGridViewColumn[] { OrderID, Cash, Total, Change });
            dgvOrders.GridColor = Color.FromArgb(2, 21, 38);
            dgvOrders.Location = new Point(12, 57);
            dgvOrders.Name = "dgvOrders";
            dgvOrders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvOrders.Size = new Size(645, 608);
            dgvOrders.TabIndex = 20;
            dgvOrders.CellClick += dgvOrders_CellClick;
            // 
            // OrderID
            // 
            OrderID.HeaderText = "OrderID";
            OrderID.Name = "OrderID";
            // 
            // Cash
            // 
            Cash.HeaderText = "Cash";
            Cash.Name = "Cash";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.Name = "Total";
            // 
            // Change
            // 
            Change.HeaderText = "Change";
            Change.Name = "Change";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(21, 18);
            label2.Name = "label2";
            label2.Size = new Size(59, 19);
            label2.TabIndex = 19;
            label2.Text = "Search";
            // 
            // tbtSearch
            // 
            tbtSearch.Font = new Font("Roboto", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            tbtSearch.Location = new Point(86, 15);
            tbtSearch.Name = "tbtSearch";
            tbtSearch.Size = new Size(197, 27);
            tbtSearch.TabIndex = 18;
            // 
            // updateTimer
            // 
            updateTimer.Enabled = true;
            updateTimer.Interval = 5000;
            updateTimer.Tick += updateTimer_Tick;
            // 
            // AdminOrderView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(2, 21, 38);
            ClientSize = new Size(669, 681);
            Controls.Add(dgvOrders);
            Controls.Add(label2);
            Controls.Add(tbtSearch);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AdminOrderView";
            Text = "AdminOrderView";
            ((System.ComponentModel.ISupportInitialize)dgvOrders).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvOrders;
        private Label label2;
        private TextBox tbtSearch;
        private DataGridViewTextBoxColumn OrderID;
        private DataGridViewTextBoxColumn Cash;
        private DataGridViewTextBoxColumn Total;
        private DataGridViewTextBoxColumn Change;
        private System.Windows.Forms.Timer updateTimer;
    }
}
namespace Y_S_System
{
    partial class ProdBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ProdBox));
            pictureBox1 = new PictureBox();
            label1 = new Label();
            label2 = new Label();
            productBox1 = new MidPanels.ProdductLabel.ProductBox();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(4, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(155, 118);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Roboto", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(30, 125);
            label1.Name = "label1";
            label1.Size = new Size(107, 18);
            label1.TabIndex = 1;
            label1.Text = "Product Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Roboto", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(60, 177);
            label2.Name = "label2";
            label2.Size = new Size(37, 15);
            label2.TabIndex = 2;
            label2.Text = "Price";
            // 
            // productBox1
            // 
            productBox1.Location = new Point(140, 164);
            productBox1.Name = "productBox1";
            productBox1.ProdName = "Product Name";
            productBox1.ProductImage = (Image)resources.GetObject("productBox1.ProductImage");
            productBox1.ProductPrice = "Php 0.00";
            productBox1.Size = new Size(8, 8);
            productBox1.TabIndex = 3;
            // 
            // panel1
            // 
            panel1.BackColor = Color.MintCream;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(163, 198);
            panel1.TabIndex = 4;
            // 
            // ProdBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(163, 198);
            Controls.Add(panel1);
            Controls.Add(productBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ProdBox";
            Text = "ProdBox";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Label label1;
        private Label label2;
        private MidPanels.ProdductLabel.ProductBox productBox1;
        private Panel panel1;
    }
}
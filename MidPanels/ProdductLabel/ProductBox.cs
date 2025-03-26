using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y_S_System.DetailPanels;

namespace Y_S_System.MidPanels.ProdductLabel
{
    public partial class ProductBox : UserControl
    {
        // Controls for the product box
        public event EventHandler<string> ProductClicked;
        private PictureBox pictureBox;
        private Label nameLabel;
        private Label priceLabel;
        private Panel backgroundPanel;
        private Label stockLabel;
        private string _prodBarcode;
        public string ProdBarcode
        {
            get { return _prodBarcode; }
            set { _prodBarcode = value; }
        }
        // Properties to set the product's image, name, and price
        [Category("Advance")]
        public string ProdName
        {
            get { return nameLabel.Text; }
            set { nameLabel.Text = value; }
        }
        [Category("Advance")]
        public string ProductPrice
        {
            get { return priceLabel.Text; }
            set { priceLabel.Text = value; }
        }
        [Category("Advance")]
        public string Stock
        {
            get { return stockLabel.Text; }
            set { stockLabel.Text = value; }
        }

        [Category("Advance")]
        public Image ProductImage
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }
        public ProductBox()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            pictureBox = new PictureBox();
            nameLabel = new Label();
            priceLabel = new Label();
            stockLabel = new Label();
            ((ISupportInitialize)pictureBox).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Anchor = AnchorStyles.Top;
            pictureBox.Image = Properties.Resources.TempProdPic;
            pictureBox.Location = new Point(5, 5);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(150, 150);
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 1;
            pictureBox.TabStop = false;
            pictureBox.Click += ProductBox_Click;
            // 
            // nameLabel
            // 
            nameLabel.Font = new Font("Roboto", 12F, FontStyle.Bold);
            nameLabel.Location = new Point(5, 159);
            nameLabel.Name = "nameLabel";
            nameLabel.Size = new Size(150, 42);
            nameLabel.TabIndex = 0;
            nameLabel.Text = "ProductNameeeeeeeeeeeeee";
            nameLabel.TextAlign = ContentAlignment.MiddleCenter;
            nameLabel.Click += ProductBox_Click;
            // 
            // priceLabel
            // 
            priceLabel.Font = new Font("Roboto", 12F, FontStyle.Bold);
            priceLabel.Location = new Point(27, 201);
            priceLabel.Name = "priceLabel";
            priceLabel.Size = new Size(100, 23);
            priceLabel.TabIndex = 2;
            priceLabel.Text = "Price";
            priceLabel.TextAlign = ContentAlignment.TopCenter;
            priceLabel.Click += ProductBox_Click;
            // 
            // stockLabel
            // 
            stockLabel.Font = new Font("Roboto", 12F, FontStyle.Bold);
            stockLabel.Location = new Point(51, 224);
            stockLabel.Name = "stockLabel";
            stockLabel.Size = new Size(54, 18);
            stockLabel.TabIndex = 3;
            stockLabel.Text = "0";
            stockLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProductBox
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(110, 172, 218);
            Controls.Add(stockLabel);
            Controls.Add(nameLabel);
            Controls.Add(pictureBox);
            Controls.Add(priceLabel);
            Cursor = Cursors.Hand;
            Name = "ProductBox";
            Size = new Size(160, 252);
            Click += ProductBox_Click;
            ((ISupportInitialize)pictureBox).EndInit();
            ResumeLayout(false);
        }

        public void colorChange()
        {
            double stock;
            if (double.TryParse(stockLabel.Text, out stock))
            {
                if (stock <= 10)
                {
                    int intStock = (int)stock;
                    int minStock = 0;
                    int maxStock = 10;

                    int clampedStock = Math.Max(minStock, Math.Min(intStock, maxStock));

                    Color startColor = Color.FromArgb(110, 172, 218);
                    Color endColor = Color.FromArgb(208, 72, 72);

                    float factor = 1 - ((float)clampedStock / maxStock);

                    int r = (int)(startColor.R + factor * (endColor.R - startColor.R));
                    int g = (int)(startColor.G + factor * (endColor.G - startColor.G));
                    int b = (int)(startColor.B + factor * (endColor.B - startColor.B));

                    BackColor = Color.FromArgb(r, g, b);
                }
            }
        }
        private void ProductBox_Click(object sender, EventArgs e)
        {
            ProductDetails productDetails = Application.OpenForms["ProductDetails"] as ProductDetails;

            if (productDetails != null)
            {
                productDetails.productLoad(_prodBarcode);
            }
        }
    }
}

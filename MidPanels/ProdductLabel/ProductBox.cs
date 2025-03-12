using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y_S_System.MidPanels.ProdductLabel
{
    public partial class ProductBox : UserControl
    {
        // Controls for the product box
        private PictureBox pictureBox;
        private Label nameLabel;
        private Label priceLabel;
        private Panel backgroundPanel;


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
        public Image ProductImage
        {
            get { return pictureBox.Image; }
            set { pictureBox.Image = value; }
        }
        public ProductBox()
        {
            InitializeCustomComponents();

            // Set default values for properties
            this.Size = new System.Drawing.Size(150, 200);
            ProdName = "Product Name";
            ProductPrice = "Php 0.00";
            ProductImage = Properties.Resources.Y_S_Logo; // Assuming you have a default image in your resources
        }
        public ProductBox(string productName, string productPrice, Image productImage)
        {
            InitializeCustomComponents();

            // Set the properties using the constructor parameters
            ProdName = productName;
            ProductPrice = productPrice;
            ProductImage = productImage;
        }

        private void InitializeCustomComponents()
        {
            pictureBox = new PictureBox
            {
                SizeMode = PictureBoxSizeMode.Zoom,
                Dock = DockStyle.Top,
                Size = new System.Drawing.Size(150, 150)
            };


            nameLabel = new Label
            {
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Font = new System.Drawing.Font("Roboto", 12, System.Drawing.FontStyle.Bold)
            };

            priceLabel = new Label
            {
                TextAlign = System.Drawing.ContentAlignment.MiddleCenter,
                Dock = DockStyle.Bottom,
                Font = new System.Drawing.Font("Roboto", 10, System.Drawing.FontStyle.Regular)
            };

            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(110, 172, 218);

            Controls.Add(nameLabel);
            Controls.Add(pictureBox);
            Controls.Add(priceLabel);
        }

        private void InitializeComponent()
        {

        }
    }
}

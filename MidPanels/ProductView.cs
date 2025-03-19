using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y_S_System.DetailPanels;
using Y_S_System.MidPanels.ProdductLabel;
using MySql.Data.MySqlClient;

namespace Y_S_System.MidPanels
{
    public partial class ProductView : Form
    {
        //string connstring = "server=localhost;port=3306;user=root;password=Prosia24!;database=yarnstitchdata";
        public static ProductDetails instance;
        public int _mode;
        ProductBox productBox = new ProductBox();
        public ProductView(int mode)
        {
            InitializeComponent();
            LoadProduct();
            _mode = mode;
        }
        public void LoadProduct()
        {
            ProductBox[] productBox = new ProductBox[50];
            for (int i = 0; i < 50; i++)
            {
                productBox[i] = new ProductBox();
                productBox[i].ProdName = "TEMP PRODUCT";
                productBox[i].ProductPrice = "Php 100.00 Per Meter";
                productBox[i].ProdBarcode = "123455123";
                productBox[i].ProductImage = Properties.Resources.Y_S_Logo;
                productPanel.Controls.Add(productBox[i]);
            }
        }

    }
}

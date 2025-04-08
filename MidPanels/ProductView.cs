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
        string connstring = connection.connstring;
        public int _mode;
        ProductBox productBox = new ProductBox();
        public ProductView(int mode)
        {
            InitializeComponent();
            LoadProduct(null);
            _mode = mode;
        }
        public void LoadProduct(string search)
        {
            productPanel.Controls.Clear();
            string loadProduct = "SELECT * FROM `yarnstitchdata`.`products`";
            string loadSearch = "SELECT * FROM `yarnstitchdata`.`products` WHERE `ProductName` LIKE '%" + tbtSearch.Text + "%' OR `ProductBarcode` LIKE '%" + tbtSearch.Text + "%'";
            MySqlConnection conn = new MySqlConnection(connstring);
            if (search == null)
            {
                using (MySqlCommand cmd = new MySqlCommand(loadProduct, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductBox productBox = new ProductBox();
                            productBox.ProdName = reader["ProductName"].ToString();
                            productBox.ProductPrice = ("Php " + reader["ProductPrice"].ToString() + "/" + reader["ProductUnit"].ToString());
                            productBox.ProdBarcode = reader["ProductBarcode"].ToString();
                            productBox.Stock = reader["ProductStock"].ToString();
                            if (reader["ProductPic"] != DBNull.Value)
                            {
                                byte[] pictureData = (byte[])reader["ProductPic"];
                                if (pictureData.Length > 0)
                                {
                                    try
                                    {
                                        using (MemoryStream ms = new MemoryStream(pictureData))
                                        {
                                            ms.Position = 0;
                                            productBox.ProductImage = Image.FromStream(ms);
                                        }
                                    }
                                    catch
                                    {
                                        productBox.ProductImage = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
                                    }
                                }
                            }
                            productBox.colorChange();
                            productPanel.Controls.Add(productBox);
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                using (MySqlCommand cmd = new MySqlCommand(loadSearch, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            ProductBox productBox = new ProductBox();
                            productBox.ProdName = reader["ProductName"].ToString();
                            productBox.ProductPrice = "Php " + reader["ProductPrice"].ToString();
                            productBox.ProdBarcode = reader["ProductBarcode"].ToString();
                            productBox.Stock = reader["ProductStock"].ToString();
                            if (reader["ProductPic"] != DBNull.Value)
                            {
                                byte[] pictureData = (byte[])reader["ProductPic"];
                                if (pictureData.Length > 0)
                                {
                                    try
                                    {
                                        using (MemoryStream ms = new MemoryStream(pictureData))
                                        {
                                            ms.Position = 0;
                                            productBox.ProductImage = Image.FromStream(ms);
                                        }
                                    }
                                    catch
                                    {
                                        productBox.ProductImage = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
                                    }
                                }
                            }
                            productBox.colorChange();
                            productPanel.Controls.Add(productBox);
                        }
                    }
                    conn.Close();
                }
            }
        }

        private void tbtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProduct(tbtSearch.Text);
        }
    }
}

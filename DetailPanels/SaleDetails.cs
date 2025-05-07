using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Y_S_System.MidPanels;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Y_S_System.DetailPanels
{
    public partial class SaleDetails : Form
    {
        string connstring = connection.connstring;
        int _id;
        public SaleDetails(int id, string role)
        {
            InitializeComponent();
            _id = id;
            if(role == "Admin")
            {
                btnDeleteProd.Visible = true;
            }
            else
            {
                btnDeleteProd.Visible = false;
            }
        }

        public void LoadOrder(string OrderID)
        {
            dgvSale.Rows.Clear();
            if (!string.IsNullOrEmpty(OrderID))
            {
                string OrderDetails = "SELECT * FROM `yarnstitchdata`.`sales` WHERE `OrderID` = \"" + OrderID + "\"";
                string OrderList = "SELECT * FROM `yarnstitchdata`.`salesdetails` WHERE `OrderID` = \"" + OrderID + "\"";

                MySqlConnection conn = new MySqlConnection(connstring);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(OrderDetails, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblOCode.Text = "OrderID: " + OrderID;
                            lblCash.Text = $"Cash: Php {reader["Cash"]:N2}";
                            lblChange.Text = $"Change: Php {reader["Change"]:N2}";
                            lblTotal.Text = $"Total: Php {reader["Total"]}";
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand(OrderList, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSale.Rows.Add(reader["ProductName"].ToString(),
                                $"Php {reader["ProductPrice"]:N2} /  {reader["ProductUnit"].ToString()}",
                                reader["Amount"].ToString(),
                                $"Php {reader["Total"]:N2}",
                                reader["ProductBarcode"].ToString());
                        }

                    }
                }
            }
            else
            {
                ClearFields();
                dgvSale.Rows.Clear();
            }

        }//Load Data

        private void LoadProduct(string ProductBarcode)
        {
            if (!string.IsNullOrEmpty(ProductBarcode))
            {
                string loadProduct = "SELECT * FROM `yarnstitchdata`.`products` WHERE `ProductBarcode` = " + ProductBarcode + "";
                MySqlConnection conn = new MySqlConnection(connstring);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(loadProduct, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblBarcode.Text = "Barcode: " + ProductBarcode;
                            lblPrice.Text = $"Price: {reader["ProductPrice"]:N2} / {reader["ProductUnit"].ToString()}";
                            lblProdName.Text = "Name: " + reader["ProductName"].ToString();
                            lblAmount.Text = "Stock: " + reader["ProductStock"].ToString();
                        }
                    }
                    using (MySqlDataReader readerpic = cmd.ExecuteReader())
                    {
                        if (readerpic.Read())
                        {
                            if (!string.IsNullOrEmpty(readerpic["ProductPic"].ToString()))
                            {
                                byte[] pictureData = (byte[])readerpic["ProductPic"];
                                using (MemoryStream ms = new MemoryStream(pictureData))
                                {
                                    ms.Position = 0;
                                    pbProdPic.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                pbProdPic.Image = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
                            }
                        }
                    }
                }
            }
            else
            {
                ClearFields();
            }
        }//Load Product

        private void dgvSale_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string ProductBarcode = dgvSale.CurrentRow.Cells["Barcode"].Value?.ToString();
            LoadProduct(ProductBarcode);
        }//dgvSale Product Click

        private void ClearFields()
        {
            lblOCode.Text = "OrderID";
            lblCash.Text = "Cash";
            lblChange.Text = "Change";
            lblTotal.Text = "Total";
            lblBarcode.Text = "Barcode";
            lblPrice.Text = "Price";
            lblProdName.Text = "Name";
            lblAmount.Text = "Stock";
            pbProdPic.Image = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
        }//Clear Fields

        private void btnDeleteProd_Click(object sender, EventArgs e)
        {
            if (confirmation())
            {
                string deleteOrder = "DELETE FROM `yarnstitchdata`.`sales` WHERE `OrderID` = " + lblOCode.Text.Replace("OrderID: ", "") + "";

                if (lblOCode.Text != "OrderID")
                {
                    MySqlConnection conn = new MySqlConnection(connstring);
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(deleteOrder, conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    ClearFields();
                    foreach (var salesView in Application.OpenForms.OfType<SalesView>())
                    {
                        salesView.LoadData(null);
                    }
                }
                else
                {
                    MessageBox.Show("Please select a product to delete.");
                }
            }
        }//Delete Order

        private bool confirmation()
        {
            using (Confirmation form = new Confirmation(_id))
            {
                DialogResult result = form.ShowDialog();
                return result == DialogResult.Yes;
            }
        }//Confirmation
    }
}

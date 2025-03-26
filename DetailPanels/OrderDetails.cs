using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Y_S_System.DetailPanels
{
    public partial class OrderDetails : Form
    {
        string connstring = "server=localhost;port=3306;user=root;password=Prosia24!;database=yarnstitchdata";
        double _price;
        double _amount;
        double _Total = 0;
        public OrderDetails()
        {
            InitializeComponent();
        }
        public void LoadProduct(string ProductBarcode)
        {
            if (tbBarcode.Text != ProductBarcode)
            {
                tbAmount.Text = "1";
                _amount = Convert.ToDouble(tbBarcode.Text);
                tbBarcode.Text = ProductBarcode;
                string prodLoad = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(prodLoad, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblProdName.Text = reader["ProductName"].ToString();
                            lblPrice.Text = reader["ProductPrice"].ToString() + " Per " + reader["ProductUnit"].ToString();
                            double.TryParse(reader["ProductPrice"].ToString(), out _price);
                            if (!string.IsNullOrEmpty(reader["ProductPic"].ToString()))
                            {
                                byte[] pictureData = (byte[])reader["ProductPic"];
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
                        else
                        {
                            MessageBox.Show("Product Not Found"); //make error
                        }
                    }
                }
            }
        }

        private void tbBarcode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrWhiteSpace(tbBarcode.Text))
                {
                    LoadProduct(tbBarcode.Text);
                }
            }
        }

        private void tbAmount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrWhiteSpace(tbBarcode.Text))
                {
                    try
                    {
                        double.TryParse(tbAmount.Text, out _amount);
                        tempSales("add", tbBarcode.Text);
                    }
                    catch { MessageBox.Show("Please enter a valid amount"); }
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            tempSales("add", tbBarcode.Text);
        }
        public void tempSales(string mode, string ProductBarcode)
        {
            if (!string.IsNullOrWhiteSpace(tbBarcode.Text) && !string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                string checkItem = "SELECT * FROM `yarnstitchdata`.`tempsales` " +
                    "WHERE (`ProductBarcode` = @ProductBarcode)";
                string updateAmount = "UPDATE `yarnstitchdata`.`tempsales` " +
                    "SET `ProductAmount` = @ProductAmount " +
                    "WHERE `ProductBarcode` = @`ProductBarcode`";
                string addProduct = "INSERT INTO `yarnstitchdata`.`tempsales` " +
                    "(`ProductBarcode`, `ProductName`, `ProductAmount`, `ProductPrice`, `ProductTotal`) " +
                    "VALUES (@ProductBarcode, @ProductName, @ProductAmount, @ProductPrice, @ProductTotal)";
                string deleteOrder = "DELETE FROM `yarnstitchdata`.`tempsales` WHERE `ProductBarcode` = @`ProductBarcode`";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(checkItem, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (mode == "add")
                            {
                                _Total = _Total - double.Parse(reader["ProductAmount"].ToString()) * double.Parse(reader["ProductPrice"].ToString());
                                try { double.TryParse(tbAmount.Text, out _amount); }
                                catch { MessageBox.Show("Please enter a valid amount"); return; }
                                using (MySqlCommand update = new MySqlCommand(updateAmount, conn))
                                {
                                    update.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    update.Parameters.AddWithValue("@ProductAmount", _amount);
                                    update.ExecuteNonQuery();
                                }
                                _Total = _Total + double.Parse(reader["ProductAmount"].ToString()) * double.Parse(reader["ProductPrice"].ToString());
                                tbTotal.Text = _Total.ToString();
                            }
                            if (mode == "delete")
                            {
                                using (MySqlCommand delete = new MySqlCommand(deleteOrder, conn))
                                {
                                    delete.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    delete.ExecuteNonQuery();
                                }
                                _Total = _Total - double.Parse(reader["ProductAmount"].ToString()) * double.Parse(reader["ProductPrice"].ToString());
                                tbTotal.Text = _Total.ToString();
                            }
                        }
                        else if (mode == "add")
                        {
                            try { double.TryParse(tbAmount.Text, out _amount); }
                            catch { MessageBox.Show("Please enter a valid amount"); return; }
                            using (MySqlCommand add = new MySqlCommand(addProduct, conn))
                            {
                                add.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                add.Parameters.AddWithValue("@ProductName", lblProdName.Text);
                                add.Parameters.AddWithValue("@ProductAmount", tbAmount.Text);
                                add.Parameters.AddWithValue("@ProductPrice", _price);
                                add.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                add.ExecuteNonQuery();
                            }
                            _Total = _Total + double.Parse(reader["ProductAmount"].ToString()) * double.Parse(reader["ProductPrice"].ToString());
                            tbTotal.Text = _Total.ToString();
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                MessageBox.Show("No product to add");
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                tempSales("delete", tbBarcode.Text);
            }
            else
            {
                MessageBox.Show("No selected row");
            }
        }

        private void tbCash_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (!string.IsNullOrWhiteSpace(tbCash.Text))
                {
                    try
                    {
                        double cash;
                        double.TryParse(tbCash.Text, out cash);
                        tbChange.Text = (cash - _Total).ToString();
                    }
                    catch { MessageBox.Show("Please enter a valid amount"); }
                }
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null) 
            {
                string ProductBarcode = dgvOrders.CurrentRow.Cells["Barcode"].Value?.ToString();
                LoadProduct(ProductBarcode);
            }
        }
        
        //LoadOrderList()
    }
}

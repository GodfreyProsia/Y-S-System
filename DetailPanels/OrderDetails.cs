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
        string _unit;
        double _amount;
        double _Total = 0;
        public OrderDetails()
        {
            InitializeComponent();
            LoadOrderList();
            Total();
            btnAdd.Visible = false;
        }
        public void LoadProduct(string ProductBarcode)
        {
            tbAmount.Text = "1";
            double.TryParse(tbBarcode.Text, out _amount);
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
                        _unit = reader["ProductUnit"].ToString();
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
                conn.Close();
                btnAdd.Visible = true;
                btnAdd.Text = "Add";
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
                    if (double.TryParse(tbAmount.Text, out _amount))
                    {
                        tempSales("add", tbBarcode.Text);
                        clearFields();
                        LoadOrderList();
                    }
                    else { MessageBox.Show("Please enter a valid amount"); }
                }
            }
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbBarcode.Text) && !string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                if (double.TryParse(tbAmount.Text, out _amount))
                {
                    tempSales("add", tbBarcode.Text);
                    clearFields();
                    LoadOrderList();
                }
                else
                {
                    MessageBox.Show("Please enter a valid amount");
                }
            }
            else
            {
                MessageBox.Show("No product to add");
            }
        }
        public void tempSales(string mode, string ProductBarcode)
        {
            if (!string.IsNullOrWhiteSpace(tbBarcode.Text) && !string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                string checkItem = "SELECT * FROM `yarnstitchdata`.`tempsales` " +
                    "WHERE (`ProductBarcode` = @ProductBarcode)";
                string updateAmount = "UPDATE `yarnstitchdata`.`tempsales` " +
                    "SET `ProductAmount` = @ProductAmount, `ProductTotal` = @ProductTotal " +
                    "WHERE `ProductBarcode` = @ProductBarcode";
                string addProduct = "INSERT INTO `yarnstitchdata`.`tempsales` " +
                    "(`ProductBarcode`, `ProductName`, `ProductAmount`, `ProductPrice`, `ProductUnit`, `ProductTotal`) " +
                    "VALUES (@ProductBarcode, @ProductName, @ProductAmount, @ProductPrice, @ProductUnit, @ProductTotal)";
                string deleteOrder = "DELETE FROM `yarnstitchdata`.`tempsales` WHERE `ProductBarcode` = @ProductBarcode";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(checkItem, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            if (btnAdd.Text == "Add")
                            {
                                double pastAmount;
                                double.TryParse(reader["ProductAmount"].ToString(), out pastAmount);
                                reader.Close();
                                try { double.TryParse(tbAmount.Text, out _amount); }
                                catch { MessageBox.Show("Please enter a valid amount"); return; }
                                using (MySqlCommand update = new MySqlCommand(updateAmount, conn))
                                {
                                    update.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    update.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                    update.Parameters.AddWithValue("@ProductAmount", _amount+pastAmount);
                                    update.ExecuteNonQuery();
                                }
                            }

                            if (btnAdd.Text == "Update")
                            {
                                double pastAmount;
                                double.TryParse(reader["ProductAmount"].ToString(), out pastAmount);
                                reader.Close();
                                try { double.TryParse(tbAmount.Text, out _amount); }
                                catch { MessageBox.Show("Please enter a valid amount"); return; }
                                using (MySqlCommand update = new MySqlCommand(updateAmount, conn))
                                {
                                    update.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    update.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                    update.Parameters.AddWithValue("@ProductAmount", _amount);
                                    update.ExecuteNonQuery();
                                }
                            }
                            else if (mode == "delete")
                            {
                                reader.Close();
                                using (MySqlCommand delete = new MySqlCommand(deleteOrder, conn))
                                {
                                    delete.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    delete.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (mode == "add")
                        {
                            reader.Close();
                            try { double.TryParse(tbAmount.Text, out _amount); }
                            catch { MessageBox.Show("Please enter a valid amount"); return; }
                            using (MySqlCommand add = new MySqlCommand(addProduct, conn))
                            {
                                add.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                add.Parameters.AddWithValue("@ProductName", lblProdName.Text);
                                add.Parameters.AddWithValue("@ProductAmount", tbAmount.Text);
                                add.Parameters.AddWithValue("@ProductPrice", _price);
                                add.Parameters.AddWithValue("@ProductUnit", _unit);
                                add.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                add.ExecuteNonQuery();
                            }
                        }
                    }
                    conn.Close();
                    Total();
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
                clearFields();
            }
            else
            {
                MessageBox.Show("No selected row");
            }
            LoadOrderList();
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
        public void LoadOrderList()
        {
            string loadOrders = "SELECT * FROM `yarnstitchdata`.`tempsales`";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(loadOrders, conn))
            {
                conn.Open();
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    dgvOrders.DataSource = dt;
                }
                conn.Close();
            }
            dgvOrders.Columns["ProductBarcode"].HeaderText = "Barcode";
            dgvOrders.Columns["ProductName"].HeaderText = "Product";
            dgvOrders.Columns["ProductAmount"].HeaderText = "Amount";
            dgvOrders.Columns["ProductPrice"].HeaderText = "Price";
            dgvOrders.Columns["ProductUnit"].HeaderText = "Unit";
            dgvOrders.Columns["ProductTotal"].HeaderText = "Total";

        }
        public void clearFields()
        {
            tbBarcode.Text = "";
            tbAmount.Text = "";
            lblProdName.Text = "Name";
            lblPrice.Text = "Price";
            pbProdPic.Image = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
            btnAdd.Visible = false;
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.Columns.Contains("ProductBarcode"))
            {
                string ProductBarcode = dgvOrders.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
                LoadProductFromDGV(ProductBarcode);
            }
        }
        public void LoadProductFromDGV(string ProductBarcode)
        {
            tbBarcode.Text = ProductBarcode;
            string prodLoad = "SELECT * FROM `yarnstitchdata`.`tempsales` WHERE (`ProductBarcode` = @ProductBarcode)";
            string picLoad = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode)";
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
                        _unit = reader["ProductUnit"].ToString();
                        tbAmount.Text = reader["ProductAmount"].ToString();
                        reader.Close();
                        using (MySqlCommand pic = new MySqlCommand(picLoad, conn))
                        {
                            pic.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                            using (MySqlDataReader readerpic = pic.ExecuteReader())
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
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("Product Not Found"); //make error
                    }
                }
                btnAdd.Visible = true;
                btnAdd.Text = "Update";
            }
        }
        public void Total()
        {
            string loadTotal = "SELECT SUM(`ProductTotal`) FROM `yarnstitchdata`.`tempsales`";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(loadTotal, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double.TryParse(reader[0].ToString(), out _Total);
                        tbTotal.Text = _Total.ToString();
                    }
                }
                conn.Close();
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(tbCash.Text)&&!string.IsNullOrWhiteSpace(tbChange.Text))
            {
                Random random = new Random();
                long randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                while (checkOrderID(randomNumber.ToString()) == false)
                {
                    randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                }
                string OrderID = randomNumber.ToString();
                
                string date = DateTime.Now.ToString("yyyy-MM-dd");
                double cash, change;
                double.TryParse(tbCash.Text, out cash);
                double.TryParse(tbChange.Text, out change);

                string addOrder = "INSERT INTO `yarnstitchdata`.`sales` " +
                    "(`OrderID` ,`Date`, `Cash`, `Change`, `Total`) " +
                    "VALUES (@OrderID, @Date, @Cash, @Change, @Total)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(addOrder, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Cash", cash);
                    cmd.Parameters.AddWithValue("@Change", change);
                    cmd.Parameters.AddWithValue("@Total", _Total);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string addSales = "INSERT INTO `yarnstitchdata`.`salesdetails` " +
                    "(`OrderID`, `ProductBarcode`, `ProductName`, `Amount`, `ProductPrice`, `ProductUnit`, `Total`) " +
                    "VALUES (@OrderID, @ProductBarcode, @ProductName, @Amount, @ProductPrice, @ProductUnit, @Total)";
               
                conn.Open(); 
                
                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.IsNewRow) continue; 
                
                    using (MySqlCommand cmd = new MySqlCommand(addSales, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@ProductBarcode", Convert.ToString(row.Cells["ProductBarcode"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductName", Convert.ToString(row.Cells["ProductName"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToString(row.Cells["ProductAmount"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductPrice", Convert.ToString(row.Cells["ProductPrice"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductUnit", Convert.ToString(row.Cells["ProductUnit"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Total", Convert.ToString(row.Cells["ProductTotal"].Value) ?? "");
                
                        cmd.ExecuteNonQuery(); 
                    }
                }
                conn.Close();
               
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand("TRUNCATE TABLE `yarnstitchdata`.`tempsales`", conn))
                    {
                        cmd.ExecuteNonQuery();
                    }
                    conn.Close();

                clearFields();
                LoadOrderList();
                tbCash.Text = "";
                tbChange.Text = "";
                tbTotal.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter cash and change");
            }
        }
        public bool checkOrderID(string RandomNum)
        {
            string checkOrderID = "SELECT * FROM `yarnstitchdata`.`sales` WHERE (`OrderID` = @OrderID)";
            MySqlConnection conn = new MySqlConnection(connstring);
            using(MySqlCommand cmd = new MySqlCommand(checkOrderID, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@OrderID", RandomNum);
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        conn.Close();
                        return false;
                    }
                    else
                    {
                        conn.Close();
                        return true;
                    }
                }
            }
        }

    }
}

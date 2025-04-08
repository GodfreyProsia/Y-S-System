using MySql.Data.MySqlClient;
using Mysqlx.Crud;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Schema;
using Y_S_System.MidPanels;
using Y_S_System;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.VisualBasic;

namespace Y_S_System.DetailPanels
{
    public partial class OrderDetails : Form
    {
        string connstring = connection.connstring;
        double _price;
        string _unit;
        double _amount;
        double _Total = 0;
        int _ID;
        public OrderDetails(int ID)
        {
            InitializeComponent();
            Total();
            btnAdd.Visible = false;
            _ID = ID;
            if(ID == 1)
            {
                btnMode.Visible = true;
                lblOrderID.Visible = false;
            }
            else
            {
                btnMode.Visible = false;
                lblOrderID.Visible = false;
            }
            LoadOrderList(null);
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
        }//Enter Key for Barcode
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
                        LoadOrderList(null);
                    }
                    else { MessageBox.Show("Please enter a valid amount"); }
                }
            }
        }//Enter Key for Amount
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbBarcode.Text) && !string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                if (double.TryParse(tbAmount.Text, out _amount))
                {
                    tempSales("add", tbBarcode.Text);
                    clearFields();
                    LoadOrderList(null);
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
        }//Add Button
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvOrders.CurrentRow != null)
            {
                tempSales("delete", tbBarcode.Text);
                clearFields();
                LoadOrderList(null);
            }
            else
            {
                MessageBox.Show("No selected row");
            }
        }//Delete Button
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
        }//Enter Key for Cash
        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.Columns.Contains("ProductBarcode") && lblOrderID.Visible == false)
            {
                string ProductBarcode = dgvOrders.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
                LoadProductFromDGV(ProductBarcode, null);
            }
            else if (dgvOrders.CurrentRow != null && dgvOrders.Columns.Contains("ProductBarcode")  && lblOrderID.Visible == true)
            {
                string ProductBarcode = dgvOrders.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
                LoadProductFromDGV(ProductBarcode, lblOrderID.Text);
            }

        }//Load Product from DGV
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitOrder();
            foreach (var productView in Application.OpenForms.OfType<ProductView>())
            {
                productView.LoadProduct(null);
            }

        }//Submit Button
        public void SubmitOrder()
        {
            double Change;
            double.TryParse(tbChange.Text, out Change);
            if (!string.IsNullOrWhiteSpace(tbCash.Text) && !string.IsNullOrWhiteSpace(tbChange.Text) && Change >= 0 && btnMode.Text == "Cashier Mode")

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
                    "(`OrderID` ,`Date`, `Cash`, `Change`, `Total`, `Terminal`) " +
                    "VALUES (@OrderID, @Date, @Cash, @Change, @Total, @Terminal)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(addOrder, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    cmd.Parameters.AddWithValue("@Date", date);
                    cmd.Parameters.AddWithValue("@Cash", cash);
                    cmd.Parameters.AddWithValue("@Change", change);
                    cmd.Parameters.AddWithValue("@Total", _Total);
                    cmd.Parameters.AddWithValue("@Terminal", _ID);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string addSales = "INSERT INTO `yarnstitchdata`.`salesdetails` " +
                    "(`OrderID`, `ProductBarcode`, `Date`, `ProductName`, `Amount`, `ProductPrice`, `ProductUnit`, `Total`) " +
                    "VALUES (@OrderID, @ProductBarcode, @Date, @ProductName, @Amount, @ProductPrice, @ProductUnit, @Total)";

                conn.Open();

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.IsNewRow) continue;

                    using (MySqlCommand cmd = new MySqlCommand(addSales, conn))
                    {
                        cmd.Parameters.AddWithValue("@OrderID", OrderID);
                        cmd.Parameters.AddWithValue("@ProductBarcode", Convert.ToString(row.Cells["ProductBarcode"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductName", Convert.ToString(row.Cells["ProductName"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Date", date);
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToString(row.Cells["ProductAmount"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductPrice", Convert.ToString(row.Cells["ProductPrice"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductUnit", Convert.ToString(row.Cells["ProductUnit"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Total", Convert.ToString(row.Cells["ProductTotal"].Value) ?? "");

                        cmd.ExecuteNonQuery();
                    }
                }
                conn.Close();

                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand("DELETE FROM `yarnstitchdata`.`tempsales` WHERE `AccountID` = @AccountID", conn))
                {
                    cmd.Parameters.AddWithValue("@AccountID", _ID);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                clearFields();
                LoadOrderList(null);
                tbCash.Text = "";
                tbChange.Text = "";
                tbTotal.Text = "";
            }
            else if (!string.IsNullOrWhiteSpace(tbCash.Text) && !string.IsNullOrWhiteSpace(tbChange.Text) && Change >= 0 && btnMode.Text == "Admin Mode")
            {
                MySqlConnection conn = new MySqlConnection(connstring);
                string Status = "UPDATE `yarnstitchdata`.`sales` " +
                    "SET `Status` = 'Paid', `Cash` = @Cash, `Change` = @Change, `Total` = @Total " +
                    "WHERE `OrderID` = @OrderID";
                string StatusDetails = "UPDATE `yarnstitchdata`.`salesdetails` " +
                    "SET `Status` = 'Paid' " +
                    "WHERE `OrderID` = @OrderID";
                double cash, change;
                double.TryParse(tbCash.Text, out cash);
                double.TryParse(tbChange.Text, out change);
                double.TryParse(tbTotal.Text, out _Total);
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(Status, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", lblOrderID.Text);
                    cmd.Parameters.AddWithValue("@Cash", cash);
                    cmd.Parameters.AddWithValue("@Change", change);
                    cmd.Parameters.AddWithValue("@Total", _Total);
                    cmd.ExecuteNonQuery();
                }
                using (MySqlCommand cmd = new MySqlCommand(StatusDetails, conn))
                {
                    cmd.Parameters.AddWithValue("@OrderID", lblOrderID.Text);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();

                string addFinnance = "UPDATE `yarnstitchdata`.`finnancesales` " +
                    "SET `ProductSold` = `ProductSold` + @ProductSold " +
                    "WHERE `ProductBarcode` = @ProductBarcode";
                string updateTotalStock = "UPDATE `yarnstitchdata`.`products` " +
                    "SET `ProductStock` = `ProductStock` - @Amount " +
                    "WHERE `ProductBarcode` = @ProductBarcode";
                string updateTotalFinnance = "UPDATE `yarnstitchdata`.`finnancesales` " +
                    "SET `ProductTotal` = `ProductTotal` + @ProductTotal " +
                    "WHERE `ProductBarcode` = @ProductBarcode";

                conn.Open();

                foreach (DataGridViewRow row in dgvOrders.Rows)
                {
                    if (row.IsNewRow) continue;

                    using (MySqlCommand cmd = new MySqlCommand(addFinnance, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductBarcode", Convert.ToString(row.Cells["ProductBarcode"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductSold", Convert.ToString(row.Cells["ProductAmount"].Value) ?? "");
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(updateTotalFinnance, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductBarcode", Convert.ToString(row.Cells["ProductBarcode"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@ProductTotal", Convert.ToString(row.Cells["ProductTotal"].Value) ?? "");
                        cmd.ExecuteNonQuery();
                    }
                    using (MySqlCommand cmd = new MySqlCommand(updateTotalStock, conn))
                    {
                        cmd.Parameters.AddWithValue("@ProductBarcode", Convert.ToString(row.Cells["ProductBarcode"].Value) ?? "");
                        cmd.Parameters.AddWithValue("@Amount", Convert.ToString(row.Cells["ProductAmount"].Value) ?? "");
                        cmd.ExecuteNonQuery();
                    }
                }

                conn.Close();
                foreach (var adminOrderView in Application.OpenForms.OfType<AdminOrderView>())
                {
                    adminOrderView.LoadPendingOrders();
                }

                clearFields();
                LoadOrderList(null);
                tbCash.Text = "";
                tbChange.Text = "";
                tbTotal.Text = "";
            }
            else
            {
                MessageBox.Show("Please enter the right amount of cash");
            }
        }//Submit Order to Database
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
                        lblPrice.Text = "Php "+ reader["ProductPrice"].ToString() + " Per " + reader["ProductUnit"].ToString();
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
        }//Load Product from Database
        public void tempSales(string mode, string ProductBarcode)
        {
            if (!string.IsNullOrWhiteSpace(tbBarcode.Text) && !string.IsNullOrWhiteSpace(tbAmount.Text))
            {
                string checkItem = "SELECT * FROM `yarnstitchdata`.`tempsales` " +
                    "WHERE (`ProductBarcode` = @ProductBarcode AND `AccountID` = @AccountID)";
                string updateAmount = "UPDATE `yarnstitchdata`.`tempsales` " +
                    "SET `ProductAmount` = @ProductAmount, `ProductTotal` = @ProductTotal " +
                    "WHERE (`ProductBarcode` = @ProductBarcode AND `AccountID` = @AccountID)";
                string addProduct = "INSERT INTO `yarnstitchdata`.`tempsales` " +
                    "(`ProductBarcode`, `ProductName`, `ProductAmount`, `ProductPrice`, `ProductUnit`, `ProductTotal`, `AccountID`) " +
                    "VALUES (@ProductBarcode, @ProductName, @ProductAmount, @ProductPrice, @ProductUnit, @ProductTotal, @AccountID)";
                string deleteOrder = "DELETE FROM `yarnstitchdata`.`tempsales` WHERE (`ProductBarcode` = @ProductBarcode AND `AccountID` = @AccountID)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(checkItem, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                    cmd.Parameters.AddWithValue("@AccountID", _ID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            double pastAmount;
                            double.TryParse(reader["ProductAmount"].ToString(), out pastAmount);
                            try { double.TryParse(tbAmount.Text, out _amount); }
                            catch { MessageBox.Show("Please enter a valid amount"); return; }
                            if (_amount <= 0) { MessageBox.Show("Please enter a valid amount"); return; }
                            
                            reader.Close();
                            if (btnAdd.Text == "Add")
                            {
                                if (checkStock(ProductBarcode, _amount + pastAmount) == false) { MessageBox.Show("Not enough stock"); return; }
                                using (MySqlCommand update = new MySqlCommand(updateAmount, conn))
                                {
                                    update.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    update.Parameters.AddWithValue("@AccountID", _ID);
                                    update.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                    update.Parameters.AddWithValue("@ProductAmount", _amount + pastAmount);
                                    update.ExecuteNonQuery();
                                }
                            }
                            else if (mode == "delete")
                            {
                                using (MySqlCommand delete = new MySqlCommand(deleteOrder, conn))
                                {
                                    delete.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    delete.Parameters.AddWithValue("@AccountID", _ID);
                                    delete.ExecuteNonQuery();
                                }
                            }
                            else if (btnAdd.Text == "Update" && mode != "delete")
                            {
                                if (checkStock(ProductBarcode, _amount) == false) { MessageBox.Show("Not enough stock"); return; }
                                using (MySqlCommand update = new MySqlCommand(updateAmount, conn))
                                {
                                    update.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                    update.Parameters.AddWithValue("@AccountID", _ID);
                                    update.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                    update.Parameters.AddWithValue("@ProductAmount", _amount);
                                    update.ExecuteNonQuery();
                                }
                            }
                        }
                        else if (mode == "add")
                        {
                            reader.Close();
                            try { double.TryParse(tbAmount.Text, out _amount); }
                            catch { MessageBox.Show("Please enter a valid amount"); return; }
                            if (_amount <= 0) { MessageBox.Show("Please enter a valid amount"); return; }
                            if (checkStock(ProductBarcode, _amount) == false) { MessageBox.Show("Not enough stock"); return; }
                            using (MySqlCommand add = new MySqlCommand(addProduct, conn))
                            {
                                add.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                                add.Parameters.AddWithValue("@ProductName", lblProdName.Text);
                                add.Parameters.AddWithValue("@ProductAmount", tbAmount.Text);
                                add.Parameters.AddWithValue("@ProductPrice", _price);
                                add.Parameters.AddWithValue("@ProductUnit", _unit);
                                add.Parameters.AddWithValue("@ProductTotal", _price * _amount);
                                add.Parameters.AddWithValue("@AccountID", _ID);
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
        }//Add, Update, Delete in TempSales
        public void LoadOrderList(string OrderID)
        {
            dgvOrders.Rows.Clear();
            MySqlConnection conn = new MySqlConnection(connstring);
            
            if(!string.IsNullOrEmpty(OrderID))
            {
                
                string loadTotal = "SELECT * FROM `yarnstitchdata`.`sales` WHERE `OrderID` = @OrderID";
                string loadOrders = "SELECT * FROM `yarnstitchdata`.`salesdetails` WHERE `OrderID` = @OrderID";
                using (MySqlCommand cmd = new MySqlCommand(loadTotal, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tbCash.Text = reader["Cash"].ToString();
                            tbChange.Text = reader["Change"].ToString();
                            tbTotal.Text = reader["Total"].ToString();
                            lblOrderID.Text = OrderID;
                        }
                    }
                    using(MySqlCommand cmd2 = new MySqlCommand(loadOrders, conn))
                    {
                        cmd2.Parameters.AddWithValue("@OrderID", OrderID);
                        using (MySqlDataReader reader = cmd2.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvOrders.Rows.Add(reader["ProductBarcode"].ToString(), reader["ProductName"].ToString(), reader["Amount"].ToString(), reader["ProductPrice"].ToString(), reader["ProductUnit"].ToString(), reader["Total"].ToString());
                            }
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                string loadOrders = "SELECT * FROM `yarnstitchdata`.`tempsales` WHERE `AccountID` = @AccountID";

                using (MySqlCommand cmd = new MySqlCommand(loadOrders, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@AccountID", _ID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvOrders.Rows.Add(reader["ProductBarcode"].ToString(), reader["ProductName"].ToString(), reader["ProductAmount"].ToString(), reader["ProductPrice"].ToString(), reader["ProductUnit"].ToString(), reader["ProductTotal"].ToString());
                        }
                    }
                }
            }

        }//Load Orders in DGV
        public void clearFields()
        {
            tbBarcode.Text = "";
            tbAmount.Text = "";
            lblProdName.Text = "Name";
            lblPrice.Text = "Price";
            pbProdPic.Image = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
            btnAdd.Visible = false;
        }//Clear Fields
        public void LoadProductFromDGV(string ProductBarcode, string OrderID)
        {
            tbBarcode.Text = ProductBarcode;
            if (string.IsNullOrEmpty(OrderID))
            {
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
            else
            {
                string prodLoad = "SELECT * FROM `yarnstitchdata`.`salesdetails` WHERE (`ProductBarcode` = @ProductBarcode AND `OrderID` = @OrderID)";
                string picLoad = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(prodLoad, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                    cmd.Parameters.AddWithValue("@OrderID", OrderID);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            lblProdName.Text = reader["ProductName"].ToString();
                            lblPrice.Text = reader["ProductPrice"].ToString() + " Per " + reader["ProductUnit"].ToString();
                            double.TryParse(reader["ProductPrice"].ToString(), out _price);
                            _unit = reader["ProductUnit"].ToString();
                            tbAmount.Text = reader["Amount"].ToString();
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
        }//Load Product from DGV
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
        }//Calculate Total
        public bool checkOrderID(string RandomNum)
        {
            string checkOrderID = "SELECT * FROM `yarnstitchdata`.`sales` WHERE (`OrderID` = @OrderID)";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(checkOrderID, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@OrderID", RandomNum);
                using (MySqlDataReader reader = cmd.ExecuteReader())
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
        }//Check if OrderID exists
        public bool checkStock(string Barcode, double amount)
        {
            string checkStock = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode)";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(checkStock, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ProductBarcode", Barcode);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        double stock;
                        double.TryParse(reader["ProductStock"].ToString(), out stock);

                        if (stock < amount)
                        {
                            return false;
                        }
                        else
                        {
                            return true;
                        }
                    }
                    else
                    {
                        return false;
                    }
                }
            }
        }//Check if stock is enough
        private void btnMode_Click(object sender, EventArgs e)
        {
            
            if (btnMode.Text == "Cashier Mode")
            {
                btnMode.Text = "Admin Mode";
                btnMode.BackColor = Color.FromArgb(208, 72, 72);
                LoadOrderList(null);
                clearFields();
                lblOrderID.Visible = true;
                btnSubmit.Text = "Accept";
                //btnDecline.Visible = true;
                var openForms = Application.OpenForms.OfType<Home>().ToList();
                foreach (var home in openForms)
                {
                    home.AdminOrderMode();
                }
            }
            else
            {
                btnMode.Text = "Cashier Mode";
                btnMode.BackColor = Color.FromArgb(110, 172, 218);
                var openForms = Application.OpenForms.OfType<Home>().ToList();
                foreach (var home in openForms)
                {
                    home.AdminCashierMode();
                }
            }
        }//Changes to AdminMode to accept Orders
    }
}

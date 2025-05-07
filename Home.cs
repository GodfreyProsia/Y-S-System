using CustomControls.RJControls;
using MySql.Data.MySqlClient;
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
using Y_S_System.DetailPanels;
using Y_S_System.MidPanels;

namespace Y_S_System
{
    public partial class Home : Form
    {
        string connstring = connection.connstring;
        public static Home instance;
        public string _role;
        public int _logkey;
        public static MAIN instance1;
        public MAIN _main;
        public Home(string role, int logkey, MAIN main)
        {
            _logkey = logkey;
            _role = role;
            _main = main;
            InitializeComponent();
            loadRpanel(new OrderDetails(_logkey));
            loadMpanel(new ProductView(0));

            if (_role == "Cashier")
            {
                btnFinnance.Visible = false;
                btnProducts.Visible = false;
            }

        }
        private void loadRpanel(object Form) //loads the right panel
        {
            if (RightPanel.Controls.Count > 0)
            {
                Form previousForm = RightPanel.Controls[0] as Form;
                if (previousForm != null)
                {
                    previousForm.Close();
                    previousForm.Dispose();
                }
            }
            if (MidPanel.Controls.Count > 0)
            {
                MidPanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            RightPanel.Controls.Add(f);
            RightPanel.Tag = f;
            f.Show();
        }
        private void loadMpanel(object Form)//loads the middle panel
        {
            if (MidPanel.Controls.Count > 0)
            {
                Form previousForm = MidPanel.Controls[0] as Form;
                if (previousForm != null)
                {
                    previousForm.Close();
                    previousForm.Dispose();
                }
            }
            if (MidPanel.Controls.Count > 0)
            {
                MidPanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            MidPanel.Controls.Add(f);
            MidPanel.Tag = f;
            f.Show();
        }
        private void tabChange(RJButton button)//changes the color of the button when clicked
        {
            btnHome.ForeColor = Color.White;
            btnInventory.ForeColor = Color.White;
            btnSales.ForeColor = Color.White;
            btnProducts.ForeColor = Color.White;
            btnFinnance.ForeColor = Color.White;
            button.ForeColor = Color.FromArgb(110, 172, 218);//set the color of the button to green
            btnHome.BorderColor = Color.Transparent;
            btnInventory.BorderColor = Color.Transparent;
            btnSales.BorderColor = Color.Transparent;
            btnProducts.BorderColor = Color.Transparent;
            btnFinnance.BorderColor = Color.Transparent;
            button.BorderColor = Color.FromArgb(110, 172, 218);//set the border color of the button to green
        }
        private void btnHome_Click(object sender, EventArgs e)
        {
            AdminCashierMode();
        }
        private void btnInventory_Click(object sender, EventArgs e)
        {
            loadRpanel(new ProductDetails(_role, 1, _logkey));
            loadMpanel(new InventoryView());
            tabChange(btnInventory);
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            loadRpanel(new SaleDetails(_logkey, _role));
            loadMpanel(new SalesView());
            tabChange(btnSales);
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            loadRpanel(new ProductDetails(_role, 2, _logkey));
            loadMpanel(new ProductView(1));
            tabChange(btnProducts);
        }
        private void btnFinnance_Click(object sender, EventArgs e)
        {
            loadRpanel(new FinnanceDetails());
            loadMpanel(new FinnanceView());
            tabChange(btnFinnance);
        }
        public void AdminOrderMode()
        {
            loadMpanel(new AdminOrderView());
            tabChange(btnHome);
        }//changes the middle panel to the order view
        public void AdminCashierMode()
        {
            loadRpanel(new OrderDetails(_logkey));
            loadMpanel(new ProductView(0));
            tabChange(btnHome);
        }//changes the middle panel to the order view

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            _main.loadpage(new Login(_main));
        }//logout button

        List<string> ProductLow = new List<string>();
        List<string> Pending = new List<string>();
        private void NotificationTimer_Tick(object sender, EventArgs e)
        {
            string readStocks = "SELECT * FROM `yarnstitchdata`.`products`";

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(readStocks, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double stock;
                            double.TryParse(reader["ProductStock"].ToString(), out stock);
                            if (stock <= 10)
                            {
                                string barcode = reader["ProductBarcode"].ToString();

                                if (!ProductLow.Contains(barcode))
                                {
                                    ProductLow.Add(barcode);
                                    Notification.Icon = SystemIcons.Warning;
                                    Notification.BalloonTipIcon = ToolTipIcon.Warning;
                                    Notification.Visible = true;
                                    Notification.BalloonTipTitle = "Low Stock Alert";
                                    Notification.BalloonTipText = $"Product: {reader["ProductName"]}\nLow on Stock";
                                    Notification.ShowBalloonTip(5000);
                                }
                            }
                        }
                    }
                }
            }

            string readPending = "SELECT * FROM `yarnstitchdata`.`sales`";

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(readPending, conn))
                {
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if (reader["Status"].ToString() == "Pending")
                            {
                                string orderID = reader["OrderID"].ToString();
                                if (!ProductLow.Contains(orderID))
                                {
                                    ProductLow.Add(orderID);
                                    Notification.Icon = SystemIcons.Warning;
                                    Notification.BalloonTipIcon = ToolTipIcon.Warning;
                                    Notification.Visible = true;
                                    Notification.BalloonTipTitle = "New Order!";
                                    Notification.BalloonTipText = $"OrderID: {reader["OrderID"]}";
                                    Notification.ShowBalloonTip(5000);
                                }
                            }
                        }
                    }
                }
            }
        }//Notification Timer
    }
}

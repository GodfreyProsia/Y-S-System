using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Y_S_System.DetailPanels;

namespace Y_S_System.MidPanels
{
    public partial class AdminOrderView : Form
    {
        string connstring = connection.connstring;
        private string lastHash = "";
        public AdminOrderView()
        {

            InitializeComponent();
            LoadPendingOrders();
        }
        public void LoadPendingOrders()
        {
            dgvOrders.Rows.Clear();
            string LoadPending = "SELECT * " +
                                 "FROM `yarnstitchdata`.`sales` " +
                                 "WHERE Status = 'Pending' " +
                                 "ORDER BY Date ASC;";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(LoadPending, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string orderId = reader["OrderID"].ToString();
                        string cash = reader["Cash"].ToString();
                        string total = reader["Total"].ToString();
                        string change = reader["Change"].ToString();

                        dgvOrders.Rows.Add(orderId, cash, total, change);
                    }
                }
            }
        }

        private void updateTimer_Tick(object sender, EventArgs e)
        {
            string LoadPending = "SELECT MD5(GROUP_CONCAT(CONCAT_WS('|', OrderID, Status, Date) ORDER BY Date)) AS Hash FROM `yarnstitchdata`.`sales` WHERE `Status` = 'Pending'";

            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(LoadPending, conn))
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string newHash = reader["Hash"]?.ToString();

                        if (newHash != lastHash)
                        {
                            lastHash = newHash;
                            LoadPendingOrders();
                        }
                    }
                }
            }
        }

        private void dgvOrders_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.CurrentRow != null && dgvOrders.Columns.Contains("OrderID"))
            {
                string OrderID = dgvOrders.CurrentRow.Cells["OrderID"].Value?.ToString();
                foreach (var orderDetails in Application.OpenForms.OfType<OrderDetails>())
                {
                    orderDetails.LoadOrderList(OrderID);
                }
            }
            else if (dgvOrders.CurrentRow == null)
            {
                string OrderID = dgvOrders.CurrentRow.Cells["OrderID"].Value?.ToString();
                foreach (var orderDetails in Application.OpenForms.OfType<OrderDetails>())
                {
                    orderDetails.LoadOrderList(OrderID);
                }
            }
        }
    }
}

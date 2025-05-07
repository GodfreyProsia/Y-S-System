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
using Y_S_System.DetailPanels;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Y_S_System.MidPanels
{
    public partial class SalesView : Form
    {
        string connstring = connection.connstring;
        public SalesView()
        {
            InitializeComponent();
            LoadData(null);
        }
        public void LoadData(string search)
        {
            dgvSales.Rows.Clear();
            string getSales = "SELECT * FROM `yarnstitchdata`.`sales` ORDER BY `Date` DESC;";

            string searchSales = "SELECT * FROM `yarnstitchdata`.`sales` " +
                                 "WHERE `OrderId` LIKE '%" + search + "%' " +
                                 "ORDER BY `Date` DESC;"; 
            MySqlConnection conn = new MySqlConnection(connstring);
            if (string.IsNullOrEmpty(search))
            {
                using (MySqlCommand cmd = new MySqlCommand(getSales, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSales.Rows.Add(reader["OrderId"].ToString(), reader["Date"].ToString(), reader["Cash"].ToString(), reader["Change"].ToString(), reader["Total"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                using (MySqlCommand cmd = new MySqlCommand(searchSales, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSales.Rows.Add(reader["OrderId"].ToString(), reader["Date"].ToString(), reader["Cash"].ToString(), reader["Change"].ToString(), reader["Total"].ToString());
                        }
                    }
                    conn.Close();
                }
            }
        }//Load Data

        private void tbtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadData(tbtSearch.Text);
        }//Search Text Box Handler

        private void dgvSales_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string OrderID = dgvSales.CurrentRow.Cells["OrderID"].Value?.ToString();
            if (!string.IsNullOrEmpty(OrderID))
            {
                foreach (var salesDetails in Application.OpenForms.OfType<SaleDetails>())
                {
                    salesDetails.LoadOrder(OrderID);
                }
            }
            else
            {
                foreach (var salesDetails in Application.OpenForms.OfType<SaleDetails>())
                {
                    salesDetails.LoadOrder(null);
                }
            }
        }//dgvSales Order Click

    }
}

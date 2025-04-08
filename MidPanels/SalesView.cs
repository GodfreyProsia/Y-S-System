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

namespace Y_S_System.MidPanels
{
    public partial class SalesView : Form
    {
        string connstring = connection.connstring;
        public SalesView()
        {
            InitializeComponent();
        }
        public void LoadData(string search )
        {
            dgvSales.Rows.Clear();
            string loadProduct = "SELECT * FROM `yarnstitchdata`.`products`";
            string loadSearch = "SELECT * FROM `yarnstitchdata`.`products` WHERE `ProductName` LIKE '%" + search + "%'";
            MySqlConnection conn = new MySqlConnection(connstring);
            if (string.IsNullOrEmpty(search))
            {
                using (MySqlCommand cmd = new MySqlCommand(loadProduct, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSales.Rows.Add(reader["ProductName"].ToString(),
                                "Php " + reader["ProductPrice"].ToString() + " / " + reader["ProductUnit"].ToString(),
                                reader["ProductStock"].ToString(),
                                reader["ProductBarcode"].ToString());
                        }
                    }
                }
            }
            else if (!string.IsNullOrEmpty(search))
            {
                using (MySqlCommand cmd = new MySqlCommand(loadSearch, conn))
                {
                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dgvSales.Rows.Add(reader["ProductName"].ToString(),
                                reader["ProductPrice"].ToString() + "/" + reader["ProductUnit"].ToString(),
                                reader["ProductStock"].ToString(),
                                reader["ProductBarcode"].ToString());
                        }
                    }
                }
            }
        }


        private void dgvSales_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvSales.CurrentRow != null && dgvSales.Columns.Contains("Barcode"))
            {
                string ProductBarcode = dgvSales.CurrentRow.Cells["Barcode"].Value?.ToString();
                foreach (var productDetails in Application.OpenForms.OfType<ProductDetails>())
                {
                    productDetails.LoadProduct(ProductBarcode);
                }
            }
            else if (dgvSales.CurrentRow == null)
            {
                string ProductBarcode = dgvSales.CurrentRow.Cells["Barcode"].Value?.ToString();
                foreach (var productDetails in Application.OpenForms.OfType<ProductDetails>())
                {
                    productDetails.clearFields();
                }
            }
        }

        private void tbtSearch_TextChanged_1(object sender, EventArgs e)
        {
            LoadData(tbtSearch.Text);
        }
    }
}

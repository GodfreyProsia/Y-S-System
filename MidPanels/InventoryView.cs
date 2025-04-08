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
using MySql.Data.MySqlClient;

namespace Y_S_System.MidPanels
{
    public partial class InventoryView : Form
    {
        string connstring = connection.connstring;
        public InventoryView()
        {
            InitializeComponent();
            LoadData(null);
        }
        public void LoadData(string search)
        {
            dgvInventory.Rows.Clear();
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
                            dgvInventory.Rows.Add(reader["ProductName"].ToString(),
                                "Php "+ reader["ProductPrice"].ToString() + " / " + reader["ProductUnit"].ToString(),
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
                            dgvInventory.Rows.Add(reader["ProductName"].ToString(),
                                reader["ProductPrice"].ToString() + "/" + reader["ProductUnit"].ToString(),
                                reader["ProductStock"].ToString(),
                                reader["ProductBarcode"].ToString());
                        }
                    }
                }
            }
        }

        private void dgvInventory_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvInventory.CurrentRow != null && dgvInventory.Columns.Contains("Barcode"))
            {
                string ProductBarcode = dgvInventory.CurrentRow.Cells["Barcode"].Value?.ToString();
                foreach (var productDetails in Application.OpenForms.OfType<ProductDetails>())
                {
                    productDetails.LoadProduct(ProductBarcode);
                }
            }
            else if (dgvInventory.CurrentRow == null)
            {
                string ProductBarcode = dgvInventory.CurrentRow.Cells["Barcode"].Value?.ToString();
                foreach (var productDetails in Application.OpenForms.OfType<ProductDetails>())
                {
                    productDetails.clearFields();
                }
            }
        }

        private void tbtSearch_TextChanged(object sender, EventArgs e)
        {
            LoadData(tbtSearch.Text);
        }
    }
}

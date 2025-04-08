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
using ZXing.QrCode.Internal;

namespace Y_S_System.MidPanels
{
    public partial class FinnanceView : Form
    {
        string connstring = connection.connstring;
        public FinnanceView()
        {
            InitializeComponent();
            LoadProducts(null);
        }
        public void LoadProducts(string search)
        {
            dgvFinnance.Rows.Clear();
            string LoadSearch = "SELECT p.ProductBarcode, " +
                                "       p.ProductName, " +
                                "       p.ProductPrice, " +
                                "       p.ProductUnit, " +
                                "       COALESCE(SUM(s.Amount), 0) AS TotalSold " +
                                "FROM `yarnstitchdata`.`products` p " +
                                "LEFT JOIN `yarnstitchdata`.`salesdetails` s " +
                                "ON p.ProductBarcode = s.ProductBarcode " +
                                "AND s.Status = 'Paid' AND s.Date BETWEEN @StartDate AND @EndDate " +
                                "WHERE p.ProductName LIKE '%" + search + "%' " +
                                "OR p.ProductBarcode LIKE '%" + search + "%' " +
                                "GROUP BY p.ProductBarcode, p.ProductName, p.ProductPrice, p.ProductUnit;";
            string GetTotalSales = "SELECT p.ProductBarcode, " +
                                   "       p.ProductName, " +
                                   "       p.ProductPrice, " +
                                   "       p.ProductUnit, " +
                                   "       COALESCE(SUM(s.Amount), 0) AS TotalSold " +
                                   "FROM `yarnstitchdata`.`products` p " +
                                   "LEFT JOIN `yarnstitchdata`.`salesdetails` s " +
                                   "ON p.ProductBarcode = s.ProductBarcode " +
                                   "AND s.Status = 'Paid' AND s.Date  BETWEEN @StartDate AND @EndDate " +
                                   "GROUP BY p.ProductBarcode, p.ProductName, p.ProductPrice, p.ProductUnit;";
            string Totalsold = "SELECT SUM(s.Amount) AS TotalSold, SUM(s.Total) AS Total " +
                              "FROM `yarnstitchdata`.`salesdetails` s " +
                              "WHERE s.Status = 'Paid' AND s.Date  BETWEEN @StartDate AND @EndDate;";

            MySqlConnection conn = new MySqlConnection(connstring);
            if (string.IsNullOrEmpty(search))
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(GetTotalSales, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", date1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", date2.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Barcode = reader["ProductBarcode"].ToString();
                            string Name = reader["ProductName"].ToString();
                            double Price = Convert.ToDouble(reader["ProductPrice"]);
                            string Unit = reader["ProductUnit"].ToString();
                            double Sold = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
                            double Total = Sold * Price;

                            dgvFinnance.Rows.Add(Barcode, Name, $"Php {Price:N2} / {Unit}", Sold.ToString(), $"Php {Total:N2}");
                        }
                    }
                }
                using (MySqlCommand cmd = new MySqlCommand(Totalsold, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", date1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", date2.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double TotalSold = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            double Total = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);

                            tbNoSales.Text = TotalSold.ToString("F2");
                            tbTotalSales.Text = $"Php {Total:N2}";
                        }
                    }
                }
                conn.Close();

            }
            else
            {
                conn.Open();
                using (MySqlCommand cmd = new MySqlCommand(LoadSearch, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", date1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", date2.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string Barcode = reader["ProductBarcode"].ToString();
                            string Name = reader["ProductName"].ToString();
                            double Price = Convert.ToDouble(reader["ProductPrice"]);
                            string Unit = reader["ProductUnit"].ToString();
                            double Sold = reader.IsDBNull(4) ? 0 : reader.GetDouble(4);
                            double Total = Sold * Price;

                            dgvFinnance.Rows.Add(Barcode, Name, $"Php {Price:N2} / {Unit}", Sold.ToString(), $"Php {Total:N2}");
                        }
                    }
                }
                
                using (MySqlCommand cmd = new MySqlCommand(Totalsold, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", date1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", date2.Value.ToString("yyyy-MM-dd"));

                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            double TotalSold = reader.IsDBNull(0) ? 0 : reader.GetDouble(0);
                            double Total = reader.IsDBNull(1) ? 0 : reader.GetDouble(1);

                            tbNoSales.Text = TotalSold.ToString("F2");
                            tbTotalSales.Text = $"Php {Total:N2}";
                        }
                    }
                }
                conn.Close();
            }


        }

        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
        }

        private void dgvFinnance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvFinnance.CurrentRow != null && dgvFinnance.Columns.Contains("ProductBarcode"))
            {
                string FinnanceBarcode = dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
                foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
                {
                    finnanceDetails.LoadProduct(FinnanceBarcode, date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
                }
            }
            else if (dgvFinnance.CurrentRow == null)
            {
                string FinnanceBarcode = dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
                foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
                {
                    finnanceDetails.clearFields();
                }
            }
        }

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
        }

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
        }
    }
}

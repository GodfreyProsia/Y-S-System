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
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView;
using Google.Protobuf.WellKnownTypes;
using static System.Runtime.InteropServices.JavaScript.JSType;


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
        private void dgvFinnanceChangeMode()
        {
            if (cbSortMode.Text == "Product")
            {
                dgvFinnance.Columns["ProductBarcode"].Visible = true;
                dgvFinnance.Columns["ProductName"].Visible = true;
                dgvFinnance.Columns["ProductPrice"].Visible = true;
                dgvFinnance.Columns["TotalSold"].Visible = true;
                dgvFinnance.Columns["Total"].Visible = true;
                dgvFinnance.Columns["Date"].Visible = false;
            }
            else
            {
                dgvFinnance.Columns["ProductBarcode"].Visible = false;
                dgvFinnance.Columns["ProductName"].Visible = false;
                dgvFinnance.Columns["ProductPrice"].Visible = false;
                dgvFinnance.Columns["TotalSold"].Visible = true;
                dgvFinnance.Columns["Total"].Visible = true;
                dgvFinnance.Columns["Date"].Visible = true;
            }
            foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
            {
                finnanceDetails.SetMode(cbSortMode.Text);
            }
        }//Change Mode based on the selected cbSortMode
        public void LoadProducts(string search)
        {

            dgvFinnance.Rows.Clear();
            dgvFinnanceChangeMode();
            if (cbSortMode.Text == "Product")
            {
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
                                    "GROUP BY p.ProductBarcode, p.ProductName, p.ProductPrice, p.ProductUnit " +
                                    "ORDER BY p.ProductName ASC;";

                string GetTotalSales = "SELECT p.ProductBarcode, " +
                                       "       p.ProductName, " +
                                       "       p.ProductPrice, " +
                                       "       p.ProductUnit, " +
                                       "       COALESCE(SUM(s.Amount), 0) AS TotalSold " +
                                       "FROM `yarnstitchdata`.`products` p " +
                                       "LEFT JOIN `yarnstitchdata`.`salesdetails` s " +
                                       "ON p.ProductBarcode = s.ProductBarcode " +
                                       "AND s.Status = 'Paid' AND s.Date BETWEEN @StartDate AND @EndDate " +
                                       "GROUP BY p.ProductBarcode, p.ProductName, p.ProductPrice, p.ProductUnit " +
                                       "ORDER BY p.ProductName ASC;";

                string Totalsold = "SELECT SUM(s.Amount) AS TotalSold, SUM(s.Total) AS Total " +
                                   "FROM `yarnstitchdata`.`salesdetails` s " +
                                   "WHERE s.Status = 'Paid' AND s.Date BETWEEN @StartDate AND @EndDate;";

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

                                dgvFinnance.Rows.Add(null, Barcode, Name, $"Php {Price:N2} / {Unit}", Sold.ToString(), $"Php {Total:N2}");
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

                                dgvFinnance.Rows.Add(null, Barcode, Name, $"Php {Price:N2} / {Unit}", Sold.ToString(), $"Php {Total:N2}");
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

                                tbTotalSales.Text = $"Php {Total:N2}";
                            }
                        }
                    }
                    conn.Close();
                }
            }
            else
            {
                string loadPerDay = "SELECT DATE(`Date`) AS SaleDate, SUM(`Amount`) AS TotalUnitsSold, SUM(`Total`) AS TotalSales " +
                                    "FROM `yarnstitchdata`.`salesdetails` WHERE `Status` = 'Paid' " +
                                    "AND " + setDateRange() + " GROUP BY SaleDate ORDER BY SaleDate DESC;";


                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(loadPerDay, conn))
                {
                    cmd.Parameters.AddWithValue("@StartDate", date1.Value.ToString("yyyy-MM-dd"));
                    cmd.Parameters.AddWithValue("@EndDate", date2.Value.ToString("yyyy-MM-dd"));

                    conn.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string saleDate = reader["SaleDate"].ToString();
                            DateTime parsedDate = DateTime.Parse(saleDate);
                            string formattedDate = parsedDate.ToString("yyyy-MM-dd");
                            double totalUnitsSold = Convert.ToDouble(reader["TotalUnitsSold"]);
                            double totalSales = Convert.ToDouble(reader["TotalSales"]);

                            dgvFinnance.Rows.Add(formattedDate, null, null, null, totalUnitsSold, $"Php {totalSales:N2}");
                        }
                    }
                    conn.Close();
                }
            }


        }//Load Products
        private string setDateRange()
        {
            DateTime startDate;
            DateTime endDate;

            if (cbDateRange.Text == "Monthly")
            {
                startDate = new DateTime(date1.Value.Year, 1, 1);
                endDate = new DateTime(date2.Value.Year, 12, 31);
            }
            else if (cbDateRange.Text == "Weekly")
            {
                startDate = new DateTime(date1.Value.Year, date1.Value.Month, date1.Value.Day);
                endDate = new DateTime(date2.Value.Year, date2.Value.Month, date2.Value.Day);
            }
            else if (cbDateRange.Text == "Yearly")
            {
                startDate = new DateTime(2000, 1, 1);
                endDate = new DateTime(DateTime.Now.Year, 12, 31);
            }
            else
            {
                return "";
            }

            return $" `Date` BETWEEN '{startDate:yyyy-MM-dd}' AND '{endDate:yyyy-MM-dd}'";
        }//Set Date Range for the query
        private string setFind(string barcode)
        {
            if (string.IsNullOrEmpty(barcode))
            {
                return "";
            }
            else
            {
                return "`ProductBarcode` = '" + barcode + "' AND";
            }
        }//Set Find for the query

        private void loadChart(string barcode)
        {
            string groupQuery = "";

            switch (cbDateRange.Text)
            {
                case "Weekly":
                    groupQuery = "SELECT " +
                                 "YEAR(`Date`) AS Yearly, " +
                                 "LAST_DAY(`Date`) AS MonthEnd, " +
                                 "DATE_ADD(`Date`, INTERVAL (7 - DAYOFWEEK(`Date`)) DAY) AS WeekEnd, " +
                                 "TIMESTAMPDIFF( " +
                                 "  WEEK, " +
                                 "  DATE_SUB(DATE_FORMAT(`Date`, '%Y-%m-01'), INTERVAL (DAYOFWEEK(DATE_FORMAT(`Date`, '%Y-%m-01')) - 1) DAY), " +
                                 "  DATE_SUB(`Date`, INTERVAL (DAYOFWEEK(`Date`) - 1) DAY) " +
                                 ") + 1 AS Weekly, " +
                                 "MONTH(`Date`) AS Monthly, " +
                                 "SUM(`Amount`) AS TotalAmount, " +
                                 "SUM(`Total`) AS TotalSum " +
                                 "FROM `salesdetails` " +
                                 "WHERE " + setFind(barcode) + setDateRange() + " " +
                                 "GROUP BY Yearly, Monthly, Weekly, WeekEnd, MonthEnd " +
                                 "ORDER BY Yearly, Monthly, Weekly";
                    break;

                case "Monthly":
                    groupQuery = "SELECT YEAR(`Date`) AS Yearly, MONTH(`Date`) AS Monthly, SUM(`Amount`) AS TotalAmount, SUM(`Total`) AS TotalSum " +
                                 "FROM `salesdetails` WHERE " + setFind(barcode) + setDateRange() +
                                 "GROUP BY Yearly, Monthly ORDER BY Yearly, Monthly";
                    break;

                case "Yearly":
                    groupQuery = "SELECT YEAR(`Date`) AS Yearly, SUM(`Amount`) AS TotalAmount, SUM(`Total`) AS TotalSum " +
                                 "FROM `salesdetails` WHERE " + setFind(barcode) + setDateRange() +
                                 "GROUP BY Yearly ORDER BY Yearly";
                    break;
            }

            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(groupQuery, conn))
            {
                conn.Open();
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    var dataPoints = new List<double>();
                    var labels = new List<string>();
                    var series = new LineSeries<double>();
                    string[] Month = { "January", "Febuary", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };

                    while (reader.Read())
                    {
                        if (cbDateRange.Text == "Monthly")
                        {
                            int MonthNum = int.Parse(reader[cbDateRange.Text].ToString()) - 1;
                            labels.Add(Month[MonthNum] + " " + reader["Yearly"].ToString());
                        }
                        if (cbDateRange.Text == "Weekly")
                        {

                            int YearNum = int.Parse(reader["Yearly"].ToString());
                            int MonthNum = int.Parse(reader["Monthly"].ToString()) - 1;
                            int WeekNum = int.Parse(reader[cbDateRange.Text].ToString());

                            switch (WeekNum % 10)
                            {
                                case 1: labels.Add(WeekNum + "st week of " + Month[MonthNum] + " " + YearNum); break;
                                case 2: labels.Add(WeekNum + "nd week of " + Month[MonthNum] + " " + YearNum); break;
                                case 3: labels.Add(WeekNum + "rd week of " + Month[MonthNum] + " " + YearNum); break;
                                default: labels.Add(WeekNum + "th week of " + Month[MonthNum] + " " + YearNum); break;
                            }
                        }
                        else
                        {
                            labels.Add(reader[cbDateRange.Text].ToString());
                        }
                        if (cbUnitsOrSales.Text == "Sales")
                        {
                            dataPoints.Add(Convert.ToDouble(reader["TotalSum"]));
                        }
                        else
                        {
                            dataPoints.Add(Convert.ToDouble(reader["TotalAmount"]));
                        }
                    }
                    if (cbUnitsOrSales.Text == "Sales")
                    {
                        series = new LineSeries<double>
                        {
                            Values = dataPoints,
                            Name = "Php"
                        };
                    }
                    else
                    {
                        series = new LineSeries<double>
                        {
                            Values = dataPoints,
                            Name = "Units"
                        };
                    }

                    salesChart.Series = new ISeries[] { series };
                    salesChart.XAxes = new[] { new Axis { Labels = labels } };
                }
            }
        }//Load Chart based on the selected cbDateRange and cbUnitsOrSales
        private void tbSearch_TextChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
        }//Search Text Box Handler

        private void dgvFinnance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string FinnanceBarcode = dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString();
            string SendDate = dgvFinnance.CurrentRow.Cells["Date"].Value?.ToString();
            if (dgvFinnance.CurrentRow != null && dgvFinnance.Columns.Contains("ProductBarcode") && cbSortMode.Text == "Product")
            {
                foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
                {
                    finnanceDetails.clearFields();
                    finnanceDetails.LoadProduct(FinnanceBarcode, date1.Value.ToString("yyyy-MM-dd"), date2.Value.ToString("yyyy-MM-dd"));
                }
            }
            else if(dgvFinnance.CurrentRow != null && dgvFinnance.Columns.Contains("Date") && cbSortMode.Text == "Day")
            {
                
                foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
                {
                    finnanceDetails.clearFields();
                    finnanceDetails.LoadProduct(null, SendDate, SendDate);
                }
            }
            else
            {
                foreach (var finnanceDetails in Application.OpenForms.OfType<FinnanceDetails>())
                {
                    finnanceDetails.clearFields();
                }
            }
            loadChart(FinnanceBarcode);
        }//dgvFinnance Product Click

        private void date1_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
            if (dgvFinnance.CurrentRow != null)
            {
                loadChart(dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString());
            }
        }//date1 Value Changed

        private void date2_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts(tbSearch.Text);
            if (dgvFinnance.CurrentRow != null)
            {
                loadChart(dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString());
            }
        }//date2 Value Changed

        private void cbDateRange_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChart(dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString());
        }//cbDateRange Selected Index Changed

        private void cbUnitsOrSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadChart(dgvFinnance.CurrentRow.Cells["ProductBarcode"].Value?.ToString());
        }//cbUnitsOrSales Selected Index Changed

        private void cbSortMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            dgvFinnanceChangeMode();
            loadChart(null);
            LoadProducts(tbSearch.Text);

        }//cbSortMode Selected Index Changed
    }
}

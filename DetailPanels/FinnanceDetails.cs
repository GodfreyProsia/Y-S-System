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

namespace Y_S_System.DetailPanels
{
    public partial class FinnanceDetails : Form
    {
        string connstring = connection.connstring;
        public FinnanceDetails()
        {
            InitializeComponent();
        }
        public void LoadProduct(string ProductBarcode, string startDate, string endDate)
        {
            string LoadProd = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode) ";
            string GetTotalSales = "SELECT SUM(`Amount`)" +
            "FROM `yarnstitchdata`.`salesdetails` "+ 
            "WHERE `ProductBarcode` = @ProductBarcode "+ 
            "AND `Date` BETWEEN @StartDate AND @EndDate";
            double total;
            double price;
            string unit;
            MySqlConnection conn = new MySqlConnection(connstring);
            using(MySqlCommand cmd = new MySqlCommand(LoadProd, conn))
            {
                cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if(reader.Read())
                    {
                        lblBarcode.Text = reader["ProductBarcode"].ToString();
                        lblProdName.Text = reader["ProductName"].ToString();
                        lblPrice.Text = $"Php { reader["ProductPrice"].ToString():N2}" +" Per " +reader["ProductUnit"].ToString();
                        price = Convert.ToDouble(reader["ProductPrice"]);
                        unit = reader["ProductUnit"].ToString();
                        lblStock.Text = reader["ProductStock"].ToString() + " " + reader["ProductUnit"].ToString() + " in Stock";
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
                        reader.Close();
                        using(MySqlCommand cmd2 = new MySqlCommand(GetTotalSales, conn))
                        {
                            cmd2.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                            cmd2.Parameters.AddWithValue("@StartDate", startDate);
                            cmd2.Parameters.AddWithValue("@EndDate", endDate);
                            using(MySqlDataReader reader2 = cmd2.ExecuteReader())
                            {
                                if(reader2.Read()) {
                                    if(reader2["SUM(`Amount`)"].ToString() == "")
                                    {
                                        total = 0;
                                    }
                                    else
                                    {
                                        total = Convert.ToDouble(reader2["SUM(`Amount`)"]);
                                    }
                                    lblSold.Text =  total.ToString() +" "+ unit + " Sold";
                                    lblTotal.Text = $"Php {total * price: N2}";
                                }
                            }
                        }
                        LoadSaleHistory(ProductBarcode, startDate, endDate);
                    }

                }
                conn.Close();
            }
        }
        public void LoadSaleHistory(string ProductBarcode, string startDate, string endDate)
        {
            dgvSale.Rows.Clear();
            dgvSale.ForeColor = Color.Black;
            string LoadSaleHistory = "SELECT * FROM `yarnstitchdata`.`salesdetails` WHERE `ProductBarcode` = @ProductBarcode AND `Status` = 'Paid' AND `Date` BETWEEN @StartDate AND @EndDate";
            MySqlConnection conn = new MySqlConnection(connstring);
            using(MySqlCommand cmd = new MySqlCommand(LoadSaleHistory, conn))
            {
                cmd.Parameters.AddWithValue("@ProductBarcode", ProductBarcode);
                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);
                conn.Open();
                using(MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        dgvSale.Rows.Add(reader["ProductName"], 
                           Convert.ToDateTime(reader["Date"]).ToString("yyyy-MM-dd"),
                           reader["Amount"], 
                            "Php "+reader["ProductPrice"]+" / " + reader["ProductUnit"], 
                            reader["Total"], 
                            reader["OrderID"]);
                    }
                }
                conn.Close();
            }
        }

        public void clearFields()
        {
            lblBarcode.Text = "Barcode";
            lblProdName.Text = "Name";
            lblPrice.Text = "Price";
            lblStock.Text = "Stock";
            lblSold.Text = "Total Units Sold";
            lblTotal.Text = "Total";
            pbProdPic.Image = Image.FromHbitmap(Properties.Resources.TempProdPic.GetHbitmap());
            dgvSale.Rows.Clear();
        }
    }
}

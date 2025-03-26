using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Y_S_System.MidPanels;
using Y_S_System.MidPanels.ProdductLabel;
using ZXing;
using MySql.Data.MySqlClient;
using ZXing.QrCode;
using ZXing.Rendering;
using ZXing.Common;
using ZXing.SkiaSharp;
using static Org.BouncyCastle.Asn1.Cmp.Challenge;
using SkiaSharp;
using ZXing.SkiaSharp.Rendering;

namespace Y_S_System.DetailPanels
{
    public partial class ProductDetails : Form
    {
        string connstring = "server=localhost;port=3306;user=root;password=Prosia24!;database=yarnstitchdata";
        public string _role;
        public int _mode;
        public double currentStock;
        public double productPrice, productStock;
        public string ProductName = "";
        public ProductDetails(string role, int mode)
        {
            InitializeComponent();
            _role = role;
            _mode = mode;
            setMode();
        }
        public void refresh()
        {
            foreach (var productView in Application.OpenForms.OfType<ProductView>())
            {
                productView.LoadProduct();
            }
            clearFields();
        }
        public void clearFields()
        {
            tbProdID.Text = "";
            tbProdName.Text = "";
            tbProdPrice.Text = "";
            tbProdStock.Text = "";
            tbProdCode.Text = "";
            cbProdUnit.Text = "";
            pbProdPic.Image = Properties.Resources.TempProdPic;
            pbBarcode.Image = null;
            dgvInventoryHis.DataSource = null;
        }
        public void productLoad(string ProductBarcode)
        {
            tbProdCode.Text = ProductBarcode;
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
                        tbProdID.Text = reader["ProductID"].ToString();
                        tbProdName.Text = reader["ProductName"].ToString();
                        tbProdPrice.Text = reader["ProductPrice"].ToString();
                        tbProdStock.Text = reader["ProductStock"].ToString();
                        cbProdUnit.Text = reader["ProductUnit"].ToString();
                        double.TryParse(tbProdStock.Text, out currentStock);
                        ProductName = tbProdName.Text;
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
                        byte[] barcodeData = (byte[])reader["ProductBarcodePic"];
                        if (barcodeData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(barcodeData))
                            {
                                ms.Position = 0;
                                pbBarcode.Image = Image.FromStream(ms);
                            }
                        }
                        loadInventoryHistory(tbProdID.Text);
                    }
                }
            }
        }
        public void loadInventoryHistory(string ProductID)
        {
            string prodHist = "SELECT `Date`, `AddedStock`, `RecordedStock` FROM `yarnstitchdata`.`inventory_history` WHERE (`ProductID` = @ProductID)";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(prodHist, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ProductID", ProductID);
                using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                {
                    try
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dgvInventoryHis.DataSource = dataTable;
                    }
                    catch
                    {
                    }
                }
            }
        }
        public void setMode()
        {
            if (_mode == 1 && _role == "Cashier")
            {
                btnAddProd.Visible = false;
                btnDeleteProd.Visible = false;
                btnUpdateProd.Visible = false;
                btnGenerate.Visible = false;
                tbProdName.Enabled = false;
                tbProdPrice.Enabled = false;
                tbProdID.Enabled = false;
                cbProdUnit.Enabled = false;
                tbProdID.Enabled = false;
                tbProdCode.Enabled = false;
                btnUploadPic.Visible = false;
            }
            if (_mode == 1 && _role == "Admin")
            {
                btnAddProd.Visible = false;
                btnDeleteProd.Visible = false;
                btnUpdateProd.Visible = false;
                btnGenerate.Visible = false;
                tbProdName.Enabled = false;
                tbProdPrice.Enabled = false;
                tbProdID.Enabled = false;
                cbProdUnit.Enabled = false;
                tbProdID.Enabled = false;
                tbProdCode.Enabled = false;
                btnUploadPic.Visible = false;
                btnAddStock.Visible = true;
            }
            if (_mode == 2 && _role == "Admin")
            {
                btnAddProd.Visible = true;
                btnDeleteProd.Visible = true;
                btnUpdateProd.Visible = true;
                btnGenerate.Visible = true;
                tbProdName.Enabled = true;
                tbProdPrice.Enabled = true;
                tbProdID.Enabled = true;
                cbProdUnit.Enabled = true;
                tbProdID.Enabled = true;
                tbProdCode.Enabled = true;
                btnUploadPic.Visible = true;
                btnAddStock.Visible = false;
            }
        }
        public bool checkFields(int mode)
        {
            if (string.IsNullOrWhiteSpace(tbProdName.Text) || string.IsNullOrWhiteSpace(tbProdPrice.Text) || string.IsNullOrWhiteSpace(tbProdStock.Text) || string.IsNullOrWhiteSpace(tbProdCode.Text) || string.IsNullOrWhiteSpace(cbProdUnit.Text) || pbProdPic.Image == null || pbBarcode.Image == null)
            {
                MessageBox.Show("Please fill in all fields and generate a barcode.");
                return false;
            }
            if (!double.TryParse(tbProdPrice.Text, out productPrice))
            {
                MessageBox.Show("Invalid Product Price. Please enter a valid number.");
                return false;
            }
            if (!double.TryParse(tbProdStock.Text, out productStock))
            {
                MessageBox.Show("Invalid Product Stock. Please enter a valid number.");
                return false;
            }
            else
            {
                bool[] allGood = { false, false };
                string[] checkType = { "Name", "ID" };
                TextBox[] checkTextBox = { tbProdName, tbProdID };
                for (int i = 0; i < mode; i++)
                {
                    string checkProd = "SELECT * FROM `yarnstitchdata`.`products` WHERE `Product" + checkType[i] + "` = @Product";
                    MySqlConnection conn = new MySqlConnection(connstring);
                    using (MySqlCommand cmd = new MySqlCommand(checkProd, conn))
                    {
                        conn.Open();
                        cmd.Parameters.AddWithValue("@Product", checkTextBox[i].Text);
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read() && ProductName != tbProdName.Text)
                            {
                                MessageBox.Show("Product " + checkType[i] + " exists.");
                            }
                            else
                            {
                                allGood[i] = true;
                            }
                        }
                        conn.Close();
                    }
                }
                if (allGood[0] == true && allGood[1] == true)
                {
                    return true;
                }
                if (allGood[0] == true && mode == 1)
                {
                    return true;
                }
            }
            return false;
        }
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            bool goodToGo = false;

            goodToGo = checkFields(2);

            if (goodToGo == true)
            {
                barcodePicPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), tbProdName.Text + ".png");
                barcodeBitmap.Save(barcodePicPath, System.Drawing.Imaging.ImageFormat.Png);
                string addProd = "INSERT INTO `yarnstitchdata`.`products` " +
                   "(`ProductID`, `ProductName`, `ProductPrice`, `ProductUnit`, `ProductBarcode`, `ProductStock`, `ProductDate`, `ProductPic`, `ProductBarcodePic`) " +
                   "VALUES (@ProductID, @ProductName, @ProductPrice, @ProductUnit, @ProductBarcode, @ProductStock, @ProductDate, @ProductPic, @ProductBarcodePic)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(addProd, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                    cmd.Parameters.AddWithValue("@ProductName", tbProdName.Text);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
                    cmd.Parameters.AddWithValue("@ProductUnit", cbProdUnit.Text);
                    cmd.Parameters.AddWithValue("@ProductBarcode", tbProdCode.Text);
                    cmd.Parameters.AddWithValue("@ProductStock", productStock);
                    cmd.Parameters.AddWithValue("@ProductDate", DateTime.Now.ToString("MM-dd-yyyy"));
                    byte[] ProductBarcodePic = File.ReadAllBytes(barcodePicPath);
                    cmd.Parameters.AddWithValue("@ProductBarcodePic", ProductBarcodePic);
                    if (prodPicPath != null)
                    {
                        byte[] ProductPic = File.ReadAllBytes(prodPicPath);
                        cmd.Parameters.AddWithValue("@ProductPic", ProductPic);
                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@ProductPic", DBNull.Value);
                    }
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string addInventory = "INSERT INTO `yarnstitchdata`.`inventory_history` " +
                    "(`ProductID`, `Date`, `AddedStock`, `RecordedStock`) " +
                    "VALUES (@ProductID, @Date, @AddedStock, @RecordedStock)";
                using (MySqlCommand cmd = new MySqlCommand(addInventory, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                    cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("MM-dd-yyyy"));
                    cmd.Parameters.AddWithValue("@AddedStock", productStock);
                    cmd.Parameters.AddWithValue("@RecordedStock", productStock);
                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
               
            }
            refresh();
        }
        public string prodPicPath;
        private void btnUploadPic_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog ofd = new OpenFileDialog() { Filter = "Image Files (*.png;*.jpg;*.jpeg)|*.png;*.jpg;*.jpeg", Multiselect = false })
            {
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    prodPicPath = ofd.FileName;
                    pbProdPic.Image = Image.FromFile(ofd.FileName);
                }
            }
        }
        public string barcodePicPath;
        public Bitmap barcodeBitmap;
        public Bitmap generateBarcodeImage(string code)
        {
            BarcodeWriter writer = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new EncodingOptions
                {
                    Width = 300,
                    Height = 100,
                    Margin = 10
                },
                Renderer = new SKBitmapRenderer()
            };
            Bitmap bitmap;
            SKBitmap skBarcode = writer.Write(code);
            using (SKImage img = SKImage.FromBitmap(skBarcode))
            using (SKData data = img.Encode(SKEncodedImageFormat.Png, 100))
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream(data.ToArray()))
            {
                bitmap = new Bitmap(ms);
            }
            
            barcodeBitmap = bitmap;
            return bitmap;
        }
        public bool checkBarcode(string code)
        {
            string checkBarcod = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @Barcode)";
            MySqlConnection conn = new MySqlConnection(connstring);
            using (MySqlCommand cmd = new MySqlCommand(checkBarcod, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Barcode", tbProdCode.Text);
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
        }
        private async void btnGenerate_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(tbProdCode.Text))
            {
                Random random = new Random();
                long randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                while (checkBarcode(randomNumber.ToString()) == false)
                {
                    randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                }
                tbProdCode.Text = randomNumber.ToString();
                pbBarcode.Image = generateBarcodeImage(randomNumber.ToString());
            }
            if (!string.IsNullOrWhiteSpace(tbProdCode.Text))
            {
                if (checkBarcode(tbProdCode.Text) == true)
                {
                    pbBarcode.Image = generateBarcodeImage(tbProdCode.Text);
                }
                if (checkBarcode(tbProdCode.Text) == false)
                {

                    string temp = tbProdCode.Text;
                    tbProdCode.Text = "Barcode already exists";
                    await Task.Delay(2000);
                    tbProdCode.Text = temp;
                }
            }
        }
        private void btnAddStock_Click(object sender, EventArgs e)
        {
            double productStock;
            if (!double.TryParse(tbProdStock.Text, out productStock))
            {
                MessageBox.Show("Invalid Product Stock. Please enter a valid number.");
                return;
            }
            MySqlConnection conn = new MySqlConnection(connstring);
            string addInventory = "INSERT INTO `yarnstitchdata`.`inventory_history` " +
                    "(`ProductID`, `Date`, `AddedStock`, `RecordedStock`) " +
                    "VALUES (@ProductID, @Date, @AddedStock, @RecordedStock)";
            using (MySqlCommand cmd = new MySqlCommand(addInventory, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                cmd.Parameters.AddWithValue("@Date", DateTime.Now.ToString("MM-dd-yyyy"));
                cmd.Parameters.AddWithValue("@AddedStock", (productStock - currentStock));
                cmd.Parameters.AddWithValue("@RecordedStock", productStock);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            string updateStock = "UPDATE `yarnstitchdata`.`products` SET " +
                "`ProductStock` = @ProductStock " +
                "WHERE `ProductID` = @ProductID";
            using (MySqlCommand cmd = new MySqlCommand(updateStock, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                cmd.Parameters.AddWithValue("@ProductStock", productStock);
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            refresh();
        }
        private void btnUpdateProd_Click(object sender, EventArgs e)
        {
            bool goodToGo = false;

            goodToGo = checkFields(1);

            if (goodToGo == true)
            {
                string searchID = "SELECT * FROM `yarnstitchdata`.`products` WHERE (`ProductBarcode` = @ProductBarcode)";
                MySqlConnection conn = new MySqlConnection(connstring);
                using (MySqlCommand cmd = new MySqlCommand(searchID, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductBarcode", tbProdCode.Text);
                    using (MySqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (!reader.Read())
                        {
                            MessageBox.Show("Product does not exist.");
                            return;
                        }
                    }
                    conn.Close();
                }

                string updateProd = "UPDATE `yarnstitchdata`.`products` SET " +
                "`ProductName` = @ProductName, " +
                "`ProductPrice` = @ProductPrice, " +
                "`ProductUnit` = @ProductUnit, " +
                "`ProductBarcode` = @ProductBarcode, " +
                "`ProductStock` = @ProductStock " +
                "WHERE `ProductID` = @ProductID";

                
                using (MySqlCommand cmd = new MySqlCommand(updateProd, conn))
                {
                    conn.Open();
                    cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                    cmd.Parameters.AddWithValue("@ProductName", tbProdName.Text);
                    cmd.Parameters.AddWithValue("@ProductPrice", productPrice);
                    cmd.Parameters.AddWithValue("@ProductUnit", cbProdUnit.Text);
                    cmd.Parameters.AddWithValue("@ProductBarcode", tbProdCode.Text);
                    cmd.Parameters.AddWithValue("@ProductStock", productStock);

                    cmd.ExecuteNonQuery();
                    conn.Close();
                }
                string[] pic = { prodPicPath, barcodePicPath };
                string[] storePic = { "ProductPic", "ProductBarcodePic" };
                byte[] PicBytes;

                for (int i = 0; i < 2; i++)
                {
                    if (pic[i] != null)
                    {
                        PicBytes = File.ReadAllBytes(pic[i]);
                        string updatePic = "UPDATE `yarnstitchdata`.`products` SET " +
                        "`" + storePic[i] + "` = @ProductPic " +
                        "WHERE `ProductID` = @ProductID";
                        using (MySqlCommand cmd = new MySqlCommand(updatePic, conn))
                        {
                            conn.Open();
                            cmd.Parameters.AddWithValue("@ProductID", tbProdID.Text);
                            cmd.Parameters.AddWithValue("@ProductPic", PicBytes);

                            cmd.ExecuteNonQuery();
                            conn.Close();
                        }
                    }
                    
                }
                refresh();
            }
        }
    }
}

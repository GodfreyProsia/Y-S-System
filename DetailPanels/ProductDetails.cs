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
        /*public void productLoad(string ProductBarcode)
        {
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
                        byte[] pictureData = (byte[])reader["ProductPic"];
                        if (pictureData.Length > 0)
                        {
                            using (MemoryStream ms = new MemoryStream(pictureData))
                            {
                                ms.Position = 0;
                                pbProdPic.Image = Image.FromStream(ms);
                            }
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
                    }
                }
            }
        }*/

        public ProductDetails(string role, int mode)
        {
            InitializeComponent();
            _role = role;
            _mode = mode;
            setMode();
        }
        public void setMode()
        {
            if (_mode == 1 && _role == "Cashier")
            {
                btnAddProd.Visible = false;
                btnDeleteProd.Visible = false;
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
        }
        private void btnAddProd_Click(object sender, EventArgs e)
        {
            double productPrice, productStock;
            bool goodToGo = false;

            if (string.IsNullOrWhiteSpace(tbProdName.Text) || string.IsNullOrWhiteSpace(tbProdPrice.Text) || string.IsNullOrWhiteSpace(tbProdStock.Text) || string.IsNullOrWhiteSpace(tbProdCode.Text) || string.IsNullOrWhiteSpace(cbProdUnit.Text) || pbProdPic.Image == null || pbBarcode.Image == null)
            {
                MessageBox.Show("Please fill in all fields and upload all images.");
                return;
            }
            else if (!double.TryParse(tbProdPrice.Text, out productPrice))
            {
                MessageBox.Show("Invalid Product Price. Please enter a valid number.");
                return;
            }
            else if (!double.TryParse(tbProdStock.Text, out productStock))
            {
                MessageBox.Show("Invalid Product Stock. Please enter a valid number.");
                return;
            }
            else
            {
                
            }
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
            barcodePicPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), ProductName + ".png");
            bitmap.Save(barcodePicPath, System.Drawing.Imaging.ImageFormat.Png);
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
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }
                conn.Close();
            }
        }
        private async void btnGenerate_Click(object sender, EventArgs e)
        {
            
            if(string.IsNullOrWhiteSpace(tbProdCode.Text))
            {
                Random random = new Random();
                long randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                while(checkBarcode(randomNumber.ToString()) == false)
                {
                    randomNumber = random.Next(100000000, 999999999) * 1000L + random.Next(1000);
                }
                tbProdCode.Text = randomNumber.ToString();
                pbBarcode.Image = generateBarcodeImage(randomNumber.ToString());
            }
            if(!string.IsNullOrWhiteSpace(tbProdCode.Text))
            {
                if (checkBarcode(tbProdCode.Text) == true)
                {
                    pbBarcode.Image = generateBarcodeImage(tbProdCode.Text);
                }
                if(checkBarcode(tbProdCode.Text) == false)
                {
                    
                    string temp = tbProdCode.Text;
                    tbProdCode.Text = "Barcode already exists";
                    await Task.Delay(2000);
                    tbProdCode.Text = temp;
                }
            }
        }


    }
}

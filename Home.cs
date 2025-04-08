using CustomControls.RJControls;
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
        public static Home instance;
        public string _role;
        public int _logkey;
        public Home(string role, int logkey)
        {
            _logkey = logkey;
            _role = role;
            InitializeComponent();
            loadRpanel(new OrderDetails(_logkey));
            loadMpanel(new ProductView(0));
            
            if(_role == "Cashier")
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
            loadRpanel(new ProductDetails(_role, 1));
            loadMpanel(new InventoryView());
            tabChange(btnInventory);
        }
        private void btnSales_Click(object sender, EventArgs e)
        {
            loadRpanel(new SaleDetails());
            loadMpanel(new SalesView());
            tabChange(btnSales);
        }
        private void btnProducts_Click(object sender, EventArgs e)
        {
            loadRpanel(new ProductDetails(_role, 2));
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
        }
        public void AdminCashierMode()
        {
            loadRpanel(new OrderDetails(_logkey));
            loadMpanel(new ProductView(0));
            tabChange(btnHome);
        }
    }
}

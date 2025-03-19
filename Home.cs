using CustomControls.RJControls;
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
            InitializeComponent();
            loadRpanel(new OrderDetails());
            loadMpanel(new ProductView(0));
            _logkey = logkey;
            _role = role;
            if(_role == "Cashier")
            {
                btnFinnance.Visible = false;
                btnProducts.Visible = false;
            }
        }
        public void loadRpanel(object Form) //loads the right panel
        {
            if (this.RightPanel.Controls.Count > 0)
            {
                Form previousForm = this.RightPanel.Controls[0] as Form;
                if (previousForm != null)
                {
                    previousForm.Close();
                    previousForm.Dispose();
                }
            }
            if (this.MidPanel.Controls.Count > 0)
            {
                this.MidPanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.RightPanel.Controls.Add(f);
            this.RightPanel.Tag = f;
            f.Show();
        }
        public void loadMpanel(object Form)//loads the middle panel
        {
            if (this.MidPanel.Controls.Count > 0)
            {
                Form previousForm = this.MidPanel.Controls[0] as Form;
                if (previousForm != null)
                {
                    previousForm.Close();
                    previousForm.Dispose();
                }
            }
            if (this.MidPanel.Controls.Count > 0)
            {
                this.MidPanel.Controls.RemoveAt(0);
            }

            Form f = Form as Form;
            f.TopLevel = false;
            f.Dock = DockStyle.Fill;
            this.MidPanel.Controls.Add(f);
            this.MidPanel.Tag = f;
            f.Show();
        }
        public void tabChange(RJButton button)//changes the color of the button when clicked
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
            loadRpanel(new OrderDetails());
            loadMpanel(new ProductView(0));
            tabChange(btnHome);
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
            loadRpanel(new ProductDetails(_role, 0));
            loadMpanel(new ProductView(1));
            tabChange(btnProducts);
        }
        private void btnFinnance_Click(object sender, EventArgs e)
        {
            loadRpanel(new FinanceDetails());
            loadMpanel(new FinanceView());
            tabChange(btnFinnance);
        }
    }
}

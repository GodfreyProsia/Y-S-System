using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;

namespace Y_S_System
{
    public partial class Login : Form
    {
        public static MAIN instance1;
        public MAIN _main;
        public Login(MAIN main)
        {
            InitializeComponent();
            _main = main;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            _main.loadpage(new Home());
        }
    }
}

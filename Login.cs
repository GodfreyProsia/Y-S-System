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
using MySql.Data.MySqlClient;

namespace Y_S_System
{
    public partial class Login : Form
    {
        string connstring = "server=localhost;port=3306;user=root;password=Prosia24!;database=yarnstitchdata";
        public static MAIN instance1;
        public MAIN _main;
        int logkey;
        string role;
        public Login(MAIN main)
        {
            InitializeComponent();
            _main = main;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            MySqlConnection conn = new MySqlConnection(connstring);

            string query = "SELECT * FROM `yarnstitchdata`.`accounts` WHERE (`Name` = @Username)";
            using (MySqlCommand cmd = new MySqlCommand(query, conn))
            {
                conn.Open();
                cmd.Parameters.AddWithValue("@Username", tbUsername.Text);
                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string pass = reader["Password"].ToString();
                        if (pass == tbPassword.Text)
                        {
                            role = reader["Role"].ToString();
                            logkey = Convert.ToInt32(reader["ID"]);
                            _main.loadpage(new Home(role, logkey));
                        }
                        else
                        {
                            Invalid.Visible = true;
                        }
                    }
                    else
                    {
                        Invalid.Visible = true;
                    }
                }
                conn.Close();
            }
        }
    }
}

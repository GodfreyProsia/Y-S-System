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
using BCrypt.Net;

namespace Y_S_System
{
    public partial class Login : Form
    {
        string connstring = connection.connstring;
        public static MAIN instance1;
        public MAIN _main;
        int logkey;
        string role;
        public Login(MAIN main)
        {
            InitializeComponent();
            _main = main;
            //set password(); Erase this later
            string password = "123456";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                string query = "UPDATE `yarnstitchdata`.`accounts` SET Password = @password WHERE ID = @id";

                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@password", hashedPassword);
                    cmd.Parameters.AddWithValue("@id", 2);
                    cmd.ExecuteNonQuery();
                }
                conn.Close();
            }
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
                        bool isValid = BCrypt.Net.BCrypt.Verify(tbPassword.Text, pass);
                        if (isValid == true)
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

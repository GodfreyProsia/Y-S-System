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

namespace Y_S_System
{
    public partial class Confirmation : Form
    {
        string connstring = connection.connstring;
        int _id;
        public Confirmation(int id)
        {
            InitializeComponent();
            _id = id;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            confirm();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                confirm();
            }
        }

        private void confirm()
        {
            string confirmPass = "SELECT * FROM `yarnstitchdata`.`accounts` WHERE `ID` = " + _id.ToString() + "";
            using (MySqlConnection conn = new MySqlConnection(connstring))
            {
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(confirmPass, conn);
                MySqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string password = reader["Password"].ToString();
                    if (BCrypt.Net.BCrypt.Verify(tbPassword.Text, password))
                    {
                        this.DialogResult = DialogResult.Yes;
                        this.Close();
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
        }
    }
}

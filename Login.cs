using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace pump
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Cancel_button_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Con_button_Click(object sender, EventArgs e)
        {
            SQL sqlit = new SQL();
            sqlit.Login(PW_TextBox.Text);
            sqlit.Conn.Open();
            string selectlogin = "select login from password";
            SqlCommand _selectlogin = new SqlCommand(selectlogin, sqlit.Conn);
            bool res = Convert.ToBoolean(_selectlogin.ExecuteScalar());
            sqlit.Conn.Close();
            if(res == true)
            {
                this.Close();
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Crane
{
    public partial class Password : Form
    {
        SQL sqlit = new SQL();
        public Password()
        {
            InitializeComponent();
        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void OK_Click(object sender, EventArgs e)
        {
            sqlit.configPW(CurrentPW_TextBox.Text,NewPW_TextBox.Text,ConPW_TextBox.Text);
            CurrentPW_TextBox.Text = "";
            NewPW_TextBox.Text = "";
            ConPW_TextBox.Text = "";
        }
    }
}

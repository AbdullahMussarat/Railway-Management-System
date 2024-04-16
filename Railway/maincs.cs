using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Railway
{
    public partial class maincs : Form
    {
        public maincs(string role)
        {
            InitializeComponent();
            
            if (role.Equals("Admin"))
            {

                searchmnu.Enabled = true;
                updatemnu.Enabled = true;
                insertmnu.Enabled = true;
                addadminmnu.Enabled = true;
            }

            else
            {

                searchmnu.Enabled = true;
                updatemnu.Enabled = false;
                insertmnu.Enabled = false;
                addadminmnu.Enabled = false;
            }
        }

        private void updatemnu_Click(object sender, EventArgs e)
        {
            new UPDATE().Show();
        }

        private void searchmnu_Click(object sender, EventArgs e)
        {
            new search().Show();

        }

        private void insertmnu_Click(object sender, EventArgs e)
        {
            new Form1().Show();

        }

        private void exit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void addadminmnu_Click(object sender, EventArgs e)
        {
            new Addadmin().Show();
        }

    
    }
}

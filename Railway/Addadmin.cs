using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace Railway
{
    public partial class Addadmin : Form
    {
        private SqlConnection xConn;
        public Addadmin()
        {
            InitializeComponent();
            cmbadd.Items.Add("Admin");
            cmbadd.Items.Add("User");
            xConn = new SqlConnection("Server=DESKTOP-Q9ICV6S\\SQLEXPRESS; DataBase=railwayDB; Trusted_Connection='YES' ");  

        }

        private void cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnadd_Click(object sender, EventArgs e)
        {
             DialogResult DR = MessageBox.Show("Added!", "Adding", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
             if (DR == DialogResult.Yes)
             {
                 xConn.Open();
                 new SqlCommand("Insert into logintbl values ('" + txte.Text + "','" + txtp.Text + "','" + cmbadd.Text + "')", xConn).ExecuteNonQuery();

                 xConn.Close();
             }
            txte.Text = txtp.Text = null;


        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            this.Close();

        }
    }
}

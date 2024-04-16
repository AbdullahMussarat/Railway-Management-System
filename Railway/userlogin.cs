using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Railway
{
    public partial class userlogin : Form
    {
        private SqlConnection xConn;
        public userlogin()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=railwayDB;Trusted_Connection=True;");
            
        }

        private void login_Click(object sender, EventArgs e)
        {

            DataTable xTable = new DataTable();
            new SqlDataAdapter("Select * from logintbl Where Email='" + txtName.Text + "' and pass='" + txtpass.Text + "'", xConn).Fill(xTable);
            
            if (xTable.Rows.Count == 1)         
            {
                string role = xTable.Rows[0]["role"].ToString();


                new maincs(role).Show();

                this.Hide();
            }
            else
            {
                txtName.Text = "Incorrect username or password";
                txtpass.Clear();
            }



        }

        private void btnsignup_Click(object sender, EventArgs e)
        {

            xConn.Open();
            new SqlCommand("Insert into logintbl values ('" + txtName.Text + "','" + txtpass.Text + "',user)", xConn).ExecuteNonQuery();

            xConn.Close();
            txtName.Text = txtpass.Text = null;


        }

        private void btnexit_Click(object sender, EventArgs e)
        {


            this.Close();

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            
        }

        private void userlogin_Load(object sender, EventArgs e)
        {
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            +
        }
    }
}

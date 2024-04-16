using System;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Railway
{
    public partial class UPDATE : Form 
    {
        private SqlConnection xConn;
        public UPDATE()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=railwayDB;Trusted_Connection=True;"); 
        }

        private void btnupdate_Click(object sender, EventArgs e)

      {
          if (txtNameup == null || txtPhoneup == null || txtPriceup == null || txtSeatup == null || txtTotalup == null) { }

          else
          {
             DialogResult DR = MessageBox.Show("Are sure to Update Data?", "Update", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
             if (DR == DialogResult.Yes)
             
                 xConn.Open();

                 new SqlCommand("Update Railwaytbl set PassengerName='" + txtNameup.Text + "',PhoneNo='" + txtPhoneup.Text + "',Railway='" + cmb1up.Text + "',FromCity='" + cmb2up.Text + "',ToCity='" + cmb3up.Text + "',TravelDate='" + DTP1up.Text + "',TicketPrice='" + txtPriceup.Text + "',NoSeats='" + txtSeatup.Text + "',Total='" + txtTotalup.Text + "' Where RID='" + txtrid.Text + "'", xConn).ExecuteNonQuery();
                 xConn.Close();

             }
        }

        private void readup_Click(object sender, EventArgs e)
        {

            view();

        }

        private void dgupdate_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

            string SID = dgupdategrid.CurrentRow.Cells[0].Value.ToString();
            string SName = dgupdategrid.CurrentRow.Cells[1].Value.ToString();
            DialogResult DR = MessageBox.Show("Are sure to delete " + SName + "'s data ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {
                xConn.Open();
                new SqlCommand("Update Railwaytbl Set sStatus='False' Where RID='" + txtrid.Text + "'", xConn).ExecuteNonQuery();
                xConn.Close();
                view();


            }

        }


        
        private void txtTotalup_Click(object sender, EventArgs e)
        {

            totalprice();


        }

        private void totalprice()
        {

            int a = Convert.ToInt32(txtPriceup.Text) * Convert.ToInt32(txtSeatup.Text);

            txtTotalup.Text = a.ToString();
        }

        private void view(){


            DataTable xTable = new DataTable();
            new SqlDataAdapter("Select * from Railwaytbl where sstatus = 'True'", xConn).Fill(xTable);
            dgupdategrid.DataSource = xTable;
        
        }

        private void dgupdate_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            int i = e.RowIndex;

            DataGridViewRow row = dgupdategrid.Rows[i];

            txtrid.Text = row.Cells[0].Value.ToString();
            txtNameup.Text = row.Cells[1].Value.ToString();
            txtPhoneup.Text = row.Cells[2].Value.ToString();
            cmb1up.Text = row.Cells[3].Value.ToString();
            cmb2up.Text = row.Cells[4].Value.ToString();
            cmb3up.Text = row.Cells[5].Value.ToString();
            DTP1up.Text = row.Cells[6].Value.ToString();
            txtPriceup.Text = row.Cells[7].Value.ToString();
            txtSeatup.Text = row.Cells[8].Value.ToString();
            txtTotalup.Text = row.Cells[9].Value.ToString();

        }

        private void dgupdate_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {


            this.Close();
        }

      
    }
}

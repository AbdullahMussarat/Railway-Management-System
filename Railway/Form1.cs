using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Railway
{
    public partial class Form1 : Form
    {
        private SqlConnection xConn;
        public Form1()
        {
            InitializeComponent();
           
            cmb1.Items.Add("Shalimaar Express");
            cmb1.Items.Add("Allama Iqbal Express");
            cmb1.Items.Add("Taez Gaam Express");
            cmb1.Items.Add("Night Coach Express");
            cmb1.Items.Add("Blue Line Express");

            cmb2.Items.Add("Karachi");
            cmb2.Items.Add("Lahore");
            cmb2.Items.Add("Islamabad");
            cmb2.Items.Add("Peshawar");
            cmb2.Items.Add("Quetta");
            cmb2.Items.Add("Multan");
            cmb2.Items.Add("Kot Addu");
            cmb2.Items.Add("Nawabshah");
            cmb2.Items.Add("Pindi");


            cmb3.Items.Add("Karachi");
            cmb3.Items.Add("Lahore");
            cmb3.Items.Add("Islamabad");
            cmb3.Items.Add("Peshawar");
            cmb3.Items.Add("Quetta");
            cmb3.Items.Add("Multan");
            cmb3.Items.Add("Kot Addu");
            cmb3.Items.Add("Nawabshah");
            cmb3.Items.Add("Pindi");

            xConn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=railwayDB;Trusted_Connection=True;"); 
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnsave_Click(object sender, EventArgs e)
        {
           
            DialogResult DR = MessageBox.Show("Are sure to Insert Data?" , "Saving", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (DR == DialogResult.Yes)
            {

                xConn.Open();
                //new SqlCommand("Insert into Railwaytbl values ('" + txtName.Text + "','" + int.Parse(txtPhone.Text) + "','" + cmb1.Text + "','" + cmb2.Text + "','" + cmb3.Text + "','" + DTP1.Text + "','" + int.Parse(txtPrice.Text) + "','" + Convert.ToInt32(txtSeat.Text) + "','" + int.Parse(txtTotal.Text) + "')", xConn).ExecuteNonQuery();
                string query = "INSERT INTO Railwaytbl (PassengerName, PhoneNo, Railway, FromCity, ToCity, TravelDate, TicketPrice, NoSeats, Total) VALUES (@Name, @Phone, @Railway, @Fcity, @Tcity, @Tdate, @Tprice, @Nseat, @Total)";

                SqlCommand command = new SqlCommand(query, xConn);
                command.Parameters.AddWithValue("@Name", txtName.Text);
                command.Parameters.AddWithValue("@Phone", int.Parse(txtPhone.Text));
                command.Parameters.AddWithValue("@Railway", cmb1.Text);
                command.Parameters.AddWithValue("@Fcity", cmb2.Text);
                command.Parameters.AddWithValue("@Tcity", cmb3.Text);
                command.Parameters.AddWithValue("@Tdate", DTP1.Text);
                command.Parameters.AddWithValue("@Tprice", int.Parse(txtPrice.Text));
                command.Parameters.AddWithValue("@Nseat", Convert.ToInt32(txtSeat.Text));
                command.Parameters.AddWithValue("@Total", int.Parse(txtTotal.Text));

                command.ExecuteNonQuery();


                xConn.Close();
            }
            txtName.Text = txtPhone.Text = cmb1.Text = cmb2.Text = cmb3.Text = DTP1.Text = txtPrice.Text = txtSeat.Text = txtTotal.Text = null;
        }


        private void totalprice(){

            int a = Convert.ToInt32(txtPrice.Text) * Convert.ToInt32(txtSeat.Text);

            txtTotal.Text = a.ToString();
        }

      

        private void txtTotal_Click(object sender, EventArgs e)
        {
            totalprice();
        }


        private void btnview_Click(object sender, EventArgs e)
        {

            DataTable xTable = new DataTable();
            new SqlDataAdapter("Select * from Railwaytbl WHERE sstatus='True'", xConn).Fill(xTable);
            DG1.DataSource = xTable;


        }

        private void cmb2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void DG1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       
    }
}

 using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace Railway
{
    public partial class search : Form
    {
        private SqlConnection xConn;
        public search()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=localhost\\SQLEXPRESS01;Database=railwayDB;Trusted_Connection=True;");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string searchTerm = txtsearch.Text;

            xConn.Open();
            
            SqlCommand command = new SqlCommand("SELECT * FROM Railwaytbl WHERE (PassengerName LIKE @searchTerm OR CAST(RID AS NVARCHAR) LIKE @searchTerm) AND sstatus = 'True'", xConn);
            command.Parameters.AddWithValue("@searchTerm", "%" + searchTerm + "%");


            SqlDataAdapter adapter = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            dgsearch.DataSource = dataTable;

            xConn.Close();
        }

        private void btnexit_Click(object sender, EventArgs e)
        {

            this.Close();
        }
    }
}


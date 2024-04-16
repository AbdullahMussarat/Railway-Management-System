using System;

using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Railway
{
    public partial class Delete : Form
    {
        private SqlConnection xConn;
        public Delete()
        {
            InitializeComponent();
            xConn = new SqlConnection("Server=DESKTOP-Q9ICV6S\\SQLEXPRESS; DataBase=railwayDB; Trusted_Connection='YES' "); 
            view();
 
        }

        private void view() { 
        
        
         DataTable xTable = new DataTable();
            new SqlDataAdapter("Select * from Railwaytbl where sstatus='False'", xConn).Fill(xTable);
            XGRID1.DataSource = xTable;
        }

        private void XGRID1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnexit_Click(object sender, EventArgs e)
        {


            this.Close();
        }

       
    }
}

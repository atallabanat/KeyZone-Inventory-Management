using KeyZone_Inventory_Management.Sales;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Return_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public virable
        public static Boolean SCR_Return_Sales;
        string bond_no;
        string bond_date;


        public Grid_Return_Sales()
        {
            InitializeComponent();
        }

        private void Grid_Return_Sales_Load(object sender, EventArgs e)
        {
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "SP_SEARCH_DVG_Return_Sales_GRID";
                Cmd.Parameters.Add(new SqlParameter("@Myear", Return_Sales.return_sales.textBox_Year.Text));
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            bond_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            bond_date = dataGridView1.CurrentRow.Cells[1].Value.ToString();


            if (SCR_Return_Sales == true)
            {
                Return_Sales.return_sales.textBox_Bond_No.Text = bond_no;
                Return_Sales.return_sales.Bond_Date.Text = bond_date;

                Return_Sales.return_sales.addScren();
                this.Close();
            }
        }
    }
}

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
    public partial class Grid_Customers : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public Virable
        string Customer_no;
        string Customer_name;
        public static Boolean SCR_Orders_Sales;
        public static Boolean SCR_Return_Sales;
        public static Boolean SCR_Invoice_Sales;
        public Grid_Customers()
        {
            InitializeComponent();
        }

        private void Grid_Customers_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Customer_Grid";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Customer_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Customer_name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Orders_Sales == true)
                    {
                        Oreder_Sales.Ord_Sales.textBox_Customer_No.Text = Customer_no;
                        Oreder_Sales.Ord_Sales.textBox_Customer_Name.Text = Customer_name;
                        SCR_Orders_Sales = false;


                    }

                    if (SCR_Return_Sales == true)
                    {
                        Return_Sales.return_sales.textBox_Customer_No.Text = Customer_no;
                        Return_Sales.return_sales.textBox_Customer_Name.Text = Customer_name;
                        SCR_Orders_Sales = false;


                    }
                    if (SCR_Invoice_Sales == true)
                    {
                        Invoice_Sales.invoice_sales.textBox_Customer_No.Text = Customer_no;
                        Invoice_Sales.invoice_sales.textBox_Customer_Name.Text = Customer_name;
                        SCR_Invoice_Sales = false;
                    }
                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

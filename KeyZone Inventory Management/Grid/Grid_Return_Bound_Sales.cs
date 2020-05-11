using KeyZone_Inventory_Management.Form_RPT;
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
    public partial class Grid_Return_Bound_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Boolean SCR_FRM_Return_Sales;
        public Grid_Return_Bound_Sales()
        {
            InitializeComponent();
        }

        private void Grid_Return_Bound_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_FRM_Return_Sales == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Return_Sales_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Return_Sales.fRM_Report.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
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

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Return_Bound_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string bond_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                    if (SCR_FRM_Return_Sales == true)
                    {
                        FRM_Report_Return_Sales.fRM_Report.textBox_Bond_No.Text = bond_no;
                        SCR_FRM_Return_Sales = false;

                    }
                    else
                    {
                        Return_Sales.return_sales.textBox_Bond_No.Text = bond_no;
                        Return_Sales.return_sales.addScren();
                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Return_Bound_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

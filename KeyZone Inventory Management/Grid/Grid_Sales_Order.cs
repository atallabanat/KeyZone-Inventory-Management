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

    public partial class Grid_Sales_Order : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public Virable
        public static Boolean SCR_FRM_Report_Sales_Order;
        string Order_No;
        string Order_Date;
        public static Boolean SCR_Orders_Sales;

        public Grid_Sales_Order()
        {
            InitializeComponent();
        }

        private void Grid_Sales_Order_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_Orders_Sales == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Orders_Sales_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", Oreder_Sales.Ord_Sales.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
                else if (SCR_FRM_Report_Sales_Order == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Orders_Sales_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Orders_Sales.fRM_Report.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Sales_Order", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Order_No = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Order_Date = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Orders_Sales == true)
                    {
                        Oreder_Sales.Ord_Sales.textBox_Order_Number.Text = Order_No;
                        Oreder_Sales.Ord_Sales.dateTime_Order_Date.Text = Order_Date;

                        Oreder_Sales.Ord_Sales.addScren();
                        SCR_Orders_Sales = false;

                    }
                    if (SCR_FRM_Report_Sales_Order == true)
                    {
                        FRM_Report_Orders_Sales.fRM_Report.textBox_Orders_No.Text = Order_No;
                        SCR_FRM_Report_Sales_Order = false;
                    }
                }

                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Sales_Order", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }
}

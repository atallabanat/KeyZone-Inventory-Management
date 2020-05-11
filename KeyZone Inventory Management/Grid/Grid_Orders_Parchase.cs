using KeyZone_Inventory_Management.Form_RPT;
using KeyZone_Inventory_Management.parchases;
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
    public partial class Grid_Orders_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Boolean SCR_FRM_Report_Order_Parchase;
        string Order_No;
        string Order_Date;
        public Grid_Orders_Parchase()
        {
            InitializeComponent();
        }

        private void Grid_Orders_Parchase_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_FRM_Report_Order_Parchase == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Orders_Parchase_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Orders_Parchase.fRM_Report.textBox_Year.Text));
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
                        Cmd.CommandText = "SP_SEARCH_DVG_Orders_Parchase_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", Orders_parchase.Ord.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Orders_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    if (SCR_FRM_Report_Order_Parchase == true)
                    {
                        FRM_Report_Orders_Parchase.fRM_Report.textBox_Orders_No.Text = Order_No;
                        SCR_FRM_Report_Order_Parchase = false;

                    }
                    else
                    {
                        Orders_parchase.Ord.textBox_Order_Number.Text = Order_No;
                        Orders_parchase.Ord.addScren();
                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Orders_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

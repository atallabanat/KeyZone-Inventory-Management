using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyZone_Inventory_Management.Bond_Inventory;
using KeyZone_Inventory_Management.Form_RPT;

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Transfer_Bond : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        public static Boolean SCR_FRM_Report_Transfer_Bond;

        public Grid_Transfer_Bond()
        {
            InitializeComponent();
        }

        private void Grid_Transfer_Bond_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_FRM_Report_Transfer_Bond == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Transfer_Bond_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Transfer_Bond.fRM_Report.textBox_Year.Text));
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
                        Cmd.CommandText = "SP_SEARCH_DVG_Transfer_Bond_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", Transfer_Bond.Transfer_B.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Transfer_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string bond_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();

                    if (SCR_FRM_Report_Transfer_Bond == true)
                    {
                        FRM_Report_Transfer_Bond.fRM_Report.textBox_Bond_No.Text = bond_no;
                        SCR_FRM_Report_Transfer_Bond = false;
                    }
                    else
                    {
                        Transfer_Bond.Transfer_B.textBox_Bond_No.Text = bond_no;
                        Transfer_Bond.Transfer_B.addScren();
                    }


                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Transfer_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

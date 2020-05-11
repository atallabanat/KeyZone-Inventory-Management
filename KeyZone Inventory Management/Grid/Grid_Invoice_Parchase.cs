using KeyZone_Inventory_Management.Form_RPT;
using KeyZone_Inventory_Management.purchases;
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
    public partial class Grid_Invoice_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public Virable
        public static Boolean SCR_FRM_Report_Invoice_Parchase;
        public static Boolean SCR_return_Parchase;
        string Invoice_No;
        string Invoice_Date;
        public Grid_Invoice_Parchase()
        {
            InitializeComponent();
        }

        private void Grid_Invoice_Parchase_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_FRM_Report_Invoice_Parchase == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Parchase_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Invoice_Parchase.fRM_Report.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    if (SCR_return_Parchase == true)
                    {
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Parchase_GRID";
                            Cmd.Parameters.Add(new SqlParameter("@Myear", return_parchase.return_Parchase.textBox_Invoice_Parchase_year.Text));
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
                            Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Parchase_GRID";
                            Cmd.Parameters.Add(new SqlParameter("@Myear", Invoice_Parchase.Inv_Parchase.textBox_Year.Text));
                            SqlDataAdapter da = new SqlDataAdapter(Cmd);
                            da.Fill(dataTable);


                        }
                        dataGridView1.DataSource = dataTable;
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Invoice_No = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Invoice_Date = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_FRM_Report_Invoice_Parchase == true)
                    {
                        FRM_Report_Invoice_Parchase.fRM_Report.textBox_Invoice__Number.Text = Invoice_No;
                        SCR_FRM_Report_Invoice_Parchase = false;
                    }
                    else
                    {
                        if (SCR_return_Parchase == true)
                        {
                            return_parchase.return_Parchase.textBox_Invoice_Parchase_No.Text = Invoice_No;
                            return_parchase.return_Parchase.addScren();
                            SCR_return_Parchase = false;
                        }
                        else
                        {
                            Invoice_Parchase.Inv_Parchase.textBox_Invoice__Number.Text = Invoice_No;
                            Invoice_Parchase.Inv_Parchase.addScren();
                        }

                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

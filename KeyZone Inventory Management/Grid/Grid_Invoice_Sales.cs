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
    public partial class Grid_Invoice_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Boolean SCR_FRM_Report_Invoice_Sales;
        public static Boolean SCR_return_Sales;

        string Invoice_No;
        string Invoice_Date;
        public Grid_Invoice_Sales()
        {
            InitializeComponent();
        }

        private void Grid_Invoice_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                if (SCR_FRM_Report_Invoice_Sales == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Sales_GRID";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", FRM_Report_Invoice_Sales.fRM_Report.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                }
                else
                {
                    if (SCR_return_Sales == true)
                    {
                        using (SqlCommand Cmd = con.CreateCommand())
                        {
                            Cmd.CommandType = CommandType.StoredProcedure;
                            Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Sales_GRID";
                            Cmd.Parameters.Add(new SqlParameter("@Myear", Return_Sales.return_sales.textBox_Invoice_Sales_Date.Text));
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
                            Cmd.CommandText = "SP_SEARCH_DVG_Invoice_Sales_GRID";
                            Cmd.Parameters.Add(new SqlParameter("@Myear", Invoice_Sales.invoice_sales.textBox_Year.Text));
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Invoice_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    if (SCR_FRM_Report_Invoice_Sales == true)
                    {
                        FRM_Report_Invoice_Sales.fRM_Report.textBox_Invoice__Number.Text = Invoice_No;
                        SCR_FRM_Report_Invoice_Sales = false;
                    }
                    else
                    {
                        if (SCR_return_Sales == true)
                        {
                            Return_Sales.return_sales.textBox_Invoice_Sales_No.Text = Invoice_No;
                            Return_Sales.return_sales.addScren_IN();
                            SCR_return_Sales = false;
                        }
                        else
                        {
                            Invoice_Sales.invoice_sales.textBox_Invoice__Number.Text = Invoice_No;
                            Invoice_Sales.invoice_sales.addScren();
                        }

                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Invoice_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

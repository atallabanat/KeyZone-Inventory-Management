using KeyZone_Inventory_Management.Form_RPT;
using Microsoft.Reporting.WinForms;
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

namespace KeyZone_Inventory_Management.Reports
{
    public partial class Report__Trans_AllStoers : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        string storeno = "0";
        public Report__Trans_AllStoers()
        {
            InitializeComponent();
        }

        private void Report__Trans_AllStoers_Load(object sender, EventArgs e)
        {
            try
            {
                ReportParameterCollection reportParameters = new ReportParameterCollection();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SP_Invoice_Parchase_Report m = new SP_Invoice_Parchase_Report();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_Report_Trans_ALL_Stores";
                cmd.Parameters.AddWithValue("@Flag", FRM_Report_Trans_Stores.Flag.ToString());
                storeno =FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.textBox_Store_No.Text;
                if (storeno == "")
                {
                    storeno = "1";
                }
                
                cmd.Parameters.AddWithValue("@StoreNo", storeno);
                cmd.Parameters.AddWithValue("@From_Odate", FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.dateTime_from.Value);
                cmd.Parameters.AddWithValue("@To_Odate", FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.dateTime_To.Value);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(m, m.Tables[0].TableName);

                reportParameters.Add(new ReportParameter("From_Date", FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.dateTime_from.Value.ToShortDateString()));
                reportParameters.Add(new ReportParameter("To_Date", FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.dateTime_To.Value.ToShortDateString()));

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                ReportDataSource reportDataSource = new ReportDataSource("DS_Report_Trans_ALL_Stores", m.Tables[0]);


                //--------------------------------------------------------------------------------------------------------


                //SP_PictureCompany ms2 = new SP_PictureCompany();
                SP_Invoice_Parchase_Report m2 = new SP_Invoice_Parchase_Report();

                SqlCommand cmd2 = con.CreateCommand();

                cmd2.CommandType = CommandType.StoredProcedure;

                cmd2.CommandText = "SP_PictureCompany";

                SqlDataAdapter da2 = new SqlDataAdapter(cmd2);
                da2.Fill(m2, m2.Tables[0].TableName);

                this.reportViewer1.LocalReport.SetParameters(reportParameters);
                ReportDataSource reportDataSource2 = new ReportDataSource("DS_img", m2.Tables[0]);



                this.reportViewer1.LocalReport.DataSources.Clear();
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource);
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);

                this.reportViewer1.RefreshReport();
                con.Close();
            }
            catch (Exception ex)

            {
                MessageBox.Show(ex.Message);
            }

        }
    }
}

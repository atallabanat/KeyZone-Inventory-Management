﻿using KeyZone_Inventory_Management.Form_RPT;
using KeyZone_Inventory_Management.Sales;
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
    public partial class Report_Invoice_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public Report_Invoice_Sales()
        {
            InitializeComponent();
        }

        private void Report_Invoice_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                ReportParameterCollection reportParameters = new ReportParameterCollection();

                con.Open();
                SqlCommand cmd = con.CreateCommand();
                SP_Invoice_Parchase_Report m = new SP_Invoice_Parchase_Report();
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_Invoice_Sales_Report";
                cmd.Parameters.AddWithValue("@Invoice_No", FRM_Report_Invoice_Sales.fRM_Report.textBox_Invoice__Number.Text);
                cmd.Parameters.AddWithValue("@Myear", FRM_Report_Invoice_Sales.fRM_Report.textBox_Year.Text);

                SqlDataAdapter da = new SqlDataAdapter(cmd);

                da.Fill(m, m.Tables[0].TableName);

                ReportDataSource reportDataSource = new ReportDataSource("DS_Invoice_Sales_Report", m.Tables[0]);

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
            catch (Exception)

            {

            }

        }
    }
}

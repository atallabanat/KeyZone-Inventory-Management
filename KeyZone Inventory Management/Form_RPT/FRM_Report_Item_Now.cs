using KeyZone_Inventory_Management.Grid;
using KeyZone_Inventory_Management.Reports;
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

namespace KeyZone_Inventory_Management.Form_RPT
{
    public partial class FRM_Report_Item_Now : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static FRM_Report_Item_Now fRM_Report_Item_Now;
        public FRM_Report_Item_Now()
        {
            fRM_Report_Item_Now = this;
            InitializeComponent();
        }

        private void textBox_Store_No_Leave(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Store_No.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select SNo,SName  from Stores where SNo=@SNo", con);
                    cmd.Parameters.Add(new SqlParameter("@SNo", textBox_Store_No.Text));

                    con.Open();
                    SqlDataReader Ra = cmd.ExecuteReader();

                    if (Ra.Read())
                    {
                        textBox_Store_Name.Text = Ra["SName"].ToString();

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد مستودع بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        textBox_Store_Name.Text = "";
                    }
                    Ra.Close();
                    con.Close();
                }
            }                       
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 FRM_Report_Item_Now", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
}

        private void btn_View_Store_No_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_FRM_Report_Item_Now = true;
            Grid_Stores grid_Stores = new Grid_Stores();
            grid_Stores.ShowDialog();
            Grid_Stores.SCR_FRM_Report_Item_Now = false;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Store_No.Text == "")
                {
                    MessageBox.Show("يرجى تحديد رقم المستودع لعرض التقرير", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    Report_Item_Now report = new Report_Item_Now();
                    report.Show();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 FRM_Report_Item_Now", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void FRM_Report_Item_Now_Load(object sender, EventArgs e)
        {

        }
    }
}

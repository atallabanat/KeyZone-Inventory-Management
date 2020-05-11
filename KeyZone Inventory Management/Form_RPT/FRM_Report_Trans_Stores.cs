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
    public partial class FRM_Report_Trans_Stores : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static int Flag=0;
        public static FRM_Report_Trans_Stores fRM_Report_Trans_Stores;
        public FRM_Report_Trans_Stores()
        {
            fRM_Report_Trans_Stores = this;
            InitializeComponent();
        }

        private void FRM_Report_Trans_Stores_Load(object sender, EventArgs e)
        {
            Flag = 0;
        }

        private void textBox_Store_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void rd_StoreNo_CheckedChanged(object sender, EventArgs e)
        {
            if(rd_StoreNo.Checked==true)
            {
                Flag = 1;

                textBox_Store_No.Enabled = true;
                btn_View_Store_No.Enabled = true;
            }
            else
            {

                Flag = 0;
                textBox_Store_No.Enabled = false;
                btn_View_Store_No.Enabled = false;
            }
        }

        private void rd_AllStores_CheckedChanged(object sender, EventArgs e)
        {
            if (rd_AllStores.Checked == true)
            {
                Flag = 0;
                textBox_Store_No.Text = "";
                textBox_Store_Name.Text = "";
            }
            else
            {
                Flag = 1;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (rd_StoreNo.Checked == true)
                {
                    if (textBox_Store_No.Text == "")
                    {
                        MessageBox.Show("يرجى تحديد رقم المستودع لعرض التقرير", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {
                        Report__Trans_AllStoers report__Trans_AllStoers = new Report__Trans_AllStoers();
                        report__Trans_AllStoers.Show();
                    }
                }
                else
                {
                    Report__Trans_AllStoers report__Trans_AllStoers = new Report__Trans_AllStoers();
                    report__Trans_AllStoers.Show();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 FRM_Report_Trans_Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Store_No_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_Report_Trans_Stores = true;
            Grid_Stores grid_Stores = new Grid_Stores();
            grid_Stores.ShowDialog();
            Grid_Stores.SCR_Report_Trans_Stores = false;

        }

        private void textBox_Store_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
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
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 FRM_Report_Trans_Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

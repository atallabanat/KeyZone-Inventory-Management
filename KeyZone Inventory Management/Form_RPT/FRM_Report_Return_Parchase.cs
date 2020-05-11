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
    public partial class FRM_Report_Return_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static FRM_Report_Return_Parchase fRM_Report;
        //public virable
        int bond_no;
        public FRM_Report_Return_Parchase()
        {
            fRM_Report = this;
            InitializeComponent();
        }

        private void FRM_Report_Return_Parchase_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.Year.ToString();

            textBox_Year.Text = date;
            textBox_Bond_No.Focus();
        }

        private void textBox_Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Bond_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("يرجى تحديد السنة للطباعة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;

                }
                if (textBox_Bond_No.Text == "")
                {
                    MessageBox.Show("يرجى تحديد رقم السند للطباعة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select count( *) as cc from return_parchase where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    bond_no = Convert.ToInt32(dr["cc"].ToString());


                }
                else
                {
                    bond_no = 0;
                }
                con.Close();

                if (bond_no == 0)
                {
                    MessageBox.Show("لا يوجد بيانات للطباعة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                Report_return_parchase Report_return_parchase2 = new Report_return_parchase();
                Report_return_parchase2.Show();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 FRM_Report_Return_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            if (textBox_Year.Text != "")
            {
                Grid_Return_Bound_Parchase.SCR_FRM_Return_Parchase = true;
                Grid_Return_Bound_Parchase Grid_Return_Bound_Parchase2 = new Grid_Return_Bound_Parchase();
                Grid_Return_Bound_Parchase2.ShowDialog();
                Grid_Return_Bound_Parchase.SCR_FRM_Return_Parchase = false;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Configuration;

namespace KeyZone_Inventory_Management
{
    public partial class OPEN_TAX_ACCOUNT : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public OPEN_TAX_ACCOUNT()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }
        //public virable
        string nameOpen_Tax_acc = "";
        private void OPEN_TAX_ACCOUNT_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 0)
            {
                textBox_Account_Number.Text = dataGridView1.CurrentRow.Cells["Column_Account_Number"].Value.ToString();
                textBox_Account_Name.Text = dataGridView1.CurrentRow.Cells["Column_Account_Name"].Value.ToString();
                textBox_Account_Rate.Text = dataGridView1.CurrentRow.Cells["Column_Account_Rate"].Value.ToString();
                textBox_Total_Account.Text = dataGridView1.CurrentRow.Cells["Column_Total_Account"].Value.ToString();

            }
        }
        private void DGV_load()
        {
            con.Open();
            SqlCommand cmd21 = new SqlCommand("select (Max(Account_Number)+1) as max from open_tax_account", con);
            SqlDataReader dr;
            dr = cmd21.ExecuteReader();
            if (dr.Read())
            {
                textBox_Account_Number.Text = dr["max"].ToString();
            }
            con.Close();

            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "SP_SELECT_DGV_OPEN_TAX_ACCOUNT";
                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;


        }

        private void OPEN_TAX_ACCOUNT_Load(object sender, EventArgs e)
        {
            DGV_load();
        }

        private void textBox_search_OnValueChanged(object sender, EventArgs e)
        {
            var dataTable = new DataTable();
            using (SqlCommand Cmd = con.CreateCommand())
            {
                Cmd.CommandType = CommandType.StoredProcedure;
                Cmd.CommandText = "SP_SEARCH_DVG_OPEN_TAX_ACCOUNT";
                Cmd.Parameters.AddWithValue("@Account_Number", "%" + textBox_search.Text + "%");
                Cmd.Parameters.AddWithValue("@Account_Name", "%" + textBox_search.Text + "%");
                Cmd.Parameters.AddWithValue("@Account_Rate", "%" + textBox_search.Text + "%");

                SqlDataAdapter da = new SqlDataAdapter(Cmd);
                da.Fill(dataTable);


            }
            dataGridView1.DataSource = dataTable;
        }

        private void textBox_Account_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Account_Rate_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Account_Number.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الحساب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Number.Focus();
                    return;
                }
                if (textBox_Account_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Name.Focus();
                    return;
                }
                    if (textBox_Account_Rate.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة نسبة الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Account_Rate.Focus();
                        return;
                    }
                if (textBox_Total_Account.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رصيد الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Total_Account.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Account_Number,Account_Name from open_tax_account where Account_Number=@Account_Number", con);
                    cmd21.Parameters.Add(new SqlParameter("@Account_Number", textBox_Account_Number.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();

                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameOpen_Tax_acc = "(" + dr["Account_Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم الحساب موجود مسبقا بإسم :  " + nameOpen_Tax_acc + "  لا يمكن إضافة حساب بنفس الرقم   ", "تكرار البيانات رقم الحساب موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_Account_Number.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_ADD_OPEN_TAX_ACCOUNT";
                        cmd.Parameters.AddWithValue("@Account_Number", textBox_Account_Number.Text);
                        cmd.Parameters.AddWithValue("@Account_Name", textBox_Account_Name.Text);
                        cmd.Parameters.AddWithValue("@Account_Rate", textBox_Account_Rate.Text);
                        cmd.Parameters.AddWithValue("@Total_Account", textBox_Total_Account.Text);
                        cmd.Parameters.AddWithValue("@Screen_Code", 1);
                        cmd.Parameters.AddWithValue("@Doc_Type", 1);
                        cmd.Parameters.AddWithValue("@ID_User", 1);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Account_Number.Text = "";
                        textBox_Account_Name.Text = "";
                        textBox_Account_Rate.Text = "";
                        textBox_Total_Account.Text = "";
                        textBox_Account_Number.Focus();
                        DGV_load();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1001 OPEN_TAX_ACCOUNT", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Account_Number.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الحساب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Number.Focus();
                    return;
                }
                if (textBox_Account_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Name.Focus();
                    return;
                }
                if (textBox_Account_Rate.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة نسبة الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Rate.Focus();
                    return;
                }
                if (textBox_Total_Account.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رصيد الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Total_Account.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_OPEN_TAX_ACCOUNT";
                    cmd.Parameters.AddWithValue("@Account_Number", textBox_Account_Number.Text);
                    cmd.Parameters.AddWithValue("@Account_Name", textBox_Account_Name.Text);
                    cmd.Parameters.AddWithValue("@Account_Rate", textBox_Account_Rate.Text);
                    cmd.Parameters.AddWithValue("@Total_Account", textBox_Total_Account.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", 1);
                    cmd.Parameters.AddWithValue("@Doc_Type", 1);
                    cmd.Parameters.AddWithValue("@ID_User", 1);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Account_Number.Text = "";
                    textBox_Account_Name.Text = "";
                    textBox_Account_Rate.Text = "";
                    textBox_Total_Account.Text = "";
                    textBox_Account_Number.Focus();
                    DGV_load();
                }
                
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1002 OPEN_TAX_ACCOUNT ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


}

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Account_Number.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الحساب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Account_Number.Focus();
                    return;
                }
                else
                {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_DELETE_OPEN_TAX_ACCOUNT";
                        cmd.Parameters.AddWithValue("@Account_Number", textBox_Account_Number.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Account_Number.Text = "";
                        textBox_Account_Name.Text = "";
                        textBox_Account_Rate.Text = "";
                        textBox_Total_Account.Text = "";
                        textBox_Account_Number.Focus();
                        DGV_load();
                    }
                }

                }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة المبرمج ، شكرا" + ee.Message, "ERROR 1003 OPEN_TAX_ACCOUNT ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
    }
    }


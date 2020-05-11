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
    public partial class Stores : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        string nameSNo = "";
        public Stores()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(SNo)+1),1) as max from Stores", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_SNo.Text = dr["max"].ToString();
                }
                con.Close();

                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Stores";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Stores_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_SNo.Text = dataGridView1.CurrentRow.Cells["Column_SNo"].Value.ToString();
                    textBox_SName.Text = dataGridView1.CurrentRow.Cells["Column_SName"].Value.ToString();
                    textBox_SAccount.Text = dataGridView1.CurrentRow.Cells["Column_SAccount"].Value.ToString();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SNo.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم االمستودع ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SNo.Focus();
                    return;
                }
                if (textBox_SName.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المستود", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SName.Focus();
                    return;
                }
                if (textBox_SAccount.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SAccount.Focus();
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Sno,SName from Stores where SNo=@SNo", con);
                    cmd21.Parameters.Add(new SqlParameter("@SNo", textBox_SNo.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameSNo = "(" + dr["SName"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم االمستودع موجود مسبقا بإسم :  " + nameSNo + "  لا يمكن إضافة مستودع بنفس الرقم   ", "تكرار البيانات رقم المستودع موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_SNo.Focus();
                        return;
                    }

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Stores";

                    cmd.Parameters.AddWithValue("@SNo", textBox_SNo.Text);
                    cmd.Parameters.AddWithValue("@SName", textBox_SName.Text);
                    cmd.Parameters.AddWithValue("@SAccount", textBox_SAccount.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Stores);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Stores);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_SNo.Text = "";
                    textBox_SName.Text = "";
                    textBox_SAccount.Text = "";
                    textBox_SName.Focus();
                    DGV_load();



                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_SNo.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم االمستودع ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SNo.Focus();
                    return;
                }
                if (textBox_SName.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المستود", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SName.Focus();
                    return;
                }
                if (textBox_SAccount.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الحساب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_SAccount.Focus();
                    return;
                }
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_UPDATE_Stores";

                cmd.Parameters.AddWithValue("@SNo", textBox_SNo.Text);
                cmd.Parameters.AddWithValue("@SName", textBox_SName.Text);
                cmd.Parameters.AddWithValue("@SAccount", textBox_SAccount.Text);
                cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Stores);
                cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Stores);
                cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                cmd.ExecuteNonQuery();
                con.Close();
                MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_SNo.Text = "";
                textBox_SName.Text = "";
                textBox_SAccount.Text = "";
                textBox_SName.Focus();
                DGV_load();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (textBox_SNo.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة رقم االمستودع ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_SNo.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_Delete_Stores";
                        cmd.Parameters.AddWithValue("@SNo", textBox_SNo.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_SNo.Text = "";
                        textBox_SName.Text = "";
                        textBox_SAccount.Text = "";
                        textBox_SName.Focus();
                        DGV_load();

                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Stores_Load(object sender, EventArgs e)
        {
            try
            {
                DGV_load();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_search_OnValueChanged(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SEARCH_DVG_Stores";
                    Cmd.Parameters.AddWithValue("@SNo", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@SName", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@SAccount", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}


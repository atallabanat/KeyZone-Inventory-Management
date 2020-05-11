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

namespace KeyZone_Inventory_Management.Defenition
{
    public partial class Screen : Form
    {
        
        //public virable
        string nameScr = "";

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select (Max(Screen_No)+1) as max from Screen", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Screen_No.Text = dr["max"].ToString();
                }
                con.Close();


                this.KeyPreview = true;
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Screen";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public Screen()
        {
            InitializeComponent();
        }



        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
                if (textBox_Screen_No.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الشاشة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Screen_No.Focus();
                    return;
                }
                if (textBox_Screen_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الشاشة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Screen_Name.Focus();
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Screen";

                    cmd.Parameters.AddWithValue("@Scree_No", textBox_Screen_No.Text);
                    cmd.Parameters.AddWithValue("@Scree_Name", textBox_Screen_Name.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Screen);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Screen);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Screen_No.Text = "";
                    textBox_Screen_Name.Text = "";
                    textBox_Screen_No.Focus();
                    DGV_load();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void Screen_Load(object sender, EventArgs e)
        {
            try
            {
                DGV_load();
                textBox_Screen_No.Focus();
                textBox_Screen_No.Select();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Screen_No.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الشاشة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Screen_No.Focus();
                    return;
                }
                if (textBox_Screen_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الشاشة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Screen_Name.Focus();
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Screen_No,Screen_Name from Screen where Screen_No=@Screen_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Screen_No", textBox_Screen_No.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameScr = "(" + dr["Screen_Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم الشاشة موجود مسبقا بإسم :  " + nameScr + "  لا يمكن إضافة شاشة بنفس الرقم   ", "تكرار البيانات رقم الشاشة موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_Screen_No.Focus();
                        return;
                    }
                    else
                    {

                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_ADD_Screen";

                        cmd.Parameters.AddWithValue("@Screen_No", textBox_Screen_No.Text);
                        cmd.Parameters.AddWithValue("@Screen_Name", textBox_Screen_Name.Text);
                        cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Screen);
                        cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Screen);
                        cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                        cmd.ExecuteNonQuery();
                        con.Close();


                        MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Screen_No.Text = "";
                        textBox_Screen_Name.Text = "";
                        textBox_Screen_No.Focus();
                        DGV_load();

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {

                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (textBox_Screen_No.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة رقم الشاشة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Screen_No.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_Delete_Screen";

                        cmd.Parameters.AddWithValue("@Screen_No", textBox_Screen_No.Text);
                        cmd.Parameters.AddWithValue("@Screen_Name", textBox_Screen_Name.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Screen_No.Text = "";
                        textBox_Screen_Name.Text = "";
                        textBox_Screen_No.Focus();
                        DGV_load();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_Screen_No.Text = dataGridView1.CurrentRow.Cells["Column_Screen_No"].Value.ToString();
                    textBox_Screen_Name.Text = dataGridView1.CurrentRow.Cells["Column_Screen_Name"].Value.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    Cmd.CommandText = "SP_SEARCH_DVG_Screen";
                    Cmd.Parameters.AddWithValue("@Screen_Name", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Screen", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Screen_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_Screen_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

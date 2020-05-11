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

namespace KeyZone_Inventory_Management.Distributor
{
    public partial class Unit : Form
    {
        //public virable
        string nameUni = "";

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Unit()
        {
            this.KeyPreview = true;

            InitializeComponent();
        }
        private void DGV_load()
        {
            try
            {


                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Unit_No)+1),1) as max from Unit", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Unit_No.Text = dr["max"].ToString();
                }
                con.Close();

                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Unit";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Unit_No.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الوحدة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Unit_No.Focus();
                    return;
                }
                if (textBox_Unit_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الوحدة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Unit_Name.Focus();
                    return;
                }

                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Unit_No,Unit_Name from Unit where Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", textBox_Unit_No.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameUni = "(" + dr["Unit_Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم الوحدة موجود مسبقا بإسم :  " + nameUni + "  لا يمكن إضافة وحدة بنفس الرقم   ", "تكرار البيانات رقم الوحدة موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_Unit_No.Focus();
                        return;
                    }

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Unit";

                    cmd.Parameters.AddWithValue("@Unit_No", textBox_Unit_No.Text);
                    cmd.Parameters.AddWithValue("@Unit_Name", textBox_Unit_Name.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Unit);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Unit);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Unit_No.Text = "";
                    textBox_Unit_Name.Text = "";
                    textBox_Unit_No.Focus();
                    DGV_load();



                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Unit_No.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم الوحدة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Unit_No.Focus();
                    return;
                }
                if (textBox_Unit_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الوحدة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Unit_No.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Unit";

                    cmd.Parameters.AddWithValue("@Unit_No", textBox_Unit_No.Text);
                    cmd.Parameters.AddWithValue("@Unit_Name", textBox_Unit_Name.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Unit);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Unit);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Unit_No.Text = "";
                    textBox_Unit_Name.Text = "";
                    textBox_Unit_No.Focus();
                    DGV_load();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (textBox_Unit_No.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة رقم الوحدة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Unit_No.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_Delete_Unit";

                        cmd.Parameters.AddWithValue("@Unit_No", textBox_Unit_No.Text);

                        cmd.ExecuteNonQuery();
                        con.Close();

                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Unit_No.Text = "";
                        textBox_Unit_Name.Text = "";
                        textBox_Unit_No.Focus();
                        DGV_load();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Unit_Load(object sender, EventArgs e)
        {
            try
            {
                DGV_load();
                textBox_Unit_No.Focus();
                textBox_Unit_No.Select();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Unit_No_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyData == Keys.Enter)
            {
                textBox_Unit_Name.Focus();
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
                    Cmd.CommandText = "SP_SEARCH_DVG_Unit";
                    Cmd.Parameters.AddWithValue("@Unit_Name", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Unit_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_Unit_No.Text = dataGridView1.CurrentRow.Cells["Column_Unit_No"].Value.ToString();
                    textBox_Unit_Name.Text = dataGridView1.CurrentRow.Cells["Column_Unit_Name"].Value.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Unit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}

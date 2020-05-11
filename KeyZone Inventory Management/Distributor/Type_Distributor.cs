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

namespace KeyZone_Inventory_Management
{
    public partial class Type_Distributor : Form
    {
        //public virable
        string nameDIS_TYPE = "";
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

       
        public Type_Distributor()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }


        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {

                if (textBox_ID.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم نوع الرتبة ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ID.Focus();
                    return;
                }
                if (textBox_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الرتبة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Name.Focus();
                    return;
                }
                if (textBox_Cost_Sales.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة سعر الرتبة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Cost_Sales.Focus();
                    return;
                }



                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select id,Name from Type_Distributor where id=@id", con);
                    cmd21.Parameters.Add(new SqlParameter("@id", textBox_ID.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameDIS_TYPE = "(" + dr["Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم العميل موجود مسبقا بإسم :  " + nameDIS_TYPE + "  لا يمكن إضافة العميل بنفس الرقم   ", "تكرار البيانات رقم العميل موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_ID.Focus();
                        return;
                    }

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Type_Distributor";

                    cmd.Parameters.AddWithValue("@ID", textBox_ID.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
                    cmd.Parameters.AddWithValue("@Cost_Sales", textBox_Cost_Sales.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Type_Distributor);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Type_Distributor);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();



                    MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_ID.Text = "";
                    textBox_Name.Text = "";
                    textBox_Cost_Sales.Text = "";
                    textBox_ID.Focus();
                    DGV_load();





                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        
        private void Type_Distributor_Load(object sender, EventArgs e)
        {
            try
            { 
                DGV_load();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }
        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(id)+1),1) as max from Type_Distributor", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_ID.Text = dr["max"].ToString();
                }
                con.Close();

                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Type_Distributor";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم رتبة المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ID.Focus();
                    return;
                }
                if (textBox_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم الرتبة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Name.Focus();
                    return;
                }
                if (textBox_Cost_Sales.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة سعر الرتبة", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Cost_Sales.Focus();
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Type_Distributor";

                    cmd.Parameters.AddWithValue("@ID", textBox_ID.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Type_Distributor);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Type_Distributor);
                    cmd.Parameters.AddWithValue("@Cost_Sales", textBox_Cost_Sales.Text);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_ID.Text = "";
                    textBox_Name.Text = "";
                    textBox_Cost_Sales.Text = "";
                    textBox_ID.Focus();
                    DGV_load();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                   

                    if (textBox_ID.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة رقم رتبة المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_ID.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_Delete_Type_Distributor";

                        cmd.Parameters.AddWithValue("@ID", textBox_ID.Text);
                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_ID.Text = "";
                        textBox_Name.Text = "";
                        textBox_Cost_Sales.Text = "";
                        textBox_ID.Focus();
                        DGV_load();
                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void Type_Distributor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Cost_Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
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
                    Cmd.CommandText = "SP_SEARCH_DVG_Type_Distributor";
                    Cmd.Parameters.AddWithValue("@Name", "%" + textBox_search.Text + "%");
 

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {

            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_ID.Text = dataGridView1.CurrentRow.Cells["Column_ID"].Value.ToString();
                    textBox_Name.Text = dataGridView1.CurrentRow.Cells["Column_Name"].Value.ToString();
                   textBox_Cost_Sales.Text = dataGridView1.CurrentRow.Cells["Column_Cost_Sales"].Value.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Type_Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
    


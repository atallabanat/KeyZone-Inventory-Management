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
    public partial class Customers : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        string nameCus = "";
        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Customers_No)+1),1) as max from Customers", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Customers_No.Text = dr["max"].ToString();
                }
                con.Close();
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Customers";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public Customers()
        {
            InitializeComponent();
            this.KeyPreview = true;
        }


        private void Customers_Load(object sender, EventArgs e)
        {
            try
            { 
                DGV_load();
                textBox_Customers_No.Focus();
                textBox_Customers_No.Select();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
            if (textBox_Customers_No.Text == "")
            {
                MessageBox.Show("يرجى تعبئة رقم العميل  ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox_Customers_No.Focus();
                return;
            }
                if (textBox_Customers_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم العميل  ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Customers_Name.Focus();
                    return;
                }
                else
                {

                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Customers_No,Customers_Name from Customers where Customers_No=@Customers_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Customers_No", textBox_Customers_No.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameCus = "(" + dr["Customers_Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم العميل موجود مسبقا بإسم :  " + nameCus + "  لا يمكن إضافة العميل بنفس الرقم   ", "تكرار البيانات رقم العميل موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_Customers_No.Focus();
                        return;
                    }

                    else
                    {



                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_ADD_Customers";

                        cmd.Parameters.AddWithValue("@Customers_No", textBox_Customers_No.Text);
                        cmd.Parameters.AddWithValue("@Customers_Name", textBox_Customers_Name.Text);
                        cmd.Parameters.AddWithValue("@Start_Date", dateTime_Start_Date.Value);
                        cmd.Parameters.AddWithValue("@Phone", textBox_Phone.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                        cmd.Parameters.AddWithValue("@Fax", textBox_Fax.Text);
                        cmd.Parameters.AddWithValue("@Email", textBox_Email.Text);
                        cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Customers);
                        cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Customers);
                        cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                        cmd.ExecuteNonQuery();
                        con.Close();


                        MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Customers_No.Text = "";
                        textBox_Customers_Name.Text = "";
                        textBox_Phone.Text = "";
                        textBox_Address.Text = "";
                        textBox_Fax.Text = "";
                        textBox_Email.Text = "";
                        textBox_Customers_No.Focus();

                        DGV_load();

                    }
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
                if (textBox_Customers_No.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم العميل  ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Customers_No.Focus();
                    return;
                }
                if (textBox_Customers_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم العميل  ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Customers_Name.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Customers";

                    cmd.Parameters.AddWithValue("@Customers_No", textBox_Customers_No.Text);
                    cmd.Parameters.AddWithValue("@Customers_Name", textBox_Customers_Name.Text);
                    cmd.Parameters.AddWithValue("@Start_Date", dateTime_Start_Date.Value);
                    cmd.Parameters.AddWithValue("@Phone", textBox_Phone.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                    cmd.Parameters.AddWithValue("@Fax", textBox_Fax.Text);
                    cmd.Parameters.AddWithValue("@Email", textBox_Email.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Customers);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Customers);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();


                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Customers_No.Text = "";
                    textBox_Customers_Name.Text = "";
                    textBox_Phone.Text = "";
                    textBox_Address.Text = "";
                    textBox_Fax.Text = "";
                    textBox_Email.Text = "";
                    textBox_Customers_No.Focus();

                    DGV_load();

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    if (textBox_Customers_No.Text == "")
                    {
                        MessageBox.Show("يرجى تعبئة رقم العميل  ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textBox_Customers_No.Focus();
                        return;
                    }

                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_DELETE_Customers";

                        cmd.Parameters.AddWithValue("@Customers_No", textBox_Customers_No.Text);


                        cmd.ExecuteNonQuery();
                        con.Close();


                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Customers_No.Text = "";
                        textBox_Customers_Name.Text = "";
                        textBox_Phone.Text = "";
                        textBox_Address.Text = "";
                        textBox_Fax.Text = "";
                        textBox_Email.Text = "";
                        textBox_Customers_No.Focus();

                        DGV_load();

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_Customers_No.Text = dataGridView1.CurrentRow.Cells["Column_Customers_No"].Value.ToString();
                    textBox_Customers_Name.Text = dataGridView1.CurrentRow.Cells["Column_Customers_Name"].Value.ToString();
                    dateTime_Start_Date.Text = dataGridView1.CurrentRow.Cells["Column_Start_Date"].Value.ToString();
                    textBox_Phone.Text = dataGridView1.CurrentRow.Cells["Column_Phone"].Value.ToString();
                    textBox_Address.Text = dataGridView1.CurrentRow.Cells["Column_Address"].Value.ToString();
                    textBox_Fax.Text = dataGridView1.CurrentRow.Cells["Column_Fax"].Value.ToString();
                    textBox_Email.Text = dataGridView1.CurrentRow.Cells["Column_Email"].Value.ToString();



                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    Cmd.CommandText = "SP_SEARCH_DGV_Customers";
                    Cmd.Parameters.AddWithValue("@Customers_Name","%"+ textBox_search.Text+"%");
                    Cmd.Parameters.AddWithValue("@phone", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Address", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Customers", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Customers_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_Customers_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

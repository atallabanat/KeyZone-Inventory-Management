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
    public partial class Supplier : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        public Supplier()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }
        //public virable
        string nameSupplier = "";
     

        private void Supplier_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(ID_Supplier)+1),1) as max from Supplier", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_ID_Supplier.Text = dr["max"].ToString();
                }
                con.Close();

                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Supplier";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);

                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Supplier_Load(object sender, EventArgs e)
        {
            try
            {

                DGV_load();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    textBox_ID_Supplier.Text = dataGridView1.CurrentRow.Cells["Column_ID_Supplier"].Value.ToString();
                   textBox_Supplier_Name.Text = dataGridView1.CurrentRow.Cells["Column_Supplier_Name"].Value.ToString();
                    textBox_Address.Text = dataGridView1.CurrentRow.Cells["Column_Address"].Value.ToString();
                    textBox_Phone1.Text = dataGridView1.CurrentRow.Cells["Column_Phone1"].Value.ToString();
                    textBox_Phone2.Text = dataGridView1.CurrentRow.Cells["Column_Phone2"].Value.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    Cmd.CommandText = "SP_SEARCH_DGV_Supplier";
                    Cmd.Parameters.AddWithValue("@Supplier_Name", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Address", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Phone1", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Phone2", "%" + textBox_search.Text + "%");
                   
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);
                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID_Supplier.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المورد ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ID_Supplier.Focus();
                    return;
                }
                if (textBox_Supplier_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المورد", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Supplier_Name.Focus();
                    return;
                }

                else
                {


                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select ID_Supplier,Supplier_Name from Supplier where ID_Supplier=@ID_Supplier", con);
                    cmd21.Parameters.Add(new SqlParameter("@ID_Supplier", textBox_ID_Supplier.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();

                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameSupplier = "(" + dr["Supplier_Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم المورد موجود مسبقا بإسم :  " + nameSupplier + "  لا يمكن إضافة مورد بنفس الرقم   ", "تكرار البيانات رقم المورد موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_ID_Supplier.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_ADD_Supplier";
                        cmd.Parameters.AddWithValue("@ID_Supplier", textBox_ID_Supplier.Text);
                        cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                        cmd.Parameters.AddWithValue("@Phone1", textBox_Phone1.Text);
                        cmd.Parameters.AddWithValue("@Phone2", textBox_Phone2.Text);
                        cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Supplier);
                        cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Supplier);
                        cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_ID_Supplier.Text = "";
                        textBox_Supplier_Name.Text = "";
                        textBox_Address.Text = "";
                        textBox_Phone1.Text = "";
                        textBox_Phone2.Text = "";
                        textBox_ID_Supplier.Focus();
                        DGV_load();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID_Supplier.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المورد ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ID_Supplier.Focus();
                    return;
                }
                if (textBox_Supplier_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المورد", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Supplier_Name.Focus();
                    return;
                }
                else
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Supplier";
                    cmd.Parameters.AddWithValue("@ID_Supplier", textBox_ID_Supplier.Text);
                    cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                    cmd.Parameters.AddWithValue("@Phone1", textBox_Phone1.Text);
                    cmd.Parameters.AddWithValue("@Phone2", textBox_Phone2.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Supplier);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Supplier);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_ID_Supplier.Text = "";
                    textBox_Supplier_Name.Text = "";
                    textBox_Address.Text = "";
                    textBox_Phone1.Text = "";
                    textBox_Phone2.Text = "";
                    textBox_ID_Supplier.Focus();
                    DGV_load();
                }

            }

            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_ID_Supplier.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_ID_Supplier.Focus();
                    return;
                }
                else
                {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_Delete_Supplier";

                        cmd.Parameters.AddWithValue("@ID_Supplier", textBox_ID_Supplier.Text);


                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_ID_Supplier.Text = "";
                        textBox_Supplier_Name.Text = "";
                        textBox_Address.Text = "";
                        textBox_Phone1.Text = "";
                        textBox_Phone2.Text = "";
                        textBox_ID_Supplier.Focus();
                        DGV_load();

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_ID_Supplier_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}


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
    public partial class Distributor : Form
    {

        public Distributor()
        {
            this.KeyPreview = true;
            InitializeComponent();
        }
        //public virable
        string nameDis = "";

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        private void DGV_load()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Distributor_Number)+1),1) as max from Distributor", con);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Distributor_Number.Text = dr["max"].ToString();
                }
                con.Close();


                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Distributor";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
                }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_add_Click(object sender, EventArgs e)
        {
            try
            { 
                if (textBox_Distributor_Number.Text=="")
                {
                    MessageBox.Show("يرجى تعبئة رقم المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);                
                    textBox_Distributor_Number.Focus();
                    return;
                }
                if (textBox_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المندوب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Name.Focus();
                    return;
                }
                if (comboBox_Rank.SelectedIndex==-1)
                {
                    MessageBox.Show("يرجى تعبئة رتبة المندوب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox_Rank.Focus();
                    return;
                }
            
                else
                {


                    con.Open();
                    SqlCommand cmd21 = new SqlCommand("select Distributor_Number,Name from Distributor where Distributor_Number=@Distributor_Number", con);
                    cmd21.Parameters.Add(new SqlParameter("@Distributor_Number", textBox_Distributor_Number.Text));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();

                    int count = 0;
                    if (dr.Read())
                    {
                        count += 1;
                        nameDis = "(" + dr["Name"].ToString() + ")";
                    }
                    con.Close();
                    if (count == 1)
                    {
                        MessageBox.Show("رقم المندوب موجود مسبقا بإسم :  " + nameDis + "  لا يمكن إضافة مندوب بنفس الرقم   ", "تكرار البيانات رقم المندوب موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                        textBox_Distributor_Number.Focus();
                        return;
                    }
                    else
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_ADD_Distributor";
                        cmd.Parameters.AddWithValue("@Distributor_Number", textBox_Distributor_Number.Text);
                        cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
                        cmd.Parameters.AddWithValue("@Rank", comboBox_Rank.SelectedIndex);
                        cmd.Parameters.AddWithValue("@ID_Number", textBox_ID_Number.Text);
                        cmd.Parameters.AddWithValue("@Phone1", textBox_Phone1.Text);
                        cmd.Parameters.AddWithValue("@Phone2", textBox_Phone2.Text);
                        cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                        cmd.Parameters.AddWithValue("@Start_Date", dateTime_Start_Date.Value);
                        cmd.Parameters.AddWithValue("@Car_Type", textBox_Car_Type.Text);
                        cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Distributor);
                        cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Distributor);
                        cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم اضافة البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Distributor_Number.Text = "";
                        textBox_Name.Text = "";
                        comboBox_Rank.SelectedIndex = -1;
                        textBox_ID_Number.Text = "";
                        textBox_Phone1.Text = "";
                        textBox_Phone2.Text = "";
                        textBox_Address.Text = "";
                        textBox_Car_Type.Text = "";
                        textBox_Distributor_Number.Focus();
                        DGV_load();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Distributor_Load(object sender, EventArgs e)
        {
            try
            {

                DGV_load();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_edit_Click(object sender, EventArgs e)
        {
            try
            { 
                if (textBox_Distributor_Number.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Distributor_Number.Focus();
                    return;
                }
                if (textBox_Name.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة اسم المندوب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Name.Focus();
                    return;
                }
                if (comboBox_Rank.SelectedIndex == -1)
                {
                    MessageBox.Show("يرجى تعبئة رتبة المندوب", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    comboBox_Rank.Focus();
                    return;
                }

                else
                {

                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_UPDATE_Distributor";

                    cmd.Parameters.AddWithValue("@Distributor_Number", textBox_Distributor_Number.Text);
                    cmd.Parameters.AddWithValue("@Name", textBox_Name.Text);
                    cmd.Parameters.AddWithValue("@Rank", comboBox_Rank.Text);
                    cmd.Parameters.AddWithValue("@ID_Number", textBox_ID_Number.Text);
                    cmd.Parameters.AddWithValue("@Phone1", textBox_Phone1.Text);
                    cmd.Parameters.AddWithValue("@Phone2", textBox_Phone2.Text);
                    cmd.Parameters.AddWithValue("@Address", textBox_Address.Text);
                    cmd.Parameters.AddWithValue("@Start_Date", dateTime_Start_Date.Value);
                    cmd.Parameters.AddWithValue("@Car_Type", textBox_Car_Type.Text);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Distributor);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Distributor);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                    MessageBox.Show("تم تعديل البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_Distributor_Number.Text = "";
                    textBox_Name.Text = "";
                    comboBox_Rank.SelectedIndex = -1;
                    textBox_ID_Number.Text = "";
                    textBox_Phone1.Text = "";
                    textBox_Phone2.Text = "";
                    textBox_Address.Text = "";
                    textBox_Car_Type.Text = "";
                    textBox_Distributor_Number.Focus();
                    DGV_load();



                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            try
            { 
                if (textBox_Distributor_Number.Text == "")
                {
                    MessageBox.Show("يرجى تعبئة رقم المندوب ", "حقل إجباري", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Distributor_Number.Focus();
                    return;
                }

                else
                {
                    if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                    {
                        con.Open();
                        SqlCommand cmd = con.CreateCommand();

                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.CommandText = "SP_DELETE_Distributor";

                        cmd.Parameters.AddWithValue("@Distributor_Number", textBox_Distributor_Number.Text);


                        cmd.ExecuteNonQuery();
                        con.Close();
                        MessageBox.Show("تم حذف البيانات  بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        textBox_Distributor_Number.Text = "";
                        textBox_Name.Text = "";
                        comboBox_Rank.SelectedIndex = -1;
                        textBox_ID_Number.Text = "";
                        textBox_Phone1.Text = "";
                        textBox_Phone2.Text = "";
                        textBox_Address.Text = "";
                        textBox_Car_Type.Text = "";
                        textBox_Distributor_Number.Focus();
                        DGV_load();

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            try
            { 
                 if(dataGridView1.Rows.Count > 0)
                {
                    comboBox_Rank.Text = dataGridView1.CurrentRow.Cells["Column_Rank"].Value.ToString();
                    textBox_Distributor_Number.Text = dataGridView1.CurrentRow.Cells["Column_Distributor_Number"].Value.ToString();
                    textBox_Name.Text = dataGridView1.CurrentRow.Cells["Column_Name"].Value.ToString();
                    textBox_ID_Number.Text = dataGridView1.CurrentRow.Cells["Column_ID_Number"].Value.ToString();
                    textBox_Phone1.Text = dataGridView1.CurrentRow.Cells["Column_Phone1"].Value.ToString();
                    textBox_Phone2.Text = dataGridView1.CurrentRow.Cells["Column_Phone2"].Value.ToString();
                    textBox_Address.Text = dataGridView1.CurrentRow.Cells["Column_Address"].Value.ToString();
                    dateTime_Start_Date.Text = dataGridView1.CurrentRow.Cells["Column_Date_Time"].Value.ToString();
                    textBox_Car_Type.Text = dataGridView1.CurrentRow.Cells["Column_Car_Type"].Value.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    Cmd.CommandText = "SP_SEARCH_DVG_Distributor";
                    Cmd.Parameters.AddWithValue("@Name", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Phone1", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Phone2", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Address", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Rank", "%" + textBox_search.Text + "%");

                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void groupBox1_Basic_Information_Enter(object sender, EventArgs e)
        {
            try
            {
                //------------ قائمة التأمينات ---------------------------//
                DataTable Dt5 = new DataTable();
                SqlCommand ca5 = new SqlCommand("select ID,Name from Type_Distributor ", con);
                SqlDataAdapter Da5 = new SqlDataAdapter(ca5);
                Da5.Fill(Dt5);
                comboBox_Rank.DataSource = Dt5;
                comboBox_Rank.DisplayMember = "Name";
                comboBox_Rank.ValueMember = "ID";

                //------------ ----------------- ---------------------------//
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Distributor", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Distributor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_Distributor_Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}

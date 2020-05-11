
using KeyZone_Inventory_Management.Form_RPT;
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

namespace KeyZone_Inventory_Management
{
    public partial class Entity_Bond : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Entity_Bond entity_Bond;
        string Checkbox_DateEnd;
        double Quntity = 0;
        double Cost = 0;
        int NewRow = 0;
        double Unit_Rate;
        double Qty;
        double R_A_Qty;
        int Print = 0;
        int printNo;
        public Entity_Bond()
        {
            this.KeyPreview = true;
            entity_Bond = this;
            InitializeComponent();
        }

      

            private void textBox_Bond_No_KeyPress(object sender, KeyPressEventArgs e)
            {
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                {
                    e.Handled = true;
                }
            }


        private void Entity_Bond_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Bond_No)+1),1) as max from Entry_Bond where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Bond_No.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Bond_No.Focus();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void max()
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Bond_No)+1),1) as max from Entry_Bond where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Bond_No.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Bond_No.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void textBox_Supplier_No_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Item_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Unit_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Stores_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Qantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Cost_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Delete_Row_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_Entry_Bond = true;
            Grid_Supplier grid_Supplier = new Grid_Supplier();
            grid_Supplier.ShowDialog();
            Grid_Supplier.SCR_Entry_Bond = false;
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Entry_Bond = true;
            Grid_Item grid_Item = new Grid_Item();
            grid_Item.ShowDialog();
            Grid_Item.SCR_Entry_Bond = false;
        }

        private void btn_Unit_Click(object sender, EventArgs e)
        {
            if (textBox_Item_No.Text != "")
            {
                Grid_Unit.SCR_Entry_Bond = true;
                Grid_Unit grid_Unit = new Grid_Unit();
                grid_Unit.ShowDialog();
                Grid_Unit.SCR_Entry_Bond = false;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_Entry_Bond = true;
            Grid_Stores grid_Stores = new Grid_Stores();
            grid_Stores.ShowDialog();
            Grid_Stores.SCR_Entry_Bond = false;
        }

        private void textBox_Supplier_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Supplier_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select ID_Supplier,Supplier_Name  from Supplier where ID_Supplier=@ID_Supplier", con);
                        cmd.Parameters.Add(new SqlParameter("@ID_Supplier", textBox_Supplier_No.Text));
                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Supplier_Name.Text = Ra["Supplier_Name"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("لا يوجد مورد بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Supplier_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();
                    }


                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_Item_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Item_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select Item_No,Item_Name  from INV_F where Item_No=@Item_No", con);
                        cmd.Parameters.Add(new SqlParameter("@Item_No", textBox_Item_No.Text));
                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Item_Name.Text = Ra["Item_Name"].ToString();
                            textBox_Unit_No.Text = "";
                            textBox_Unit_Name.Text = "";
                        }
                        else
                        {
                            MessageBox.Show("لا يوجد مادة بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Item_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();
                    }


                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Unit_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Unit_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select Unit_No,Unit_Name  from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                        cmd.Parameters.Add(new SqlParameter("@Item_No", textBox_Item_No.Text));
                        cmd.Parameters.Add(new SqlParameter("@Unit_No", textBox_Unit_No.Text));

                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Unit_Name.Text = Ra["Unit_Name"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("لا يوجد وحدة لهذه المادة بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Unit_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Stores_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Stores_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select SNo,SName  from Stores where SNo=@SNo", con);
                        cmd.Parameters.Add(new SqlParameter("@SNo", textBox_Stores_No.Text));

                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Stores_Name.Text = Ra["SName"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("لا يوجد مستودع بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Stores_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();
                    }







                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void flag_endDate()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("select Checkbox_DateEnd  from INV_F where Item_No=@Item_No", con);
                cmd.Parameters.Add(new SqlParameter("@Item_No", textBox_Item_No.Text));

                con.Open();
                SqlDataReader Ra = cmd.ExecuteReader();
                if (textBox_Item_No.Text != "")
                {
                    if (Ra.Read())
                    {
                        Checkbox_DateEnd = Ra["Checkbox_DateEnd"].ToString();

                    }
                    else
                    {
                        Checkbox_DateEnd = "0";
                    }

                }
                Ra.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Item_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رمز المادة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Item_No.Focus();
                    return;

                }
                if (textBox_Item_Name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك اسم المادة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Item_No.Focus();
                    return;
                }
                if (textBox_Unit_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم الوحدة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Unit_No.Focus();
                    return;
                }
                if (textBox_Unit_Name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك اسم الوحدة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Unit_No.Focus();
                    return;
                }
                if (textBox_Stores_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم المستودع فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Stores_No.Focus();
                    return;
                }
                if (textBox_Stores_Name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك اسم المستودع فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Stores_No.Focus();
                    return;
                }
                if (textBox_Qantity.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك الكمية فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Qantity.Focus();
                    return;
                }
                if (textBox_Cost.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك الكلفة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Cost.Focus();
                    return;
                }
                if (textBox_End_Date.Text == "  /  /" && Checkbox_DateEnd == "1")
                {
                    MessageBox.Show("هذه المادة مرتبطة بتاريخ صلاحية لا يمكنك ترك تاريخ الصلاحية فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_End_Date.Focus();
                    return;
                }
                try
                {
                    DateTime dew = Convert.ToDateTime(textBox_End_Date.Text);
                }
                catch
                {
                    textBox_End_Date.Text = "";
                    if (Checkbox_DateEnd == "1")
                    {
                        MessageBox.Show("هذه المادة مرتبطة بتاريخ صلاحية لا يمكنك ترك تاريخ الصلاحية فارغ أو التاريخ المدخل غير صحيح", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        return;
                    }

                }
                Data_ADD_Rows();

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Stores_No.Text, textBox_Stores_Name.Text, textBox_Qantity.Text, textBox_Cost.Text, textBox_total1_groupbox1.Text, textBox_End_Date.Text);
                textBox_Item_No.Text = "";
                textBox_Item_Name.Text = "";
                textBox_Unit_No.Text = "";
                textBox_Unit_Name.Text = "";
                textBox_Qantity.Text = "";
                textBox_Cost.Text = "";
                textBox_total1_groupbox1.Text = "";
                textBox_Stores_No.Text = "";
                textBox_Stores_Name.Text = "";
                textBox_End_Date.Text = "";
                MessageBox.Show("تم إضافة المادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Item_No.Focus();
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Sum_TotalGrid()
        {
            try
            {
                double TotalALLRows = 0;
                double TotalALLQuntity = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);
                    double TotalQuntity = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

                    TotalALLRows += TotalRows;
                    TotalALLQuntity += TotalQuntity;
                    textBox_Total2_groupBox2.Text = TotalALLRows.ToString();
                    textBox1.Text = TotalALLQuntity.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Sum_Total_Item()
        {
            try
            {
                if (textBox_Qantity.Text == "")
                {
                    Quntity = 0;
                }
                else
                {
                    Quntity = Convert.ToDouble(textBox_Qantity.Text);


                }
                if (textBox_Cost.Text == "")
                {
                    Cost = 0;

                }
                else
                {
                    Cost = Convert.ToDouble(textBox_Cost.Text);

                }

                textBox_total1_groupbox1.Text =Convert.ToString( Quntity * Cost);


            }
            catch
            {
                Quntity = 0;
                Cost = 0;
                textBox_total1_groupbox1.Text = "0";



            }



        }

        private void textBox_Item_No_TextChanged(object sender, EventArgs e)
        {
            try
            {


                flag_endDate();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_End_Date_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    btn_Add_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Qantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_Cost_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {

                    textBox_Item_No.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    textBox_Item_Name.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                    textBox_Unit_No.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                    textBox_Unit_Name.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
                    textBox_Stores_No.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox_Stores_Name.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox_Qantity.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox_Cost.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox_total1_groupbox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox_End_Date.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();


                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Entity_Bond_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }
        private void ADD_Row()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Entry_Bond";

                    cmd.Parameters.AddWithValue("@Bond_No", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Bond_Date", dateTime_Bond_Date.Value);
                    if (textBox_Supplier_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", textBox_Supplier_No.Text);

                    }

                    cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    cmd.Parameters.AddWithValue("@Total_Bond", textBox_Total2_groupBox2.Text);
                    cmd.Parameters.AddWithValue("@Total_Qty_Bond", textBox1.Text);


                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@R_Sores_No", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@R_Cost", dataGridView1.Rows[i].Cells[7].Value);

                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells[8].Value);
                    if (dataGridView1.Rows[i].Cells[9].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", dataGridView1.Rows[i].Cells[9].Value);

                    }
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Entry_Bond);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Entry_Bond);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم تخزين المستند  بنجاح بالرقم " + textBox_Bond_No.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DELETE_Row_i2_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_Entry_Bond_i2_Trans";

                cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Entry_Bond);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ADD_Row_i2_trans()
        {
            try
            {


                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Row_Entry_Bond_i2_trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //Kind >> ادخال 1 
                    cmd.Parameters.AddWithValue("@Kind", 1);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Entry_Bond);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Entry_Bond);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", 3);
                    cmd.Parameters.AddWithValue("@S_No", textBox_Supplier_No.Text);
                    cmd.Parameters.AddWithValue("@S_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    cmd.Parameters.AddWithValue("@Total_Order", textBox_Total2_groupBox2.Text);
                    cmd.Parameters.AddWithValue("@Discount", 0);
                    cmd.Parameters.AddWithValue("@On_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@R_Sores_No", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i].Cells[6].Value);
                    //---------إستعلام عن معامل التحويل------------------------------

                    SqlCommand cmd21 = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i].Cells[0].Value));
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i].Cells[2].Value));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    Qty = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    if (dr.Read())
                    {
                        Unit_Rate = Convert.ToDouble(dr["Unit_Rate"].ToString());
                    }
                    else
                    {
                        Unit_Rate = 1;
                    }
                    dr.Close();


                    R_A_Qty = Qty * Unit_Rate;
                    cmd.Parameters.AddWithValue("@R_A_Qty", R_A_Qty);
                    //----------------------------------------------------------------------
                    cmd.Parameters.AddWithValue("@R_Price", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@R_Discount", 0);
                    cmd.Parameters.AddWithValue("@R_Discount_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells[8].Value);
                    if (dataGridView1.Rows[i].Cells[9].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", dataGridView1.Rows[i].Cells[9].Value);

                    }
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_Entry_Bond";

                cmd.Parameters.AddWithValue("@Bond_No", textBox_Bond_No.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1020 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void clear_screen()
        {
            textBox_Bond_No.Text = "";
            textBox_Supplier_No.Text = "";
            textBox_Supplier_Name.Text = "";
            textBox_Note.Text = "";
            textBox_Total2_groupBox2.Text = "";
            textBox1.Text = "";
            dataGridView1.Rows.Clear();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Print = 0;
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox_Bond_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم السند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                printNo = Convert.ToInt32(textBox_Bond_No.Text);
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("يرجى عدم ترك الفاتورة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                con.Open();
                SqlCommand cmd22 = new SqlCommand("select DISTINCT Bond_No from Entry_Bond where Bond_No=@Bond_No and MYear=@MYear", con);
                cmd22.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd22.Parameters.Add(new SqlParameter("@MYear", textBox_Year.Text));

                SqlDataReader dr2;
                dr2 = cmd22.ExecuteReader();

                if (dr2.Read())
                {
                    NewRow = 1;

                }
                else
                {
                    NewRow = 0;
                }
                con.Close();
                //----------------------------------------------------------------------------------------------------------------

                if (NewRow == 0)
                {
                    ADD_Row_i2_trans();
                    ADD_Row();
                    clear_screen();
                    Entity_Bond_Load(sender, e);
                }
                else if (NewRow == 1)
                {
                    Delete_Row();
                    DELETE_Row_i2_Trans();
                    ADD_Row_i2_trans();
                    ADD_Row();
                    clear_screen();
                    Entity_Bond_Load(sender, e);

                }
                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Entry_Bond where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Year.Text = dr["Myear"].ToString();
                    dateTime_Bond_Date.Text = dr["Bond_Date"].ToString();
                    textBox_Supplier_No.Text = dr["Supplier_No"].ToString();
                    textBox_Supplier_Name.Text = dr["Supplier_Name"].ToString();
                    textBox_Note.Text = dr["Note"].ToString();
                    textBox_Total2_groupBox2.Text = dr["Total_Bond"].ToString();
                    textBox1.Text = dr["Total_Qty_Bond"].ToString();
                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    max();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Item_No,R_Item_Name,R_Unit_No,R_Unit_Name,R_Sores_No, R_Stores_Name, R_Quantity,R_Cost,R_Total,R_End_Date from Entry_Bond where Bond_No=@Bond_No", con);
                cmd.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Item_No"].ToString(), dr2["R_Item_Name"].ToString(), dr2["R_Unit_No"].ToString(), dr2["R_Unit_Name"].ToString(), dr2["R_Sores_No"].ToString(), dr2["R_Stores_Name"].ToString(), dr2["R_Quantity"].ToString(), dr2["R_Cost"].ToString(), dr2["R_Total"].ToString(), dr2["R_End_Date"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1022 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            if(textBox_Year.Text!="")
            {
                Grid_Entry_Bond entry_Bond = new Grid_Entry_Bond();
                entry_Bond.ShowDialog();
            }
        }

        private void textBox_Bond_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Bond_No.Text != "")
                    {
                        addScren();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Entry_Bond fRM_Report_Entry_Bond = new FRM_Report_Entry_Bond();
                    fRM_Report_Entry_Bond.Show();
                    FRM_Report_Entry_Bond.fRM_Report.textBox_Bond_No.Text = printNo.ToString();
                    FRM_Report_Entry_Bond.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1024 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك حقل السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (textBox_Bond_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم السند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    Delete_Row();
                    DELETE_Row_i2_Trans();
                    MessageBox.Show("تم حذف المستند بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_screen();
                    Entity_Bond_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Entry_Bond", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

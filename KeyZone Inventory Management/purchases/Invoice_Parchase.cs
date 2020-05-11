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

namespace KeyZone_Inventory_Management.purchases
{
    public partial class Invoice_Parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Invoice_Parchase Inv_Parchase;
        string Approval;
        int Check_Approval;
        int NewRow = 0;
        int status_Invoice;
        int On_Percentage;
        double Unit_Rate;
        double Qty;
        double R_A_Qty;
        int Print = 0;
        int printNo;


        public Invoice_Parchase()
        {
            this.KeyPreview = true;
            Inv_Parchase = this;
            InitializeComponent();
        }
        //varriable
        string Checkbox_DateEnd;
        double Quntity = 0;
        double Price_parchase = 0;
        double discount = 0;
        double discount2;
        double discount_Percent = 0;
        double Total_Before_Discount = 0;
        double Total_After_Discount = 0;
        double Total = 0;

        private void Sum_Total_Item()
        {
            try
            {
                if(textBox_Qantity.Text =="")
                {
                    Quntity = 0;
                }
                else
                {
                    Quntity = Convert.ToDouble(textBox_Qantity.Text);


                }
                if (textBox_Price_Parchase.Text =="")
                {
                    Price_parchase = 0;

                }
                else
                {
                    Price_parchase = Convert.ToDouble(textBox_Price_Parchase.Text);

                }
                
                Total_Before_Discount = (Quntity * Price_parchase);

                if(textBox_Discount1_GroupBox1.Text=="")
                {
                    discount = 0;

                }
                else
                {
                    discount = Convert.ToDouble(textBox_Discount1_GroupBox1.Text);

                }
                if (textBox_Discount_Percentage.Text =="")
                {
                    discount_Percent = 0;
                }
                else
                {
                    discount_Percent = Convert.ToDouble(textBox_Discount_Percentage.Text) / 100;

                }

                Total_After_Discount = Total_Before_Discount - discount;
                Total = Total_After_Discount - (Total_Before_Discount * discount_Percent);

                textBox_total1_groupbox1.Text = Total.ToString();


            }
            catch
            {
                Quntity = 0;
                Price_parchase = 0;
                discount = 0;
                discount_Percent = 0;
                Total_Before_Discount = 0;
                Total_After_Discount = 0;
                Total = 0;
                textBox_total1_groupbox1.Text = Total.ToString();



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

        private void textBox_Qantity_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Price_Parchase_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Discount1_GroupBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



       

        private void textBox_Discount_Percentage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_End_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void Invoice_Parchase_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Invoice_No)+1),1) as max from Invoice_Parchase where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Invoice__Number.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Invoice__Number.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Year_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Year_Leave(object sender, EventArgs e)
        {
            if (textBox_Year.Text.Length > 4 || textBox_Year.Text.Length < 4)
            {
                textBox_Year.Text = "";
            }
        }

        private void Invoice_Parchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_Invoice__Number_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Supplier_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount1_GroupBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount_Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_Invoice_Parchase = true;
            Grid_Supplier ss = new Grid_Supplier();
            ss.ShowDialog();
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Invoice_Parchase = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
        }

        private void btn_Unit_Click(object sender, EventArgs e)
        {
            if (textBox_Item_No.Text != "")
            {
                Grid_Unit.SCR_Invoice_Parchase = true;
                Grid_Unit ss = new Grid_Unit();
                ss.ShowDialog();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_Invoice_Parchase = true;
            Grid_Stores ss = new Grid_Stores();
            ss.ShowDialog();
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_Stores_No_KeyPress_1(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
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
                if (textBox_Price_Parchase.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك سعر الشراء فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Price_Parchase.Focus();
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Sum_TotalGrid()
        {
            try
            {
                double TotalALLRows = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[8].Value);

                    TotalALLRows += TotalRows;
                    textBox_Total.Text = TotalALLRows.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Qantity.Text, textBox_Price_Parchase.Text, textBox_Discount1_GroupBox1.Text, textBox_Discount_Percentage.Text, textBox_total1_groupbox1.Text, textBox_Stores_No.Text, textBox_Stores_Name.Text, textBox_End_Date.Text);
                textBox_Item_No.Text = "";
                textBox_Item_Name.Text = "";
                textBox_Unit_No.Text = "";
                textBox_Unit_Name.Text = "";
                textBox_Qantity.Text = "";
                textBox_Price_Parchase.Text = "";
                textBox_Discount1_GroupBox1.Text = "";
                textBox_Discount_Percentage.Text = "";
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Item_No_TextChanged(object sender, EventArgs e)
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_End_Date_KeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {


                if (e.KeyCode == Keys.Enter)
                {
                    //dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Qantity.Text, textBox_Price_Parchase.Text, textBox_Discount1_GroupBox1.Text, textBox_Discount_Percentage.Text, textBox_total1_groupbox1.Text, textBox_Stores_No.Text, textBox_Stores_Name.Text, textBox_End_Date.Text);
                    //textBox_Item_No.Text = "";
                    //textBox_Item_Name.Text = "";
                    //textBox_Unit_No.Text = "";
                    //textBox_Unit_Name.Text = "";
                    //textBox_Qantity.Text = "";
                    //textBox_Price_Parchase.Text = "";
                    //textBox_Discount1_GroupBox1.Text = "";
                    //textBox_Discount_Percentage.Text = "";
                    //textBox_total1_groupbox1.Text = "";
                    //textBox_Stores_No.Text = "";
                    //textBox_Stores_Name.Text = "";
                    //textBox_End_Date.Text = "";

                    //MessageBox.Show("تم إضافة المادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //textBox_Item_No.Focus();
                    btn_Add_Click(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Sum_Total_Parchase()
        {
            try
            {
                if (textBox_Discount.Text != "")
                {
                    discount2 = Convert.ToDouble(textBox_Discount.Text);
                    if (checkBox2.Checked == true)
                    {
                        discount2 = (discount2 / 100) * Convert.ToDouble(textBox_Total.Text);

                    }
                }
                else
                {
                    discount2 = 0;
                }
                double totall = Convert.ToDouble(textBox_Total.Text) - discount2;
                textBox_Net_Total.Text = totall.ToString();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBox2.Checked == true)
                {
                    On_Percentage = 1;
                }
                else
                {
                    On_Percentage = 0;
                }
                Sum_Total_Parchase();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }


        private void textBox_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Parchase();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Total_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Parchase();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1022 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Print = 0;
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (textBox_Invoice__Number.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم الفاتورة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

                printNo = Convert.ToInt32(textBox_Invoice__Number.Text);
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("الفاتورة فارغه", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                if (textBox_Supplier_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم المورد فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (textBox_Supplier_Name.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك اسم المورد فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (textBox_Net_Total.Text == "" || textBox_Net_Total.Text == "0")
                {
                    MessageBox.Show("لا يمكنك حفظ فاتورة قيمتها 0", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }


                //----------------------------------------اذا كانت الفاتورة معتمدة لا يقبل التعديل--------------------------------------------------------------------
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select DISTINCT Approval from Invoice_Parchase where Invoice_No=@Invoice_No and myear=@myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice__Number.Text));
                cmd21.Parameters.Add(new SqlParameter("@myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    Approval = dr["Approval"].ToString();

                }
                else
                {
                    Approval = "0";
                }
                con.Close();
                //----------------------------------------------------------------------------------------------------------------


                //----------------------------------------------تفقيد الفاتورة موجودة في الداتا--------------------------------------------------------------
                con.Open();
                SqlCommand cmd22 = new SqlCommand("select DISTINCT Invoice_No from Invoice_Parchase where Invoice_No=@Invoice_No and myear=@myear", con);
                cmd22.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice__Number.Text));
                cmd22.Parameters.Add(new SqlParameter("@myear", textBox_Year.Text));
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



                if (Approval == "1")
                {
                    MessageBox.Show("عذرا الفاتورة معتمدة ومرحلة لايمكنك التعديل عليها", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Invoice__Number.Focus();
                    return;
                }
                else
                {
                    if (NewRow == 0)
                    {
                        if (check_OK_Invoice.Checked == false)
                        {
                            if (MessageBox.Show("سيتم حفظ الفاتورة من غير اعتمادها ، هل تريد اعتمادها ؟", "فاتورة غير معتمدة", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                check_OK_Invoice.Checked = true;
                                if (check_OK_Invoice.Checked == true)
                                {
                                    ADD_Row_Trans();
                                }
                                ADD_Row();
                                clear_screen();
                                Invoice_Parchase_Load(sender, e);
                            }
                            else
                            {

                                ADD_Row();
                                clear_screen();
                                Invoice_Parchase_Load(sender, e);
                            }
                        }
                        else
                        {
                            if (check_OK_Invoice.Checked == true)
                            {
                                ADD_Row_Trans();
                            }
                            ADD_Row();
                            clear_screen();
                            Invoice_Parchase_Load(sender, e);
                        }

                    }
                    else if (NewRow == 1)
                    {

                        if (check_OK_Invoice.Checked == false)
                        {
                            if (MessageBox.Show("سيتم حفظ الفاتورة من غير اعتمادها ، هل تريد اعتمادها ؟", "فاتورة غير معتمدة", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                            {
                                check_OK_Invoice.Checked = true;
                                if (check_OK_Invoice.Checked == true)
                                {
                                    ADD_Row_Trans();
                                }
                                Delete_Row();
                                ADD_Row();
                                clear_screen();
                                Invoice_Parchase_Load(sender, e);
                            }
                            else
                            {
                                Delete_Row();
                                ADD_Row();
                                clear_screen();
                                Invoice_Parchase_Load(sender, e);
                            }
                        }
                        else
                        {
                            Delete_Row();
                            if (check_OK_Invoice.Checked == true)
                            {
                                ADD_Row_Trans();
                            }
                            ADD_Row();
                            clear_screen();
                            Invoice_Parchase_Load(sender, e);
                        }

                    }
                }






                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Max()
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Invoice_No)+1),1) as max from Invoice_Parchase where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Invoice__Number.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Invoice__Number.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1024 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Invoice_Parchase where Invoice_No=@Invoice_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice__Number.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Supplier_No.Text = dr["Supplier_No"].ToString();
                    textBox_Supplier_Name.Text = dr["Supplier_Name"].ToString();
                    textBox_Year.Text = dr["Myear"].ToString();
                    textBox_Total.Text = dr["Invoice_before_NetTotal"].ToString();
                    textBox_Discount.Text = dr["Invoice_Net_Discount"].ToString();
                    textBox_Note.Text = dr["Invoice_Note"].ToString();
                    dateTime_Invoice_Date.Text = dr["Invoice_Date"].ToString();
                    status_Invoice = Convert.ToInt32(dr["status_Invoice"].ToString());
                    if (status_Invoice == 0)
                    {
                        radioButton1.Checked = true;
                    }
                    else if (status_Invoice == 1)
                    {
                        radioButton2.Checked = true;
                    }
                    On_Percentage = Convert.ToInt32(dr["On_Percentage"]);
                    if (On_Percentage == 1)
                    {
                        checkBox2.Checked = true;
                    }
                    else
                    {
                        checkBox2.Checked = false;
                    }
                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    Max();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Item_No,R_Item_Name,R_Unit_No,R_Unit_Name,R_Quantity,R_Price_Parchase,R_Discount,R_Discount_Percentage,R_Total,R_Sores_No,R_Stores_Name,R_End_Date from Invoice_Parchase where Invoice_No=@Invoice_No and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                cmd.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice__Number.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Item_No"].ToString(), dr2["R_Item_Name"].ToString(), dr2["R_Unit_No"].ToString(), dr2["R_Unit_Name"].ToString(), dr2["R_Quantity"].ToString(), dr2["R_Price_Parchase"].ToString(), dr2["R_Discount"].ToString(), dr2["R_Discount_Percentage"].ToString(), dr2["R_Total"].ToString(), dr2["R_Sores_No"].ToString(), dr2["R_Stores_Name"].ToString(), dr2["R_End_Date"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void clear_screen()
        {
            textBox_Supplier_No.Text = "";
            textBox_Supplier_Name.Text = "";
            textBox_Note.Text = "";
            radioButton1.Checked = true;
            checkBox2.Checked = false;
            textBox_Total.Text = "0";
            textBox_Net_Total.Text = "";
            textBox_Discount.Text = "";
            dataGridView1.Rows.Clear();
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

                    cmd.CommandText = "SP_ADD_Invoice_Parchase";

                    cmd.Parameters.AddWithValue("@Invoice_No", textBox_Invoice__Number.Text);
                    cmd.Parameters.AddWithValue("@Approval", Check_Approval);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Invoice_Date", dateTime_Invoice_Date.Value);

                    if (textBox_Supplier_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@status_Invoice", status_Invoice);
                    cmd.Parameters.AddWithValue("@Invoice_Note", textBox_Note.Text);
                    if (textBox_Net_Total.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Invoice_Net_Total", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Invoice_Net_Total", textBox_Net_Total.Text);

                    }
                    if (textBox_Discount.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Invoice_Net_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Invoice_Net_Discount", textBox_Discount.Text);

                    }
                    if (textBox_Total.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Invoice_before_NetTotal", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Invoice_before_NetTotal", textBox_Total.Text);

                    }

                    cmd.Parameters.AddWithValue("@On_Percentage", On_Percentage);
                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@R_Sores_No", dataGridView1.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", dataGridView1.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@R_Price_Parchase", dataGridView1.Rows[i].Cells[5].Value);
                    if (dataGridView1.Rows[i].Cells[6].Value == "" || dataGridView1.Rows[i].Cells[6].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", dataGridView1.Rows[i].Cells[6].Value);
                    }
                    if (dataGridView1.Rows[i].Cells[7].Value == "" || dataGridView1.Rows[i].Cells[7].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount_Percentage", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount_Percentage", dataGridView1.Rows[i].Cells[7].Value);

                    }
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells[8].Value);
                    if (dataGridView1.Rows[i].Cells[11].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", dataGridView1.Rows[i].Cells[11].Value);

                    }
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم اضافة الطلب  بنجاح بالرقم " + textBox_Invoice__Number.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1026 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ADD_Row_Trans()
        {
            try
            {
                for (int i2 = 0; i2 < dataGridView1.Rows.Count; i2++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Invoice_Parchase_i2_Trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Invoice__Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //إدخال-------------------------------------
                    cmd.Parameters.AddWithValue("@Kind", 1);
                    //-------------------------------------------
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Invoice_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", status_Invoice);

                    if (textBox_Supplier_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@S_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@S_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@S_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Note.Text);
                    if (textBox_Total.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Total_Order", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Total_Order", textBox_Total.Text);

                    }
                    if (textBox_Discount.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Discount", textBox_Discount.Text);

                    }

                    cmd.Parameters.AddWithValue("@On_Percentage", On_Percentage);


                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i2].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i2].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i2].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i2].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@R_Sores_No", dataGridView1.Rows[i2].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", dataGridView1.Rows[i2].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i2].Cells[4].Value);
                    //---------إستعلام عن معامل التحويل------------------------------

                    SqlCommand cmd21 = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i2].Cells[0].Value));
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i2].Cells[2].Value));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    Qty = Convert.ToDouble(dataGridView1.Rows[i2].Cells[4].Value);
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
                    cmd.Parameters.AddWithValue("@R_Price", dataGridView1.Rows[i2].Cells[5].Value);
                    if (dataGridView1.Rows[i2].Cells[6].Value == "" || dataGridView1.Rows[i2].Cells[6].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount", dataGridView1.Rows[i2].Cells[6].Value);
                    }
                    if (dataGridView1.Rows[i2].Cells[7].Value == "" || dataGridView1.Rows[i2].Cells[7].Value == null)
                    {
                        cmd.Parameters.AddWithValue("@R_Discount_Percentage", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_Discount_Percentage", dataGridView1.Rows[i2].Cells[7].Value);

                    }
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i2].Cells[8].Value);
                    if (dataGridView1.Rows[i2].Cells[11].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", dataGridView1.Rows[i2].Cells[11].Value);

                    }
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1027 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_Invoice_Parchase";

                cmd.Parameters.AddWithValue("@Invoice_No", textBox_Invoice__Number.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1028 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void check_OK_Invoice_CheckedChanged(object sender, EventArgs e)
        {
            if(check_OK_Invoice.Checked==true)
            {
                Check_Approval = 1;
            }
            else
            {
                Check_Approval = 0;
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Invoice = 0;
            }
            if (radioButton2.Checked == true)
            {
                //مم مدينة
                status_Invoice = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Invoice = 0;
            }
            if (radioButton2.Checked == true)
            {
                //مم مدينة
                status_Invoice = 1;
            }
        }

        private void textBox_Invoice__Number_KeyDown(object sender, KeyEventArgs e)


        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Invoice__Number.Text != "")
                    {
                        addScren();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1029 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Invoice_No_Click(object sender, EventArgs e)
        {
            if (textBox_Year.Text != "")
            {
                Grid_Invoice_Parchase ss = new Grid_Invoice_Parchase();
                ss.ShowDialog();
            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (textBox_Invoice__Number.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم الفاتورة فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

                //----------------------------------------اذا كانت الفاتورة معتمدة لا يقبل الحذف--------------------------------------------------------------------
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select DISTINCT Approval from Invoice_Parchase where Invoice_No=@Invoice_No", con);
                cmd21.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice__Number.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    Approval = dr["Approval"].ToString();

                }
                else
                {
                    Approval = "0";
                }
                con.Close();
                //----------------------------------------------------------------------------------------------------------------


                if (Approval == "1")
                {
                    MessageBox.Show("عذرا الفاتورة معتمدة ومرحلة لايمكنك حذفها", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox_Invoice__Number.Focus();
                    return;
                }
                else
                {
                    Delete_Row();
                    clear_screen();
                    Invoice_Parchase_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1030 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {




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
                    textBox_Stores_No.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textBox_Stores_Name.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();
                    textBox_Qantity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox_Price_Parchase.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox_Discount1_GroupBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox_Discount_Percentage.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox_total1_groupbox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox_End_Date.Text = dataGridView1.CurrentRow.Cells[11].Value.ToString();


                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1031 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Invoice_Parchase FRM_Report_Invoice_Parchase2 = new FRM_Report_Invoice_Parchase();
                    FRM_Report_Invoice_Parchase2.Show();
                    FRM_Report_Invoice_Parchase.fRM_Report.textBox_Invoice__Number.Text = printNo.ToString();
                    FRM_Report_Invoice_Parchase.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1032 Invoice_Parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Invoice__Number_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

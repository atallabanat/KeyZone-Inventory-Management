using KeyZone_Inventory_Management.Form_RPT;
using KeyZone_Inventory_Management.Grid;
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
    public partial class return_parchase : Form
    {

        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static return_parchase return_Parchase;
        int status_Invoice;
        double Quntity = 0;
        double Price_parchase = 0;
        double discount_Percent = 0;
        double Total_Before_Discount = 0;
        double Total_After_Discount = 0;
        double discount = 0;
        double Total = 0;
        int NewRow=0;
        double Unit_Rate;
        double Qty;
        double R_A_Qty;
        double Unit_Rate2;
        double QauntityText = 0;
        double ALLQauntity = 0;
        double QauntityCC = 0;
        int status_Order = 0;
        int Print = 0;
        int printNo;
        public return_parchase()
        {
            return_Parchase = this;
            this.KeyPreview = true;
            InitializeComponent();
        }


        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Invoice_Parchase where Invoice_No=@Invoice_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice_Parchase_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Invoice_Parchase_year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Supplier_No.Text = dr["Supplier_No"].ToString();
                    textBox_Supplier_Name.Text = dr["Supplier_Name"].ToString();
                    textBox_Note.Text = dr["Invoice_Note"].ToString();
                    status_Invoice = Convert.ToInt32(dr["status_Invoice"].ToString());
                    if (status_Invoice == 0)
                    {
                        radioButton1.Checked = true;
                    }
                    else if (status_Invoice == 1)
                    {
                        radioButton2.Checked = true;
                    }


                    textBox_Total.Text = dr["Invoice_before_NetTotal"].ToString();


                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    // Max();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Item_No,R_Item_Name,R_Unit_No,R_Unit_Name,R_Quantity,R_Price_Parchase,R_Discount,R_Discount_Percentage,R_Total,R_Sores_No,R_Stores_Name,R_End_Date from Invoice_Parchase where Invoice_No=@Invoice_No and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice_Parchase_No.Text));
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Invoice_Parchase_year.Text));
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void clear_screen()
        {
            textBox_Supplier_No.Text = "";
            textBox_Supplier_Name.Text = "";
            textBox_Note.Text = "";
            radioButton1.Checked = true;
            
            textBox_Total.Text = "0";

            textBox_Invoice_Parchase_No.Text = "";
            dataGridView1.Rows.Clear();
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void return_parchase_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;
                textBox_Invoice_Parchase_year.Text = date;
                MaxBond();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void MaxBond()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Bond_No)+1),1) as max from return_parchase where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_return_ID.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_return_ID.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void return_parchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void textBox_return_ID_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Invoice_Parchase_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Invoice_Parchase_Date_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_Discount_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Price_Parchase_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount1_GroupBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Discount_Percentage_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_return_Parchase = true;
            Grid_Supplier ss = new Grid_Supplier();
            ss.ShowDialog();
            Grid_Supplier.SCR_return_Parchase = false;
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_return_Parchase = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
            Grid_Item.SCR_return_Parchase = false;
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

                //----------------- تفقيد الكمية ------------------------------------------------------------------------------------------------------------------------------

                SelectUnit_Rate();
                QauntityText = Convert.ToDouble(textBox_Qantity.Text);
                ALLQauntity = QauntityText * Unit_Rate2;
                QauntityCC2();

                if (ALLQauntity > QauntityCC)
                {
                    MessageBox.Show(" عذرا الكمية غير كافية ، الكمية المتواجدة في هذا المستودع  " + QauntityCC + "  والكمية المراد إخراجها   " + ALLQauntity);
                    return;
                }

                //--------------------------------------------------------------------------------------------------------------------------------------------------------------
                Data_ADD_Rows();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void QauntityCC2()
        {
            try
            {
                SqlCommand cmd = new SqlCommand("SELECT  sum(case when Kind = 1 and R_Sores_No=@R_Sores_No then R_A_Qty else 0 end) - sum(case when Kind = 2 and R_Sores_No =@R_Sores_No then R_A_Qty else 0 end) as Quantity FROM i2_trans with(nolock) where R_Item_No=@R_Item_No and R_End_Date=@R_End_Date and R_Sores_No=@R_Sores_No", con);
                cmd.Parameters.Add(new SqlParameter("@R_Item_No", textBox_Item_No.Text));
                string EEND_DATE = textBox_End_Date.Text;
                if (EEND_DATE == "  /  /")
                {
                    EEND_DATE = "";
                }
                cmd.Parameters.Add(new SqlParameter("@R_End_Date", EEND_DATE));
                cmd.Parameters.Add(new SqlParameter("@R_Sores_No", textBox_Stores_No.Text));


                con.Open();
                SqlDataReader Ra = cmd.ExecuteReader();

                if (Ra.Read())
                {
                    if (Ra["Quantity"].ToString() == "")
                    {
                        QauntityCC = 0;
                    }
                    else
                    {
                        QauntityCC = Convert.ToDouble(Ra["Quantity"].ToString());
                    }






                }
                else
                {
                    QauntityCC = 0;
                }


                Ra.Close();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        public void SelectUnit_Rate()
        {
            try
            {
                if (textBox_Item_No.Text != "" && textBox_Unit_No.Text != "")
                {
                    SqlCommand cmd = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No =@Item_No and Unit_No=@Unit_No", con);
                    cmd.Parameters.Add(new SqlParameter("@Item_No", textBox_Item_No.Text));
                    cmd.Parameters.Add(new SqlParameter("@Unit_No", textBox_Unit_No.Text));

                    con.Open();
                    SqlDataReader Ra = cmd.ExecuteReader();
                    if (textBox_Item_No.Text != "")
                    {
                        if (Ra.Read())
                        {
                            Unit_Rate2 = Convert.ToDouble(Ra["Unit_Rate"].ToString());

                        }
                        else
                        {
                            Unit_Rate2 = 1;
                        }

                    }
                    Ra.Close();
                    con.Close();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }



        private void textBox_return_ID_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_return_ID.Text != "")
                    {
                        addScren_Bond();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_Price_Parchase.Text == "")
                {
                    Price_parchase = 0;

                }
                else
                {
                    Price_parchase = Convert.ToDouble(textBox_Price_Parchase.Text);

                }

                Total_Before_Discount = (Quntity * Price_parchase);

                if (textBox_Discount1_GroupBox1.Text == "")
                {
                    discount = 0;

                }
                else
                {
                    discount = Convert.ToDouble(textBox_Discount1_GroupBox1.Text);

                }
                if (textBox_Discount_Percentage.Text == "")
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


        private void textBox_Invoice_Parchase_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Invoice_Parchase_year.Text != "")
                    {
                        if (textBox_Invoice_Parchase_No.Text != "")
                        {
                            addScren();
                        }
                        else
                        {
                            MessageBox.Show("يرجى تحديد رقم فاتورة الشراء لعرض الفواتير", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجى تحديد سنة فاتورة الشراء لعرض الفاتورة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_return_ID.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم المستند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                printNo = Convert.ToInt32(textBox_return_ID.Text);
                if (textBox_Invoice_Parchase_year.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك سنة فاتورة الشراء فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (textBox_Invoice_Parchase_No.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم فاتورة الشراء فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (dataGridView1.Rows.Count <= 0)
                {
                    MessageBox.Show("الفاتورة فارغه", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                if (textBox_Total.Text == "" || textBox_Total.Text == "0")
                {
                    MessageBox.Show("لا يمكنك حفظ فاتورة قيمتها 0", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }

                //----------------- تفقيد الكمية ------------------------------------------------------------------------------------------------------------------------------



                for (int i22 = 0; i22 < dataGridView1.RowCount; i22++)
                {
                    SqlCommand cmd = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No =@Item_No and Unit_No=@Unit_No", con);
                    cmd.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i22].Cells[0].Value));
                    cmd.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i22].Cells[2].Value));

                    con.Open();
                    SqlDataReader Ra = cmd.ExecuteReader();

                    if (Ra.Read())
                    {
                        Unit_Rate2 = Convert.ToDouble(Ra["Unit_Rate"].ToString());

                    }
                    else
                    {
                        Unit_Rate2 = 1;
                    }


                    Ra.Close();
                    con.Close();

                    QauntityText = Convert.ToDouble(dataGridView1.Rows[i22].Cells[4].Value);
                    ALLQauntity = QauntityText * Unit_Rate2;

                    SqlCommand cmd2 = new SqlCommand("SELECT  sum(case when Kind = 1 and R_Sores_No=@R_Sores_No then R_A_Qty else 0 end) - sum(case when Kind = 2 and R_Sores_No =@R_Sores_No then R_A_Qty else 0 end) as Quantity FROM i2_trans with(nolock) where R_Item_No=@R_Item_No and R_End_Date=@R_End_Date and R_Sores_No=@R_Sores_No", con);
                    cmd2.Parameters.Add(new SqlParameter("@R_Item_No", dataGridView1.Rows[i22].Cells[0].Value));
                    string EEND_DATE = dataGridView1.Rows[i22].Cells[11].Value.ToString();
                    if (EEND_DATE == "  /  /")
                    {
                        EEND_DATE = "";
                    }
                    cmd2.Parameters.Add(new SqlParameter("@R_End_Date", EEND_DATE));
                    cmd2.Parameters.Add(new SqlParameter("@R_Sores_No", dataGridView1.Rows[i22].Cells[9].Value));


                    con.Open();
                    SqlDataReader Ra2 = cmd2.ExecuteReader();

                    if (Ra2.Read())
                    {
                        if (Ra2["Quantity"].ToString() == "")
                        {
                            QauntityCC = 0;
                        }
                        else
                        {
                            QauntityCC = Convert.ToDouble(Ra2["Quantity"].ToString());
                        }






                    }
                    else
                    {
                        QauntityCC = 0;
                    }


                    Ra.Close();
                    con.Close();



                    if (ALLQauntity > QauntityCC)
                    {

                        MessageBox.Show("عذرا الكمية للمادة  " + dataGridView1.Rows[i22].Cells[1].Value.ToString() + "  غير كافية  " + "المراد استرجاعه  " + ALLQauntity + " والكمية المتواجدة في المستودع  " + QauntityCC);

                        return;
                    }

                }








                //--------------------------------------------------------------------------------------------------------------------------------------------------------------

                //----------------------------------------------تفقيد المستند موجودة في الداتا--------------------------------------------------------------
                con.Open();
                SqlCommand cmd22 = new SqlCommand("select DISTINCT Bond_No from return_parchase where Bond_No=@Bond_No and myear=@myear", con);
                cmd22.Parameters.Add(new SqlParameter("@Bond_No", textBox_return_ID.Text));
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




                if (NewRow == 0)
                {

                    ADD_Row_Trans();
                    ADD_Row();
                    clear_screen();
                    return_parchase_Load(sender, e);
                }
                else if (NewRow == 1)
                {
                    DELETE_I2_Trans();
                    Delete_Row();
                    ADD_Row_Trans();
                    ADD_Row();
                    clear_screen();
                    return_parchase_Load(sender, e);
                }


                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_return_parchase";

                cmd.Parameters.AddWithValue("@Bond_No", textBox_return_ID.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    cmd.CommandText = "SP_ADD_return_parchase";

                    cmd.Parameters.AddWithValue("@Bond_No", textBox_return_ID.Text);
                    cmd.Parameters.AddWithValue("@Bond_Date", dateTimePicker_Doc_Date.Value);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);

                    cmd.Parameters.AddWithValue("@Year_parcahse", textBox_Invoice_Parchase_year.Text);
                    cmd.Parameters.AddWithValue("@Invoice_parcahse_Number", textBox_Invoice_Parchase_No.Text);





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

                    cmd.Parameters.AddWithValue("@status_Order", status_Invoice);


                    cmd.Parameters.AddWithValue("@Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Stores_No", dataGridView1.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@Stores_Name", dataGridView1.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Price_Parchase", dataGridView1.Rows[i].Cells[5].Value);


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

                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[8].Value);

                    if (dataGridView1.Rows[i].Cells[11].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@End_Date", dataGridView1.Rows[i].Cells[11].Value);

                    }
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Invoice_Parchase);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم اضافة الطلب  بنجاح بالرقم " + textBox_return_ID.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void addScren_Bond()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from return_parchase where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_return_ID.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Year.Text = dr["Myear"].ToString();
                    dateTimePicker_Doc_Date.Text = dr["Bond_Date"].ToString();
                    textBox_Invoice_Parchase_year.Text = dr["Year_parcahse"].ToString();
                    textBox_Invoice_Parchase_No.Text = dr["Invoice_parcahse_Number"].ToString();
                    textBox_Supplier_No.Text = dr["Supplier_No"].ToString();
                    textBox_Supplier_Name.Text = dr["Supplier_Name"].ToString();
                    textBox_Note.Text = dr["Note"].ToString();
                    status_Order = Convert.ToInt32(dr["status_Order"].ToString());




                    if (status_Order == 0)
                    {
                        radioButton1.Checked = true;
                    }
                    else if (status_Order == 1)
                    {
                        radioButton2.Checked = true;
                    }
                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    MaxBond();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select Item_No,Item_Name,Unit_No,Unit_Name,Quantity,Price_Parchase,R_Discount,R_Discount_Percentage,Total_Row,Stores_No,Stores_Name,End_Date from return_parchase where Bond_No=@Bond_No and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Bond_No", textBox_return_ID.Text));
                cmd.Parameters.Add(new SqlParameter("@myear", textBox_Year.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["Item_No"].ToString(), dr2["Item_Name"].ToString(), dr2["Unit_No"].ToString(), dr2["Unit_Name"].ToString(), dr2["Quantity"].ToString(), dr2["Price_Parchase"].ToString(), dr2["R_Discount"].ToString(), dr2["R_Discount_Percentage"].ToString(), dr2["Total_Row"].ToString(), dr2["Stores_No"].ToString(), dr2["Stores_Name"].ToString(), dr2["End_Date"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    cmd.CommandText = "SP_ADD_return_parchase_i2_Trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_return_ID.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //إخراج-------------------------------------
                    cmd.Parameters.AddWithValue("@Kind", 2);
                    //-------------------------------------------
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_return_parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_return_parchase);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", dateTimePicker_Doc_Date.Value);
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

                    cmd.Parameters.AddWithValue("@Discount", "0");



                    cmd.Parameters.AddWithValue("@On_Percentage", "0");


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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1020 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void btn_view_invoice_parchase_no_Click(object sender, EventArgs e)
        {
            if(textBox_Invoice_Parchase_year.Text=="")
            {
                MessageBox.Show("يرجى تحديد سنة فاتورة الشراء لعرض الفواتير","عملية خاطئة",MessageBoxButtons.OK,MessageBoxIcon.Error);
                return;
            }
            else
            {
                Grid_Invoice_Parchase.SCR_return_Parchase = true;
                Grid_Invoice_Parchase grid_Invoice_Parchase = new Grid_Invoice_Parchase();
                grid_Invoice_Parchase.ShowDialog();
                Grid_Invoice_Parchase.SCR_return_Parchase = false;
            }
        }

        private void btn_view_return_ID_Click(object sender, EventArgs e)
        {
            Grid_Return_Bound_Parchase grid_Return_Bound_Parchase = new Grid_Return_Bound_Parchase();
            grid_Return_Bound_Parchase.Show();
        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Return_Parchase fRM_Report_Return_Parchase = new FRM_Report_Return_Parchase();
                    fRM_Report_Return_Parchase.Show();

                    FRM_Report_Return_Parchase.fRM_Report.textBox_Bond_No.Text = printNo.ToString();
                    FRM_Report_Return_Parchase.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DELETE_I2_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_return_parchase_i2_Trans";

                cmd.Parameters.AddWithValue("@Order_No", textBox_return_ID.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);

                cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_return_parchase);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1022 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_return_ID.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك رقم المستند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;

                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    DELETE_I2_Trans();
                    Delete_Row();
                    MessageBox.Show("تم حذف المستند بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_screen();
                    return_parchase_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 return_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

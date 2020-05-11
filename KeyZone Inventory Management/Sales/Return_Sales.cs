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

namespace KeyZone_Inventory_Management.Sales
{
    public partial class Return_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public virable
        public static Return_Sales return_sales;
        int status_Order;
        int NewRow = 0;
        int status_Invoice = 0;
        double Unit_Rate;
        double Qty;
        double R_A_Qty;
        double Price_Sales = 0;
        double Quntity = 0;
        int Print = 0;
        int printNo;
        public Return_Sales()
        {
            return_sales = this;
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void btn_Delete_Row_Click(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void Return_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;
                textBox_Invoice_Sales_Date.Text = date;

                max();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void max()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Bond_No)+1),1) as max from Return_Sales where myear=@myear", con);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Return_Sales_KeyDown(object sender, KeyEventArgs e)
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

        private void textBox_Invoice_Sales_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Invoice_Sales_Date_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Customer_No_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Distributor_No_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_Price_Sales_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Bonus_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        public void addScren_IN()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Invoice_Sales where Invoice_No=@Invoice_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice_Sales_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Invoice_Sales_Date.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Customer_No.Text = dr["Customer_No"].ToString();
                    textBox_Customer_Name.Text = dr["Customer_Name"].ToString();

                    textBox_Distributor_No.Text = dr["Supplier_No"].ToString();
                    textBox_Distributor_Name.Text = dr["Supplier_Name"].ToString();

                    textBox_Des.Text = dr["Note"].ToString();

                    status_Invoice = Convert.ToInt32(dr["status_Order"].ToString());
                    if (status_Invoice == 0)
                    {
                        radioButton1.Checked = true;
                    }
                    else if (status_Invoice == 1)
                    {
                        radioButton2.Checked = true;
                    }


                    ////textBox_Total.Text = dr["Invoice_before_NetTotal"].ToString();
                    ////textBox_Net_Total.Text = dr["Invoice_Net_Total"].ToString();


                    con.Close();
                }
                else
                {
                    con.Close();
                    clear_screen();
                    // max();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Item_No,R_Item_Name,R_Unit_No,R_Unit_Name,R_Sores_No,R_Stores_Name,R_Quantity,R_Price_Sales,R_Discount,R_Discount_Percentage,R_Total,R_Bouns,R_End_Date from Invoice_Sales where Invoice_No=@Invoice_No and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Invoice_No", textBox_Invoice_Sales_No.Text));
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Invoice_Sales_Date.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Item_No"].ToString(), dr2["R_Item_Name"].ToString(), dr2["R_Unit_No"].ToString(), dr2["R_Unit_Name"].ToString(), dr2["R_Sores_No"].ToString(), dr2["R_Stores_Name"].ToString(), dr2["R_Quantity"].ToString(), dr2["R_Price_Sales"].ToString(), dr2["R_Total"].ToString(), dr2["R_Bouns"].ToString(), dr2["R_End_Date"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_Price_Sales.Text == "")
                {
                    Price_Sales = 0;

                }
                else
                {
                    Price_Sales = Convert.ToDouble(textBox_Price_Sales.Text);

                }

                textBox_total1_groupbox1.Text = Convert.ToString(Quntity * Price_Sales);


            }
            catch
            {
                Quntity = 0;
                Price_Sales = 0;
                textBox_total1_groupbox1.Text = "0";



            }



        }

        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Return_Sales where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Year.Text = dr["Myear"].ToString();
                    Bond_Date.Text = dr["Bond_Date"].ToString();
                    textBox_Invoice_Sales_Date.Text = dr["Year_Sales"].ToString();
                    textBox_Invoice_Sales_No.Text = dr["Invoice_Sales_Number"].ToString();
                    textBox_Customer_No.Text = dr["Customer_No"].ToString();
                    textBox_Customer_Name.Text = dr["Customer_Name"].ToString();
                    textBox_Distributor_No.Text = dr["Distributor_No"].ToString();
                    textBox_Distributor_Name.Text = dr["Distributor_Name"].ToString();
                    textBox_Des.Text = dr["Note"].ToString();
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
                    max();
                    return;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select Item_No,Item_Name,Unit_No,Unit_Name,Stores_No,Stores_Name,Quantity,Price_Sales,Total_Row ,Bouns,End_Date from Return_Sales where Bond_No=@Bond_No and myear=@myear", con);
                cmd.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd.Parameters.Add(new SqlParameter("@myear", textBox_Year.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["Item_No"].ToString(), dr2["Item_Name"].ToString(), dr2["Unit_No"].ToString(), dr2["Unit_Name"].ToString(), dr2["Stores_No"].ToString(), dr2["Stores_Name"].ToString(), dr2["Quantity"].ToString(), dr2["Price_Sales"].ToString(), dr2["Total_Row"].ToString(), dr2["Bouns"].ToString(), dr2["End_Date"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void clear_screen()
        {
            dataGridView1.Rows.Clear();
            
            textBox_Invoice_Sales_No.Text = "";
            textBox_Customer_No.Text = "";
            textBox_Customer_Name.Text = "";
            textBox_Distributor_No.Text = "";
            textBox_Distributor_Name.Text = "";
            textBox_Des.Text = "";
            radioButton1.Checked = true;
            textBox_Total.Text = "";
        }

        private void btn_view_return_ID_Click(object sender, EventArgs e)
        {

            Grid_Return_Bound_Sales grid_Return_Bound_Sales = new Grid_Return_Bound_Sales();
            grid_Return_Bound_Sales.Show();

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Order = 0;
            }
            if (radioButton2.Checked == true)
            {
                //مم مدينة
                status_Order = 1;
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                //نقدي
                status_Order = 0;
            }
            if (radioButton2.Checked == true)
            {
                //ذمم مدينة
                status_Order = 1;
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    textBox_Price_Sales.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();
                    textBox_total1_groupbox1.Text = dataGridView1.CurrentRow.Cells[8].Value.ToString();
                    textBox_Bonus.Text = dataGridView1.CurrentRow.Cells[9].Value.ToString();
                    textBox_End_Date.Text = dataGridView1.CurrentRow.Cells[10].Value.ToString();


                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_Price_Sales.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك سعر البيع فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Price_Sales.Focus();
                    return;
                }

                Data_ADD_Rows();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Stores_No.Text, textBox_Stores_Name.Text, textBox_Qantity.Text, textBox_Price_Sales.Text, textBox_total1_groupbox1.Text, textBox_Bonus.Text, textBox_End_Date.Text);
                textBox_Item_No.Text = "";
                textBox_Item_Name.Text = "";
                textBox_Unit_No.Text = "";
                textBox_Unit_Name.Text = "";
                textBox_Stores_No.Text = "";
                textBox_Stores_Name.Text = "";
                textBox_Qantity.Text = "";
                textBox_Price_Sales.Text = "";
                textBox_total1_groupbox1.Text = "";
                textBox_Bonus.Text = "";
                textBox_End_Date.Text = "";
                MessageBox.Show("تم إضافة المادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                textBox_Item_No.Focus();
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Delete_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Year.Focus();
                    return;

                }
                if (textBox_Bond_No.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم المستند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Bond_No.Focus();
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    Delete_Row();
                    DELETE_Row_Trans();
                    MessageBox.Show("تم حذف المستند بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_screen();
                    Return_Sales_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void Delete_Row()
        {
            try
            {
                con.Open();
                SqlCommand cmd3 = con.CreateCommand();

                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.CommandText = "SP_Delete_Return_Sales";

                cmd3.Parameters.AddWithValue("@Bond_No", textBox_Bond_No.Text);
                cmd3.Parameters.AddWithValue("@Myear", textBox_Year.Text);

                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void ADD_Row()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Return_Sales";

                    cmd.Parameters.AddWithValue("@Bond_No", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@Bond_Date", Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Year_Sales", textBox_Invoice_Sales_Date.Text);
                    cmd.Parameters.AddWithValue("@Invoice_Sales_Number", textBox_Invoice_Sales_No.Text);

                    if (textBox_Customer_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Customer_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Customer_No", textBox_Customer_No.Text);

                    }

                    cmd.Parameters.AddWithValue("@Customer_Name", textBox_Customer_Name.Text);

                    if (textBox_Distributor_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Distributor_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Distributor_No", textBox_Distributor_No.Text);

                    }

                    cmd.Parameters.AddWithValue("@Distributor_Name", textBox_Distributor_Name.Text);

                    cmd.Parameters.AddWithValue("@Note", textBox_Des.Text);
                    cmd.Parameters.AddWithValue("@status_Order", status_Order);
                    cmd.Parameters.AddWithValue("@Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Stores_No", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Stores_Name", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Price_Sales", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Bouns", dataGridView1.Rows[i].Cells[9].Value);
                    cmd.Parameters.AddWithValue("@End_Date", dataGridView1.Rows[i].Cells[10].Value);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Return_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Return_Sales);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم تخزين المستند  بنجاح بالرقم " + textBox_Bond_No.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            try
            {
                Print = 0;
                if (textBox_Year.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك السنة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Year.Focus();
                    return;

                }
                if (textBox_Bond_No.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم المستند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Bond_No.Focus();
                    return;
                }
                printNo = Convert.ToInt32(textBox_Bond_No.Text);

                if (textBox_Invoice_Sales_No.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم الفاتورة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Invoice_Sales_No.Focus();
                    return;
                }


                if (textBox_Invoice_Sales_Date.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك سنة الفاتورة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Invoice_Sales_Date.Focus();
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
                //------------------------------------------------------------------------------------------------------------
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select DISTINCT Bond_No from Return_Sales where Bond_No=@Bond_No and myear=@myear", con);

                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_No.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
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
                    Return_Sales_Load(sender, e);
                }
                else if (NewRow == 1)
                {

                    Delete_Row();
                    DELETE_Row_Trans();
                    ADD_Row_Trans();
                    ADD_Row();
                    clear_screen();
                    Return_Sales_Load(sender, e);

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DELETE_Row_Trans()
        {
            try
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_DELETE_Return_Sales_i2_Trans";

                cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                //-------------------------------------------
                cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Return_Sales);
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

                    cmd.CommandText = "SP_ADD_return_Sales_i2_Trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_No.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //إدخال-------------------------------------
                    cmd.Parameters.AddWithValue("@Kind", 1);
                    //-------------------------------------------
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Return_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Return_Sales);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", status_Invoice);

                    if (textBox_Customer_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@S_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@S_No", textBox_Customer_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@S_Name", textBox_Customer_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Des.Text);
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
                    cmd.Parameters.AddWithValue("@R_Sores_No", dataGridView1.Rows[i2].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", dataGridView1.Rows[i2].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i2].Cells[6].Value);
                    //---------إستعلام عن معامل التحويل------------------------------

                    SqlCommand cmd21 = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i2].Cells[0].Value));
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i2].Cells[2].Value));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    Qty = Convert.ToDouble(dataGridView1.Rows[i2].Cells[6].Value);
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

                    cmd.Parameters.AddWithValue("@R_Price", dataGridView1.Rows[i2].Cells[7].Value);


                    cmd.Parameters.AddWithValue("@R_Discount", "0");



                    cmd.Parameters.AddWithValue("@R_Discount_Percentage", "0");


                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i2].Cells[8].Value);

                    if (dataGridView1.Rows[i2].Cells[10].Value == "  /  /")
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", "");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@R_End_Date", dataGridView1.Rows[i2].Cells[10].Value);

                    }
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);


                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1020 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Invoice_Sales_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Invoice_Sales_Date.Text != "")
                    {
                        if (textBox_Invoice_Sales_No.Text != "")
                        {
                            addScren_IN();
                        }
                        else
                        {
                            MessageBox.Show("يرجى تحديد رقم فاتورة البيع لعرض الفواتير", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                        }
                    }
                    else
                    {
                        MessageBox.Show("يرجى تحديد سنة فاتورة البيع لعرض الفاتورة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_view_invoice_parchase_no_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox_Invoice_Sales_Date.Text == "")
                {
                    MessageBox.Show("يرجى تحديد سنة فاتورة البيع لعرض الفواتير", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    Grid_Invoice_Sales.SCR_return_Sales = true;
                    Grid_Invoice_Sales Grid_Invoice_Sales1 = new Grid_Invoice_Sales();
                    Grid_Invoice_Sales1.ShowDialog();
                    Grid_Invoice_Sales.SCR_return_Sales = false;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1022 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Price_Sales_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1024 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Return_Sales FRM_Report_Return_Sales2 = new FRM_Report_Return_Sales();
                    FRM_Report_Return_Sales2.Show();

                    FRM_Report_Return_Sales.fRM_Report.textBox_Bond_No.Text = printNo.ToString();
                    FRM_Report_Return_Sales.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Return_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

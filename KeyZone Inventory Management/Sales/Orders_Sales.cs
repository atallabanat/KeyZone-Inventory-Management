using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KeyZone_Inventory_Management.Grid;
using KeyZone_Inventory_Management.Reports;
using KeyZone_Inventory_Management.Form_RPT;

namespace KeyZone_Inventory_Management.Sales
{
    public partial class Oreder_Sales : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public virable
        public static Oreder_Sales Ord_Sales;
        int status_Order;
        int NewRow = 0;
        double Quntity = 0;
        double Price = 0;
        double discount = 0;
        double Total_Before_Discount = 0;
        double Total_After_Discount = 0;
        double Total = 0;
        double Price_Sales = 0;
        double discount2;
        int Print = 0;
        int printNo;



        public Oreder_Sales()
        {
            Ord_Sales = this;
            this.KeyPreview = true;
            InitializeComponent();
        }

        private void Orders_Sales_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void Orders_Sales_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Order_Number)+1),1) as max from Order_Sales where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Order_Number.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Order_Number.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void Sum_TotalGrid()
        {
            try
            {
                double TotalALLRows = 0;
                double TotalALLRowsDIS = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[7].Value);
                    double totalDIS = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);
                    TotalALLRows += TotalRows;
                    TotalALLRowsDIS += totalDIS;
                    textBox_Total.Text = TotalALLRows.ToString();
                    textBox_Discount.Text = TotalALLRowsDIS.ToString();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                Sum_TotalGrid();
                Sum_Total_Sales();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_View_Customer_No_Click(object sender, EventArgs e)
        {
            Grid_Customers.SCR_Orders_Sales = true;
            Grid_Customers grid_Customers = new Grid_Customers();
            grid_Customers.ShowDialog();
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

        private void textBox_Qantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Order_Sales where Order_Number=@Order_Number and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Order_Number", textBox_Order_Number.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Customer_No.Text = dr["Customer_No"].ToString();
                    textBox_Customer_Name.Text = dr["Customer_Name"].ToString();
                    textBox_Distributor_No.Text = dr["Distributor_No"].ToString();
                    textBox_Distributor_Name.Text = dr["Distributor_Name"].ToString();
                    textBox_Year.Text = dr["Myear"].ToString();
                    textBox_Des.Text = dr["Note"].ToString();
                    dateTime_Order_Date.Text = dr["Order_Date"].ToString();
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
                SqlCommand cmd = new SqlCommand("select Item_No,Item_Name,Unit_No,Unit_Name,Quantity,Price,Discount,Total_Row from Order_Sales where Order_Number=@Order_Number", con);
                cmd.Parameters.Add(new SqlParameter("@Order_Number", textBox_Order_Number.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["Item_No"].ToString(), dr2["Item_Name"].ToString(), dr2["Unit_No"].ToString(), dr2["Unit_Name"].ToString(), dr2["Quantity"].ToString(), dr2["Price"].ToString(), dr2["Discount"].ToString(), dr2["Total_Row"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void max()
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Order_Number)+1),1) as max from Order_Sales where myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Order_Number.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Order_Number.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
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

        private void textBox_Customer_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Customer_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select Customers_No,Customers_Name  from Customers where Customers_No=@Customers_No", con);
                        cmd.Parameters.Add(new SqlParameter("@Customers_No", textBox_Customer_No.Text));
                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Customer_Name.Text = Ra["Customers_Name"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("لا يوجد عميل بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Customer_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();
                    }


                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                //ذمم مدينة
                status_Order = 1;
            }
        }


        private void btn_View_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Orders_Sales = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
            Grid_Item.SCR_Orders_Sales = false;
        }

        private void btn_View_Unit_Click(object sender, EventArgs e)
        {
            if (textBox_Item_No.Text == "")
            {
                MessageBox.Show("يرجى تعبئة رمز المادة", "خطأ ادخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

                Grid_Unit.SCR_Order_Sales = true;
                Grid_Unit ss = new Grid_Unit();
                ss.ShowDialog();
                Grid_Unit.SCR_Order_Sales = false;

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
        private void clear_screen()
        {
            dataGridView1.Rows.Clear();
            textBox_Order_Number.Text = "";
            textBox_Customer_No.Text = "";
            textBox_Customer_Name.Text = "";
            textBox_Distributor_No.Text = "";
            textBox_Distributor_Name.Text = "";
            textBox_Des.Text = "";
            textBox_Discount.Text = "";
            textBox_Net_Total.Text = "";
            radioButton1.Checked = true;
            textBox_Total.Text = "";
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
                if (textBox_Order_Number.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم الطلب فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Order_Number.Focus();
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    DELETE_Order_DATA();
                    MessageBox.Show("تم حذف الطلب بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    clear_screen();
                    Orders_Sales_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_Order_Number.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم الطلب فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Order_Number.Focus();
                    return;
                }
                printNo = Convert.ToInt32(textBox_Order_Number.Text);
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
                SqlCommand cmd21 = new SqlCommand("select Order_Number from Order_Sales where Order_Number=@Order_Number and myear=@myear", con);

                cmd21.Parameters.Add(new SqlParameter("@Order_Number", textBox_Order_Number.Text));
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
                    ADD_TO_Order_DATA();
                    clear_screen();
                    Orders_Sales_Load(sender, e);
                }
                else if (NewRow == 1)
                {

                    DELETE_Order_DATA();
                    EDIT_Order_DATA();
                    clear_screen();
                    Orders_Sales_Load(sender, e);
                }



                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void EDIT_Order_DATA()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {


                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Orders_Sales";

                    cmd.Parameters.AddWithValue("@Order_Number", textBox_Order_Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", dateTime_Order_Date.Value);
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
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Discount", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Orders_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Orders_Sales);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم تعديل الطلب  بنجاح بالرقم " + textBox_Order_Number.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DELETE_Order_DATA()
        {
            try
            {
                con.Open();
                SqlCommand cmd3 = con.CreateCommand();

                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.CommandText = "SP_DELETE_Orders_Sales";

                cmd3.Parameters.AddWithValue("@Order_Number", textBox_Order_Number.Text);
                cmd3.Parameters.AddWithValue("@Myear", textBox_Year.Text);

                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void ADD_TO_Order_DATA()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Orders_Sales";

                    cmd.Parameters.AddWithValue("@Order_Number", textBox_Order_Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", dateTime_Order_Date.Value);
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
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Price", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Discount", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Orders_Sales);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Orders_Sales);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }

                MessageBox.Show("تم اضافة الطلب  بنجاح بالرقم " + textBox_Order_Number.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //Distributor
        private void btn_supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Distributor.SCR_Orders_Sales = true;
            Grid_Distributor grid_Distributor = new Grid_Distributor();
            grid_Distributor.ShowDialog();
        }

        private void btn_View_SOrder_Number_Click(object sender, EventArgs e)
        {
            Grid_Sales_Order.SCR_Orders_Sales = true;
            Grid_Sales_Order grid_Sales_Order = new Grid_Sales_Order();
            grid_Sales_Order.ShowDialog();
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
                if (textBox_Qantity.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك الكمية فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Qantity.Focus();
                    return;
                }
                if (textBox_Price.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك السعر  فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Price.Focus();
                    return;
                }

                Data_ADD_Rows();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Qantity.Text, textBox_Price.Text, textBox_Discount1_GroupBox1.Text, textBox_total1_groupbox1.Text);
                textBox_Item_No.Text = "";
                textBox_Item_Name.Text = "";
                textBox_Unit_No.Text = "";
                textBox_Unit_Name.Text = "";
                textBox_Qantity.Text = "";
                textBox_Price.Text = "";
                textBox_Discount1_GroupBox1.Text = "";
                textBox_total1_groupbox1.Text = "";
                MessageBox.Show("تم إضافة المادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Item_No.Focus();
                Sum_TotalGrid();
                Sum_Total_Sales();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    textBox_Qantity.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
                    textBox_Price.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
                    textBox_Discount1_GroupBox1.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
                    textBox_total1_groupbox1.Text = dataGridView1.CurrentRow.Cells[7].Value.ToString();

                    int index = dataGridView1.CurrentCell.RowIndex;
                    dataGridView1.Rows.RemoveAt(index);
                    Sum_TotalGrid();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_Order_Number_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Order_Number.Text != "")
                    {
                        addScren();
                    }

                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Order_Number_KeyPress(object sender, KeyPressEventArgs e)
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

        private void textBox_Discount_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Distributor_No_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Enter)
                {
                    if (textBox_Distributor_No.Text != "")
                    {
                        SqlCommand cmd = new SqlCommand("select Distributor_Number,Name  from Distributor where Distributor_Number=@Distributor_Number", con);
                        cmd.Parameters.Add(new SqlParameter("@Distributor_Number", textBox_Distributor_No.Text));
                        con.Open();
                        SqlDataReader Ra = cmd.ExecuteReader();

                        if (Ra.Read())
                        {
                            textBox_Distributor_Name.Text = Ra["Name"].ToString();

                        }
                        else
                        {
                            MessageBox.Show("لا يوجد مندوب بهذا الرقم", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            textBox_Distributor_Name.Text = "";
                        }
                        Ra.Close();
                        con.Close();
                    }


                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                if (textBox_Price.Text == "")
                {
                    Price_Sales = 0;

                }
                else
                {
                    Price_Sales = Convert.ToDouble(textBox_Price.Text);

                }
                if (textBox_Discount1_GroupBox1.Text == "")
                {
                    discount = 0;

                }
                else
                {
                    discount = Convert.ToDouble(textBox_Discount1_GroupBox1.Text);

                }

                Total_Before_Discount = (Quntity * Price_Sales) - discount;
                textBox_total1_groupbox1.Text = Total_Before_Discount.ToString();


            }
            catch
            {
                discount = 0;
                Quntity = 0;
                Price_Sales = 0;
                Total_Before_Discount = 0;
                textBox_total1_groupbox1.Text = Total_Before_Discount.ToString();



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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1020 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Price_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Item();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1022 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Sum_Total_Sales()
        {
            try
            {
                if (textBox_Discount.Text != "")
                {
                    discount2 = Convert.ToDouble(textBox_Discount.Text);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1023 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Discount_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Sum_Total_Sales();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1024 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Orders_Sales FRM_Report_Orders_Sales2 = new FRM_Report_Orders_Sales();
                    FRM_Report_Orders_Sales2.Show();
                    FRM_Report_Orders_Sales.fRM_Report.textBox_Orders_No.Text = printNo.ToString();
                    FRM_Report_Orders_Sales.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1025 Oreder_Sales", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
    


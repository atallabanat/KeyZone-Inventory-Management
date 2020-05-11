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

namespace KeyZone_Inventory_Management.parchases
{
    public partial class Orders_parchase : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        public static Orders_parchase Ord;
        double cost = 0;
        double Quntity = 0;
        double Total = 0;
        int NewRow = 0;
        int status_Order;
        int Number_Store;
        int Flag_Chek_Item_No=0;
        public static int Row_Unit;
        public static int Col_Unit;
        int Print = 0;
        int printNo;

        public Orders_parchase()
        {
            Ord = this;
            this.KeyPreview = true;
            InitializeComponent();
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
                if (textBox_Total2_groupBox2.Text == "" || textBox_Total2_groupBox2.Text == "0")
                {
                    MessageBox.Show("لا يمكنك حفظ فاتورة قيمتها 0", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }
                //------------------------------------------------------------------------------------------------------------
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select Order_No from Orders_Parchase where Order_No=@Order_No and myear=@myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Order_No", textBox_Order_Number.Text));
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

                    ADDOrders();
                    clear_screen();
                    Orders_parchase_Load(sender, e);
                }
                else if (NewRow == 1)
                {


                    DeleteOrder();
                    EDITodersADD();
                    clear_screen();
                    Orders_parchase_Load(sender, e);

                }



                Print = 1;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void EDITodersADD()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {


                    SqlCommand cmd = con.CreateCommand();
                    con.Open();
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Orders_parchase";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Order_Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", dateTime_Order_Date.Value);
                    if (textBox_Supplier_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Des.Text);
                    cmd.Parameters.AddWithValue("@status_Order", status_Order);
                    cmd.Parameters.AddWithValue("@Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Price_Cost", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Sores_No", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Stores_Name", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Orders_parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Orders_parchase);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();
                }
                MessageBox.Show("تم تعديل الطلب  بنجاح بالرقم " + textBox_Order_Number.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void ADDOrders()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Orders_parchase";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Order_Number.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    cmd.Parameters.AddWithValue("@Order_Date", dateTime_Order_Date.Value);
                    if (textBox_Supplier_No.Text == "")
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", "0");

                    }
                    else
                    {
                        cmd.Parameters.AddWithValue("@Supplier_No", textBox_Supplier_No.Text);

                    }
                    cmd.Parameters.AddWithValue("@Supplier_Name", textBox_Supplier_Name.Text);
                    cmd.Parameters.AddWithValue("@Note", textBox_Des.Text);
                    cmd.Parameters.AddWithValue("@status_Order", status_Order);
                    cmd.Parameters.AddWithValue("@Item_No", dataGridView1.Rows[i].Cells[0].Value);
                    cmd.Parameters.AddWithValue("@Item_Name", dataGridView1.Rows[i].Cells[1].Value);
                    cmd.Parameters.AddWithValue("@Unit_No", dataGridView1.Rows[i].Cells[2].Value);
                    cmd.Parameters.AddWithValue("@Unit_Name", dataGridView1.Rows[i].Cells[3].Value);
                    cmd.Parameters.AddWithValue("@Quantity", dataGridView1.Rows[i].Cells[4].Value);
                    cmd.Parameters.AddWithValue("@Price_Cost", dataGridView1.Rows[i].Cells[5].Value);
                    cmd.Parameters.AddWithValue("@Total_Row", dataGridView1.Rows[i].Cells[6].Value);
                    cmd.Parameters.AddWithValue("@Sores_No", dataGridView1.Rows[i].Cells[7].Value);
                    cmd.Parameters.AddWithValue("@Stores_Name", dataGridView1.Rows[i].Cells[8].Value);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Orders_parchase);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Orders_parchase);
                    cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);

                    cmd.ExecuteNonQuery();
                    con.Close();

                }
                MessageBox.Show("تم اضافة الطلب  بنجاح بالرقم " + textBox_Order_Number.Text + "", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void DeleteOrder()
        {
            try
            {
                con.Open();
                SqlCommand cmd3 = con.CreateCommand();

                cmd3.CommandType = CommandType.StoredProcedure;

                cmd3.CommandText = "SP_DELETE_Orders_parchase";

                cmd3.Parameters.AddWithValue("@Order_No", textBox_Order_Number.Text);
                cmd3.Parameters.AddWithValue("@Myear", textBox_Year.Text);

                cmd3.ExecuteNonQuery();
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Orders_parchase_Load(object sender, EventArgs e)
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Order_No)+1),1) as max from Orders_Parchase where myear=@myear", con);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1005 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void max()
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Order_No)+1),1) as max from Orders_Parchase where myear=@myear", con);
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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

        private void Orders_parchase_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{TAB}");
            }



        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1007 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        //int ss1;
        //int sNO1;
        //int sNA1;
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            //if (dataGridView1.CurrentRow.Cells[0].Selected == true)
            //{
            //    int flagcountunit1 = 0;
            //    if (dataGridView1.Rows[Row_Unit].Cells[0].Value == null)
            //    {
            //        flagcountunit1 = 1;

            //    }
            //    else
            //    {
            //        try
            //        {
            //            ss1 = Convert.ToInt32(dataGridView1.Rows[Row_Unit].Cells[0].Value);
            //            flagcountunit1 = 0;

            //        }
            //        catch
            //        {
            //            ss1 = 0;
            //            flagcountunit1 = 0;
            //        }

            //    }

            //    if (flagcountunit1 == 0)
            //    {
            //        SqlCommand na = new SqlCommand();
            //        na = new SqlCommand("select Item_No,Item_Name from INV_F where Item_No = @Item_No", con);
            //        na.Parameters.Add(new SqlParameter("@Item_No", ss1));

            //        SqlDataReader dr;
            //        con.Open();
            //        dr = na.ExecuteReader();
            //        if (dr.Read())
            //        {

            //            dataGridView1.Rows[Row_Unit].Cells[1].Value = dr["Item_Name"].ToString();

            //            con.Close();

            //        }
            //        else
            //        {
            //            MessageBox.Show("لا يوجد مادة بهذا الرقم");
            //            dataGridView1.Rows[Row_Unit].Cells[1].Value = "";
            //            con.Close();
            //            Flag_Chek_Item_No = 1;


            //        }

            //    }

            //}
            ////------------------------------------------------------------------------------------

            //if (dataGridView1.CurrentRow.Cells[2].Selected == true)
            //{
            //    int flagcountunit2 = 0;
            //    if (dataGridView1.Rows[Row_Unit].Cells[2].Value == null)
            //    {
            //        flagcountunit2 = 1;

            //    }
            //    else
            //    {
            //        try
            //        {
            //            sNO1 = Convert.ToInt32(dataGridView1.Rows[Row_Unit].Cells[2].Value);
            //            sNA1 = Convert.ToInt32(dataGridView1.Rows[Row_Unit].Cells[0].Value);
            //            flagcountunit2 = 0;

            //        }
            //        catch
            //        {
            //            sNO1 = 0;
            //            flagcountunit2 = 0;
            //        }

            //    }

            //    if (flagcountunit2 == 0)
            //    {
            //        SqlCommand na = new SqlCommand();
            //        na = new SqlCommand("select Unit_No,Unit_Name from Items_Unit_Cust where Item_No=@Item_No and Unit_No = @Unit_No ", con);
            //        na.Parameters.Add(new SqlParameter("@Unit_No", sNO1));
            //        na.Parameters.Add(new SqlParameter("@Item_No", sNA1));

            //        SqlDataReader dr;
            //        con.Open();
            //        dr = na.ExecuteReader();
            //        if (dr.Read())
            //        {

            //            dataGridView1.Rows[Row_Unit].Cells[3].Value = dr["Unit_Name"].ToString();

            //            con.Close();

            //        }
            //        else
            //        {
            //            MessageBox.Show("لا يوجد وحدة بهذا الرقم");
            //            dataGridView1.Rows[Row_Unit].Cells[3].Value = "";
            //            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[2];
            //            con.Close();
            //            Flag_Chek_Item_No = 1;


            //        }

            //    }

            //}


        }

        private void Sum_TotalGrid()
        {
            try
            {
                double TotalALLRows = 0;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double TotalRows = Convert.ToDouble(dataGridView1.Rows[i].Cells[6].Value);

                    TotalALLRows += TotalRows;
                    textBox_Total2_groupBox2.Text = TotalALLRows.ToString();
                }

            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1008 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1009 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }







            //if (e.KeyCode == Keys.Enter)
            //{
            //    Col_Unit = dataGridView1.CurrentCell.ColumnIndex;
            //    Row_Unit = dataGridView1.CurrentCell.RowIndex;

            //    if (Col_Unit < dataGridView1.Columns.Count)
            //    {
            //        if (dataGridView1.Rows[Row_Unit].Cells[0].Value == "" || dataGridView1.Rows[Row_Unit].Cells[0].Value == null)
            //        {
            //            MessageBox.Show("لعرض المواد" + " F3 " + "لا يمكن ترك رمز المادة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[0];
            //            dataGridView1.Focus();
            //        }
            //        else
            //        {
            //            if (dataGridView1.Rows[Row_Unit].Cells[0].Selected == true && dataGridView1.Rows[Row_Unit].Cells[0].Value != null && dataGridView1.Rows[Row_Unit].Cells[0].Value != "")
            //            {
            //                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[2];

            //                    dataGridView1.Focus();
            //                if(Flag_Chek_Item_No==1)
            //                {
            //                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[0];

            //                    dataGridView1.Focus();

            //                    Flag_Chek_Item_No = 0;
            //                }

            //            }
            //            else
            //            {
            //                if (dataGridView1.Rows[Row_Unit].Cells[2].Selected == true)
            //                {
            //                    if (dataGridView1.Rows[Row_Unit].Cells[2].Value == "" || dataGridView1.Rows[Row_Unit].Cells[2].Value == null)
            //                    {
            //                        MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[2];
            //                        dataGridView1.Focus();
            //                        return;
            //                    }
            //                    else
            //                    {
            //                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[Col_Unit+2];
            //                        if(Flag_Chek_Item_No==1)
            //                        {
            //                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[2];
            //                            Flag_Chek_Item_No = 0;
            //                        }
            //                    }
            //                }
            //                else
            //                {
            //                    if (dataGridView1.Rows[Row_Unit].Cells[4].Selected == true)
            //                    {
            //                        if (dataGridView1.Rows[Row_Unit].Cells[4].Value == "" || dataGridView1.Rows[Row_Unit].Cells[4].Value == null)
            //                        {
            //                            MessageBox.Show("لا يمكن ترك الكمية فارغة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[4];
            //                            dataGridView1.Focus();
            //                            return;
            //                        }
            //                        else
            //                        {
            //                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[Col_Unit + 1];
            //                            if(dataGridView1.Rows[Row_Unit].Cells[5].Value != null || dataGridView1.Rows[Row_Unit].Cells[5].Value !="")
            //                            {
            //                                try
            //                                {
            //                                    cost = Convert.ToDouble(dataGridView1.Rows[Row_Unit].Cells[5].Value);

            //                                }
            //                                catch
            //                                {
            //                                    cost = 0;
            //                                }
            //                            }
            //                            if(dataGridView1.Rows[Row_Unit].Cells[6].Value != null || dataGridView1.Rows[Row_Unit].Cells[6].Value != "")
            //                            {
            //                                try
            //                                {
            //                                    Quntity = Convert.ToDouble(dataGridView1.Rows[Row_Unit].Cells[4].Value);
            //                                }
            //                                catch
            //                                {
            //                                    Quntity = 0;
            //                                }


            //                                Total = cost * Quntity;
            //                                dataGridView1.Rows[Row_Unit].Cells[6].Value = Total.ToString();

            //                            }
            //                        }

            //                    }
            //                    else
            //                    {
            //                        if (dataGridView1.Rows[Row_Unit].Cells[5].Selected == true)
            //                        {
            //                            if (dataGridView1.Rows[Row_Unit].Cells[5].Value == "" || dataGridView1.Rows[Row_Unit].Cells[5].Value == null)
            //                            {
            //                                MessageBox.Show("لا يمكن ترك الكلفة فارغة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[5];
            //                                dataGridView1.Focus();
            //                                return;
            //                            }
            //                            else
            //                            {
            //                                try
            //                                {
            //                                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[Col_Unit + 2];

            //                                     cost = Convert.ToDouble(dataGridView1.Rows[Row_Unit].Cells[5].Value);
            //                                     Quntity = Convert.ToDouble(dataGridView1.Rows[Row_Unit].Cells[4].Value);
            //                                     Total = cost * Quntity;
            //                                    dataGridView1.Rows[Row_Unit].Cells[6].Value = Total.ToString();

            //                                }
            //                                catch
            //                                {

            //                                     cost = 0;
            //                                     Quntity = 0;
            //                                    Total = cost * Quntity;
            //                                    dataGridView1.Rows[Row_Unit].Cells[6].Value = Total.ToString();

            //                                }
            //                                finally
            //                                {
            //                                    if (Total == 0)
            //                                    {
            //                                        MessageBox.Show("أخطاء إدخال");

            //                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[4];
            //                                    }
            //                                }
            //                            }
            //                        }
            //                        else
            //                        {
            //                            if (dataGridView1.Rows[Row_Unit].Cells[7].Selected == true)
            //                            {
            //                                if (dataGridView1.Rows[Row_Unit].Cells[7].Value == "" || dataGridView1.Rows[Row_Unit].Cells[7].Value == null)
            //                                {
            //                                    MessageBox.Show("لعرض المستودعات" + " F3 " + "لا يمكن ترك رقم المستودع فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[7];
            //                                    dataGridView1.Focus();
            //                                    return;

            //                                }
            //                                else
            //                                {
            //                                    if (dataGridView1.Rows[Row_Unit].Cells[0].Value == "" || dataGridView1.Rows[Row_Unit].Cells[0].Value == null)
            //                                    {
            //                                        MessageBox.Show("لعرض المواد" + " F3 " + "لا يمكن ترك رمز المادة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[0];
            //                                        dataGridView1.Focus();
            //                                    }
            //                                    else
            //                                    {
            //                                        if (dataGridView1.Rows[Row_Unit].Cells[2].Value == "" || dataGridView1.Rows[Row_Unit].Cells[2].Value == null)
            //                                        {
            //                                            MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[2];
            //                                            dataGridView1.Focus();
            //                                            return;
            //                                        }
            //                                        else
            //                                        {
            //                                            if (dataGridView1.Rows[Row_Unit].Cells[4].Value == "" || dataGridView1.Rows[Row_Unit].Cells[4].Value == null)
            //                                            {
            //                                                MessageBox.Show("لا يمكن ترك الكمية فارغة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                                dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[4];
            //                                                dataGridView1.Focus();
            //                                                return;

            //                                            }
            //                                            else
            //                                            {
            //                                                if (dataGridView1.Rows[Row_Unit].Cells[5].Value == "" || dataGridView1.Rows[Row_Unit].Cells[5].Value == null)
            //                                                {
            //                                                    MessageBox.Show("لا يمكن ترك الكلفة فارغة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[5];
            //                                                    dataGridView1.Focus();
            //                                                    return;

            //                                                }
            //                                                else
            //                                                {
            //                                                    if (dataGridView1.Rows[Row_Unit].Cells[6].Value == "0")
            //                                                    {
            //                                                        MessageBox.Show("مجموع هذه المادة قيمته صفر ، عملية غير مقبولة", "خطأ إدخال", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //                                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[5];
            //                                                        dataGridView1.Focus();
            //                                                        return;

            //                                                    }
            //                                                    else
            //                                                    {
            //                                                        try
            //                                                        {
            //                                                            Number_Store = Convert.ToInt32(dataGridView1.Rows[Row_Unit].Cells[7].Value);
            //                                                        }
            //                                                        catch
            //                                                        {
            //                                                            dataGridView1.Rows[Row_Unit].Cells[7].Value = "";
            //                                                            Number_Store = 0;
            //                                                        }
            //                                                        finally
            //                                                        {
            //                                                            if (Number_Store == 0)
            //                                                            {
            //                                                                MessageBox.Show("أخطاء إدخال");
            //                                                                dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[7];
            //                                                                Col_Unit = 6;

            //                                                            }
            //                                                            else
            //                                                            {
            //                                                                dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit].Cells[Col_Unit + 1];
            //                                                            }

            //                                                        }
            //                                                    }

            //                                                }

            //                                            }

            //                                        }
            //                                    }                                                                                                
            //                                }
            //                            }                                        

            //                        }

            //                    }
            //                }
            //            }

            //        }

            //        if (Col_Unit == dataGridView1.Columns.Count - 2)
            //        {

            //            Col_Unit = 0;
            //            dataGridView1.Rows.Add();
            //            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit + 1].Cells[Col_Unit];
            //            dataGridView1.Focus();





            //        }


            //  }

            //if (dataGridView1.CurrentRow.Cells[0].Selected == true)
            //{
            //    if (e.KeyCode == Keys.F3)
            //    {
            //        flag_Unit = 1;
            //        Grid_Unit gg = new Grid_Unit();
            //        gg.Show();
            //    }
            //}
            //  }

        }

        private void btn_View_Supplier_No_Click(object sender, EventArgs e)
        {
            Grid_Supplier.SCR_Orders_Parchase = true;
            Grid_Supplier ss = new Grid_Supplier();
            ss.ShowDialog();
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
        private void Sum_Total_Item()
        {
            try
            {

                cost = Convert.ToDouble(textBox_Cost.Text);
                Quntity = Convert.ToDouble(textBox_Qantity.Text);
                Total = cost * Quntity;
                textBox_total1_groupbox1.Text = Total.ToString();

            }
            catch
            {

                cost = 0;
                Quntity = 0;
                Total = cost * Quntity;
                textBox_total1_groupbox1.Text = Total.ToString();

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1010 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1011 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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



                    btn_Add_Click(sender, e);



                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1012 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Data_ADD_Rows()
        {
            try
            {
                dataGridView1.Rows.Add(textBox_Item_No.Text, textBox_Item_Name.Text, textBox_Unit_No.Text, textBox_Unit_Name.Text, textBox_Qantity.Text, textBox_Cost.Text, textBox_total1_groupbox1.Text, textBox_Stores_No.Text, textBox_Stores_Name.Text);
                textBox_Item_No.Text = "";
                textBox_Item_Name.Text = "";
                textBox_Unit_No.Text = "";
                textBox_Unit_Name.Text = "";
                textBox_Qantity.Text = "";
                textBox_Cost.Text = "";
                textBox_total1_groupbox1.Text = "";
                textBox_Stores_No.Text = "";
                textBox_Stores_Name.Text = "";
                MessageBox.Show("تم إضافة المادة بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                textBox_Item_No.Focus();
                Sum_TotalGrid();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1013 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item.SCR_Orders_Parchase = true;
            Grid_Item ss = new Grid_Item();
            ss.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_Orders_Parchase = true;
            Grid_Stores ss = new Grid_Stores();
            ss.ShowDialog();
        }

        private void textBox_Order_Number_KeyPress(object sender, KeyPressEventArgs e)
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void btn_Unit_Click(object sender, EventArgs e)
        {
            if(textBox_Item_No.Text!="")
            {
                Grid_Unit.SCR_Orders_Parchase = true;
                Grid_Unit ss = new Grid_Unit();
                ss.ShowDialog();
            }
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1014 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1015 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
                    MessageBox.Show("يرجى عدم ترك الكلفة فارغة", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Cost.Focus();
                    return;
                }

                Data_ADD_Rows();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
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
        private void clear_screen()
        {
            dataGridView1.Rows.Clear();
            textBox_Supplier_No.Text = "";
            textBox_Supplier_Name.Text = "";
            textBox_Des.Text = "";
            radioButton1.Checked = true;
            textBox_Total2_groupBox2.Text = "";
        }
        private void textBox_Order_Number_KeyDown_1(object sender, KeyEventArgs e)

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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1018 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        public void addScren()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from Orders_Parchase where Order_No=@Order_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Order_No", textBox_Order_Number.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {

                    textBox_Supplier_No.Text = dr["Supplier_No"].ToString();
                    textBox_Supplier_Name.Text = dr["Supplier_Name"].ToString();
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
                SqlCommand cmd = new SqlCommand("select Item_No,Item_Name,Unit_No,Unit_Name,Quantity,Price_Cost,Total_Row,Sores_No,Stores_Name from Orders_Parchase where Order_No=@Order_No", con);
                cmd.Parameters.Add(new SqlParameter("@Order_No", textBox_Order_Number.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["Item_No"].ToString(), dr2["Item_Name"].ToString(), dr2["Unit_No"].ToString(), dr2["Unit_Name"].ToString(), dr2["Quantity"].ToString(), dr2["Price_Cost"].ToString(), dr2["Total_Row"].ToString(), dr2["Sores_No"].ToString(), dr2["Stores_Name"].ToString());
                    Sum_TotalGrid();
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1019 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_Year.Text!="")
            {
                Grid_Orders_Parchase ss = new Grid_Orders_Parchase();
                ss.ShowDialog();
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
                if (textBox_Order_Number.Text == "")
                {
                    MessageBox.Show("لا يمكن ترك رقم الطلب فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    textBox_Order_Number.Focus();
                    return;
                }
                if (MessageBox.Show("هل انت متاكد من عملية الحذف", "حذف سجل", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {

                    DeleteOrder();
                    MessageBox.Show("تم حذف الطلب بنجاح", "عملية صحيحة", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    clear_screen();
                    Orders_parchase_Load(sender, e);
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1020 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void textBox_Item_No_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_P_Save_Click(object sender, EventArgs e)
        {
            try
            {
                btn_Save_Click(sender, e);
                if (Print == 1)
                {
                    FRM_Report_Orders_Parchase FRM_Report_Orders_Parchase2 = new FRM_Report_Orders_Parchase();
                    FRM_Report_Orders_Parchase2.Show();
                    FRM_Report_Orders_Parchase.fRM_Report.textBox_Orders_No.Text = printNo.ToString();
                    FRM_Report_Orders_Parchase.fRM_Report.textBox_Year.Text = textBox_Year.Text;
                }
                Print = 0;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1021 Orders_parchase", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

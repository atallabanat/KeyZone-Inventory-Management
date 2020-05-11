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

namespace KeyZone_Inventory_Management.Bond_Inventory
{
    public partial class sett_Inventory : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static sett_Inventory sett_Inventory2;
        int Flag_Back = 0;
        double Qty;
        double R_A_Qty;
        double Unit_Rate;
        string SStore_No;
        string SStore_Name;
        public sett_Inventory()
        {
            sett_Inventory2 = this;
            this.KeyPreview = true;
            InitializeComponent();
            this.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            if (textBox_Stores_No.Text == "")
            {
                MessageBox.Show("الرجاء تحديد المستودع المطلوب لاحضار الاصناف","عملية خاطئة",MessageBoxButtons.OK,MessageBoxIcon.Error);
                textBox_Stores_No.Focus();
                return;
            }
                dataGridView1.Rows.Clear();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_Sett_inventory";
            cmd.Parameters.AddWithValue("@R_Sores_No", textBox_Stores_No.Text);

            con.Open();
            SqlDataReader dr5;
            dr5 = cmd.ExecuteReader();


            while (dr5.Read())
            {


                dataGridView1.Rows.Add(dr5["R_Item_No"].ToString(), dr5["R_Item_Name"].ToString(), dr5["R_Unit_No"].ToString(), dr5["R_Unit_Name"].ToString(), dr5["R_Price"].ToString(), dr5["R_Quantity2"].ToString(), dr5["R_Quantity1"].ToString());



            }
            dr5.Close();
            con.Close();

            SqlCommand cmd2 = new SqlCommand("select SUM(Cost_Paid) as Cost_Paid  from Add_Paid where Store_No=@Store_No and  Used_Sett is null", con);
            cmd2.Parameters.Add(new SqlParameter("@Store_No", textBox_Stores_No.Text));

            con.Open();
            SqlDataReader Ra = cmd2.ExecuteReader();

            if (Ra.Read())
            {
                textBox_ALLPaid.Text = Ra["Cost_Paid"].ToString();

            }
            else
            {
                textBox_ALLPaid.Text = "0";
            }
            Ra.Close();
            con.Close();

            //------------------ الرصيد السابق ---------------------------------------------------------------------------------------------
            SqlCommand cmd3 = new SqlCommand("select  sum(crdit) - sum(Debt) as Balance from Balance_Manf where Store_No=@Store_No", con);
            cmd3.Parameters.Add(new SqlParameter("@Store_No", textBox_Stores_No.Text));

            con.Open();
            SqlDataReader Ra3 = cmd3.ExecuteReader();

            if (Ra3.Read())
            {
                textBox_Balance.Text = Ra3["Balance"].ToString();

            }
            else
            {
                textBox_Balance.Text = "0";
            }
            Ra3.Close();
            con.Close();

        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void dataGridView1_CellLeave(object sender, DataGridViewCellEventArgs e)
        {


        }
        private void Save_Doc()
        {
            for(int i=0; i < dataGridView1.RowCount; i++)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_ADD_Sett_Inventory";

                cmd.Parameters.AddWithValue("@Bond_No", textBox_Bond_NO.Text);
                cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                cmd.Parameters.AddWithValue("@Date_Bond", dateTime_Bond_Date.Value);
                cmd.Parameters.AddWithValue("@Store_No", textBox_Stores_No.Text);
                cmd.Parameters.AddWithValue("@Store_Name", textBox_Stores_Name.Text);
                cmd.Parameters.AddWithValue("@Amt_Dawn", textBox_Total_Dawn.Text);
                cmd.Parameters.AddWithValue("@Amt_End", textBox_Total_End.Text);
                if (textBox_ALLPaid.Text == "")
                {
                    textBox_ALLPaid.Text = "0";
                }
                cmd.Parameters.AddWithValue("@Amt_ALLPaid", textBox_ALLPaid.Text);
                cmd.Parameters.AddWithValue("@Amt_Tot", textBox_tot.Text);
                if(textBox_Balance.Text=="")
                {
                    textBox_Balance.Text = "0";
                }
                cmd.Parameters.AddWithValue("@Amt_Balance", textBox_Balance.Text);
                cmd.Parameters.AddWithValue("@Amt_REQ", textBox_REQ.Text);
                cmd.Parameters.AddWithValue("@TTotal", textBox2.Text);

                cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells["Column4"].Value);
                cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells["Column_Item_Name"].Value);
                cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells["Column5"].Value);
                cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells["Column_Unit_Name"].Value);
                cmd.Parameters.AddWithValue("@R_Price_Item", dataGridView1.Rows[i].Cells["Column_Price"].Value);
                if(dataGridView1.Rows[i].Cells["Column1"].Value=="")
                {
                    dataGridView1.Rows[i].Cells["Column1"].Value = 0;
                }
                
                cmd.Parameters.AddWithValue("@R_Quantity_Sales", dataGridView1.Rows[i].Cells["Column1"].Value);
                cmd.Parameters.AddWithValue("@R_Quantity_UP", dataGridView1.Rows[i].Cells["Column_Quantity"].Value);
                cmd.Parameters.AddWithValue("@R_MRow", dataGridView1.Rows[i].Cells["Column_MRow"].Value);
                cmd.Parameters.AddWithValue("@R_diff", dataGridView1.Rows[i].Cells["Column_diff"].Value);
                cmd.Parameters.AddWithValue("@R_Price_Dawn", dataGridView1.Rows[i].Cells["Column_Dawn"].Value);
                cmd.Parameters.AddWithValue("@R_Price_End", dataGridView1.Rows[i].Cells["Column_end"].Value);
                cmd.Parameters.AddWithValue("@R_Price_REQ", dataGridView1.Rows[i].Cells["Column_Tot"].Value);

                cmd.Parameters.AddWithValue("@Flag_Back", Flag_Back);
                cmd.Parameters.AddWithValue("@Used_Sett", 1);
                cmd.Parameters.AddWithValue("@ID_User", 1);
                

                cmd.ExecuteNonQuery();
                con.Close();
            }

        }
        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentRow.Cells["Column_MRow"].Value != null)
            {
                double REQ = 0;
                double Price = 0;
                double Tot = 0;
                double TPriceDawn = 0;
                double TPriceEnd = 0;
                double QuantityNow = 0;
                double MRow = 0;
                double diff = 0;
                QuantityNow = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Column_Quantity"].Value);
                MRow = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Column_MRow"].Value);
                diff = QuantityNow - MRow;
                dataGridView1.CurrentRow.Cells["Column_diff"].Value = diff.ToString();


                Price = Convert.ToDouble(dataGridView1.CurrentRow.Cells["Column_Price"].Value);

                //-------------------------------------------------------------------

                //------- مبلغ التحميل
                TPriceDawn = QuantityNow * Price;
                dataGridView1.CurrentRow.Cells["Column_Dawn"].Value = TPriceDawn.ToString();
                //-----------------------------------------------------------------------

                //---- مبلغ الجرد
                TPriceEnd = MRow * Price;
                dataGridView1.CurrentRow.Cells["Column_end"].Value = TPriceEnd.ToString();

                //--------------------------------------------------------------------------

                //---- المبلغ المطلوب
                Tot = diff * Price; ;
                dataGridView1.CurrentRow.Cells["Column_Tot"].Value = Tot.ToString();

                //--------------------------------------------------------------------------




                subTotal_Dawn_End_tot();
            }
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
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
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1006 sett_Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void sett_Inventory_Load(object sender, EventArgs e)
        {
            string date = DateTime.Now.Year.ToString();

            textBox_Year.Text = date;
            Max();


        }
        private void clear()
        {
            dataGridView1.Rows.Clear();
            textBox_Total_Dawn.Text = "0";
            textBox_Total_End.Text = "0";
            textBox_ALLPaid.Text = "0";
            textBox_tot.Text = "0";
            textBox2.Text = "0";
            textBox_Balance.Text = "0";
            textBox_REQ.Text = "0";
            textBox_Stores_No.Text = "";
            textBox_Stores_Name.Text = "";
            radioButton2.Checked = true;
            Max();

        }
        private void Max()
        {
            try
            {
                string date = DateTime.Now.Year.ToString();

                textBox_Year.Text = date;

                con.Open();
                SqlCommand cmd21 = new SqlCommand("select isnull((Max(Bond_No)+1),1) as max from sett_Inventory where Myear=@myear", con);
                cmd21.Parameters.AddWithValue("@myear", textBox_Year.Text);
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();
                if (dr.Read())
                {
                    textBox_Bond_NO.Text = dr["max"].ToString();
                }
                con.Close();
                textBox_Bond_NO.Focus();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 sett_Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void subTotal_Dawn_End_tot()
        {
            double TotalALLDawn = 0;
            double TotalALLEnd = 0;
            double TotalALLTot = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                double TotalDawn = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_Dawn"].Value);
                double TotalEnd = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_end"].Value);
                double TTot = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_Tot"].Value);

                TotalALLDawn += TotalDawn;
                TotalALLEnd += TotalEnd;
                TotalALLTot += TTot;

                textBox_Total_Dawn.Text = TotalALLDawn.ToString();
                textBox_Total_End.Text = TotalALLEnd.ToString();
                textBox_tot.Text = TotalALLTot.ToString();


                //---- (المطلوب)مجموع الدفعات المتبقية
                if(textBox_ALLPaid.Text=="")
                {
                    textBox_ALLPaid.Text = "0";
                }
                double ALLPaid = Convert.ToDouble( textBox_ALLPaid.Text);
                double RR = 0;
                RR = TotalALLTot - ALLPaid;
                textBox_REQ.Text = RR.ToString();

                //--------------------------------------------------------------------------
                //------------------------ المجموع

                double Balance = 0;
                double TTotal = 0;
                if (textBox_Balance.Text=="")
                {
                    Balance = 0;
                }
                else
                {
                    Balance = Convert.ToDouble(textBox_Balance.Text);

                }

                TTot = RR + Balance;
                textBox2.Text = TTot.ToString();


            }
        }

        private void btn_View_Bond_No_Click(object sender, EventArgs e)
        {
            Grid_Stores.SCR_sett_Inventory = true;
            Grid_Stores ss = new Grid_Stores();
            ss.ShowDialog();
            Grid_Stores.SCR_sett_Inventory = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Add_Paid add_Paid = new Add_Paid();
            add_Paid.ShowDialog();
        }
        private void i2_Trans()
        {
            //-------------- تحويل جميع المواد الداخلة وكمياتها الى موقوفة------------/
                Update_Used_Sett();
            //----------------------------------------------------------------------------/

            

            for (int i=0; i < dataGridView1.RowCount; i++)
            {
                //-------- كمية الجرد ----------------------------------------------------------------/
                double EE = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_MRow"].Value);
                //-----------------------------------------------------------------------------------//

                double QS = 0;
                try
                {
                     QS = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column1"].Value);
                }
                catch(Exception)
                {
                    QS = 0;
                }


                if (QS > 0)
                {
                    //------------- اذا كان في كمية متبقية ------------------------//
                    if (EE > 0)
                    {
                        ADD_Row_i2_trans_IN(i);
                    }
                    //------------------------------------------------------------------
                }
                else
                {
                    

                    ADD_Row_i2_trans_Out(i);
                    //------------- اذا كان في كمية متبقية ------------------------//
                    if (EE > 0)
                    {
                        ADD_Row_i2_trans_IN(i);
                    }
                    //------------------------------------------------------------------

                }
            }
        }
        private void ADD_Row_i2_trans_Out(int i)
        {
            try
            {
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Row_Sett_Inventory_i2_trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_NO.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //Kind >> ادخال 1 ,, اخراج 2
                    cmd.Parameters.AddWithValue("@Kind", 2);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Sett_inventory_out);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Sett_inventory_out);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", 3);
                    cmd.Parameters.AddWithValue("@S_No", "");
                    cmd.Parameters.AddWithValue("@S_Name", "");
                    cmd.Parameters.AddWithValue("@Note", "سند تسوية جرد تلقائي رقم "+ textBox_Bond_NO.Text + "إخراج");
                    cmd.Parameters.AddWithValue("@Total_Order", textBox_Total_Dawn.Text);
                    cmd.Parameters.AddWithValue("@Discount", 0);
                    cmd.Parameters.AddWithValue("@On_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells["Column4"].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells["Column_Item_Name"].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells["Column5"].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells["Column_Unit_Name"].Value);

                    cmd.Parameters.AddWithValue("@R_Sores_No", textBox_Stores_No.Text);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", textBox_Stores_Name.Text);

                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i].Cells["Column_Quantity"].Value);
                    //---------إستعلام عن معامل التحويل------------------------------

                    SqlCommand cmd21 = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i].Cells["Column4"].Value));
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i].Cells["Column5"].Value));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    Qty = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_Quantity"].Value);
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
                    cmd.Parameters.AddWithValue("@R_Price", dataGridView1.Rows[i].Cells["Column_Price"].Value);
                    cmd.Parameters.AddWithValue("@R_Discount", 0);
                    cmd.Parameters.AddWithValue("@R_Discount_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells["Column_Dawn"].Value);
                    

                    cmd.Parameters.AddWithValue("@R_End_Date", "");
                    cmd.Parameters.AddWithValue("@ID_User", 1);


                    cmd.ExecuteNonQuery();
                    con.Close();
                //}
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 sett_inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }


        private void ADD_Row_i2_trans_IN(int i)
        {
            try
            {
                //for (int i = 0; i < dataGridView1.Rows.Count; i++)
                //{
                    con.Open();
                    SqlCommand cmd = con.CreateCommand();

                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.CommandText = "SP_ADD_Row_Sett_Inventory_i2_trans";

                    cmd.Parameters.AddWithValue("@Order_No", textBox_Bond_NO.Text);
                    cmd.Parameters.AddWithValue("@Myear", textBox_Year.Text);
                    //Kind >> ادخال 1 ,, اخراج 2
                    cmd.Parameters.AddWithValue("@Kind", 1);
                    cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_Sett_inventory_IN);
                    cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_Sett_inventory_IN);
                    cmd.Parameters.AddWithValue("@Tablet", 0);
                    cmd.Parameters.AddWithValue("@Odate", dateTime_Bond_Date.Value);
                    cmd.Parameters.AddWithValue("@status_Order", 3);
                    cmd.Parameters.AddWithValue("@S_No", "");
                    cmd.Parameters.AddWithValue("@S_Name", "");
                    cmd.Parameters.AddWithValue("@Note", "سند تسوية جرد تلقائي رقم " + textBox_Bond_NO.Text + "إدخال");
                    cmd.Parameters.AddWithValue("@Total_Order", textBox_Total_End.Text);
                    cmd.Parameters.AddWithValue("@Discount", 0);
                    cmd.Parameters.AddWithValue("@On_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Item_No", dataGridView1.Rows[i].Cells["Column4"].Value);
                    cmd.Parameters.AddWithValue("@R_Item_Name", dataGridView1.Rows[i].Cells["Column_Item_Name"].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_No", dataGridView1.Rows[i].Cells["Column5"].Value);
                    cmd.Parameters.AddWithValue("@R_Unit_Name", dataGridView1.Rows[i].Cells["Column_Unit_Name"].Value);

                    cmd.Parameters.AddWithValue("@R_Sores_No", SStore_No);
                    cmd.Parameters.AddWithValue("@R_Stores_Name", SStore_Name);

                    cmd.Parameters.AddWithValue("@R_Quantity", dataGridView1.Rows[i].Cells["Column_MRow"].Value);
                    //---------إستعلام عن معامل التحويل------------------------------

                    SqlCommand cmd21 = new SqlCommand("select Unit_Rate from Items_Unit_Cust where Item_No=@Item_No and Unit_No=@Unit_No", con);
                    cmd21.Parameters.Add(new SqlParameter("@Item_No", dataGridView1.Rows[i].Cells["Column4"].Value));
                    cmd21.Parameters.Add(new SqlParameter("@Unit_No", dataGridView1.Rows[i].Cells["Column5"].Value));
                    SqlDataReader dr;
                    dr = cmd21.ExecuteReader();
                    Qty = Convert.ToDouble(dataGridView1.Rows[i].Cells["Column_MRow"].Value);
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
                    cmd.Parameters.AddWithValue("@R_Price", dataGridView1.Rows[i].Cells["Column_Price"].Value);
                    cmd.Parameters.AddWithValue("@R_Discount", 0);
                    cmd.Parameters.AddWithValue("@R_Discount_Percentage", 0);
                    cmd.Parameters.AddWithValue("@R_Total", dataGridView1.Rows[i].Cells["Column_end"].Value);


                    cmd.Parameters.AddWithValue("@R_End_Date", "");
                    cmd.Parameters.AddWithValue("@ID_User", 1);


                    cmd.ExecuteNonQuery();
                    con.Close();
                //}
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1016 sett_inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        private void Update_Used_Sett()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_Sett_inventory_Update_Used";

            cmd.Parameters.AddWithValue("@R_Sores_No", textBox_Stores_No.Text);
            cmd.Parameters.AddWithValue("@Bond_Sett", textBox_Bond_NO.Text);


            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox_Year.Text=="")
            {
                MessageBox.Show("يرجى عدم ترك حقل السنة فارغ","عملية خاطئة",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                return;
            }
            if (textBox_Bond_NO.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم المستند فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox_Stores_No.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل رقم المستودع فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (textBox_Stores_Name.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك حقل اسم المستودع فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if(dataGridView1.RowCount == 0)
            {
                MessageBox.Show("يرجى عدم ترك بيانات الجدول فارغ", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;

            }
            Flag_Backk();
            Save_Doc();
            i2_Trans();
            Balance();
            End_Paid();
            clear();
            Max();
        }

        private void Balance()
        {
            string Note = "من سند تسوية الجرد التلقائي رقم "+ textBox_Bond_NO.Text;

            double BB = 0;
            double Debt = 0;
            double Crdit = 0;
            if (textBox2.Text=="")
            {
                BB = 0;
            }
            else
            {
                BB = Convert.ToDouble(textBox2.Text);
            }
            if(BB >= 0)
            {
                Crdit = BB;
            }
            else if(BB < 0)
            {
                Debt = BB * -1;
            }
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.CommandText = "SP_ADD_Balance_Manf";

            cmd.Parameters.AddWithValue("@Store_No", textBox_Stores_No.Text);
            cmd.Parameters.AddWithValue("@Store_Name", textBox_Stores_Name.Text);
            cmd.Parameters.AddWithValue("@Note", Note);
            cmd.Parameters.AddWithValue("@Debt", Debt);
            cmd.Parameters.AddWithValue("@Crdit", Crdit);
            cmd.Parameters.AddWithValue("@ID_User", 1);

            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void End_Paid()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();

            cmd.CommandType = CommandType.Text;

            cmd.CommandText = "update Add_Paid set Used_Sett=1 , Bond_Sett=@Bond_Sett where Store_No=@Store_No and Used_Sett is null ";
            cmd.Parameters.AddWithValue("@Bond_Sett",textBox_Bond_NO.Text);
            cmd.Parameters.AddWithValue("@Store_No", textBox_Stores_No.Text);
            
            cmd.ExecuteNonQuery();
            con.Close();
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if(radioButton1.Checked==true)
            {
                Flag_Back = 1;
            }
            else
            {
                Flag_Back = 0;
            }
        }
        private void Flag_Backk()
        {
            if(Flag_Back==1)
            {
                SqlCommand cmd2 = new SqlCommand("select R_store_No,R_store_Name  from comf", con);


                con.Open();
                SqlDataReader Ra = cmd2.ExecuteReader();

                if (Ra.Read())
                {
                    SStore_No = Ra["R_store_No"].ToString();
                    SStore_Name = Ra["R_store_Name"].ToString();
                }
                else
                {
                    SStore_No = "0";
                    SStore_Name = "مشكلة في تسوية الجرد";
                }
                Ra.Close();
                con.Close();

             
            }
            else
            {
                SStore_No =textBox_Stores_No.Text;
                SStore_Name = textBox_Stores_Name.Text;
            }
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Flag_Back = 1;
            }
            else
            {
                Flag_Back = 0;
            }
        }

        private void textBox_Stores_No_Leave(object sender, EventArgs e)
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

        private void textBox_Bond_NO_Leave(object sender, EventArgs e)
        {

        }
        public void Select_Screen()
        {
            try
            {
                con.Open();
                SqlCommand cmd21 = new SqlCommand("select top 1 * from sett_Inventory where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd21.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_NO.Text));
                cmd21.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr;
                dr = cmd21.ExecuteReader();

                if (dr.Read())
                {
                    textBox_Year.Text = dr["Myear"].ToString();
                    dateTime_Bond_Date.Text = dr["Date_Bond"].ToString();                   
                    textBox_Stores_No.Text = dr["Store_No"].ToString();
                    textBox_Stores_Name.Text = dr["Store_Name"].ToString();
                    textBox_Total_Dawn.Text = dr["Amt_Dawn"].ToString();
                    textBox_Total_End.Text = dr["Amt_End"].ToString();
                    textBox_ALLPaid.Text = dr["Amt_ALLPaid"].ToString();
                    textBox_tot.Text = dr["Amt_Tot"].ToString();
                    textBox_Balance.Text = dr["Amt_Balance"].ToString();
                    textBox_REQ.Text = dr["Amt_REQ"].ToString();
                    textBox2.Text = dr["TTotal"].ToString();
                    if(dr["Flag_Back"].ToString()=="1")
                    {
                        radioButton1.Checked = true;
                    }
                    else
                    {
                        radioButton2.Checked = true;
                    }
                    con.Close();
                    button1.Enabled = false;
                }
                else
                {
                    con.Close();
                    Max();
                    clear();
                    button1.Enabled = true;
                }


                con.Open();
                dataGridView1.Rows.Clear();
                SqlCommand cmd = new SqlCommand("select R_Item_No,R_Item_Name,R_Unit_No,R_Unit_Name,R_Price_Item, R_Quantity_Sales, R_Quantity_UP,R_MRow,R_diff,R_Price_Dawn,R_Price_End,R_Price_REQ from sett_Inventory where Bond_No=@Bond_No and Myear=@Myear", con);
                cmd.Parameters.Add(new SqlParameter("@Bond_No", textBox_Bond_NO.Text));
                cmd.Parameters.Add(new SqlParameter("@Myear", textBox_Year.Text));
                SqlDataReader dr2;
                dr2 = cmd.ExecuteReader();
                while (dr2.Read())
                {
                    dataGridView1.Rows.Add(dr2["R_Item_No"].ToString(), dr2["R_Item_Name"].ToString(), dr2["R_Unit_No"].ToString(), dr2["R_Unit_Name"].ToString(), dr2["R_Price_Item"].ToString(), dr2["R_Quantity_Sales"].ToString(), dr2["R_Quantity_UP"].ToString(), dr2["R_MRow"].ToString(), dr2["R_diff"].ToString(), dr2["R_Price_Dawn"].ToString(), dr2["R_Price_End"].ToString(), dr2["R_Price_REQ"].ToString());
                    
                }

                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1017 sett_Inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_Bond_NO_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                if (textBox_Bond_NO.Text != "")
                {
                    Select_Screen();
                    
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Grid_Sett_inventory.SCR_Sett_invff = true;
            Grid_Sett_inventory grid = new Grid_Sett_inventory();
            grid.ShowDialog();
            Grid_Sett_inventory.SCR_Sett_invff = false;

        }
    }
}

using KeyZone_Inventory_Management.Bond_Inventory;
using KeyZone_Inventory_Management.Sales;
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

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Qauntity : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Transfer_Bond;
        public static Boolean SCR_Destruction_Bond;
        public static Boolean SCR_Invoice_Sales;
        double Unit_Rate2;
        string Item_No;
        string Item_Name;
        string Quantity;
        string R_A_Qty;
        string End_Date;

        public Grid_Qauntity()
        {
            
            InitializeComponent();
        }
        public void SelectUnit_Rate()
        {
            try
            {

                SqlCommand cmd = new SqlCommand("select top 1 Unit_Rate from Items_Unit_Cust where Item_No=@Item_No order by Unit_Rate desc", con);
                if (SCR_Transfer_Bond == true)
                {
                    cmd.Parameters.Add(new SqlParameter("@Item_No", Transfer_Bond.Transfer_B.textBox_Item_No.Text));
                }
                if (SCR_Out_Bond == true)
                {
                    cmd.Parameters.Add(new SqlParameter("@Item_No", Out_Bond.out_B.textBox_Item_No.Text));

                }
                if (SCR_Destruction_Bond == true)
                {
                    cmd.Parameters.Add(new SqlParameter("@Item_No", Destruction_Bond.Destruction_B.textBox_Item_No.Text));

                }
                if (SCR_Invoice_Sales == true)
                {
                    cmd.Parameters.Add(new SqlParameter("@Item_No", Invoice_Sales.invoice_sales.textBox_Item_No.Text));

                }

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
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
        public void LLOOP()
        {
            try
            {
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    double col_UnitMain = Convert.ToDouble(dataGridView1.Rows[i].Cells["Col_R_A_qty"].Value);
                    dataGridView1.Rows[i].Cells["Col_Qauntity"].Value = col_UnitMain / Unit_Rate2;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
        private void Grid_Qauntity_Load(object sender, EventArgs e)
        {
            try
            {
                if (SCR_Transfer_Bond == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SELECT_DGV_Qauntity_Grid";
                        Cmd.Parameters.AddWithValue("@R_Item_No", Transfer_Bond.Transfer_B.textBox_Item_No.Text);
                        Cmd.Parameters.AddWithValue("@R_Sores_No", Transfer_Bond.Transfer_B.textBox_From_Stores_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;

                    SelectUnit_Rate();
                    LLOOP();

                }
                if (SCR_Invoice_Sales == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SELECT_DGV_Qauntity_Grid";
                        Cmd.Parameters.AddWithValue("@R_Item_No", Invoice_Sales.invoice_sales.textBox_Item_No.Text);
                        Cmd.Parameters.AddWithValue("@R_Sores_No", Invoice_Sales.invoice_sales.textBox_Stores_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;

                    SelectUnit_Rate();
                    LLOOP();

                }
                if (SCR_Out_Bond == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SELECT_DGV_Qauntity_Grid";
                        Cmd.Parameters.AddWithValue("@R_Item_No", Out_Bond.out_B.textBox_Item_No.Text);
                        Cmd.Parameters.AddWithValue("@R_Sores_No", Out_Bond.out_B.textBox_Stores_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                    SelectUnit_Rate();
                    LLOOP();
                }

                if (SCR_Destruction_Bond == true)
                {
                    var dataTable = new DataTable();
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SELECT_DGV_Qauntity_Grid";
                        Cmd.Parameters.AddWithValue("@R_Item_No", Destruction_Bond.Destruction_B.textBox_Item_No.Text);
                        Cmd.Parameters.AddWithValue("@R_Sores_No", Destruction_Bond.Destruction_B.textBox_Stores_No.Text);
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
                    SelectUnit_Rate();
                    LLOOP();
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Item_No = dataGridView1.CurrentRow.Cells["R_Item_No"].Value.ToString();
                    Item_Name = dataGridView1.CurrentRow.Cells["R_Item_Name"].Value.ToString();
                    Quantity = dataGridView1.CurrentRow.Cells["Col_Qauntity"].Value.ToString();
                    R_A_Qty = dataGridView1.CurrentRow.Cells["Col_R_A_qty"].Value.ToString();
                    End_Date = dataGridView1.CurrentRow.Cells["Col_EndDate"].Value.ToString();


                    if (SCR_Transfer_Bond == true)
                    {
                        Transfer_Bond.Transfer_B.textBox_Qantity.Text = Quantity;
                        Transfer_Bond.Transfer_B.textBox_End_Date.Text = End_Date;
                        SCR_Transfer_Bond = false;
                    }
                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_B.textBox_Qantity.Text = Quantity;
                        Out_Bond.out_B.textBox_End_Date.Text = End_Date;
                        SCR_Out_Bond = false;
                    }
                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.Destruction_B.textBox_Qantity.Text = Quantity;
                        Destruction_Bond.Destruction_B.textBox_End_Date.Text = End_Date;
                        SCR_Destruction_Bond = false;
                    }
                    if (SCR_Invoice_Sales == true)
                    {
                        Invoice_Sales.invoice_sales.textBox_Qantity.Text = Quantity;
                        Invoice_Sales.invoice_sales.textBox_End_Date.Text = End_Date;
                        SCR_Destruction_Bond = false;
                    }

                }

                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1004 Grid_Qauntity", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

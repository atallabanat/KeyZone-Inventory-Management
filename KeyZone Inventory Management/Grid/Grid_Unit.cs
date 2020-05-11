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
using KeyZone_Inventory_Management.Bond_Inventory;
using KeyZone_Inventory_Management.Defenition;
using KeyZone_Inventory_Management.Distributor;
using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
using KeyZone_Inventory_Management.Sales;

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Unit : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
       
        public static Grid_Unit unna;
        public static Boolean SCR_Orders_Parchase;
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_Entry_Bond;
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Destruction_Bond;
        public static Boolean SCR_Transfer_Bond;
        public static Boolean SCR_INV_F;
        public static Boolean SCR_Order_Sales;
        public static Boolean SCR_Invoice_Sales;
        string unit_no;
        string unit_Name;
        
        public Grid_Unit()
        {
            InitializeComponent();
        }

        private void Grid_Unit_Load(object sender, EventArgs e)
        {


            try
            {
                var dataTable = new DataTable();
                if (SCR_INV_F == true)
                {

                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DVG_ALLUnit";
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Transfer_Bond == true)
                {

                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Transfer_Bond.Transfer_B.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;

                }

                if (SCR_Orders_Parchase == true)
                {

                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Orders_parchase.Ord.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;

                }

                if (SCR_Entry_Bond == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Entity_Bond.entity_Bond.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Invoice_Parchase == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Invoice_Parchase.Inv_Parchase.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Out_Bond == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Out_Bond.out_B.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Destruction_Bond == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Destruction_Bond.Destruction_B.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Order_Sales == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Oreder_Sales.Ord_Sales.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
                if (SCR_Invoice_Sales == true)
                {
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item_UnitNO";
                        Cmd.Parameters.AddWithValue("@Item_No", "" + Invoice_Sales.invoice_sales.textBox_Item_No.Text + " ");
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }


                    dataGridView1.DataSource = dataTable;
                }
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        protected void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    unit_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    unit_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Transfer_Bond == true)
                    {
                        Transfer_Bond.Transfer_B.textBox_Unit_No.Text = unit_no;
                        Transfer_Bond.Transfer_B.textBox_Unit_Name.Text = unit_Name;
                        SCR_Transfer_Bond = false;
                    }

                    if (SCR_Invoice_Sales == true)
                    {
                        Invoice_Sales.invoice_sales.textBox_Unit_No.Text = unit_no;
                        Invoice_Sales.invoice_sales.textBox_Unit_Name.Text = unit_Name;
                        SCR_Invoice_Sales = false;
                    }

                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.Destruction_B.textBox_Unit_No.Text = unit_no;
                        Destruction_Bond.Destruction_B.textBox_Unit_Name.Text = unit_Name;
                        SCR_Destruction_Bond = false;
                    }

                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_B.textBox_Unit_No.Text = unit_no;
                        Out_Bond.out_B.textBox_Unit_Name.Text = unit_Name;
                        SCR_Out_Bond = false;
                    }

                    if (SCR_Orders_Parchase == true)
                    {
                        Orders_parchase.Ord.textBox_Unit_No.Text = unit_no;
                        Orders_parchase.Ord.textBox_Unit_Name.Text = unit_Name;
                        SCR_Orders_Parchase = false;
                    }
                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Unit_No.Text = unit_no;
                        Invoice_Parchase.Inv_Parchase.textBox_Unit_Name.Text = unit_Name;
                        SCR_Invoice_Parchase = false;
                    }
                    if (SCR_Entry_Bond == true)
                    {
                        Entity_Bond.entity_Bond.textBox_Unit_No.Text = unit_no;
                        Entity_Bond.entity_Bond.textBox_Unit_Name.Text = unit_Name;
                        SCR_Entry_Bond = false;
                    }
                    if (SCR_Order_Sales == true)
                    {
                        Oreder_Sales.Ord_Sales.textBox_Unit_No.Text = unit_no;
                        Oreder_Sales.Ord_Sales.textBox_Unit_Name.Text = unit_Name;
                        SCR_Order_Sales = false;
                    }
                    if (SCR_INV_F == true)
                    {
                        if (INV_F.flag_Unit == 2)
                        {
                            INV_F.iNV.dataGridView2.CurrentRow.Cells[0].Value = unit_no;
                            INV_F.iNV.dataGridView2.CurrentRow.Cells[1].Value = unit_Name;
                            INV_F.flag_Unit = 0;

                        }
                        else if (INV_F.flag_Unit == 1)
                        {
                            INV_F.iNV.dataGridView1.CurrentRow.Cells[0].Value = unit_no;
                            INV_F.iNV.dataGridView1.CurrentRow.Cells[1].Value = unit_Name;
                            INV_F.flag_Unit = 0;
                        }
                        SCR_INV_F = false;

                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Unit", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

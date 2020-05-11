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
using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
using KeyZone_Inventory_Management.Sales;

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Item : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Boolean SCR_Orders_Parchase;
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_return_Parchase;
        public static Boolean SCR_Entry_Bond;
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Destruction_Bond;
        public static Boolean SCR_Transfer_Bond;
        public static Boolean SCR_Orders_Sales;
        public static Boolean SCR_Invoice_Sales;
        string Item_No;
        string Item_Name;

        public object Destruction_B { get; private set; }

        public Grid_Item()
        {
            InitializeComponent();
        }

        private void Grid_Item_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Item_Grid";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Item_No = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Item_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Transfer_Bond == true)
                    {
                        Transfer_Bond.Transfer_B.textBox_Item_No.Text = Item_No;
                        Transfer_Bond.Transfer_B.textBox_Item_Name.Text = Item_Name;
                        Transfer_Bond.Transfer_B.textBox_Unit_No.Text = "";
                        Transfer_Bond.Transfer_B.textBox_Unit_Name.Text = "";
                        Transfer_Bond.Transfer_B.flag_endDate();
                        SCR_Transfer_Bond = false;

                    }


                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.Destruction_B.textBox_Item_No.Text = Item_No;
                        Destruction_Bond.Destruction_B.textBox_Item_Name.Text = Item_Name;
                        Destruction_Bond.Destruction_B.flag_endDate();
                        Destruction_Bond.Destruction_B.textBox_Unit_No.Text = "";
                        Destruction_Bond.Destruction_B.textBox_Unit_Name.Text = "";
                        SCR_Destruction_Bond = false;

                    }


                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_B.textBox_Item_No.Text = Item_No;
                        Out_Bond.out_B.textBox_Item_Name.Text = Item_Name;
                        Out_Bond.out_B.flag_endDate();
                        Out_Bond.out_B.textBox_Unit_No.Text = "";
                        Out_Bond.out_B.textBox_Unit_Name.Text = "";
                        SCR_Out_Bond = false;
                    }
                    if (SCR_Orders_Parchase == true)
                    {

                        Orders_parchase.Ord.textBox_Item_No.Text = Item_No;
                        Orders_parchase.Ord.textBox_Item_Name.Text = Item_Name;
                        Orders_parchase.Ord.textBox_Unit_No.Text = "";
                        Orders_parchase.Ord.textBox_Unit_Name.Text = "";
                        SCR_Orders_Parchase = false;
                    }
                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Item_No.Text = Item_No;
                        Invoice_Parchase.Inv_Parchase.textBox_Item_Name.Text = Item_Name;
                        SCR_Invoice_Parchase = false;
                        Invoice_Parchase.Inv_Parchase.flag_endDate();
                        Invoice_Parchase.Inv_Parchase.textBox_Unit_No.Text = "";
                        Invoice_Parchase.Inv_Parchase.textBox_Unit_Name.Text = "";

                    }
                    if (SCR_return_Parchase == true)
                    {
                        return_parchase.return_Parchase.textBox_Item_No.Text = Item_No;
                        return_parchase.return_Parchase.textBox_Item_Name.Text = Item_Name;
                        SCR_return_Parchase = false;
                        return_parchase.return_Parchase.textBox_Unit_No.Text = "";
                        return_parchase.return_Parchase.textBox_Unit_Name.Text = "";
                    }
                    if (SCR_Entry_Bond == true)
                    {
                        Entity_Bond.entity_Bond.textBox_Item_No.Text = Item_No;
                        Entity_Bond.entity_Bond.textBox_Item_Name.Text = Item_Name;
                        Entity_Bond.entity_Bond.flag_endDate();
                        SCR_Entry_Bond = false;
                        Entity_Bond.entity_Bond.textBox_Unit_No.Text = "";
                        Entity_Bond.entity_Bond.textBox_Unit_Name.Text = "";
                    }
                    if (SCR_Orders_Sales == true)
                    {
                        Oreder_Sales.Ord_Sales.textBox_Item_No.Text = Item_No;
                        Oreder_Sales.Ord_Sales.textBox_Item_Name.Text = Item_Name;
                        SCR_Orders_Sales = false;
                        Oreder_Sales.Ord_Sales.textBox_Unit_No.Text = "";
                        Oreder_Sales.Ord_Sales.textBox_Unit_Name.Text = "";
                    }
                    if (SCR_Invoice_Sales == true)
                    {
                        Invoice_Sales.invoice_sales.textBox_Item_No.Text = Item_No;
                        Invoice_Sales.invoice_sales.textBox_Item_Name.Text = Item_Name;
                        Invoice_Sales.invoice_sales.flag_endDate();
                        SCR_Invoice_Sales = false;
                        Invoice_Sales.invoice_sales.textBox_Unit_No.Text = "";
                        Invoice_Sales.invoice_sales.textBox_Unit_Name.Text = "";
                    }
                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void textBox_search_OnValueChanged(object sender, EventArgs e)
        {
            try
            {

                var dataTable2 = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SEARCH_DGV_INV_F_Grid_Item";
                    Cmd.Parameters.AddWithValue("@Item_No", "%" + textBox_search.Text + "%");
                    Cmd.Parameters.AddWithValue("@Item_Name", "%" + textBox_search.Text + "%");
                    SqlDataAdapter da2 = new SqlDataAdapter(Cmd);
                    da2.Fill(dataTable2);


                }
                dataGridView1.DataSource = dataTable2;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1003 Grid_Item", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

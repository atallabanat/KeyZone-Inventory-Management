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
using KeyZone_Inventory_Management.Form_RPT;
using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
using KeyZone_Inventory_Management.Sales;

namespace KeyZone_Inventory_Management.Grid
{
    public partial class Grid_Stores : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);

        //public Virable
        public static Boolean SCR_Add_Paid;
        public static Boolean SCR_sett_Inventory;
        public static Boolean SCR_Orders_Parchase;
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_Entry_Bond;
        public static Boolean SCR_Out_Bond;
        public static Boolean SCR_Destruction_Bond;
        public static Boolean SCR_Transfer_FROM;
        public static Boolean SCR_Transfer_TO;
        public static Boolean SCR_Invoice_Sales;
        public static Boolean SCR_Report_Trans_Stores;
        public static Boolean SCR_FRM_Report_Item_Now;
        public static Boolean SCR_FRM_Account_Manf;
        string Stores_No;
        string Stores_Name;
        public Grid_Stores()
        {
            InitializeComponent();
        }

        private void Grid_Stores_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Stores_Grid";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Stores_No = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Stores_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Transfer_FROM == true)
                    {
                        Transfer_Bond.Transfer_B.textBox_From_Stores_No.Text = Stores_No;
                        Transfer_Bond.Transfer_B.textBox_From_Stores_Name.Text = Stores_Name;
                        SCR_Transfer_FROM = false;
                    }
                    if (SCR_Invoice_Sales == true)
                    {
                        Invoice_Sales.invoice_sales.textBox_Stores_No.Text = Stores_No;
                        Invoice_Sales.invoice_sales.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Invoice_Sales = false;
                    }
                    if (SCR_Transfer_TO == true)
                    {
                        Transfer_Bond.Transfer_B.textBox_To_Stores_No.Text = Stores_No;
                        Transfer_Bond.Transfer_B.textBox_To_Stores_Name.Text = Stores_Name;
                        SCR_Transfer_TO = false;
                    }

                    if (SCR_Destruction_Bond == true)
                    {
                        Destruction_Bond.Destruction_B.textBox_Stores_No.Text = Stores_No;
                        Destruction_Bond.Destruction_B.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Destruction_Bond = false;
                    }


                    if (SCR_Out_Bond == true)
                    {
                        Out_Bond.out_B.textBox_Stores_No.Text = Stores_No;
                        Out_Bond.out_B.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Out_Bond = false;
                    }


                    if (SCR_Entry_Bond == true)
                    {
                        Entity_Bond.entity_Bond.textBox_Stores_No.Text = Stores_No;
                        Entity_Bond.entity_Bond.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Entry_Bond = false;
                    }
                    if (SCR_Orders_Parchase == true)
                    {
                        Orders_parchase.Ord.textBox_Stores_No.Text = Stores_No;
                        Orders_parchase.Ord.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Orders_Parchase = false;
                    }
                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Stores_No.Text = Stores_No;
                        Invoice_Parchase.Inv_Parchase.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Invoice_Parchase = false;
                    }
                    if (SCR_Report_Trans_Stores == true)
                    {
                        FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.textBox_Store_No.Text = Stores_No;
                        FRM_Report_Trans_Stores.fRM_Report_Trans_Stores.textBox_Store_Name.Text = Stores_Name;
                        SCR_Report_Trans_Stores = false;
                    }
                    if(SCR_Add_Paid == true)
                    {
                        Add_Paid.add_Paid.textBox_Stores_No.Text = Stores_No;
                        Add_Paid.add_Paid.textBox_Stores_Name.Text = Stores_Name;
                        SCR_Add_Paid = false;
                    }
                    if(SCR_sett_Inventory==true)
                    {
                        sett_Inventory.sett_Inventory2.textBox_Stores_No.Text = Stores_No;
                        sett_Inventory.sett_Inventory2.textBox_Stores_Name.Text = Stores_Name;
                        SCR_sett_Inventory = false;
                    }
                    if(SCR_FRM_Report_Item_Now==true)
                    {
                        FRM_Report_Item_Now.fRM_Report_Item_Now.textBox_Store_No.Text = Stores_No;
                        FRM_Report_Item_Now.fRM_Report_Item_Now.textBox_Store_Name.Text = Stores_Name;
                        SCR_FRM_Report_Item_Now = false;
                    }
                    if(SCR_FRM_Account_Manf==true)
                    {
                        FRM_Account_Manf.fRM_Account_Manf.textBox_Store_No.Text = Stores_No;
                        FRM_Account_Manf.fRM_Account_Manf.textBox_Store_Name.Text = Stores_Name;
                        SCR_FRM_Account_Manf = false;
                    }
                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Stores", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
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
    public partial class Grid_Supplier : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public Virable
        public static Boolean SCR_Orders_Parchase;
        public static Boolean SCR_Invoice_Parchase;
        public static Boolean SCR_return_Parchase;
        public static Boolean SCR_Entry_Bond;
        string Supplier_no;
        string Supplier_Name;
        public Grid_Supplier()
        {
            InitializeComponent();
        }

        private void Grid_Supplier_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
                using (SqlCommand Cmd = con.CreateCommand())
                {
                    Cmd.CommandType = CommandType.StoredProcedure;
                    Cmd.CommandText = "SP_SELECT_DGV_Supplier_Grid";
                    SqlDataAdapter da = new SqlDataAdapter(Cmd);
                    da.Fill(dataTable);


                }
                dataGridView1.DataSource = dataTable;
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    Supplier_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                    Supplier_Name = dataGridView1.CurrentRow.Cells[1].Value.ToString();

                    if (SCR_Orders_Parchase == true)
                    {
                        Orders_parchase.Ord.textBox_Supplier_No.Text = Supplier_no;
                        Orders_parchase.Ord.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_Orders_Parchase = false;

                    }
                    if (SCR_Invoice_Parchase == true)
                    {
                        Invoice_Parchase.Inv_Parchase.textBox_Supplier_No.Text = Supplier_no;
                        Invoice_Parchase.Inv_Parchase.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_Invoice_Parchase = false;
                    }
                    if (SCR_return_Parchase == true)
                    {
                        return_parchase.return_Parchase.textBox_Supplier_No.Text = Supplier_no;
                        return_parchase.return_Parchase.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_return_Parchase = false;
                    }
                    if (SCR_Entry_Bond == true)
                    {
                        Entity_Bond.entity_Bond.textBox_Supplier_No.Text = Supplier_no;
                        Entity_Bond.entity_Bond.textBox_Supplier_Name.Text = Supplier_Name;
                        SCR_Entry_Bond = false;
                    }

                }
                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Supplier", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

     
    }
}

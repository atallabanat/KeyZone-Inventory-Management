using KeyZone_Inventory_Management.Bond_Inventory;
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
    public partial class Grid_Sett_inventory : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public static Boolean SCR_Sett_invff;
        public Grid_Sett_inventory()
        {
            InitializeComponent();
        }

        private void Grid_Sett_inventory_Load(object sender, EventArgs e)
        {
            try
            {
                var dataTable = new DataTable();
               
              
                    using (SqlCommand Cmd = con.CreateCommand())
                    {
                        Cmd.CommandType = CommandType.StoredProcedure;
                        Cmd.CommandText = "SP_Grid_Sett_inventory";
                        Cmd.Parameters.Add(new SqlParameter("@Myear", sett_Inventory.sett_Inventory2.textBox_Year.Text));
                        SqlDataAdapter da = new SqlDataAdapter(Cmd);
                        da.Fill(dataTable);


                    }
                    dataGridView1.DataSource = dataTable;
              
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 Grid_Sett_inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.Rows.Count > 0)
                {
                    string bond_no = dataGridView1.CurrentRow.Cells[0].Value.ToString();


                    if (SCR_Sett_invff == true)
                    {
                        sett_Inventory.sett_Inventory2.textBox_Bond_NO.Text = bond_no;
                        sett_Inventory.sett_Inventory2.Select_Screen();
                        SCR_Sett_invff = false;
                    }

                }

                this.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1002 Grid_Sett_inventory", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

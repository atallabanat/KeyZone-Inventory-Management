using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;

namespace KeyZone_Inventory_Management.UserControls
{
    public partial class KZ : UserControl
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        public KZ()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            textBox1.Width += 1;

            if(textBox1.Width >= 1594)
            {
                textBox1.Width = 1;
            }
        }

        private void KZ_Load(object sender, EventArgs e)
        {
            try
            {
                SqlCommand sqlCommand = new SqlCommand("select note from note where id=1", con);
                SqlDataReader dr;
                con.Open();
                dr = sqlCommand.ExecuteReader();

                if (dr.Read())
                {
                    textBox1.Text = dr["note"].ToString();
                }
                con.Close();
            }
            catch (Exception ee)
            {
                con.Close();
                MessageBox.Show("يرجى تصوير الخطأ ومراجعة مدير النظام ، شكرا" + ee.Message, "ERROR 1001 KZ", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}

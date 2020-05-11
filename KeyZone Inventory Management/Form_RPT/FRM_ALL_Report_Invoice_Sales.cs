using KeyZone_Inventory_Management.Reports;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyZone_Inventory_Management.Form_RPT
{
    public partial class FRM_ALL_Report_Invoice_Sales : Form
    {
        public static FRM_ALL_Report_Invoice_Sales fRM_ALL;
        public FRM_ALL_Report_Invoice_Sales()
        {
            fRM_ALL = this;
            InitializeComponent();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ALL_Report_Invoice_Sales aLL_Report = new ALL_Report_Invoice_Sales();
            aLL_Report.Show();
        }

        private void FRM_ALL_Report_Invoice_Sales_Load(object sender, EventArgs e)
        {

        }
    }
}

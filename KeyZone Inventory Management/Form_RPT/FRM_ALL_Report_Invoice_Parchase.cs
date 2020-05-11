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
    public partial class FRM_ALL_Report_Invoice_Parchase : Form
    {
        public static FRM_ALL_Report_Invoice_Parchase fRM_ALL_P;
        public FRM_ALL_Report_Invoice_Parchase()
        {
            fRM_ALL_P = this;
            InitializeComponent();
        }

        private void FRM_ALL_Report_Invoice_Parchase_Load(object sender, EventArgs e)
        {

        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            ALL_Report_Invoice_Parchase aLL_Report = new ALL_Report_Invoice_Parchase();
            aLL_Report.Show();
        }
    }
}

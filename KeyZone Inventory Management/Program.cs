using KeyZone_Inventory_Management.Admin;
using KeyZone_Inventory_Management.Bond_Inventory;
using KeyZone_Inventory_Management.Distributor;
using KeyZone_Inventory_Management.Grid;
using KeyZone_Inventory_Management.parchases;
using KeyZone_Inventory_Management.purchases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KeyZone_Inventory_Management
{
    static class Program
    {
        public static string user_ID;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new login ());
        }
    }
}

using KeyZone_Inventory_Management.Grid;
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

namespace KeyZone_Inventory_Management.Distributor
{


    public partial class INV_F : Form
    {
        static string constring = ConfigurationManager.ConnectionStrings["Con"].ConnectionString;
        SqlConnection con = new SqlConnection(constring);
        //public virable
        //ياض اوعك تلعبي فيهم او تغيري قيمهم بغيبككك
        public static string unn;
        public static INV_F iNV;
        public static int Row_Unit1;
        public static int Col_Unit1;
        public static int Row_Unit2;
        public static int Col_Unit2;
        public static int check_Tax=0;
        public static int check_EndDate=0;
        public static int flag_Unit;
        public static int flag_checkrow1 = 0;
        public static int flag_checkrow2 = 0;
        public static int rowcheck_Count;
        public static int rowcheck_Count2;
        //متغير تعادل عدد الاسطر مع شرط أصغر وحدة
        int ss = 0;
        int ss3 = 0;
        int Back = 0;
        int Back2 = 0;
        //-----------------------------------------
        public static int Flag_Btn_Save;
        string Item_Barcode;
        public INV_F()
        {
            iNV = this;
            this.KeyPreview = true;
            InitializeComponent();
            this.KeyPreview = true;
            
            //this.KeyPress += new KeyPressEventHandler(dataGridView1_KeyPress);
            //this.KeyPress += new KeyPressEventHandler(dataGridView2_KeyPress);
        }
        private void Do_Validating()
        {
            if(textBox_ID_Items.Text=="")
            {
                MessageBox.Show("يرجى عدم ترك ( رمز المادة ) فارغ", "معلومات المادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_ID_Items.Focus();          
                return;
            }
            if (textBox_Name_Items.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك ( اسم المادة ) فارغ", "معلومات المادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Name_Items.Focus();
                return;
            }
            if (textBox_Barcode_Items.Text == "")
            {
                MessageBox.Show("يرجى عدم ترك ( باركود المادة ) فارغ", "معلومات المادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Barcode_Items.Focus();
                return;
            }
            if(Checkbox_Tax.Checked==true)
            {
                if(textBox_NU_Tax.Text=="")
                {
                    MessageBox.Show("يرجى عدم ترك ( رقم الضريبة ) فارغ", "معلومات المادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_NU_Tax.Focus();
                    Flag_Btn_Save = 0;
                    return;
                }
                if (textBox_NA_Tax.Text == "")
                {
                    MessageBox.Show("يرجى عدم ترك ( اسم الضريبة ) فارغ", "معلومات المادة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    textBox_NA_Tax.Focus();
                    Flag_Btn_Save = 0;
                    return;
                }
            }
            for (int i1 = 0; i1 < dataGridView1.RowCount; i1++)
            {
                Flag_Btn_Save = 0;


                if (dataGridView1.Rows[i1].Cells[0].Value == "" || dataGridView1.Rows[i1].Cells[0].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( رقم الوحدة ) فارغ في السطر" + "  " + i1, "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i1].Cells[0];
                    dataGridView1.Focus();

                    return;

                }

                if (dataGridView1.Rows[i1].Cells[1].Value == "" || dataGridView1.Rows[i1].Cells[1].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( اسم الوحدة ) فارغ في السطر" + "  " + i1, "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i1].Cells[1];
                    dataGridView1.Focus();
                    return;

                }
                if (dataGridView1.Rows[i1].Cells[2].Value == "" || dataGridView1.Rows[i1].Cells[2].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( سعر الكلفة ) فارغ في السطر" + "  " + i1, "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i1].Cells[2];
                    dataGridView1.Focus();
                    return;

                }
                if (dataGridView1.Rows[i1].Cells[3].Value == "" || dataGridView1.Rows[i1].Cells[3].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( سعر البيع ) فارغ في السطر" + "  " + i1, "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i1].Cells[3];
                    dataGridView1.Focus();
                    return;

                }
                if (dataGridView1.Rows[i1].Cells[4].Value == "" || dataGridView1.Rows[i1].Cells[4].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( معامل التحويل ) فارغ في السطر" + "  " + i1, "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    dataGridView1.CurrentCell = dataGridView1.Rows[i1].Cells[4];
                    dataGridView1.Focus();
                    return;

                }




                ss = ss + 1;
                rowcheck_Count = ss;
                if (dataGridView1.Rows[i1].Cells[5].Value == "" || dataGridView1.Rows[i1].Cells[5].Value == null || dataGridView1.Rows[i1].Cells[5].Value == "0")
                {
                    if (flag_checkrow1 < 1)
                    {
                        flag_checkrow1 = 0;
                    }

                }
                else
                {
                    flag_checkrow1++;
                }


            }
            if (rowcheck_Count == dataGridView1.RowCount)
            {
                if (flag_checkrow1 == 1)
                {
                    ss = 0;
                    flag_checkrow1 = 0;
                    //return;
                    //Done
                }
                else if (flag_checkrow1 == 0)
                {
                    MessageBox.Show("يرجى اختيار مادة ضمن أصغر وحدة", "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    return;
                }
                else if (flag_checkrow1 > 1)
                {
                    MessageBox.Show("يوجد أكثر من مادة تحتوي على أصغر وحدة يرجى اختيار واحدة فقط", "الوحدات وفئات الأسعار الخاصة بلعميل", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss = 0;
                    flag_checkrow1 = 0;
                    return;

                }
            }

            //datagridview2 checkk


            for (int i2 = 0; i2 < dataGridView2.RowCount; i2++)
            {


                if (dataGridView2.Rows[i2].Cells[0].Value == "" || dataGridView2.Rows[i2].Cells[0].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( رقم الوحدة ) فارغ في السطر" + "  " + i2, "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss3 = 0;
                    flag_checkrow2 = 0;
                    dataGridView2.CurrentCell = dataGridView2.Rows[i2].Cells[0];
                    dataGridView2.Focus();

                    return;

                }

                if (dataGridView2.Rows[i2].Cells[1].Value == "" || dataGridView2.Rows[i2].Cells[1].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( اسم الوحدة ) فارغ في السطر" + "  " + i2, "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss3 = 0;
                    flag_checkrow2 = 0;
                    dataGridView2.CurrentCell = dataGridView2.Rows[i2].Cells[1];
                    dataGridView2.Focus();
                    return;

                }
                if (dataGridView2.Rows[i2].Cells[2].Value == "" || dataGridView2.Rows[i2].Cells[2].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( سعر الكلفة ) فارغ في السطر" + "  " + i2, "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss3 = 0;
                    flag_checkrow2 = 0;
                    dataGridView2.CurrentCell = dataGridView2.Rows[i2].Cells[2];
                    dataGridView2.Focus();
                    return;

                }
                if (dataGridView2.Rows[i2].Cells[3].Value == "" || dataGridView2.Rows[i2].Cells[3].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( سعر البيع ) فارغ في السطر" + "  " + i2, "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss3 = 0;
                    flag_checkrow2 = 0;
                    dataGridView2.CurrentCell = dataGridView2.Rows[i2].Cells[3];
                    dataGridView2.Focus();
                    return;

                }
                if (dataGridView2.Rows[i2].Cells[4].Value == "" || dataGridView2.Rows[i2].Cells[4].Value == null)
                {
                    MessageBox.Show("يرجى عدم ترك ( معامل التحويل ) فارغ في السطر" + "  " + i2, "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    ss3 = 0;
                    flag_checkrow2 = 0;
                    dataGridView2.CurrentCell = dataGridView2.Rows[i2].Cells[4];
                    dataGridView2.Focus();
                    return;

                }

                ss3 = ss3 + 1;
                rowcheck_Count2 = ss3;
                if (dataGridView2.Rows[i2].Cells[5].Value == "" || dataGridView2.Rows[i2].Cells[5].Value == null || dataGridView2.Rows[i2].Cells[5].Value == "0")
                {
                    if (flag_checkrow2 < 1)
                    {
                        flag_checkrow2 = 0;
                    }

                }
                else
                {
                    flag_checkrow2++;
                }



                if (rowcheck_Count2 == dataGridView2.RowCount)
                {
                    if (flag_checkrow2 == 1)
                    {
                        ss3 = 0;
                        flag_checkrow2 = 0;
                        Flag_Btn_Save = 1;
                        return;
                        //Done
                    }
                    else if (flag_checkrow2 == 0)
                    {
                        MessageBox.Show("يرجى اختيار مادة ضمن أصغر وحدة", "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ss3 = 0;
                        flag_checkrow2 = 0;
                        return;
                    }
                    else if (flag_checkrow2 > 1)
                    {
                        MessageBox.Show("يوجد أكثر من مادة تحتوي على أصغر وحدة يرجى اختيار واحدة فقط", "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        ss3 = 0;
                        flag_checkrow2 = 0;
                        return;

                    }
                }

            }


        }

        private void bunifuCheckbox1_OnChange(object sender, EventArgs e)
        {
            if (Checkbox_Tax.Checked == true)
            {
                check_Tax = 1;
                label_Tax.Visible = true;
                textBox_NU_Tax.Visible = true;
                textBox_NA_Tax.Visible = true;
                btn_View_Tax.Visible = true;
                textBox_NU_Tax.Text = "";
                textBox_NA_Tax.Text = "";
            }
            else
            {
                check_Tax = 0;
                label_Tax.Visible = false;
                textBox_NU_Tax.Visible = false;
                textBox_NA_Tax.Visible = false;
                btn_View_Tax.Visible = false;
                textBox_NU_Tax.Text = "";
                textBox_NA_Tax.Text = "";
            }
        }

        private void textBox_NU_Tax_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void tabControl1_Click(object sender, EventArgs e)
        {
            if (tabPage2.Focus() == true)
            {
                dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[0];
                dataGridView1.Focus();
            }

            if (tabPage3.Focus() == true)
            {
                dataGridView2.CurrentCell = dataGridView2.Rows[0].Cells[0];
                dataGridView2.Focus();
            }
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {


            if (e.KeyCode == Keys.Enter)
            {
                Col_Unit1 = dataGridView1.CurrentCell.ColumnIndex;
                Row_Unit1 = dataGridView1.CurrentCell.RowIndex;

                if (Col_Unit1 < dataGridView1.Columns.Count )
                {
                    if (dataGridView1.Rows[Row_Unit1].Cells[0].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[0].Value == null)
                    {
                        MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[0];
                        dataGridView1.Focus();
                    }
                    else
                    {
                        if (dataGridView1.Rows[Row_Unit1].Cells[0].Selected == true)
                        {
                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[2];
                            if(Back==1)
                            {
                                dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[0];
                                Back = 0;
                            }
                            dataGridView1.Focus();
                        }
                        else
                        {
                            if (dataGridView1.Rows[Row_Unit1].Cells[2].Selected == true)
                            {
                                if (dataGridView1.Rows[Row_Unit1].Cells[2].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[2].Value == null)
                                {
                                    MessageBox.Show("لا يمكن ترك سعر الكلفة فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[2];
                                    dataGridView1.Focus();
                                    return;
                                }
                                else
                                {
                                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[Col_Unit1 + 1];
                                }
                            }
                            else
                            {
                                if (dataGridView1.Rows[Row_Unit1].Cells[3].Selected == true)
                                {
                                    if (dataGridView1.Rows[Row_Unit1].Cells[3].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[3].Value == null)
                                    {
                                        MessageBox.Show("لا يمكن ترك سعر البيع فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[3];
                                        dataGridView1.Focus();
                                    }

                                    else
                                    {
                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[Col_Unit1 + 1];
                                    }
                                }
                                else
                                {
                                    if (dataGridView1.Rows[Row_Unit1].Cells[4].Selected == true)
                                    {
                                        if (dataGridView1.Rows[Row_Unit1].Cells[4].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[4].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك معامل التحويل فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[4];
                                            dataGridView1.Focus();
                                        } 
                                        else
                                        {
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[Col_Unit1 + 1];
                                        }
                                        
                                    }
                                    if (dataGridView1.Rows[Row_Unit1].Cells[6].Selected == true)
                                    {
                                        if (dataGridView1.Rows[Row_Unit1].Cells[0].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[0].Value == null)
                                        {
                                            MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[0];
                                            dataGridView1.Focus();
                                            return;
                                        }
                                        if (dataGridView1.Rows[Row_Unit1].Cells[2].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[2].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك سعر الكلفة فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[2];
                                            dataGridView1.Focus();
                                            return;
                                        }
                                        if (dataGridView1.Rows[Row_Unit1].Cells[3].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[3].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك سعر البيع فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[3];
                                            dataGridView1.Focus();
                                            return;
                                        }
                                        if (dataGridView1.Rows[Row_Unit1].Cells[4].Value == "" || dataGridView1.Rows[Row_Unit1].Cells[4].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك معامل التحويل فارغ", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[4];
                                            dataGridView1.Focus();
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[Col_Unit1 + 1];
                                    }

                                }
                            }
                        }
                    }
                }

                if (Col_Unit1 == dataGridView1.Columns.Count -1 )
                {

                    Col_Unit1 = 0;
                    dataGridView1.Rows.Add();
                    dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1 + 1].Cells[Col_Unit1];
                    dataGridView1.Focus();





                }


            }

            if (dataGridView1.CurrentRow.Cells[0].Selected == true)
            {
                if (e.KeyCode == Keys.F3)
                {
                    flag_Unit = 1;
                    Grid_Unit.SCR_INV_F = true;
                    Grid_Unit gg = new Grid_Unit();
                    gg.ShowDialog();
                    Grid_Unit.SCR_INV_F = false;
                }
                
            }


        }

        private void dataGridView2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Col_Unit2 = dataGridView2.CurrentCell.ColumnIndex;
                Row_Unit2 = dataGridView2.CurrentCell.RowIndex;


                if (Col_Unit2 < dataGridView2.Columns.Count)
                {
                    if (dataGridView2.Rows[Row_Unit2].Cells[0].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[0].Value == null)
                    {
                        MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[0];
                        dataGridView2.Focus();
                    }
                    else
                    {
                        if (dataGridView2.Rows[Row_Unit2].Cells[0].Selected == true)
                        {
                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[2];
                            if(Back2==1)
                            {
                                dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[0];
                            }

                            dataGridView2.Focus();
                        }
                        else
                        {
                            if (dataGridView2.Rows[Row_Unit2].Cells[2].Selected == true)
                            {
                                if (dataGridView2.Rows[Row_Unit2].Cells[2].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[2].Value == null)
                                {
                                    MessageBox.Show("لا يمكن ترك سعر الكلفة فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                    dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[2];
                                    dataGridView2.Focus();
                                    return;
                                }
                                else
                                {
                                    dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[Col_Unit2 + 1];
                                }
                            }
                            else
                            {
                                if (dataGridView2.Rows[Row_Unit2].Cells[3].Selected == true)
                                {
                                    if (dataGridView2.Rows[Row_Unit2].Cells[3].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[3].Value == null)
                                    {
                                        MessageBox.Show("لا يمكن ترك سعر البيع فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                        dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[3];
                                        dataGridView2.Focus();
                                    }

                                    else
                                    {
                                        dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[Col_Unit2 + 1];
                                    }
                                }
                                else
                                {
                                    if (dataGridView2.Rows[Row_Unit2].Cells[4].Selected == true)
                                    {
                                        if (dataGridView2.Rows[Row_Unit2].Cells[4].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[4].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك معامل التحويل فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[4];
                                            dataGridView2.Focus();
                                        }
                                        else
                                        {
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[Col_Unit2 + 1];
                                        }

                                    }
                                    if (dataGridView2.Rows[Row_Unit2].Cells[6].Selected == true)
                                    {
                                        if (dataGridView2.Rows[Row_Unit2].Cells[0].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[0].Value == null)
                                        {
                                            MessageBox.Show("لعرض الوحدات" + " F3 " + "لا يمكن ترك رقم الوحدة فارغ قم بضغط على", "عملية خاطئة", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[0];
                                            dataGridView2.Focus();
                                            return;
                                        }
                                        if (dataGridView2.Rows[Row_Unit2].Cells[2].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[2].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك سعر الكلفة فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[2];
                                            dataGridView2.Focus();
                                            return;
                                        }
                                        if (dataGridView2.Rows[Row_Unit2].Cells[3].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[3].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك سعر البيع فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[3];
                                            dataGridView2.Focus();
                                            return;
                                        }
                                        if (dataGridView2.Rows[Row_Unit2].Cells[4].Value == "" || dataGridView2.Rows[Row_Unit2].Cells[4].Value == null)
                                        {
                                            MessageBox.Show("لا يمكن ترك معامل التحويل فارغ", "الوحدات وفئات الأسعار الخاصة بلمندوب",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                                            dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[4];
                                            dataGridView2.Focus();
                                            return;
                                        }

                                    }
                                    else
                                    {
                                        dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2].Cells[Col_Unit2 + 1];
                                    }

                                }
                            }
                        }
                    }



                    if (Col_Unit2 == dataGridView2.Columns.Count - 1)
                    {

                        Col_Unit2 = 0;
                        dataGridView2.Rows.Add();
                        dataGridView2.CurrentCell = dataGridView2.Rows[Row_Unit2 + 1].Cells[Col_Unit2];
                        dataGridView2.Focus();





                    }
                }

            }

            if (dataGridView2.CurrentRow.Cells[0].Selected == true)
            {
                if (e.KeyCode == Keys.F3)
                {
                    flag_Unit = 2;
                    Grid_Unit.SCR_INV_F = true;
                    Grid_Unit gg = new Grid_Unit();
                    gg.ShowDialog();
                    Grid_Unit.SCR_INV_F = false;

                }
            }
        }

        private void INV_F_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd21 = new SqlCommand("select isnull((Max(Item_No)+1),1) as max from INV_F", con);
            SqlDataReader dr;
            dr = cmd21.ExecuteReader();
            if (dr.Read())
            {
                textBox_ID_Items.Text = dr["max"].ToString();
                textBox_Barcode_Items.Text= dr["max"].ToString();
            }
            con.Close();
            textBox_ID_Items.Focus();

            dataGridView1.Rows.Add();
            dataGridView2.Rows.Add();
        }

        private void INV_F_KeyDown(object sender, KeyEventArgs e)

        {

            //if (dataGridView1.Rows[Row_Unit1].Cells[2].Selected == true || dataGridView1.Rows[Row_Unit1].Cells[3].Selected == true || dataGridView1.Rows[Row_Unit1].Cells[4].Selected == true || dataGridView1.Rows[Row_Unit1].Cells[0].Selected == true)
            //{
            //    if (e.KeyValue != 13 && e.KeyValue < 48 || e.KeyValue > 57 && e.KeyValue != 114 && e.KeyValue != 190)
            //    {

            //        MessageBox.Show("خطأ إدخال ، لا يمكن إضافة حروف في هذه الخانة", "الوحدات وفئات الأسعار الخاصة بلعميل",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //        //dataGridView1.Rows[Row_Unit1].Cells[2].Value = "";
            //        //dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[0];
            //        tabPage1.Focus();
            //        return;

            //    }
            //}
            //else
            //{
            //    if (dataGridView2.Rows[Row_Unit2].Cells[2].Selected == true || dataGridView2.Rows[Row_Unit2].Cells[3].Selected == true || dataGridView2.Rows[Row_Unit2].Cells[4].Selected == true || dataGridView2.Rows[Row_Unit2].Cells[0].Selected == true)
            //    {
            //        if (e.KeyValue != 13 && e.KeyValue < 48 || e.KeyValue > 57 && e.KeyValue != 114 && e.KeyValue != 190)
            //        {

            //            MessageBox.Show("خطأ إدخال ، لا يمكن إضافة حروف في هذه الخانة", "الوحدات وفئات الأسعار الخاصة بلمندوب", MessageBoxButtons.OK,MessageBoxIcon.Warning);
            //            //dataGridView1.Rows[Row_Unit1].Cells[2].Value = "";
            //            //dataGridView1.CurrentCell = dataGridView1.Rows[Row_Unit1].Cells[0];
            //            tabPage2.Focus();
            //            return;
            //        }
            //    }
            //}

        }

        int ss2;
        private void dataGridView2_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {

            if (dataGridView2.CurrentRow.Cells[0].Selected == true)
            {
                int flagcountunit2 = 0;
                if (dataGridView2.Rows[Row_Unit2].Cells[0].Value == null)
                {
                    flagcountunit2 = 1;

                }
                else
                {
                    ss2 = Convert.ToInt32(dataGridView2.Rows[Row_Unit2].Cells[0].Value);
                    flagcountunit2 = 0;
                }

                if (flagcountunit2 == 0)
                {
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select Unit_No,Unit_Name from unit where Unit_No = @Unit_No", con);
                    na.Parameters.Add(new SqlParameter("@Unit_No", ss2));

                    SqlDataReader dr;
                    con.Open();
                    dr = na.ExecuteReader();
                    if (dr.Read())
                    {

                        dataGridView2.Rows[Row_Unit2].Cells[1].Value = dr["Unit_Name"].ToString();

                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد وحدة بهذا الرقم");
                        con.Close();
                        Back2 = 1;
                    }
                    
                }


            }
        }
        int ss1;
        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)

        {
            if (dataGridView1.CurrentRow.Cells[0].Selected == true)
            {
                int flagcountunit1 = 0;
                if (dataGridView1.Rows[Row_Unit1].Cells[0].Value == null)
                {
                    flagcountunit1 = 1;

                }
                else
                {
                    ss1 = Convert.ToInt32(dataGridView1.Rows[Row_Unit1].Cells[0].Value);
                    flagcountunit1 = 0;
                }

                if (flagcountunit1 == 0)
                {
                    SqlCommand na = new SqlCommand();
                    na = new SqlCommand("select Unit_No,Unit_Name from unit where Unit_No = @Unit_No", con);
                    na.Parameters.Add(new SqlParameter("@Unit_No", ss1));

                    SqlDataReader dr;
                    con.Open();
                    dr = na.ExecuteReader();
                    if (dr.Read())
                    {

                        dataGridView1.Rows[Row_Unit1].Cells[1].Value = dr["Unit_Name"].ToString();

                        con.Close();

                    }
                    else
                    {
                        MessageBox.Show("لا يوجد وحدة بهذا الرقم");
                        con.Close();
                        Back = 1;
                        

                        
                    }
                    
                }

            }
        }



        private void btn_add_Click(object sender, EventArgs e)
        {
            Do_Validating();

            con.Open();
            SqlCommand cmd21 = new SqlCommand("select Item_Barcode,Item_Name from INV_F where Item_Barcode=@Item_Barcode", con);
            cmd21.Parameters.Add(new SqlParameter("@Item_Barcode", textBox_Barcode_Items.Text));
            SqlDataReader dr;
            dr = cmd21.ExecuteReader();
            int count = 0;
            if (dr.Read())
            {
                count += 1;
                Item_Barcode = "(" + dr["Item_Name"].ToString() + ")";
            }
            con.Close();
            if (count == 1)
            {
                MessageBox.Show("باركود المادة موجود مسبقا لمادة :  " + Item_Barcode + "  لا يمكن إضافة باركود بنفس الرقم   ", "تكرار البيانات باركود المادة موجود مسبقا  !", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBox_Barcode_Items.Focus();
                return;
            }
            

            if (Flag_Btn_Save ==1)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.CommandText = "SP_ADD_INV_F";

                cmd.Parameters.AddWithValue("@Item_No", textBox_ID_Items.Text);
                cmd.Parameters.AddWithValue("@Item_Name", textBox_Name_Items.Text);
                cmd.Parameters.AddWithValue("@Item_Barcode", textBox_Barcode_Items.Text);
                cmd.Parameters.AddWithValue("@Des", textBox_Des_Items.Text);
                cmd.Parameters.AddWithValue("@Checkbox_Tax", check_Tax);
                if(textBox_NU_Tax.Text=="")
                {
                    cmd.Parameters.AddWithValue("@Tax_No", "0");
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Tax_No", textBox_NU_Tax.Text);
                }

                cmd.Parameters.AddWithValue("@Tax_Name", textBox_NA_Tax.Text);
                cmd.Parameters.AddWithValue("@Checkbox_DateEnd", check_EndDate);
                cmd.Parameters.AddWithValue("@Screen_Code", Class_Pro.ID_INV_F);
                cmd.Parameters.AddWithValue("@Doc_Type", Class_Pro.ID_INV_F);
                cmd.Parameters.AddWithValue("@ID_User", Program.user_ID);






                cmd.ExecuteNonQuery();
                con.Close();

                Do_Save_DataGridView1();

                Do_Save_DataGridView2();


                MessageBox.Show("تم حفظ العملية بنجاح","عملية صحيحة",MessageBoxButtons.OK,MessageBoxIcon.Information);
                ClearScreen();
            }
            else
            {
                MessageBox.Show("لم تتم عملية الحفظ ، البيانات غير مكتملة","البيانات غير مكتملة",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }
        private void Do_Save_DataGridView1()
        {
            for (int i1 = 0; i1 < dataGridView1.Rows.Count; i1++)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ADD_Items_Unit_Cust";

                cmd.Parameters.AddWithValue("@Item_No", textBox_ID_Items.Text);
                cmd.Parameters.AddWithValue("@Item_Barcode", textBox_Barcode_Items.Text);
                cmd.Parameters.AddWithValue("@Unit_No", dataGridView1.Rows[i1].Cells[0].Value);
                cmd.Parameters.AddWithValue("@Unit_Name", dataGridView1.Rows[i1].Cells[1].Value);
                cmd.Parameters.AddWithValue("@Price_Cost", dataGridView1.Rows[i1].Cells[2].Value);
                cmd.Parameters.AddWithValue("@Price_Sales", dataGridView1.Rows[i1].Cells[3].Value);
                cmd.Parameters.AddWithValue("@Unit_Rate", dataGridView1.Rows[i1].Cells[4].Value);
                cmd.Parameters.AddWithValue("@Unit_min", dataGridView1.Rows[i1].Cells[5].Value);
                cmd.Parameters.AddWithValue("@Unit_Barcode", dataGridView1.Rows[i1].Cells[6].Value);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void Do_Save_DataGridView2()
        {
            for (int i2 = 0; i2 < dataGridView2.Rows.Count; i2++)
            {
                con.Open();
                SqlCommand cmd = con.CreateCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "SP_ADD_Items_Unit_Man";

                cmd.Parameters.AddWithValue("@Item_No", textBox_ID_Items.Text);
                cmd.Parameters.AddWithValue("@Item_Barcode", textBox_Barcode_Items.Text);
                cmd.Parameters.AddWithValue("@Unit_No", dataGridView2.Rows[i2].Cells[0].Value);
                cmd.Parameters.AddWithValue("@Unit_Name", dataGridView2.Rows[i2].Cells[1].Value);
                cmd.Parameters.AddWithValue("@Price_Cost", dataGridView2.Rows[i2].Cells[2].Value);
                cmd.Parameters.AddWithValue("@Price_Sales", dataGridView2.Rows[i2].Cells[3].Value);
                cmd.Parameters.AddWithValue("@Unit_Rate", dataGridView2.Rows[i2].Cells[4].Value);
                cmd.Parameters.AddWithValue("@Unit_min", dataGridView2.Rows[i2].Cells[5].Value);
                cmd.Parameters.AddWithValue("@Unit_Barcode", dataGridView2.Rows[i2].Cells[6].Value);
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
        private void ClearScreen()
        {
            textBox_ID_Items.Text = "";
            textBox_Name_Items.Text = "";
            textBox_Barcode_Items.Text = "";

            textBox_Des_Items.Text = "";
            Checkbox_Tax.Checked = false;
            check_Tax = 0;
            textBox_NU_Tax.Text = "";
            textBox_NA_Tax.Text = "";
            Checkbox_DateEnd.Checked = false;
            check_EndDate = 0;
            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add();
            dataGridView2.Rows.Clear();
            dataGridView2.Rows.Add();



        }
        private void Checkbox_DateEnd_OnChange(object sender, EventArgs e)
        {
            if(Checkbox_DateEnd.Checked==true)
            {
                check_EndDate = 1;
            }
            else
            {
                check_EndDate = 0;
            }
        }

        private void btn_clear1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.Rows.Count > 1)
            {
                int index = dataGridView1.CurrentCell.RowIndex;
                dataGridView1.Rows.RemoveAt(index);
            }
        }

        private void btn_clear2_Click(object sender, EventArgs e)
        {
            if (dataGridView2.Rows.Count > 1)
            {
                int index = dataGridView2.CurrentCell.RowIndex;
                dataGridView2.Rows.RemoveAt(index);
            }
        }

        private void btn_unit_Click(object sender, EventArgs e)
        {
            Unit unitShow = new Unit();
            unitShow.ShowDialog();
        }

        private void btn_Item_Click(object sender, EventArgs e)
        {
            Grid_Item grid_Item = new Grid_Item();
            grid_Item.ShowDialog();
        }

        private void dataGridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void dataGridView2_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && !char.IsPunctuation(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void textBox_Name_Items_KeyPress(object sender, KeyPressEventArgs e)
        {

        }
    }

}

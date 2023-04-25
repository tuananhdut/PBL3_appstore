
using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GiaoDien
{
    public partial class FDoanhMuc : Form
    {
        private Authorization PhanQuyen;
        public FDoanhMuc(Authorization PhanQuyen)
        {
            InitializeComponent();
            this.PhanQuyen = PhanQuyen;
            setFormByAuthorization();
        }
        private void setFormByAuthorization()
        {
            switch (PhanQuyen)
            {
                case Authorization.Admin:

                    break;
                case Authorization.User:
                    tabControl1.TabPages.Remove(tabPage1);
                    tabControl1.TabPages.Remove(tabPage4);
                    break;
            }
        }


        private void KhoaThongTinDT()
        {
            cbbCategory_DT.Enabled = false;
            tbCatagory_DT.Enabled = false;
            cbbManufacturer_DT.Enabled = false;
            tbManufacturer_DT.Enabled = false;
            tbCostPrice_DT.Enabled = false;
            tbQuantity_DT.Enabled = false;
            tbSalePrice_DT.Enabled = false;
            tbDescription_DT.Enabled = false;
            tbProductName_DT.Enabled = false;
        }

        private void MoThongTinDT()
        {
            cbbCategory_DT.Enabled = true;
            cbbManufacturer_DT.Enabled = true;
            tbCostPrice_DT.Enabled = true;
            tbQuantity_DT.Enabled = true;
            tbSalePrice_DT.Enabled = true;
            tbDescription_DT.Enabled = true;
            tbProductName_DT.Enabled = true;
        }
        
        private void btEdit_DT_Click(object sender, EventArgs e)
        {
            MoThongTinDT();
        }


        private void setThongTinDT()
        {
            tbProductID_DT.Text = "";
            cbbCategory_DT.Text = "";
            tbCatagory_DT.Text = "";
            cbbManufacturer_DT.Text = "";
            tbManufacturer_DT.Text = "";
            tbCostPrice_DT.Text = "";
            tbQuantity_DT.Text = "";
            tbSalePrice_DT.Text = "";
            tbDescription_DT.Text = "";
            tbProductName_DT.Text = "";
        }
        private void btAdd_DT_Click(object sender, EventArgs e)
        {
            setThongTinDT();
            MoThongTinDT();
            tbProductID_DT.Enabled = true;
            tbProductName_DT.Enabled = true;
        }

        private void btExitDT_Click(object sender, EventArgs e)
        {
            setThongTinDT();
            MoThongTinDT();
        }


        private Form formshow;

        private void openPanelBody(Form f1)
        {
            if (formshow != null)
            {
                formshow.Close();
            }
            formshow = f1;
            f1.TopLevel = false;
            f1.FormBorderStyle = FormBorderStyle.None;
            f1.Dock = DockStyle.Fill;
            panel1.Controls.Add(f1);
            panel1.Tag = f1;
            f1.BringToFront();
            f1.Show();
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            Hang f1 = new Hang();
            openPanelBody(f1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FTheLoai f1 = new FTheLoai();
            openPanelBody(f1);
        }

        private void btAddKH_Click(object sender, EventArgs e)
        {

        }
    }
}


using BLL;
using DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Linq;
using System.Runtime.CompilerServices;
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
            loangDTGVCustomer();
            loangDTGVAccount();
            ViewDanhMucDT();
            SetCBB_DT();
          
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

        private void loangDTGVAccount()
        {
            dtgv_NV.Rows.Clear();
            AccountBLL accountBLL = new AccountBLL();
            foreach (var row in accountBLL.getALLAcount())
            {
                dtgv_NV.Rows.Add(row.AccountID,row.FullName,(Authorization)row.Position,row.PhoneNumber,row.Address);
            }
        }

        private void loangDTGVCustomer()
        {
            dtgv_KH.Rows.Clear();
            CustomerBLL customerBLL = new CustomerBLL();
            foreach (var customer in customerBLL.getALLCustomer())
            {
                dtgv_KH.Rows.Add(customer.CustomerID, customer.FullName, customer.PhoneNumber, customer.Address);
            }
        }
       
        // Danh mục điện thoại 
        private void setThongTinDT()
        {
            txtProductID_DT.Text = "";
            cbbCategory_DT.Text = "";
            txtCatagory_DT.Text = "";
            cbbManufacturer_DT.Text = "";
            txtManufacturer_DT.Text = "";
            txtCostPrice_DT.Text = "";
            txtQuantity_DT.Text = "";
            txtSalePrice_DT.Text = "";
            txtDescription_DT.Text = "";
            txtProductName_DT.Text = "";
        }
        private void btAdd_DT_Click(object sender, EventArgs e)
        {
            gb_TTDT.Enabled = true;
            btDel_DT.Enabled = false;
            btEdit_DT.Enabled = false;
            btAdd_DT.Enabled = true;   
        }

        private void btExitDT_Click(object sender, EventArgs e)
        {
            gb_TTDT.Enabled = false;
            btDel_DT.Enabled = true;
            btEdit_DT.Enabled = true;
            btAdd_DT.Enabled = true;
            setThongTinDT();
        }
        // Lưu thông tin điện thoại 
        private void btSave_DT_Click(object sender, EventArgs e)
        {
            if (txtProductID_DT.Text==""||txtProductName_DT.Text==""||txtCostPrice_DT.Text==""||txtSalePrice_DT.Text==""||txtQuantity_DT.Text ==""||txtDescription_DT.Text =="")
            {
                MessageBox.Show("Vui lòng nhập thông tin đầy đủ");
            }else
            {
                Product save = new Product()
                {
                    ProductID = Convert.ToInt32(txtProductID_DT.Text),
                    CategoryID = Convert.ToInt32(cbbCategory_DT.Text),
                    ManufacturerID = Convert.ToInt32(cbbManufacturer_DT.Text),
                    ProductName = Convert.ToString(txtProductName_DT.Text),
                    CostPrice = Convert.ToInt32(txtCostPrice_DT.Text),
                    SalePrice = Convert.ToInt32(txtSalePrice_DT.Text),
                    Quantity = Convert.ToInt32(txtQuantity_DT.Text),
                    Description = Convert.ToString (txtDescription_DT.Text),
                };
                ProductBLL bll = new ProductBLL();
                bll.AddOrUpdateBLL(save);
            }
            gb_TTDT.Enabled = false;
            btDel_DT.Enabled = true;
            btEdit_DT.Enabled = true;
            btAdd_DT.Enabled = true;
            setThongTinDT();
            ViewDanhMucDT();
           

        }
        private void btDel_DT_Click(object sender, EventArgs e)
        {
            if (dtgvProduct_DT.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dtgvProduct_DT.CurrentRow;
                int del = Convert.ToInt32(r.Cells[0].Value);
                ProductBLL bll = new ProductBLL();
                bll.DeleteBLL(del);
            }else
            {
                MessageBox.Show("Vui lòng chọn dòng xóa");
            }
            ViewDanhMucDT();
        }
        private void btEdit_DT_Click(object sender, EventArgs e)
        {
            gb_TTDT.Enabled = true;
            if (dtgvProduct_DT.SelectedRows.Count > 0)
            {
                DataGridViewRow r = dtgvProduct_DT.CurrentRow;
                int up = Convert.ToInt32(r.Cells[0].Value);
                Product edit = new Product();
                ProductBLL bll = new ProductBLL();
                edit = bll.GetProductBLL(up);
                txtProductID_DT.Text= Convert.ToString(edit.ProductID);
                txtProductName_DT.Text = Convert.ToString(edit.ProductName);
                cbbCategory_DT.Text = Convert.ToString(edit.CategoryID);
                cbbManufacturer_DT.Text = Convert.ToString(edit.ManufacturerID);
                txtCostPrice_DT.Text = Convert.ToString(edit.CostPrice);
                txtSalePrice_DT.Text = Convert.ToString(edit.SalePrice);
                txtQuantity_DT.Text = Convert.ToString(edit.Quantity);
                txtDescription_DT.Text= Convert.ToString(edit.Description);

            }
            else
            {
                MessageBox.Show("Vui lòng chọn dòng muốn cập nhật");
            }
        }

        private void SetCBB_DT()
        {
            CatagoryBLL cb1 = new CatagoryBLL();
            cbbCategory_DT.Items.AddRange(cb1.getAllCBBCatagory().ToArray());
            ManufactureBLL cb2 = new ManufactureBLL();
            cbbManufacturer_DT.Items.AddRange(cb2.getAllCBBManuFacture().ToArray());
        }
        private void ViewDanhMucDT()
        {
            ProductBLL bll = new ProductBLL();
            dtgvProduct_DT.DataSource = bll.GetProductsBLL();
        }
        private void cbbCategory_DT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(cbbCategory_DT.Text);
            CatagoryBLL bll = new CatagoryBLL();
            Category find =bll.getCategoryBLL(ID);
            txtCatagory_DT.Text = find.CategoryName;
        }
        private void cbbManufacturer_DT_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ID = Convert.ToInt32(cbbManufacturer_DT.Text);
            ManufactureBLL bll = new ManufactureBLL();
            Manufacturer find =  bll.getManufactureBLL(ID);
            txtManufacturer_DT.Text = find.ManufacturerName;
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

        private void showThongTinKhachHang()
        {
            tbSDT_KH.Enabled = true;
            tbCustomerName_KH.Enabled = true;
            tbAddress_KH.Enabled = true;
        }
        private void hideThongTinKhachHang()
        {
            tbSDT_KH.Enabled = false;
            tbCustomerName_KH.Enabled = false;
            tbAddress_KH.Enabled = false;
        }
        private void btAddKH_Click(object sender, EventArgs e)
        {
            // mở button lưu 
            btSave_Kh.Enabled = true;

            // mở các tb để nhập
            showThongTinKhachHang();

            // xóa các dữ liệu cũ 
            tbCustomerID_KH.Text = "";
            tbAddress_KH.Text = "";
            tbAddress_KH.Text = "";
            tbCustomerName_KH.Text = "";
            tbSDT_KH.Text = "";


            // khóa các hành động khác
            btEdit_Kh.Enabled = false;
            btDelete_KH.Enabled = false;
        }

        private void btSave_Kh_Click(object sender, EventArgs e)
        {
            //khóa các tb để nhập
            hideThongTinKhachHang();

            if (tbSDT_KH.Text ==""||tbAddress_KH.Text==""||tbCustomerName_KH.Text == "")
            {
                MessageBox.Show("vui lòng nhập đầy đủ thông tin");
            } else
            {
                Customer kh = new Customer()
                {
                    FullName = tbCustomerName_KH.Text,
                    Address = tbAddress_KH.Text,
                    PhoneNumber = tbSDT_KH.Text
                };
                if (tbCustomerID_KH.Text != "") kh.CustomerID = Convert.ToInt32(tbCustomerID_KH.Text);
                CustomerBLL bll = new CustomerBLL();
                bll.addAndUpdateCustomer(kh);
                MessageBox.Show("thêm thành công");
                tbCustomerID_KH.Text = kh.CustomerID.ToString();
            }

            //mở các hành động khác
            btEdit_Kh.Enabled = true;
            btDelete_KH.Enabled = true;
            btAddKH.Enabled = true;

            //cập nhật lại danh sách
            loangDTGVCustomer();

            // khóa hành động lưu 
            btSave_Kh.Enabled = false;
        }

        private void btEdit_Kh_Click(object sender, EventArgs e)
        {
            if (dtgv_KH.SelectedRows.Count == 1)
            {
                // mở button save 
                btSave_Kh.Enabled = true;

                // xử lý
                int id = Convert.ToInt32(dtgv_KH.SelectedRows[0].Cells[0].Value);
                CustomerBLL customerBLL = new CustomerBLL();
                Customer customer = customerBLL.getCustomerByID(id);
                tbCustomerName_KH.Text = customer.FullName;
                tbCustomerID_KH.Text = customer.CustomerID.ToString();
                tbAddress_KH.Text = customer.Address;
                tbSDT_KH.Text = customer.PhoneNumber;

            }
            else
            {
                MessageBox.Show("vui lòng chọn 1 ô trên bảng");
            }

            // mở khóa các text box
            showThongTinKhachHang();

            // khóa các sự kiện khác 
            btAddKH.Enabled = false;
            btDelete_KH.Enabled = false;
        }

        private void btExitKH_Click(object sender, EventArgs e)
        {
            btAddKH.Enabled = true;
            btDelete_KH.Enabled = true;
            btEdit_Kh.Enabled = true;

            // các text boxt trống
            tbCustomerID_KH.Text = "";
            tbAddress_KH.Text = "";
            tbAddress_KH.Text = "";
            tbCustomerName_KH.Text = "";
            tbSDT_KH.Text = "";
        }

        private void btDelete_KH_Click(object sender, EventArgs e)
        {
            if (dtgv_KH.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dtgv_KH.SelectedRows[0];
                CustomerBLL bll = new CustomerBLL();
                bll.removeCustomer(Convert.ToInt32(row.Cells[0].Value));
                loangDTGVCustomer();
            }
            else
            {
                MessageBox.Show("vui lòng chọn 1 ô trên bảng");
            }
        }

        private void setNullEmployeeInformation()
        {
            tbUsenameNV.Text = "";
            tbEmployeeID_NV.Text = "";
            tbFullname_NV.Text = "";
            tbAddress_NV.Text = "";
            tbPhoneNumber_NV.Text = "";
        }
        private void UnlockingEmployeeInformation()
        {
            tbUsenameNV.Enabled = true;
            tbPhoneNumber_NV.Enabled = true;
            tbFullname_NV.Enabled = true;
            tbAddress_NV.Enabled = true;
        }

        private void lockingEmployeeInformation()
        {
            tbUsenameNV.Enabled = false;
            tbPhoneNumber_NV.Enabled = false;
            tbFullname_NV.Enabled = false;
            tbAddress_NV.Enabled = false;
        }
        private void btAdd_NV_Click(object sender, EventArgs e)
        {
            // đưa thông tin khách hàng bằng null
            setNullEmployeeInformation();

            // mở khóa các tb thông tin khách hàng
            UnlockingEmployeeInformation();

            //khóa chức năng khác
            btEditNV.Enabled = false;
            btDeleteNV.Enabled = false;
            btShowNV.Enabled = false;

            // mở khóa bt save
            btSaveNV.Enabled = true;

           

        }

        private void btSaveNV_Click(object sender, EventArgs e)
        {
         
            // xử lý 
            if (tbAddress_NV.Text == "" || tbFullname_NV.Text == "" || tbAddress_NV.Text == "")
            {
                MessageBox.Show("vui lòng nhập đủ thông tin");
            } else
            {
                try
                { 
                    // khóa các tb thông tin nhân viên 
                    lockingEmployeeInformation();

                    //khóa bt save
                    btSaveNV.Enabled = false;

                    // mở khóa các chức năng khác
                    btEditNV.Enabled = true;
                    btDeleteNV.Enabled = true;
                    btShowNV.Enabled = true;
                    btAdd_NV.Enabled = true;

                    // xử lý 
                    Account account = new Account();
                    account.Address = tbAddress_NV.Text;
                    account.Password = "MFiOo6+2RArvarIP0FJHfO/KqDYOeGsKExzEwn4oSLKQHe5N";
                    account.FullName = tbFullname_NV.Text;
                    account.Username = tbUsenameNV.Text;
                    account.PhoneNumber = tbPhoneNumber_NV.Text;
                    if (tbEmployeeID_NV.Text != "")
                    {
                        account.AccountID = Convert.ToInt32(tbEmployeeID_NV.Text);
                    }
                 

                    AccountBLL accountBLL = new AccountBLL();
                    accountBLL.updateAndAddAccount(account);
                    tbEmployeeID_NV.Text = account.AccountID.ToString();
                    loangDTGVAccount();
                }
                catch (Exception)
                {
                    MessageBox.Show("xử lý không thành công");
                }
            }
        }

        private void btEditNV_Click(object sender, EventArgs e)
        {
            if (dtgv_NV.SelectedRows.Count == 1)
            {
                // mở khóa các tb thông tin khách hàng
                UnlockingEmployeeInformation();

                //khóa chức năng khác
                btDeleteNV.Enabled = false;
                btShowNV.Enabled = false;
                btAdd_NV.Enabled = false;

                // mở khóa bt save
                btSaveNV.Enabled = true;

                // xử lý   
                int id = Convert.ToInt32(dtgv_NV.SelectedRows[0].Cells[0].Value);
                AccountBLL accountBLL = new AccountBLL();
                Account acc = accountBLL.GetAccountByID(id);
                tbEmployeeID_NV.Text = acc.AccountID.ToString();
                tbFullname_NV.Text = acc.FullName.ToString();
                tbPhoneNumber_NV.Text =acc.PhoneNumber;
                tbAddress_NV.Text = acc.Address;
                tbUsenameNV.Text = acc.Username;

            }
            else
            {
                MessageBox.Show("vui lòng chọn 1 ô trên bảng");
            }
        }

        private void btExitNV_Click(object sender, EventArgs e)
        {
            //setNullEmployeeInformation
            setNullEmployeeInformation();

            //khóa Information
            lockingEmployeeInformation();

            //khóa bt save
            btSaveNV.Enabled = false;

            // mở khóa các chức năng khác
            btEditNV.Enabled = true;
            btDeleteNV.Enabled = true;
            btShowNV.Enabled = true;
            btAdd_NV.Enabled = true;
        }

        private void btDeleteNV_Click(object sender, EventArgs e)
        {
            if (dtgv_NV.SelectedRows.Count == 1)
            {
                DataGridViewRow row = dtgv_NV.SelectedRows[0];
                int id = Convert.ToInt32(row.Cells[0].Value.ToString());
                AccountBLL accountBll = new AccountBLL();
                accountBll.removeAccountByID(id);
                loangDTGVAccount();
            }
            else
            {
                MessageBox.Show("vui lòng chọn 1 ô trên bảng");
            }
        }

      

        private void tbPhoneNumber_NV_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("vui lòng nhập số");
            }
        }

        private void tbSDT_KH_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                MessageBox.Show("vui lòng nhập số");
            }
        }

        
    }
}

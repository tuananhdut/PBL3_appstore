﻿using BLL;
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
    public partial class FHoaDon : Form
    {
        private Account acc;
        public FHoaDon(Account acc)
        {
            InitializeComponent();
            this.acc = acc;
            setCBBProuctID();
            setCBBCustomerID();
        }
        
        private void setCBBCustomerID()
        {
            CustomerBLL bll = new CustomerBLL();
            cbbCustomerID.Items.AddRange(bll.getALLCustomer().ToArray());
        }
        private void btAddInvoice_Click(object sender, EventArgs e)
        {
            // xóa các dữ liệu trên form
            setNullThongTinChung();

            tbInvoiceDate.Text = DateTime.Now.ToString();
            tbEmployeeID.Text = acc.AccountID.ToString();
            tbEmployeeName.Text = acc.FullName;

            // khóa các textbox
            tbInvoiceDate.Enabled = false;
            tbEmployeeID.Enabled = false;
            tbEmployeeName.Enabled = false;

            // khóa các chức năng 
            btUpdateInvoice.Enabled = false;
            btPrintInvoice.Enabled = false;
            btChecking.Enabled = false;
        }

    

        private void cbbCustomerID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Customer ct = (Customer)(cbbCustomerID.SelectedItem);
            tbCustomerName.Text = ct.FullName;
            tbAddressCustomer.Text = ct.Address;
            tbPhoneNumber.Text = ct.PhoneNumber;
        }

        private void setCBBProuctID()
        {
            ProductBLL bll = new ProductBLL();
            cbbProductID.Items.AddRange(bll.getALLProduct().ToArray());
        }
        private void cbbProductID_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product p = (Product)(cbbProductID.SelectedItem);
            tbProductName.Text = p.ProductName;
            tbSalePrice.Text = p.SalePrice.ToString();
        }

        private void btExitInvoice_Click(object sender, EventArgs e)
        {
            // mở khóa các chức năng(button)
            btPrintInvoice.Enabled = true;
            btUpdateInvoice.Enabled = true;
            btAddInvoice.Enabled = true;
            btChecking.Enabled = true;

            //
        }
        private void setNullThongTinMatHang()
        {
            cbbProductID.Text = "";
            tbProductName.Text = "";
            tbQuantityProduct.Text = "";
            tbSale.Text = "";
            tbSalePrice.Text = "";
        }

        private void setNullThongTinChung()
        {
            tbInvoiceID.Text = "";
            tbInvoiceDate.Text = "";
            tbCustomerName.Text = "";
            tbEmployeeID.Text = "";
            tbEmployeeName.Text = "";
            tbAddressCustomer.Text = "";
            cbbCustomerID.Text = "";
            tbPhoneNumber.Text = "";
        }
        private void btSaveInvoice_Click(object sender, EventArgs e)
        {
            // tạo khách hàng mới hoặc sử dụng lại khách hàng cũ
            if (cbbCustomerID.Text == "")
            {
                if (tbAddressCustomer.Text == "" || tbCustomerName.Text == "" || tbPhoneNumber.Text == "")
                {
                    MessageBox.Show("hãy nhập đầy đủ thông tin");
                }
                else
                {
                    Customer kh = new Customer()
                    {

                        Address = tbAddressCustomer.Text,
                        FullName = tbCustomerName.Text,
                        PhoneNumber = tbPhoneNumber.Text
                    };
                    //add customer
                    CustomerBLL bll = new CustomerBLL();
                    bll.addCustomer(kh);
                    // gán customerId Cho cbb CustomerID
                    cbbCustomerID.Text = kh.CustomerID.ToString();
                }
            }
            // tạo hóa đơn mới 
            if (tbInvoiceID.Text == "")
            {
                Invoice HD = new Invoice()
                {
                    EmployeeID = Convert.ToInt32(tbEmployeeID.Text),
                    CustomerID = Convert.ToInt32(cbbCustomerID.Text),
                    InvoiceDate = DateTime.Now,
                    TotalAmount = 0
                };

                InvoiceBLL bLL = new InvoiceBLL();
                bLL.addInvoice(HD);
                tbInvoiceID.Text = HD.InvoiceID.ToString();
            }


            // tạo chi tiết hóa đơn mới 
            if (cbbProductID.Text==null||tbQuantityProduct.Text==""||tbSale.Text=="")
            {
                MessageBox.Show("hãy nhập đầy đủ thông tin");
            }
            else
            {
                InvoiceDetail CTHD = new InvoiceDetail()
                {
                    ProductID = Convert.ToInt32(cbbProductID.Text),
                    InvoiceID = Convert.ToInt32(tbInvoiceID.Text),
                    Quantity = Convert.ToInt16(tbQuantityProduct.Text),
                    SalePrice = Convert.ToInt32(tbSale.Text)
                };
                InvoiceDetailBLL bLL1 = new InvoiceDetailBLL();
                bLL1.AddInvoiceDetail(CTHD);
                MessageBox.Show("ok");
                // hiển thị lên datagridview
                dtgvInvoiceDetail.DataSource = bLL1.getListInvoiceDetailByInvoiceID(Convert.ToInt32(tbInvoiceID.Text));
            }
            // các textbox thông tin mặt hàng rỗng
            setNullThongTinMatHang();

           

            //mở khóa chức năng
            btPrintInvoice.Enabled = true;
            btUpdateInvoice.Enabled = true;
            btAddInvoice.Enabled = true;
            btChecking.Enabled = true;
        }

        private void btUpdateInvoice_Click(object sender, EventArgs e)
        {
            // khóa chức năng
            btAddInvoice.Enabled = false;
            btPrintInvoice.Enabled = false;
            btChecking.Enabled = false;
        }
    }
}
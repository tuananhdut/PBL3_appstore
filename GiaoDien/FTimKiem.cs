using BLL;
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
    public partial class FTimKiem : Form
    {
        private Authorization PhanQuyen;
        public FTimKiem(Authorization phanquyen)
        {
            InitializeComponent();
            this.PhanQuyen = phanquyen;
            setFormByAuthorization();
        }
        private void setFormByAuthorization()
        {
            switch (PhanQuyen)
            {
                case Authorization.Admin:

                    break;
                case Authorization.User:
                    tabControl1.TabPages.Remove(tabPage4);
                    break;
            }
        }

        private void btSearchCustomer_Click(object sender, EventArgs e)
        {
            CustomerBLL customerBLL = new CustomerBLL();
            dtgvCustomer.Rows.Clear();
            int? id = null;
            try
            {
                id = Convert.ToInt32(tbCustomerID.Text);
            }
            catch (Exception)
            {
            }
            string name = tbCustomerName.Text;
            string phone = tbCustomerPhoneNumber.Text;
            string address = tbCustomerAddress.Text;

            if (phone == "") phone = null;
            if (name == "") name = null;
            if (address == "") address = null;

            foreach (var customer in customerBLL.searchCustomer(id, name, address, phone))
            {
                dtgvCustomer.Rows.Add(customer.CustomerID, customer.FullName,customer.PhoneNumber,customer.Address);
            }
        }

        private void btResetCustomer_Click(object sender, EventArgs e)
        {
            tbCustomerID.Text = "";
            tbCustomerName.Text = "";
            tbCustomerAddress.Text = "";
            tbCustomerPhoneNumber.Text = "";
            dtgvCustomer.Rows.Clear();
        }
    }
}

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


    }
}

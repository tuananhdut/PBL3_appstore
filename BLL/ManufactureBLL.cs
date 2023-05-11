using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public  class ManufactureBLL
    {
        public List<Manufacturer> GetManufacturesBLL()

        {
            List<Manufacturer> list = new List<Manufacturer>();
            list = ManufactureDAL.Instance.GetAllManufacture();
            return list;
        }
        public CBBItem getCBBManufacture(Manufacturer a)
        {
            return new CBBItem()
            {
                ID = a.ManufacturerID,
                Text = a.ManufacturerName
            };
        }
        public List<CBBItem> getAllCBBManuFacture()
        {
            List<CBBItem> res = new List<CBBItem>();
            foreach (Manufacturer i in GetManufacturesBLL())
            {
                res.Add(getCBBManufacture(i));
            }
            return res;
        }
        public Manufacturer getManufactureBLL(int ID)
        {
            return ManufactureDAL.Instance.GetManufacture(ID);
        }
    }
}

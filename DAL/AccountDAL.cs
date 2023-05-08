using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AccountDAL
    {
        AppStore db;
        public static AccountDAL _intance;
        public static AccountDAL Intance
        {
            get
            {
                if (_intance == null)
                {
                    new AccountDAL();
                }
                return _intance;
            }
            private set { }
        }

        //contructer
        public AccountDAL()
        {
            db = new AppStore();
        }

        //return account by usename
        public Account getAccountByUsename(string usename)
        {
            return db.Accounts.Where(c => String.Compare(c.Username, usename, StringComparison.Ordinal)==0).FirstOrDefault();
        }

        public List<Account> getALLAccount()
        {
            return db.Accounts.ToList();
        }

        public void updateAndAddAccount(Account account)
        {
            db.Accounts.AddOrUpdate(account);
            db.SaveChanges();
        }
        public void removeAccountByID(int id)
        {
            Account account = db.Accounts.Find(id);
            if (account != null)
            {
                db.Accounts.Remove(account);
                db.SaveChanges();
            }

        }
    }
}

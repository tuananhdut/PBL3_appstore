using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountBLL
    {
        private AccountDAL dal;
        public static AccountBLL _intance;
        public static AccountBLL Intance
        {
            get
            {
                if (_intance == null) new AccountBLL();
                return _intance;
            }
            private set { }
        }
        public AccountBLL()
        {
            dal = new AccountDAL();
        }

        public string HashPassword(string password)
        {
            byte[] salt = new byte[16];
            new RNGCryptoServiceProvider().GetBytes(salt);

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            byte[] hashBytes = new byte[36];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, 16);
            Buffer.BlockCopy(hash, 0, hashBytes, 16, 20);
            return Convert.ToBase64String(hashBytes);
        }

        public bool VerifyPassword(string enteredPassword, string storedHash)
        {
            byte[] hashBytes = Convert.FromBase64String(storedHash);
            byte[] salt = new byte[16];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, 16);

            var pbkdf2 = new Rfc2898DeriveBytes(enteredPassword, salt, 10000);
            byte[] hash = pbkdf2.GetBytes(20);

            for (int i = 0; i < 20; i++)
            {
                if (hashBytes[i + 16] != hash[i])
                {
                    return false;
                }
            }

            return true;
        }
        public Account CheckAccount(string usename, string passwork)
        {
            Account acc= dal.getAccountByUsename(usename);
            if (acc != null && VerifyPassword(passwork,acc.Password) && acc.Username==usename) return acc;
            return null;
        }
        public List<Account> getALLAcount() => dal.getALLAccount();
        public void updateAndAddAccount(Account account) => dal.updateAndAddAccount(account);
        public void removeAccountByID(int id) => dal.removeAccountByID(id);
        public Account GetAccountByID(int id) => dal.GetAccountByID(id);
    }
}

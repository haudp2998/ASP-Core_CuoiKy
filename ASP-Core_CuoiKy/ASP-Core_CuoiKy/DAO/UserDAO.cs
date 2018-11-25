using ASP_Core_CuoiKy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_Core_CuoiKy.DAO
{
    public class UserDAO
    {
        private readonly OnlineShopContext db;


        public UserDAO(OnlineShopContext context)
        {
            db = context;
        }
     
        public long Insert(User user)
        {
            db.User.Add(user);
            db.SaveChanges();
            return user.Id;
        }
        public bool Login(string userName, string passWord)
        {
            var result = db.User.Count(p => p.UserName == userName && p.Password == passWord);
            if (result > 0)
            {
                return true;
            }
            else
            {
                return false;
            } 
        }
    }
}

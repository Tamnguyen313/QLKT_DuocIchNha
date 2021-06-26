using QLKT_DuocIchNhan.Areas.Admin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    public class UserAdmin
    {
        private Model db = new Model();
        public long Insert(Admin entity)
        {
            db.Admins.Add(entity);
            db.SaveChanges();
            return entity.id;
        }
        public Admin getById(string userName)
        {
            return db.Admins.SingleOrDefault(x => x.username == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Admins.SingleOrDefault(x => x.username == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.password == passWord)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool CheckUserName(string userName)
        {
            return db.Admins.Count(x => x.username == userName) > 0;
        }
    }
}
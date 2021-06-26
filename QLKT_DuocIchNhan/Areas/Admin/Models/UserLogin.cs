using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    [Serializable]
    public class UserLogin
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
    }
}
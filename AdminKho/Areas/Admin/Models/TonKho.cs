using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminKho.Areas.Admin.Models
{
    public class TonKho
    {
        public string Mathuoc { get; set; }
        public int? Soluongnhap { get; set; }
        public int? Soluong { get; set; }
        public int? Ton_kho { get; set; }
        public string Het_han { get; set; }
        public int? Sl_het_han { get; set; }
    }
}
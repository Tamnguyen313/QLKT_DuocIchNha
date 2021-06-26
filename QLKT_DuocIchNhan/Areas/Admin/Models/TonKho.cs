using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    public class TonKho
    {
        public string Maphieuxuat { get; set; }
        public string Mathuoc { get; set; }
        public int? Soluongnhap { get; set; }
        public int? Soluongxuat { get; set; }
        public int? Ton_kho { get; set; }
        public string Canh_bao { get; set; }
        public string Het_han { get; set; }
        public int? So_ngay_hh { get; set; }
        public int? Sl_het_han { get; set; }
    }
}
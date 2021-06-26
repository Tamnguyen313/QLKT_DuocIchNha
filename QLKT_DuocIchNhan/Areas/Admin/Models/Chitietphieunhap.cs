namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Chitietphieunhap")]
    public partial class Chitietphieunhap
    {
        [Key, Column(Order = 0)]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã phiếu nhập!")]
        public string Maphieunhap { get; set; }

        [Key, Column(Order = 1)]
        [StringLength(50)]
        [Required(ErrorMessage = "Vui lòng nhập mã thuốc!")]
        public string Mathuoc { get; set; }

        [StringLength(100)]
        public string Tenthuoc { get; set; }

        [StringLength(100)]
        public string Tennhacungcap { get; set; }

        [StringLength(50)]
        public string Malothuoc { get; set; }

        public int? Soluongnhap { get; set; }

        [StringLength(50)]
        public string Donvitinh { get; set; } 

        public int? Dongia { get; set; }

        public int? Thue { get; set; }

        public int? Thanhtien { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

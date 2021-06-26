namespace AdminKho.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Thuoc")]
    public partial class Thuoc
    {
        [Key]
        [StringLength(50)]
        public string Mathuoc { get; set; }

        [StringLength(50)]
        public string Tenthuoc { get; set; }

        [StringLength(50)]
        public string Manhacungcap { get; set; }

        [StringLength(50)]
        public string Manhomthuoc { get; set; }

        [StringLength(10)]
        public string Nhacungcap { get; set; }

        [StringLength(50)]
        public string Malothuoc { get; set; }

        [StringLength(50)]
        public string Donvitinh { get; set; }

        public int? Soluongtoithieu { get; set; }

        public int? Soluongtoida { get; set; }

        public int? Giatien { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }
    }
}

namespace AdminKho.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieuxuat")]
    public partial class Phieuxuat
    {
        [Key]
        [StringLength(50)]
        public string Maphieuxuat { get; set; }

        [StringLength(50)]
        public string Mathuoc { get; set; }

        [StringLength(50)]
        public string Malothuoc { get; set; }

        public int? Soluong { get; set; }

        [StringLength(50)]
        public string Donvitinh { get; set; }

        public int? Dongia { get; set; }

        public int? Thanhtien { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayxuat { get; set; }

        [StringLength(50)]
        public string Ghichu { get; set; }
    }
}

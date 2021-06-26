namespace AdminKho.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Lothuoc")]
    public partial class Lothuoc
    {
        [Key]
        [StringLength(50)]
        public string Malothuoc { get; set; }

        [StringLength(50)]
        public string Mathuoc { get; set; }

        [StringLength(50)]
        public string Tenlothuoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaynhap { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayxuat { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayhethan { get; set; }
    }
}

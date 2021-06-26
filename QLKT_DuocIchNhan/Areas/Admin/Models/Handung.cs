namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Handung")]
    public partial class Handung
    {
        [Key]
        [StringLength(50)]
        public string Mathuoc { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaysanxuat { get; set; }

        public DateTime Ngayhethan { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

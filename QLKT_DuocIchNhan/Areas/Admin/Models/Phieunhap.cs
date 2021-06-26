namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Phieunhap")]
    public partial class Phieunhap
    {
        [Key]
        [StringLength(50)]
        public string Maphieunhap { get; set; }

        [StringLength(50)]
        public string Manhacungcap { get; set; }

        [StringLength(100)]
        public string Nguoilapphieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngaylapphieu { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

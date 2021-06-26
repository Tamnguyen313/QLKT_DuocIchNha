namespace QLKT_DuocIchNhan.Areas.Admin.Models
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
        public string Madonvinhan { get; set; }

        [StringLength(100)]
        public string Nguoilapphieu { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Ngayxuatphieu { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

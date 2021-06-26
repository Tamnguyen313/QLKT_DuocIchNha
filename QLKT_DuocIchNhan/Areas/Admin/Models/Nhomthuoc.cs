namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhomthuoc")]
    public partial class Nhomthuoc
    {
        [Key]
        [StringLength(50)]
        public string Manhomthuoc { get; set; }

        [StringLength(100)]
        public string Tennhomthuoc { get; set; }

        [StringLength(50)]
        public string Malothuoc { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

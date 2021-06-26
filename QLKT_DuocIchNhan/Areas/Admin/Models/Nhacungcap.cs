namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Nhacungcap")]
    public partial class Nhacungcap
    {
        [Key]
        [StringLength(50)]
        public string Manhacungcap { get; set; }

        [StringLength(100)]
        public string Tennhacungcap { get; set; }

        [StringLength(150)]
        public string Diachi { get; set; }

        [StringLength(11)]
        public string Sodienthoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

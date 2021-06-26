namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Donvinhan")]
    public partial class Donvinhan
    {
        [Key]
        [StringLength(50)]
        public string Madonvinhan { get; set; }

        [StringLength(50)]
        public string Tendonvinhan { get; set; }

        [StringLength(11)]
        public string Sodienthoai { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(150)]
        public string Ghichu { get; set; }
    }
}

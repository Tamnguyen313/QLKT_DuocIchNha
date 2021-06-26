using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace QLKT_DuocIchNhan.Areas.Admin.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Chitietphieunhap> Chitietphieunhaps { get; set; }
        public virtual DbSet<Chitietphieuxuat> Chitietphieuxuats { get; set; }
        public virtual DbSet<Donvinhan> Donvinhans { get; set; }
        public virtual DbSet<Handung> Handungs { get; set; }
        public virtual DbSet<Lothuoc> Lothuocs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhomthuoc> Nhomthuocs { get; set; }
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
           
        }
    }
}

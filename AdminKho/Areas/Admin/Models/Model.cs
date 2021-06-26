using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace AdminKho.Areas.Admin.Models
{
    public partial class Model : DbContext
    {
        public Model()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Lothuoc> Lothuocs { get; set; }
        public virtual DbSet<Nhacungcap> Nhacungcaps { get; set; }
        public virtual DbSet<Nhomthuoc> Nhomthuocs { get; set; }
        public virtual DbSet<Phieunhap> Phieunhaps { get; set; }
        public virtual DbSet<Phieuxuat> Phieuxuats { get; set; }
        public virtual DbSet<Thuoc> Thuocs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Thuoc>()
                .Property(e => e.Nhacungcap)
                .IsFixedLength();
        }
    }
}

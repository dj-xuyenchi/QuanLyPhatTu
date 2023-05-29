using CMS_Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS_Infrastructure.AppContext
{
    public class AppDbContext : DbContext
    {
        public DbSet<PhatTu> PhatTu { get; set; }
        public DbSet<DaoTrang> DaoTrang { get; set; }
        public DbSet<DonDangKy> DonDangKy { get; set; }
        public DbSet<KieuThanhVien> KieuThanhVien { get; set; }
        public DbSet <PhatTuDaoTrang> PhatTuDaoTrang { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LOTUS-PC\\SQLEXPRESS;Integrated Security=true;Initial Catalog=QuanLyPhatTu;MultipleActiveResultSets=True;");
        }
    }
}

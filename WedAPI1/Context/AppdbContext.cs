using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;
using WedAPI1.Entities;

namespace WedAPI1.Context
{
    public class AppdbContext:DbContext
    {
        public DbSet<KhachHang> KhachHang { get;set; }
        public DbSet<HoaDon> HoaDons { get;set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get;set; }
        public DbSet<SanPham> SanPhams { get;set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get;set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source = localhost;Initial Catalog = DBQuanLyBanHang;User ID = sa; Password = 1231234;encrypt=true;trustservercertificate=true");
        }
    }
}

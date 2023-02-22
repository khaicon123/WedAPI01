using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;

namespace WedAPI1.Entities
{
    public class ChiTietHoaDon
    {
        [Key]
        public int? IdChiTietHoaDon { get; set; }
        public HoaDon? hoaDon { get; set; }
        public int HoaDonId { get; set; }
       // public SanPham SanPham { get; set; }
        public int SanPhamId { get; set; }
        public int SoLuong { get; set; }
        public string DVT { get; set; }
        public double? ThanhTien { get; set; }
    }
}

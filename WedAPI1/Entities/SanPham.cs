namespace WedAPI1.Entities
{
    public class SanPham
    {
        public int SanPhamId { get; set; }
        public LoaiSanPham LoaiSanPham { get;set; }
        public int LoaiSanPhamId { get;private set; }
        public string TenSanPham { get; set; }
        public double GiaThanh { get; set; }
        public string MoTa { get; set; }
        public DateTime? NgayHetHan { get; set; }
        public string KiHieuSanPham { get; set; }

    }
}

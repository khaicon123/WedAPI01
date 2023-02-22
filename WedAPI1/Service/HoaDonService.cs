using WedAPI1.Context;
using WedAPI1.Entities;
using WedAPI1.Interface;

namespace WedAPI1.Service
{
    public class HoaDonService : IHoaDonService
    {
        private readonly AppdbContext _AppDbContext=new AppdbContext();

        public string TaoMaGiaoDich()
        {
            string res = DateTime.Now.ToString("yyyyMMdd") + "_";
            var SoGDHomNay=_AppDbContext.HoaDons.Count(x=>x.ThoiGianTao.Date==DateTime.Now.Date);
            if (SoGDHomNay > 0)
            {
                int tmp = SoGDHomNay + 1;
                if (tmp < 10) res = res + "00" + tmp;
                if (tmp < 100) res = res + "0" + tmp;

            }
            else res = res + "001";
            return res;
        }
        public HoaDon ThemHoaDon(HoaDon hoaDon)
        {
            using (var trans = _AppDbContext.Database.BeginTransaction()) 
            {
                hoaDon.ThoiGianTao = DateTime.Now;
                hoaDon.MaGiaoDich = TaoMaGiaoDich();
                hoaDon.ThoiGianCapNhat = DateTime.Now;
                hoaDon.TongTien = 0;
                var lstChiTietHoaDon = hoaDon.ChiTietHoaDons;
                //hoaDon.ChiTietHoaDons = null;
                _AppDbContext.Add(hoaDon);
                _AppDbContext.SaveChanges();
                foreach(var chitiet in lstChiTietHoaDon)
                {
                    if (_AppDbContext.SanPhams.Any(x => x.SanPhamId == chitiet.SanPhamId))
                    {
                        chitiet.HoaDonId = hoaDon.HoaDonId;
                        chitiet.IdChiTietHoaDon = null;
                        var sanpham = _AppDbContext.SanPhams.FirstOrDefault(x => x.SanPhamId == chitiet.SanPhamId);
                        chitiet.ThanhTien = sanpham.GiaThanh * chitiet.SoLuong;
                        _AppDbContext.Add(chitiet);
                        _AppDbContext.SaveChanges();
                    }
                    else throw new Exception($"San Pham Khong Ton Tai .Vui Long Kiem Tra Lai San Pham Co Id La {chitiet.SanPhamId}");

                }
                hoaDon.TongTien = lstChiTietHoaDon.Sum(x => x.ThanhTien);
                _AppDbContext.SaveChanges();
                trans.Commit();
                return hoaDon;
            }
        }
        public HoaDon SuaHoaDon(HoaDon hoaDon)
        {
            using(var trans = _AppDbContext.Database.BeginTransaction())
            {
                HoaDon HoaDonSua = _AppDbContext.HoaDons.Where(x => x.HoaDonId == hoaDon.HoaDonId).FirstOrDefault();
                HoaDonSua.ThoiGianCapNhat=DateTime.Now;
                HoaDonSua.TenHoaDon=hoaDon.TenHoaDon;
                HoaDonSua.GhiChu=hoaDon.GhiChu;
                _AppDbContext.Update(HoaDonSua);
                _AppDbContext.SaveChanges();
                trans.Commit();
                return HoaDonSua;
            }
        }
        public IQueryable<HoaDon> TimKiem(int? year = null, string name = null, int? TongTien = null)
        {
            var query = _AppDbContext.HoaDons.OrderBy(x => x.ThoiGianTao).AsQueryable();
            if (year != null) query=query.Where(x=>x.ThoiGianTao.Year== year);
            if(name!=null) query=query.Where(x=>x.TenHoaDon.ToLower().Contains(name.ToLower()));
            if(TongTien!=null) query=query.Where(x=>x.TongTien==TongTien);
            return query;
        }
    }
}

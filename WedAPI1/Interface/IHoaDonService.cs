using WedAPI1.Entities;

namespace WedAPI1.Interface
{
    public interface IHoaDonService
    {
        public HoaDon ThemHoaDon(HoaDon hoaDon);
        public HoaDon SuaHoaDon(HoaDon hoaDon);
        public string TaoMaGiaoDich();
        public IQueryable<HoaDon> TimKiem(int? year=null,string name=null,int? TongTien=null);
    }
}

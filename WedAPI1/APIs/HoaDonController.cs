using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WedAPI1.Entities;
using WedAPI1.Interface;
using WedAPI1.Service;

namespace WedAPI1.APIs
{
    [Route("api/[controller]")]
    [ApiController]
    public class HoaDonController : ControllerBase
    {
        private readonly IHoaDonService _hoaDonService=new HoaDonService();
        [HttpPost]
        public IActionResult ThemHoaDon(HoaDon hoaDon)
        {
            var res = _hoaDonService.ThemHoaDon(hoaDon);
            return Ok(res);
        }
        [HttpPut("/SuaHoaDon")]
        public IActionResult SuaHoaDon(HoaDon hoaDon)
        {
            var res=_hoaDonService.SuaHoaDon(hoaDon);
            return Ok(res);
        }
        [HttpGet]
        public IActionResult TimKiem(int? year = null, string name = null, int? TongTien = null)
        {
            var res = _hoaDonService.TimKiem(year, name, TongTien);
            return Ok(res);
        }
    }
}

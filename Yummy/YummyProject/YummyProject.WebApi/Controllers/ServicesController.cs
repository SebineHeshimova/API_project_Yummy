using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly YummyDBContext _context;
        public ServicesController(YummyDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateService(Service service)
        {
            _context.Services.Add(service);
            _context.SaveChanges();
            return Ok("Kategory elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
            return Ok("service ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("service ugurla silindi");
        }
        [HttpGet]
        public IActionResult ServiceList()
        {
            var values = _context.Services.ToList();
            return Ok(values);
        }
        [HttpGet("GetService")]
        public IActionResult GetService(int id)
        {
            var value = _context.Services.Find(id);
            return Ok(value);
        }

    }
}

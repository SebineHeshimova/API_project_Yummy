using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ServiceDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicesController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public ServicesController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateService(CreateServiceDTO ServiceDTO)
        {
            var value = _mapper.Map<Service>(ServiceDTO);
            _context.Services.Add(value);
            _context.SaveChanges();
            return Ok("Service elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateService(UpdateServiceDto ServiceDTO)
        {
            var value = _mapper.Map<Service>(ServiceDTO);
            _context.Services.Update(value);
            _context.SaveChanges();
            return Ok("Service ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteService(int id)
        {
            var value = _context.Services.Find(id);
            _context.Services.Remove(value);
            _context.SaveChanges();
            return Ok("Service ugurla silindi");
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

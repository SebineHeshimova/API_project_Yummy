using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.AboutDTOs;
using YummyProject.WebApi.DTOs.AboutDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public AboutsController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDTO AboutDTO)
        {
            var value = _mapper.Map<About>(AboutDTO);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("About elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDTO AboutDTO)
        {
            var value = _mapper.Map<About>(AboutDTO);
            _context.Abouts.Update(value);
            _context.SaveChanges();
            return Ok("About ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("About ugurla silindi");
        }
        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }
        [HttpGet("GetAbout")]
        public IActionResult GetAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            return Ok(value);
        }

    }
}

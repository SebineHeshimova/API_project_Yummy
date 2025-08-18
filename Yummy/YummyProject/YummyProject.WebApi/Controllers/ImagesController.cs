using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ImageDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public ImagesController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateImage(CreateImageDTO imageDTO)
        {
            var value = _mapper.Map<Image>(imageDTO);
            _context.Images.Add(value);
            _context.SaveChanges();
            return Ok("Image elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateImage(UpdateImageDTO imageDTO)
        {
            var value = _mapper.Map<Image>(imageDTO);
            _context.Images.Update(value);
            _context.SaveChanges();
            return Ok("Image ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteImage(int id)
        {
            var value = _context.Images.Find(id);
            _context.Images.Remove(value);
            _context.SaveChanges();
            return Ok("Image ugurla silindi");
        }
        [HttpGet]
        public IActionResult ImageList()
        {
            var values = _context.Images.ToList();
            return Ok(values);
        }
        [HttpGet("GetImage")]
        public IActionResult GetImage(int id)
        {
            var value = _context.Images.Find(id);
            return Ok(value);
        }

    }
}

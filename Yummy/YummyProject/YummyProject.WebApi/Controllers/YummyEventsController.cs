using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.YummyEventDTOs;
using YummyProject.WebApi.DTOs.YummyEventDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public YummyEventsController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateYummyEvent(CreateYummyEventDTO yummyEventDTO)
        {
            var value = _mapper.Map<YummyEvent>(yummyEventDTO);
            _context.YummyEvents.Add(value);
            _context.SaveChanges();
            return Ok("YummyEvent elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateYummyEvent(UpdateYummyEventDTO yummyEventDTO)
        {
            var value = _mapper.Map<YummyEvent>(yummyEventDTO);
            _context.YummyEvents.Update(value);
            _context.SaveChanges();
            return Ok("YummyEvent ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok("YummyEvent ugurla silindi");
        }
        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }
        [HttpGet("GetYummyEvent")]
        public IActionResult GetYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            return Ok(value);
        }
    }
}

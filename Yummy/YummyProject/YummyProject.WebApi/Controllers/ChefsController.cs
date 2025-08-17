using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ChefDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly YummyDBContext _context ;
        private readonly IMapper _mapper ;
        public ChefsController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult CreateChef(CreateChefDTO chefDTO) 
        {
            var value=_mapper.Map<Chef>(chefDTO);
            _context.Chefs.Add(value);
            _context.SaveChanges();
            return Ok("Shef ugurla elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateChef(UpdateChefDTO chefDTO) 
        {
            var value = _mapper.Map<Chef>(chefDTO);
            _context.Chefs.Update(value);
            _context.SaveChanges();
            return Ok("Shef ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value =_context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Shef ugurla silindi");
        }
        [HttpGet]
        public IActionResult ChefList()
        {
            var value = _context.Chefs.ToList();
            return Ok(value);
        }
        [HttpGet("GetChef")]
        public IActionResult GetChef(int id) 
        {
            var value=_context.Chefs.Find(id);
            return Ok(value);
        }


    }
}

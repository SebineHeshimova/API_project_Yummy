using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly YummyDBContext _context ;
        public ChefsController(YummyDBContext context)
        {
            _context = context;
        }
       
        [HttpPost]
        public IActionResult CreateChef(Chef chef) 
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Shef ugurla elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateChef(Chef chef) 
        {
            _context.Chefs.Update(chef);
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

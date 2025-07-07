using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly YummyDBContext _context;
        public CategoriesController(YummyDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategory elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Category ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value=_context.Categories.Find(id);
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Category ugurla silindi");
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }
        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var value= _context.Categories.Find(id);
            return Ok(value);
        }
        
    }
}

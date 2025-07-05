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
    }
}

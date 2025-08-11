using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.CategoryDTOs;
using YummyProject.WebApi.DTOs.FeatureDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateCategory(CreateCagetoryDTO cagetoryDTO)
        {
            var value = _mapper.Map<Category>(cagetoryDTO);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Category elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateCategory(UpdateCategoryDTO categoryDTO)
        {
            var value=_mapper.Map<Category>(categoryDTO);
            _context.Categories.Update(value);
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

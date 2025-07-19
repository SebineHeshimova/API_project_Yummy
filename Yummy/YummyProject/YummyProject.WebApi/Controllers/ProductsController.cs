using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ProductDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IValidator<Product> _validator;
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public ProductsController(IValidator<Product> validator, YummyDBContext context, IMapper mapper)
        {
            _validator = validator;
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            var validationResult= _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return Ok("Mehsul ugurla elave edildi!");
            }
        }
        [HttpPost("CreateProductWithCategory")]
        public IActionResult CreateProductWithCategory(CreateProductDTO createProductDTO)
        {
            var value = _mapper.Map<Product>(createProductDTO);
            _context.Products.Add(value);
            _context.SaveChanges();
            return Ok("Mehsul ugurla elave edildi!");

        }
        [HttpGet("ProductListWithCategory")]
        public IActionResult ProductListWithCategory()
        {
            var value=_context.Products.Include(x=>x.Categories).ToList();
            return Ok(_mapper.Map<List<GetProductWithCategoryDTO>>(value));
        }
        [HttpGet]
        public IActionResult ProductList()
        {
            var value = _context.Products.ToList();
            return Ok(value);
        }
        [HttpDelete]
        public IActionResult DeleteProduct(int id)
        {
            var value=_context.Products.Find(id);
            _context.Products.Remove(value);
            _context.SaveChanges();
            return Ok("Mehsul ugurla silindi!");
        }
        [HttpGet("GetProduct")]
        public IActionResult GetProduct(int id)
        {
            var value=_context.Products.Find(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateProduct(Product product)
        {
            var validationResult = _validator.Validate(product);
            if (!validationResult.IsValid)
            {
                return BadRequest(validationResult.Errors.Select(x => x.ErrorMessage));
            }
            else
            {
                _context.Products.Update(product);
                _context.SaveChanges();
                return Ok("Mehsul ugurla deyishdirildi!");
            }
        }
    }
}

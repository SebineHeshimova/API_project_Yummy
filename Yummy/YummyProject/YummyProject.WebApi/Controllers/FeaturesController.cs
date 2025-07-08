using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.FeatureDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeaturesController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyDBContext _context;
        public FeaturesController(IMapper mapper, YummyDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateFeature(CreateFeatureDTO createFeatureDTO)
        {
            var value= _mapper.Map<Feature>(createFeatureDTO);
            _context.Features.Add(value);
            _context.SaveChanges();
            return Ok("Feature ugurla elave olundu!");
        }
        [HttpPut]
        public IActionResult UpdateFeature(UpdateFeatureDTO updateFeatureDTO)
        {
            var value=_mapper.Map<Feature>(updateFeatureDTO);
            _context.Features.Update(value);
            _context.SaveChanges();
            return Ok("Feature ugurla deyisdirildi!");
        }
        [HttpDelete]
        public IActionResult DeleteFeature(int id)
        {
            var value = _context.Features.Find(id);
            _context.Features.Remove(value);
            _context.SaveChanges();
            return Ok("Feature ugurla silindi!");
        }
        [HttpGet]
        public IActionResult FeatureList()
        {
            var values= _context.Features.ToList();
            return Ok(_mapper.Map<List<GetFeatureDTO>>(values));
        }
        [HttpGet("{id}")]
        public IActionResult GetFeature(int id)
        {
            var value=_context.Features.Find(id);
            return Ok(_mapper.Map<GetByIdFeatureDTO>(value));
        }
    }
}

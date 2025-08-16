using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.FeedbackDTOs;
using YummyProject.WebApi.DTOs.FeedbackDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbacksController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public FeedbacksController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateFeedback(CreateFeedbackDTO feedbackDTO)
        {
            var value = _mapper.Map<Feedback>(feedbackDTO);
            _context.Feedbacks.Add(value);
            _context.SaveChanges();
            return Ok("Feedback elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateFeedback(UpdateFeedbackDTO feedbackDTO)
        {
            var value = _mapper.Map<Feedback>(feedbackDTO);
            _context.Feedbacks.Update(value);
            _context.SaveChanges();
            return Ok("Feedback ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteFeedback(int id)
        {
            var value = _context.Feedbacks.Find(id);
            _context.Feedbacks.Remove(value);
            _context.SaveChanges();
            return Ok("Feedback ugurla silindi");
        }
        [HttpGet]
        public IActionResult FeedbackList()
        {
            var values = _context.Feedbacks.ToList();
            return Ok(values);
        }
        [HttpGet("GetFeedback")]
        public IActionResult GetFeedback(int id)
        {
            var value = _context.Feedbacks.Find(id);
            return Ok(value);
        }
    }
}

using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.MessageDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {
       private readonly IMapper _mapper;
        private readonly YummyDBContext _context;
        public MessagesController(IMapper mapper, YummyDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDTO messageDTO)
        {
            var value=_mapper.Map<Message>(messageDTO);
           _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj ugurla elave olundu!");
        }
        [HttpPut]
        public IActionResult UpdateMessage(UpdateMessageDTO messageDTO)
        {
            var value=_mapper.Map<Message>(messageDTO);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj ugurla deyisdirildi!");
        }
        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj ugurla silindi!");
        }
        [HttpGet]
        public IActionResult MessageLIst()
        {
            var value = _context.Messages.ToList();
            return Ok(_mapper.Map<List<GetMessageDTO>>(value));
        }
        [HttpGet("{id}")]
        public IActionResult GetMessage(int id)
        {
            var value =_context.Messages.Find(id);
            return Ok(_mapper.Map<GetByIdMessageDTO>(value));
        }
    }
}

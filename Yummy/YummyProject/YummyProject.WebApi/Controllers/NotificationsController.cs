using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.NotificationDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly YummyDBContext _context;
        public NotificationsController(IMapper mapper, YummyDBContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateNotification(CreateNotificationDTO createNotificationDTO)
        {
            var value = _mapper.Map<Notification>(createNotificationDTO);
            _context.Notifications.Add(value);
            _context.SaveChanges();
            return Ok("Notification ugurla elave olundu!");
        }
        [HttpPut]
        public IActionResult UpdateNotification(UpdateNotificationDTO updateNotificationDTO)
        {
            var value = _mapper.Map<Notification>(updateNotificationDTO);
            _context.Notifications.Update(value);
            _context.SaveChanges();
            return Ok("Notification ugurla deyisdirildi!");
        }
        [HttpDelete]
        public IActionResult DeleteNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            _context.Notifications.Remove(value);
            _context.SaveChanges();
            return Ok("Notification ugurla silindi!");
        }
        [HttpGet]
        public IActionResult NotificationList()
        {
            var values = _context.Notifications.ToList();
            return Ok(_mapper.Map<List<GetNotificationDTO>>(values));
        }
        [HttpGet("{id}")]
        public IActionResult GetNotification(int id)
        {
            var value = _context.Notifications.Find(id);
            return Ok(_mapper.Map<GetByIdNotificationDTO>(value));
        }
        [HttpGet("GetNotificationIsReadFalse")]
        public IActionResult GetNotificationIsReadFalse()
        {
            var value = _context.Notifications.Where(x => x.IsRead == false).ToList();
            return Ok(value);
        }
    }
}

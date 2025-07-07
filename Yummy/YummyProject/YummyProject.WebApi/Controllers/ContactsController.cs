using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ContactDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly YummyDBContext _context;

        public ContactsController(YummyDBContext context)
        {
            _context = context;
        }
        [HttpPost]
        public IActionResult CreateContact(CreateContactDTO createContactDTO)
        {
            Contact contact = new Contact();
            contact.Address = createContactDTO.Address;
            contact.Phone = createContactDTO.Phone;
            contact.Email = createContactDTO.Email;
            contact.MapLocation = createContactDTO.MapLocation;
            contact.OpenHours = createContactDTO.OpenHours;
            _context.Contacts.Add(contact);
            _context.SaveChanges();
            return Ok("Kontakt melumatlari ugurla elave olundu!");
        }
        [HttpPut]
        public IActionResult UpdateContact(UpdateContactDTO updateContactDTO)
        {
            Contact contact = new Contact();
            contact.ContactId = updateContactDTO.ContactId;
            contact.Address = updateContactDTO.Address;
            contact.Phone = updateContactDTO.Phone;
            contact.Email = updateContactDTO.Email;
            contact.MapLocation = updateContactDTO.MapLocation;
            contact.OpenHours = updateContactDTO.OpenHours;
            _context.Contacts.Update(contact);
            _context.SaveChanges();
            return Ok("Kontakt ugurla yenilendi!");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteContact(int id)
        {
            var value = _context.Contacts.Find(id);
            _context.Contacts.Remove(value);
            _context.SaveChanges();
            return Ok("Melumat ugurla silindi!");
        }
        [HttpGet]
        public IActionResult ConractList()
        {
            var value = _context.Contacts.ToList();
            return Ok(value);
        }
        [HttpGet("GetContact")]
        public IActionResult GetContact(int id)
        {
            var value = _context.Contacts.Find(id);
            return Ok(value);
        }
    }
}

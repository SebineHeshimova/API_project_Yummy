using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using YummyProject.WebApi.DAL;
using YummyProject.WebApi.DTOs.ReservationDTOs;
using YummyProject.WebApi.Entity;

namespace YummyProject.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationsController : ControllerBase
    {
        private readonly YummyDBContext _context;
        private readonly IMapper _mapper;
        public ReservationsController(YummyDBContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        [HttpPost]
        public IActionResult CreateReservation(CreateReservationDTO reservationDTO)
        {
            var value = _mapper.Map<Reservation>(reservationDTO);
            _context.Reservations.Add(value);
            _context.SaveChanges();
            return Ok("Reservation elave olundu");
        }
        [HttpPut]
        public IActionResult UpdateReservation(UpdateReservationDTO reservationDTO)
        {
            var value = _mapper.Map<Reservation>(reservationDTO);
            _context.Reservations.Update(value);
            _context.SaveChanges();
            return Ok("Reservation ugurla deyisdirildi");
        }
        [HttpDelete]
        public IActionResult DeleteReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            _context.Reservations.Remove(value);
            _context.SaveChanges();
            return Ok("Reservation ugurla silindi");
        }
        [HttpGet]
        public IActionResult ReservationList()
        {
            var values = _context.Reservations.ToList();
            return Ok(values);
        }
        [HttpGet("GetReservation")]
        public IActionResult GetReservation(int id)
        {
            var value = _context.Reservations.Find(id);
            return Ok(value);
        }

    }
}

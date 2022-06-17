using Entities;
using Entities.RequestParameters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Linq;

namespace MIchi_Soft_Backend.Controllers
{
    [Authorize]
    [Route("api/booking")]
    [ApiController]
    public class BookingController : MainController
    {
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
        }

        [HttpPost]
        [Route("")]
        public ActionResult<Booking> Post(Booking booking)
        {
            if (!ModelState.IsValid)
            {
                var errors = string.Join("\n", ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToArray());

                return BadRequest(errors);
            }
            var newBooking = _bookingService.Add(booking);

            return Created("api/patients", newBooking);
        }

        [HttpGet]
        [Route("{id}")]
        public ActionResult<Booking> GetById(int id)
        {
            return Ok(_bookingService.ListById(id));
        }

        [HttpGet]
        [Route("")]
        public ActionResult<Booking> Get([FromQuery] BookingRequestParameters query)
        {
            return Ok(_bookingService.List(query));
        }
    }
}

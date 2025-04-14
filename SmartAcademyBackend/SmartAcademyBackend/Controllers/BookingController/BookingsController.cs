using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartAcademyBackend.DTOs.BookingDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Service.BookingService;

namespace SmartAcademyBackend.Controllers.BookingController
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController(IBookingService bookingService) : ControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> addNewBooking(AddbookingDTO newBooking)
        {
            var booking = await bookingService.addNewBooking(newBooking);

            if(!booking.Equals("booking added"))
                return BadRequest(booking);
            return Ok(booking);
        }

        [HttpGet]
        public async Task<ActionResult<List<GetBookingDTO>>> getAllBookings()
        {
            return Ok(await bookingService.getAllBookings());
        }

        [HttpGet("{bookingId}")]
        public async Task<ActionResult<GetBookingDTO>> getBookingsById(int bookingId)
        {
            var booking = await bookingService.getBookingsByBookingId(bookingId);
            if(booking == null)
                return NotFound();
            return Ok(booking);
        }

        [HttpGet("student-bookings/{studentId}")]
        public async Task<ActionResult<List<GetBookingDTO>>> getBookingByStudentId(int studentId)
        {
            return Ok(await bookingService.getBookingByStudentId(studentId));
        }

        [HttpGet("tutor-bookings/{tutorId}")]
        public async Task<ActionResult<List<GetBookingDTO>>> getBookingByTutorId(int tutorId)
        {

            return Ok(await bookingService.getBookingByTutorId(tutorId));
        }

        [HttpGet("by-date/{date}")]
        public async Task<ActionResult<List<GetBookingDTO>>> getBookingByTutorId(DateOnly date)
        {

            return Ok(await bookingService.getBookingsByDate(date));
        }

        [HttpPut("cancel-booking/{bookingId}")]
        public async Task<IActionResult> cancelBooking(int bookingId)
        {
            await bookingService.deleteBooking(bookingId);

            return NoContent();
        }
    }
}

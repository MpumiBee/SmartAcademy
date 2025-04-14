using SmartAcademyBackend.DTOs.BookingDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.BookingService
{
    public interface IBookingService
    {
        Task<string> addNewBooking(AddbookingDTO addbookingDTO);
        Task<List<GetBookingDTO>> getAllBookings();
        Task<GetBookingDTO?> getBookingsByBookingId(int bookingId);
        Task<List<GetBookingDTO>> getBookingByStudentId(int studentId);
        Task<List<GetBookingDTO>> getBookingByTutorId(int tutorId);
        Task<List<GetBookingDTO>> getBookingsByDate(DateOnly bookingsDate);

        Task deleteBooking(int bookingId);
    }
}

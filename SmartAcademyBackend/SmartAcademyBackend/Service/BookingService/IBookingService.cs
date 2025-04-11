using SmartAcademyBackend.DTOs.BookingDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.BookingService
{
    public interface IBookingService
    {
        Task<string> addNewBooking(AddbookingDTO addbookingDTO);
    }
}

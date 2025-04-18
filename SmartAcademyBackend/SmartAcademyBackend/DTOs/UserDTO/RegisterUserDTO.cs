using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.DTOs.UserDTO
{
    public record RegisterUserDTO(string Email,
                                   string Password,   
                                   UserRole Role
        );
   
}

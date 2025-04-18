using SmartAcademyBackend.DTOs.UserDTO;
using SmartAcademyBackend.Entities;

namespace SmartAcademyBackend.Service.UserService
{
    public interface IAuthService
    {
        Task<User?> registerUser(RegisterUserDTO registerUserDTO);
        Task<string?> login(loginDTO requestUserData);
    }
}

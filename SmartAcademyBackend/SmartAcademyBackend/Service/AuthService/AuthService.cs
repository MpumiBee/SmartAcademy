using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SmartAcademyBackend.Data;
using SmartAcademyBackend.DTOs.UserDTO;
using SmartAcademyBackend.Entities;
using SmartAcademyBackend.Service.UserService;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SmartAcademyBackend.Service.AuthService
{
    public class AuthService(SmartAcademyDbContext _context, IConfiguration configuration) : IAuthService
    {
        public async Task<string?> login(loginDTO requestUserData)
        {
            var user = await _context.Users.FirstOrDefaultAsync(user=>user.Email.ToLower().Equals(requestUserData.Email.ToLower())); 
            if (user is null)
                return null;

            if (new PasswordHasher<User>().VerifyHashedPassword(user, user.PasswordHash, requestUserData.Password)
                == PasswordVerificationResult.Failed)

                return null;

            
            return CreateToken(user);

        }

        
        public async Task<User?> registerUser(RegisterUserDTO registerUserDTO)
        {


            if(await _context.Users.AnyAsync(User => User.Email.ToLower().Equals(registerUserDTO.Email.ToLower())))
                return null;

            var user = new User();

            var hashedPassword = new PasswordHasher<User>()
                                    .HashPassword(user, registerUserDTO.Password);

            user.Email = registerUserDTO.Email;
            user.PasswordHash = hashedPassword;

            _context.Add(user);
            await _context.SaveChangesAsync();
            return user;
        }

        private string CreateToken(User user)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                new Claim(ClaimTypes.Role,user.Role.ToString())
            };
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(configuration.GetValue<string>("AppSettings:Token")!));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512);

            var tokenDescriptor = new JwtSecurityToken(
                issuer: configuration.GetValue<string>("AppSettings:Issuer"),
                audience: configuration.GetValue<string>("AppSettings:Audience"),
                claims: claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

        }
    }
}

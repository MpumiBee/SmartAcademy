using SmartAcademyBackend.Enums;

namespace SmartAcademyBackend.Entities
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public UserRole Role { get; set; }
        public bool IsActive { get; set; } = true;
        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public Student? Student { get; set; }
        //public Parent? Parent { get; set; }
        public Tutor? Tutor { get; set; }
    }
}

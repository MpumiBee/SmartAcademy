using System.ComponentModel.DataAnnotations;

namespace SmartAcademyBackend.Entities
{
    public class Parent
    {
        [Key]
        public int ParentId { get; set; }
        public string ParentName { get; set; } = string.Empty;
        public string ParentSurname { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public ICollection<Student> Students { get; set; } = new List<Student>();
    }
}

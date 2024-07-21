using System.ComponentModel.DataAnnotations;

namespace Task2.Models
{
    public class DaUser
    {
        [Key]
        public int id { set; get; }
        [Required]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        [MinLength(3)]
        public string LastName { get; set; }
        public string Email { get; set; }

        public string Phone { get; set; }
        public DateOnly DOB { get; set; }
    }
}

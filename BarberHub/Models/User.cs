using BarberHub.Enumerators;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        public string Email { get; set; }

        [Required]
        public ETypeUser Type { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }
    }
}

using BarberHub.Enumerators;
using System.ComponentModel.DataAnnotations;

namespace BarberHub.ViewModel
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Sobrenome")]
        public string LastName { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Tipo de usuário")]
        public ETypeUser Type { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Senha")]
        public string Password { get; set; }
    }
}

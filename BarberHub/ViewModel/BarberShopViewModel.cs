
using System.ComponentModel.DataAnnotations;

namespace BarberHub.ViewModel
{
    public class BarberShopViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        [Display(Name = "Endereço")]
        public string Address { get; set; }

        public int UserId { get; set; }
    }
}

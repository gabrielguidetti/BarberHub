using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("BARBER_SHOPS")]
    public class BarberShop
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(150)]
        public string Address { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public ICollection<Barber> Barbers { get; set; }

        public ICollection<Service> Services { get; set; }

        public BarberShop()
        {
            Barbers = new Collection<Barber>();
            Services = new Collection<Service>();
        }
    }
}

using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("BARBERS")]
    public class Barber
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public TimeSpan StartWorkTime { get; set; }

        [Required]
        public TimeSpan FinishWorkTime { get; set; }

        public int BarberShopId { get; set; }

        public BarberShop BarberShop { get; set; }
    }
}

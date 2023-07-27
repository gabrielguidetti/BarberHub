using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("SERVICES")]
    public class Service
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "Decimal(10,2)")]
        public decimal Price { get; set; }

        public int BarberShopId { get; set; }

        public BarberShop BarberShop { get; set; }
    }
}

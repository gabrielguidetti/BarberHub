using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("BARBER_SERVICES")]
    public class BarberService
    {
        [Key]
        public int Id { get; set; }

        public int ServiceId { get;set; }

        public Service Service { get; set; }

        public int BarberId { get; set; }

        public Barber Barber { get; set; }

        public TimeSpan TimeSpent { get; set; }
    }
}

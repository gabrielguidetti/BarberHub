using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BarberHub.Models
{
    [Table("MARKED_SERVICES")]
    public class MarkedService
    {
        [Key]
        public int Id { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ServiceId { get; set; }
        public Service Service { get; set; }

        public DateTime Date { get; set; }
    }
}

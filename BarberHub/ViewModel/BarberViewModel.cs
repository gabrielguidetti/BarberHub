using System.ComponentModel.DataAnnotations;

namespace BarberHub.ViewModel
{
    public class BarberViewModel
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Digitar nome!")]
        [StringLength(50)]
        public string Name { get; set; }

        [Display(Name = "Horário de início")]
        [Required(ErrorMessage = "Digitar horário de início!")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan StartWorkTime { get; set; }

        [Display(Name = "Horário de saída")]
        [Required(ErrorMessage = "Digitar horário de saída!")]
        [DisplayFormat(DataFormatString = "{0:hh\\:mm}", ApplyFormatInEditMode = true)]
        public TimeSpan FinishWorkTime { get; set; }

        public int BarberShopId { get; set; }
    }
}

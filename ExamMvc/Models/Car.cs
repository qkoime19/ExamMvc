using System.ComponentModel.DataAnnotations;

namespace ExamMvc.Models
{
    public class Car
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Полето „Модел“ е задължително.")]
        [StringLength(200)]
        [Display(Name = "Модел")]
        public string Model { get; set; }

        [Required(ErrorMessage = "Полето „Марка“ е задължително.")]
        [StringLength(100)]
        [Display(Name = "Марка")]
        public string Brand { get; set; }

        [Required(ErrorMessage = "Полето „Гориво“ е задължително.")]
        [StringLength(50)]
        [Display(Name = "Гориво")]
        public string FuelType { get; set; }

        [Range(1950, 2100, ErrorMessage = "Година: стойност между 1950 и 2100.")]
        [Display(Name = "Година")]
        public int Year { get; set; }

        [Range(0.0, 500000.0, ErrorMessage = "Цена (лв.): стойност между 0 и 500000.")]
        [Display(Name = "Цена (лв.)")]
        public decimal Price { get; set; }
    }
}

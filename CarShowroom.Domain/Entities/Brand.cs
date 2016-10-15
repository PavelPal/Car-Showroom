using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Domain.Entities
{
    public class Brand
    {
        public Brand()
        {
            Cars = new List<Car>();
        }

        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Производитель")]
        public string Body { get; set; }

        [Display(Name = "Изображение")]
        public byte[] Image { get; set; }

        public string ImageType { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Страна")]
        public string Country { get; set; }

        public List<Car> Cars { get; set; }
    }
}
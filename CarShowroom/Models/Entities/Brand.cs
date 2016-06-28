using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Models.Entities
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
        [Display(Name = "Название производителя")]
        public string Body { get; set; }

        public byte[] Image { get; set; }
        public string ImageType { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Страна производителя")]
        public string Country { get; set; }

        public List<Car> Cars { get; set; }
    }
}
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Models.Entities
{
    public class DriveUnit
    {
        public DriveUnit()
        {
            Car = new List<Car>();
        }

        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required(ErrorMessage = "Неверно заполнено поле")]
        [Display(Name = "Тип привода")]
        public string Body { get; set; }

        public List<Car> Car { get; set; }
    }
}
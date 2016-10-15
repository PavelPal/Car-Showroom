using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CarShowroom.Domain.Entities
{
    public class CarImage
    {
        [Key,
         DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public byte[] Image { get; set; }
        public string ImageType { get; set; }
        public Car Car { get; set; }
        public int CarId { get; set; }
    }
}
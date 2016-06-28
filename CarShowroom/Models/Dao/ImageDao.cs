using System.Linq;
using CarShowroom.Models.Entities;

namespace CarShowroom.Models.Dao
{
    public class ImageDao : IImageDao
    {
        public CarImage GetCarImage(int id)
        {
            var item = new CarImage();
            using (var context = new ApplicationDbContext())
            {
                item = context.CarImages.FirstOrDefault(i => i.CarId == id);
            }
            return item;
        }
    }
}
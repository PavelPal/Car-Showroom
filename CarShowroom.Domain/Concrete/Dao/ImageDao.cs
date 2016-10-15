using System.Collections.Generic;
using System.Linq;
using CarShowroom.Domain.Abstract.Dao;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Domain.Concrete.Dao
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

        public IEnumerable<CarImage> GetAllCarImage(int id)
        {
            IEnumerable<CarImage> list;
            using (var context = new ApplicationDbContext())
            {
                list = context.CarImages.Where(i => i.CarId == id);
            }
            return list;
        }
    }
}
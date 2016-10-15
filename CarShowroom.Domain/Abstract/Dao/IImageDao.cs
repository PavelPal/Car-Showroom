using System.Collections.Generic;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Domain.Abstract.Dao
{
    public interface IImageDao
    {
        CarImage GetCarImage(int id);
        IEnumerable<CarImage> GetAllCarImage(int id);
    }
}
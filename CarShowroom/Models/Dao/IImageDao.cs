using CarShowroom.Models.Entities;

namespace CarShowroom.Models.Dao
{
    public interface IImageDao
    {
        CarImage GetCarImage(int id);
    }
}
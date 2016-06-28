using CarShowroom.Models.Dao;
using CarShowroom.Models.Entities;

namespace CarShowroom.Models.Services
{
    public class HomeService : IHomeService
    {
        private readonly UnitOfWork<Brand> _brand;
        private readonly UnitOfWork<Car> _car;

        public HomeService()
        {
            _brand = new UnitOfWork<Brand>();
            _car = new UnitOfWork<Car>();
        }

        public ViewModels.IndexViewModel InicializeIndexViewModel()
        {
            return new ViewModels.IndexViewModel(_brand.EntityDao.GetAll(), _car.EntityDao.GetAll());
        }
    }
}
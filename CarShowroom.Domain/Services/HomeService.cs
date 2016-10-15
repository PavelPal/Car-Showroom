using CarShowroom.Domain.Abstract.Services;
using CarShowroom.Domain.Concrete;
using CarShowroom.Domain.Entities;
using CarShowroom.Domain.ViewModels;

namespace CarShowroom.Domain.Services
{
    public class HomeService : IHomeService
    {
        private readonly Repository<Brand> _brand;
        private readonly Repository<Car> _car;

        public HomeService()
        {
            _brand = new Repository<Brand>();
            _car = new Repository<Car>();
        }

        public IndexViewModel InicializeIndexViewModel()
        {
            return new IndexViewModel(_brand.EntityDao.GetAll(), _car.EntityDao.GetAll());
        }
    }
}
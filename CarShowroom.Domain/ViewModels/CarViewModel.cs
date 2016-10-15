using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using CarShowroom.Domain.Concrete;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Domain.ViewModels
{
    public class CarViewModel
    {
        public CarViewModel()
        {
            Car = new Car();
            CarImages = new List<CarImage>();
            BodyTypes = Inicialize<BodyType>();
            Brands = Inicialize<Brand>();
            CarTypes = Inicialize<CarType>();
            DriveUnits = Inicialize<DriveUnit>();
            Engines = Inicialize<Engine>();
            Headlights = Inicialize<Headlight>();
            Transmissions = Inicialize<Transmission>();
        }

        public Car Car { get; set; }
        public List<SelectListItem> BodyTypes { get; set; }
        public List<SelectListItem> Brands { get; set; }
        public List<CarImage> CarImages { get; set; }
        public List<SelectListItem> CarTypes { get; set; }
        public List<SelectListItem> DriveUnits { get; set; }
        public List<SelectListItem> Engines { get; set; }
        public List<SelectListItem> Headlights { get; set; }
        public List<SelectListItem> Transmissions { get; set; }

        private List<SelectListItem> Inicialize<T>() where T : class
        {
            var unit = new Repository<T>();
            var list = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Выберите",
                    Value = "",
                    Disabled = true,
                    Selected = true
                }
            };
            list.AddRange(unit.EntityDao.GetAll().Select(item => new SelectListItem
            {
                Disabled = false,
                Selected = false,
                Value = item.GetType().GetProperty("Id").GetValue(item).ToString(),
                Text = item.GetType().GetProperty("Body").GetValue(item).ToString()
            }));
            return list;
        }
    }
}
using System.Collections.Generic;
using CarShowroom.Models.Entities;

namespace CarShowroom.Models.ViewModels
{
    public class IndexViewModel
    {
        public IndexViewModel()
        {
            Brands = new List<Brand>();
            Cars = new List<Car>();
        }

        public IndexViewModel(IEnumerable<Brand> brands, IEnumerable<Car> carModels)
        {
            Brands = brands;
            Cars = carModels;
        }

        public IEnumerable<Brand> Brands { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
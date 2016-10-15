using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;
using CarShowroom.Domain.Abstract.Services;
using CarShowroom.Domain.Entities;
using CarShowroom.Domain.ViewModels;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CarController : Controller
    {
        private readonly IAdminService _adminService;

        public CarController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<Car>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(new CarViewModel());
        }

        [HttpPost]
        public ActionResult Create(Car car, HttpPostedFileBase image1 = null,
            HttpPostedFileBase image2 = null, HttpPostedFileBase image3 = null,
            HttpPostedFileBase image4 = null)
        {
            if (!ModelState.IsValid)
            {
                var model = new CarViewModel();
                model.Car = car;
                return View(model);
            }
            if (image1 != null && image2 != null && image3 != null && image4 != null)
            {
                _adminService.Create(car);
                var imageList = new List<HttpPostedFileBase> {image1, image2, image3, image4};
                foreach (var image in imageList)
                {
                    var carImage = new CarImage
                    {
                        ImageType = image.ContentType,
                        Image = new byte[image.ContentLength],
                        CarId = car.Id
                    };
                    image.InputStream.Read(carImage.Image, 0, image.ContentLength);
                    _adminService.Create(carImage);
                }
            }
            else
            {
                ModelState.AddModelError("CarImages", "Не выбрана картинка");
                var model = new CarViewModel();
                model.Car = car;
                return View(model);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Details(int? id)
        {
            if (id == null || _adminService.Get<Car>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            var model = new CarViewModel();
            model.Car = _adminService.Get<Car>(id.Value);
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<Car>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            var model = new CarViewModel();
            model.Car = _adminService.Get<Car>(id.Value);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Car car)
        {
            if (!ModelState.IsValid)
            {
                var model = new CarViewModel();
                model.Car = car;
                return View(model);
            }
            _adminService.Update(car);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<Car>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Car>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<Car>(id);
            return RedirectToAction("Index");
        }
    }
}
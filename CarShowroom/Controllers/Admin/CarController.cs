using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;
using CarShowroom.Models.ViewModels;

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
        public ActionResult Create(Car car)
        {
            if (!ModelState.IsValid)
            {
                var model = new CarViewModel();
                model.Car = car;
                return View(model);
            }
            _adminService.Create(car);
            return RedirectToAction("Index");
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
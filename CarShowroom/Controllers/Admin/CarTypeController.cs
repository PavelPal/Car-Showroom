using System.Web.Mvc;
using CarShowroom.Domain.Abstract.Services;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class CarTypeController : Controller
    {
        private readonly IAdminService _adminService;

        public CarTypeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<CarType>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(CarType carType)
        {
            if (!ModelState.IsValid) return View(carType);
            _adminService.Create(carType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<CarType>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<CarType>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(CarType carType)
        {
            if (!ModelState.IsValid) return View(carType);
            _adminService.Update(carType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<CarType>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<CarType>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<CarType>(id);
            return RedirectToAction("Index");
        }
    }
}
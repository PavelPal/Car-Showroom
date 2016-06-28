using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class DriveUnitController : Controller
    {
        private readonly IAdminService _adminService;

        public DriveUnitController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<DriveUnit>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DriveUnit driveUnit)
        {
            if (!ModelState.IsValid) return View(driveUnit);
            _adminService.Create(driveUnit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<DriveUnit>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<DriveUnit>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(DriveUnit driveUnit)
        {
            if (!ModelState.IsValid) return View(driveUnit);
            _adminService.Update(driveUnit);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<DriveUnit>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<DriveUnit>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<DriveUnit>(id);
            return RedirectToAction("Index");
        }
    }
}
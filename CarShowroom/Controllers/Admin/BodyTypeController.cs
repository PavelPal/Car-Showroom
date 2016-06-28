using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class BodyTypeController : Controller
    {
        private readonly IAdminService _adminService;

        public BodyTypeController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<BodyType>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BodyType bodyType)
        {
            if (!ModelState.IsValid) return View(bodyType);
            _adminService.Create(bodyType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<BodyType>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<BodyType>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(BodyType bodyType)
        {
            if (!ModelState.IsValid) return View(bodyType);
            _adminService.Update(bodyType);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<BodyType>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<BodyType>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<BodyType>(id);
            return RedirectToAction("Index");
        }
    }
}
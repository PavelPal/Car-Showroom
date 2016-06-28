using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class EngineController : Controller
    {
        private readonly IAdminService _adminService;

        public EngineController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<Engine>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Engine engine)
        {
            if (!ModelState.IsValid) return View(engine);
            _adminService.Create(engine);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<Engine>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Engine>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(Engine engine)
        {
            if (!ModelState.IsValid) return View(engine);
            _adminService.Update(engine);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<Engine>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Engine>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<Engine>(id);
            return RedirectToAction("Index");
        }
    }
}
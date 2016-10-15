using System.Web.Mvc;
using CarShowroom.Domain.Abstract.Services;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class HeadlightController : Controller
    {
        private readonly IAdminService _adminService;

        public HeadlightController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<Headlight>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Headlight headlight)
        {
            if (!ModelState.IsValid) return View(headlight);
            _adminService.Create(headlight);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<Headlight>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Headlight>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(Headlight headlight)
        {
            if (!ModelState.IsValid) return View(headlight);
            _adminService.Update(headlight);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<Headlight>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Headlight>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<Headlight>(id);
            return RedirectToAction("Index");
        }
    }
}
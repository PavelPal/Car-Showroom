using System.Web.Mvc;
using CarShowroom.Domain.Abstract.Services;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class TransmissionController : Controller
    {
        private readonly IAdminService _adminService;

        public TransmissionController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<Transmission>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Transmission transmission)
        {
            if (!ModelState.IsValid) return View(transmission);
            _adminService.Create(transmission);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<Transmission>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Transmission>(id.Value));
        }

        [HttpPost]
        public ActionResult Update(Transmission transmission)
        {
            if (!ModelState.IsValid) return View(transmission);
            _adminService.Update(transmission);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<Transmission>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Transmission>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<Transmission>(id);
            return RedirectToAction("Index");
        }
    }
}
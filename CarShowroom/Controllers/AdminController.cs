using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;

namespace CarShowroom.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminService _adminService;

        public AdminController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Orders()
        {
            return View(_adminService.GetAll<Order>());
        }

        [HttpGet]
        public ActionResult Reviews()
        {
            return View(_adminService.GetAll<Review>());
        }
    }
}
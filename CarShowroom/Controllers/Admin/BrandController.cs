using System.Web;
using System.Web.Mvc;
using CarShowroom.Models.Entities;
using CarShowroom.Models.Services;

namespace CarShowroom.Controllers.Admin
{
    [Authorize(Roles = "Admin")]
    public class BrandController : Controller
    {
        private readonly IAdminService _adminService;

        public BrandController(IAdminService adminService)
        {
            _adminService = adminService;
        }

        [HttpGet]
        public ActionResult Index()
        {
            return View(_adminService.GetAll<Brand>());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create([Bind(Exclude = "Image, ImageType")] Brand brand,
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(brand);
            if (image != null)
            {
                brand.ImageType = image.ContentType;
                brand.Image = new byte[image.ContentLength];
                image.InputStream.Read(brand.Image, 0, image.ContentLength);
            }
            else
            {
                ModelState.AddModelError("Brand.Image", "Не выбрана картинка");
            }
            _adminService.Create(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Update(int? id)
        {
            if (id == null || _adminService.Get<Brand>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Brand>(id.Value));
        }

        [HttpPost]
        public ActionResult Update([Bind(Exclude = "Image, ImageType")] Brand brand,
            HttpPostedFileBase image = null)
        {
            if (!ModelState.IsValid) return View(brand);
            if (image != null)
            {
                brand.ImageType = image.ContentType;
                brand.Image = new byte[image.ContentLength];
                image.InputStream.Read(brand.Image, 0, image.ContentLength);
            }
            else
            {
                var newBrand = _adminService.Get<Brand>(brand.Id);
                brand.ImageType = newBrand.ImageType;
                brand.Image = newBrand.Image;
            }
            _adminService.Update(brand);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null || _adminService.Get<Brand>(id.Value) == null)
            {
                return RedirectToAction("Index");
            }
            return View(_adminService.Get<Brand>(id.Value));
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            _adminService.Delete<Brand>(id);
            return RedirectToAction("Index");
        }
    }
}
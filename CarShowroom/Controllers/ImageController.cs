using System.Web.Mvc;
using CarShowroom.Models.Dao;
using CarShowroom.Models.Entities;

namespace CarShowroom.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageDao _imageDao;
        private readonly UnitOfWork<Brand> _unitOfWork;

        public ImageController(IImageDao imageDao)
        {
            _unitOfWork = new UnitOfWork<Brand>();
            _imageDao = imageDao;
        }

        public FileContentResult GetBrandImage(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var item = _unitOfWork.EntityDao.Get(id.Value);
            return item != null ? File(item.Image, item.ImageType) : null;
        }

        public FileContentResult GetCarImage(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var item = _imageDao.GetCarImage(id.Value);
            return item != null ? File(item.Image, item.ImageType) : null;
        }
    }
}
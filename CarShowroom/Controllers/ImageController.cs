using System.Web.Mvc;
using CarShowroom.Domain.Abstract.Dao;
using CarShowroom.Domain.Concrete;
using CarShowroom.Domain.Entities;

namespace CarShowroom.Controllers
{
    public class ImageController : Controller
    {
        private readonly IImageDao _imageDao;
        private readonly Repository<Brand> _repository;

        public ImageController(IImageDao imageDao)
        {
            _repository = new Repository<Brand>();
            _imageDao = imageDao;
        }

        public FileContentResult GetBrandImage(int? id)
        {
            if (id == null)
            {
                return null;
            }
            var item = _repository.EntityDao.Get(id.Value);
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
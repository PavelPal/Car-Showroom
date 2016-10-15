using System.Web.Mvc;
using CarShowroom.Domain;
using CarShowroom.Domain.Concrete;
using CarShowroom.Domain.Entities;
using CarShowroom.Domain.ViewModels;

namespace CarShowroom.Controllers
{
    public class CartController : Controller
    {
        private readonly Repository<Car> _repository;

        public CartController()
        {
            _repository = new Repository<Car>();
        }

        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View(new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            });
        }

        public RedirectToRouteResult AddToCart(Cart cart, int id, string returnUrl)
        {
            var car = _repository.EntityDao.Get(id);

            if (car != null)
            {
                cart.AddItem(car, 1);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public RedirectToRouteResult RemoveFromCart(Cart cart, int id, string returnUrl)
        {
            var car = _repository.EntityDao.Get(id);

            if (car != null)
            {
                cart.RemoveLine(car);
            }
            return RedirectToAction("Index", new {returnUrl});
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }
    }
}
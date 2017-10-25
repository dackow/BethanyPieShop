using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;

namespace BethanyPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ShoppingCart _shoppingCart;

        public ShoppingCartController(IPieRepository pr, ShoppingCart sc)
        {
            _pieRepository = pr;
            _shoppingCart = sc;
        }

        public ViewResult Index()
        {
            var items = _shoppingCart.GetShoppingCartItems();
            _shoppingCart.ShoppingCartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetShopingCartTotal()
            };

            return View(shoppingCartViewModel);
        }
    }
}
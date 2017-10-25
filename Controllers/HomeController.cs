using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.Models;
using BethanyPieShop.ViewModels;

namespace BethanyPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;

        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public ViewResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                PiesOfTheWeek = _pieRepository.PiesOfWeek
            };

            return View(homeViewModel);
        }
    }
}
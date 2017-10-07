using Microsoft.AspNetCore.Mvc;
using BethanyPieShop.Models;

namespace BethanyPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public ViewResult List()
        {
            return View(_pieRepository.Pies);
        }

        public ViewResult Index()
        {
            ViewBag.Message = "Welcome to my great shop";
            return View();
        }

    }

}
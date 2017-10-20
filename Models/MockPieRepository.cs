using System.Collections.Generic;
using System.Linq;

namespace BethanyPieShop.Models
{
    public class MockPieRepository : IPieRepository
    {
        private readonly ICategoryRepository _categoryRepository = new MockCategoryRepository();

        public IEnumerable<Pie> Pies
        {
            get
            {
                return new List<Pie>
                {
                    new Pie {PieId = 1, Name = "Strawberry Pie", Price=15.95M, ShortDescription = "Strawberry good pie",  Category = _categoryRepository.Categories.ToList()[0], ImageThumbnailUrl = "Images/bethanylogo.png", ImageUrl = "Images/carousel1.jpg"},
                    new Pie {PieId = 2, Name = "Cheese cake", Price=18.95M, ShortDescription = "Cheese cake good",  Category = _categoryRepository.Categories.ToList()[1], ImageThumbnailUrl = "Images/carousel2.jpg", ImageUrl = "Images/carousel2.jpg"},
                    new Pie {PieId = 3, Name = "Rhubarb Pie", Price=15.95M, ShortDescription = "Rhubarb pie - delicious",  Category = _categoryRepository.Categories.ToList()[2], ImageThumbnailUrl = "Images/carousel3.jpg", ImageUrl = "Images/carousel3.jpg"},
                    new Pie {PieId = 4, Name = "Pumpkin Pie", Price=12.95M, ShortDescription = "Halloween pumpkin pie",  Category = _categoryRepository.Categories.ToList()[0], ImageThumbnailUrl = "Images/carousel1.jpg", ImageUrl = "Images/carousel1.jpg"},
                };
            }
        }

        public IEnumerable<Pie> PiesOfWeek { get; }

        public Pie GetPieById(int pie)
        {
            throw new System.NotImplementedException();
        }

    }
}
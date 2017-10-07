using System.Collections.Generic;

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
                    new Pie {PieId = 1, Name = "Strawberry Pie", Price=15.95M, ShortDescription = "Strawberry good pie"},
                    new Pie {PieId = 2, Name = "Cheese cake", Price=18.95M, ShortDescription = "Cheese cake good"},
                    new Pie {PieId = 3, Name = "Rhubarb Pie", Price=15.95M, ShortDescription = "Rhubarb pie - delicious"},
                    new Pie {PieId = 4, Name = "Pumpkin Pie", Price=12.95M, ShortDescription = "Halloween pumpkin pie"},
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
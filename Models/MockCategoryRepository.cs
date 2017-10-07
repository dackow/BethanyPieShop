using System.Collections.Generic;

namespace BethanyPieShop.Models
{
    public class MockCategoryRepository : ICategoryRepository
    {
        
        public IEnumerable<Category> Categories
        {
            get
            {
                return new List<Category>
                {
                    new Category {CategoryId=1, CategoryName="Fruit pies", Description="All-fruity pies"},
                    new Category {CategoryId=2, CategoryName="Cheese cakes", Description="Good cheesy cakes"},
                    new Category {CategoryId=3, CategoryName="Seasonal pies", Description="All the season"}
                };
            }
        }
    }
}
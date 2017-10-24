using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanyPieShop.Models
{
    public static class DbInitializer
    {
        private static Dictionary<string, Category> _categories;
        private static List<Pie> _pies;

        public static void Seed(IApplicationBuilder applicationBuilder, IServiceProvider serviceProvider)
        {
            AppDbContext ctx = serviceProvider.GetRequiredService<AppDbContext>();
            //AppDbContext ctx =  applicationBuilder.ApplicationServices.GetRequiredService<AppDbContext>();

            if(!ctx.Categories.Any())
            {
                ctx.Categories.AddRange(Categories.Select(x => x.Value));
            }

            if(!ctx.Pies.Any())
            {
                ctx.Pies.AddRange(Pies.Select(x => x));
            }

            ctx.SaveChanges();
        }


        private static List<Pie> Pies
        {
            get
            {
                if(_pies == null)
                {
                    _pies = new List<Pie>
                    {
                        new Pie {Name = "Cheese cake", Price=18.95M, ShortDescription = "Cheese cake good",  Category = Categories["Fruit pies"] , ImageThumbnailUrl = "Images/carousel2.jpg", ImageUrl = "Images/carousel2.jpg"},
                        new Pie {Name = "Rhubarb Pie", Price=15.95M, ShortDescription = "Rhubarb pie - delicious",  Category =Categories["Cheese pies"], ImageThumbnailUrl = "Images/carousel3.jpg", ImageUrl = "Images/carousel3.jpg"},
                        new Pie {Name = "Pumpkin Pie", Price=12.95M, ShortDescription = "Halloween pumpkin pie",  Category = Categories["Seasonal pies"], ImageThumbnailUrl = "Images/carousel1.jpg", ImageUrl = "Images/carousel1.jpg"},
                    };
                }

                return _pies;
            }
        }

        private static Dictionary<string, Category>  Categories
        {
            get
            {
                    if(_categories == null)
                    {
                        var genresList = new Category[]
                        {
                            new Category {CategoryName = "Fruit pies"},
                            new Category {CategoryName = "Cheese pies"},
                            new Category {CategoryName = "Seasonal pies"}
                        };


                        _categories = new Dictionary<string, Category>();
                        foreach(Category genre in genresList)
                        {
                            _categories.Add(genre.CategoryName, genre);
                        }
                    }
                    return _categories;
            }
        }
    }
}

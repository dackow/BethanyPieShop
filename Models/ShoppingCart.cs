using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace BethanyPieShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;

        private ShoppingCart(AppDbContext context)
        {
            this._appDbContext = context;
        }

        public string ShoppingCartId { get; set;}
        public List<ShoppingCartItem> ShoppingCartItems { get; set; }

        public List<ShoppingCartItem> GetShoppingCartItems()
        {
            if(ShoppingCartItems != null)
            {
                return ShoppingCartItems;
            }
            else
            {
                return ShoppingCartItems = _appDbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Include( s => s.Pie).ToList();
            }
        }

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();

            string cardId = session.GetString("CartId");

            if(cardId == null)
            {
                cardId = Guid.NewGuid().ToString();
                session.SetString("CartId", cardId);
            }

            return new ShoppingCart(context) {ShoppingCartId = cardId};
        }

        public void AddPie(Pie pie, int amount)
        {
            var shoppingCardItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            if(shoppingCardItem == null)
            {
                shoppingCardItem = new ShoppingCartItem
                {
                    ShoppingCartId = ShoppingCartId,
                    Pie = pie,
                    Amount = 1
                };

                _appDbContext.ShoppingCartItems.Add(shoppingCardItem);
            }
            else
            {
                shoppingCardItem.Amount++;
            }

            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var shoppingCardItem = _appDbContext.ShoppingCartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

            int localAmount = 0;

            if(shoppingCardItem != null)
            {
                if(shoppingCardItem.Amount > 1)
                {
                    shoppingCardItem.Amount--;
                    localAmount = shoppingCardItem.Amount;
                }
                else
                {
                    _appDbContext.ShoppingCartItems.Remove(shoppingCardItem);
                }
                _appDbContext.SaveChanges();
            }

            return localAmount;
        }

        public void ClearCart()
        {
            var items = _appDbContext.ShoppingCartItems.Where( i => i.ShoppingCartId == ShoppingCartId);

            _appDbContext.ShoppingCartItems.RemoveRange(items);

            _appDbContext.SaveChanges();
        }

        public decimal GetShopingCartTotal()
        {
            var total = _appDbContext.ShoppingCartItems.Where(i => i.ShoppingCartId == ShoppingCartId).Select(i => i.Amount * i.Pie.Price).Sum();
            return total;
        }
    }
}
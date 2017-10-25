using System.Collections.Generic;
using BethanyPieShop.Models;

namespace BethanyPieShop.ViewModels
 {
     public class HomeViewModel
     {
         public IEnumerable<Pie> PiesOfTheWeek { get; set; }

     }
 }
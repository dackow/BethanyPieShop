using System.Collections.Generic;

namespace BethanyPieShop.Models
{
    public interface IPieRepository
    {
        IEnumerable<Pie> Pies { get; }
        IEnumerable<Pie> PiesOfWeek { get; }
        Pie GetPieById(int pie);
    }
}
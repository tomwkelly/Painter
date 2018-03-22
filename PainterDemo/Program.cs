using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainterDemo
{
  class Program
  {

    private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
    {
      double bestPrice = 0;
      IPainter cheapest = null;

      foreach (var painter in painters)
      {
        if (painter.IsAvailable)
        {
          double price = painter.EstimateCompensation(sqMeters);
          if (cheapest == null || price < bestPrice)
          {
            cheapest = painter;
          }
        }
      }

      return cheapest;
    }

    static void Main(string[] args)
    {
    }
  }
}

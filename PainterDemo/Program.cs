using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PainterDemo
{
  class Program
  {

    static void Main(string[] args)
    {
      var painters = new ProportionalPainter[10];

      IPainter painter;

      // Painters working together
      painter = CompositePainterFactories.CreateGroup(painters);

      // Cheapest painter
      painter = CompositePainterFactories.CreateCheapestSelector(painters);

      // Fastest painter
      painter = CompositePainterFactories.CreateFastestSelector(painters);
    }
  }
}

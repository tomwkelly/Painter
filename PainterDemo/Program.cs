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
      return painters.Where(painter => painter.IsAvailable)
                     .WithMinimum(painter => painter.EstimateCompensation(sqMeters));

    }

    private static IPainter FindFastestPainter(double sqMeters, IEnumerable<IPainter> painters)
    {
      return painters.Where(painter => painter.IsAvailable)
        .WithMinimum(painter => painter.EstimateTimeToPaint(sqMeters));

    }

    private static void WorkTogether(double sqMeters, IEnumerable<IPainter> painters)
    {
      var time = 
        TimeSpan.FromHours(
          1/
      painters
      .Where(painter => painter.IsAvailable)
      .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
      .Sum());

      double cost =
      painters
        .Where(painter => painter.IsAvailable)
        .Select(painter =>
          painter.EstimateCompensation(sqMeters) /
          painter.EstimateTimeToPaint(sqMeters).TotalHours *
          time.TotalHours)
        .Sum();
    }

    static void Main(string[] args)
    {
    }
  }
}

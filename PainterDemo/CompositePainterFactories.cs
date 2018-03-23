// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="CompositePainterFactories.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PainterDemo
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  static class CompositePainterFactories
  {


    public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters) =>
      new CompositePainter<IPainter>(painters,
        (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters));


    public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters) =>
      new CompositePainter<IPainter>(painters, 
        (sqMeters, sequence) => new Painters(sequence).GetFastestOne(sqMeters));

    public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters) => new CompositePainter<ProportionalPainter>(
      painters,
      (sqMeters, sequence) =>
      {

        var time = TimeSpan.FromHours(
          1 / sequence.Where(painter => painter.IsAvailable)
            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours).Sum());

        var cost = sequence.Where(painter => painter.IsAvailable).Select(
          painter => painter.EstimateCompensation(sqMeters) / painter.EstimateTimeToPaint(sqMeters).TotalHours
                     * time.TotalHours).Sum();

        return new ProportionalPainter()
               {
                 TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
                 DollarsPerHour = cost / time.TotalHours
               };
      });
  }
}
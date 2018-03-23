// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="PaintingGroup.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PainterDemo
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public class PaintingGroup : IPainter
  {
    private IEnumerable<ProportionalPainter> Painters { get; }

    public bool IsAvailable => this.Painters.Any(painter => painter.IsAvailable);

    public PaintingGroup(IEnumerable<ProportionalPainter> painters)
    {
      this.Painters = painters.ToList();
    }

    private IPainter Reduce(double sqMeters)
    {
      var time =
        TimeSpan.FromHours(
          1 /
          this.Painters
            .Where(painter => painter.IsAvailable)
            .Select(painter => 1 / painter.EstimateTimeToPaint(sqMeters).TotalHours)
            .Sum());

      var cost =
        this.Painters
          .Where(painter => painter.IsAvailable)
          .Select(painter =>
            painter.EstimateCompensation(sqMeters) /
            painter.EstimateTimeToPaint(sqMeters).TotalHours *
            time.TotalHours)
          .Sum();

      return new ProportionalPainter()
      {
        TimePerSqMeter = TimeSpan.FromHours(time.TotalHours / sqMeters),
        DollarsPerHour = cost / time.TotalHours
      };
    }

    public TimeSpan EstimateTimeToPaint(double sqMeters) => 
      this.Reduce(sqMeters).EstimateTimeToPaint(sqMeters);

    public double EstimateCompensation(double sqMeters) => 
      this.Reduce(sqMeters).EstimateCompensation(sqMeters);
  }
}
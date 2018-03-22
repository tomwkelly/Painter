// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="IPainter.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PainterDemo
{
  using System;

  public interface IPainter
  {
    bool IsAvailable { get; }

    TimeSpan EstimateTimeToPaint(double sqMeters);

    double EstimateCompensation(double sqMeters);
  }
}
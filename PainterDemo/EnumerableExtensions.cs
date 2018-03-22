// --------------------------------------------------------------------------------------------------------------------
// <copyright company="twentysix" file="EnumerableExtensions.cs">
// Copyright (c) twentysix.  All rights reserved.
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace PainterDemo
{
  using System;
  using System.Collections.Generic;
  using System.Linq;

  public static class EnumerableExtensions
  {
    public static T WithMinimum<T, TKey>(this IEnumerable<T> sequence, Func<T, TKey> criterion)
      where T : class 
      where TKey : IComparable<TKey> => 
        sequence.Select(obj => 
          Tuple.Create(obj, criterion(obj)))
            .Aggregate((Tuple<T, TKey>)null, (best, cur) => best == null || cur.Item2.CompareTo(best.Item2) < 0 ? cur : best)
            .Item1;
  }
}
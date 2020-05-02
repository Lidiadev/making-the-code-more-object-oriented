using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public static class CompositePainterFactories
    {
        public static IPainter CreateCheapestSelector(IEnumerable<IPainter> painters)
            => new CompositePainter<IPainter>
            (
                painters, 
                (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetCheapestOne(sqMeters)
             );

        public static IPainter CreateFastestSelector(IEnumerable<IPainter> painters)
            => new CompositePainter<IPainter>
            (
                painters,
                (sqMeters, sequence) => new Painters(sequence).GetAvailable().GetFastestOne(sqMeters)
            );

        public static IPainter CreateGroup(IEnumerable<ProportionalPainter> painters)
            => new CompositePainter<ProportionalPainter>
            (painters, (sqMeters, sequence) =>
            {
                TimeSpan time = TimeSpan.FromHours(
              sequence
                  .Where(x => x.IsAvailable)
                  .Select(x => 1 / x.EstimateTimeToPaint(sqMeters).TotalHours)
                  .Sum()
              );

                double cost = sequence
                    .Where(x => x.IsAvailable)
                    .Select(x => x.EstimateCompensation(sqMeters) / x.EstimateTimeToPaint(sqMeters).TotalHours * time.TotalHours)
                    .Sum();

                return new ProportionalPainter(time, cost);
            });
    }
}

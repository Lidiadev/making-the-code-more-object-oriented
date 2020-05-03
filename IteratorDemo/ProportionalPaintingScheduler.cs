using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public class ProportionalPaintingScheduler : IPaitingScheduler<ProportionalPainter>
    {
        public IEnumerable<PainterTask<ProportionalPainter>> Schedule(double sqMeters, IEnumerable<ProportionalPainter> painters)
        {
            IEnumerable<Tuple<ProportionalPainter, double>> velocities
                = painters.Select(p => Tuple.Create(p, sqMeters / p.EstimateTimeToPaint(sqMeters).TotalHours));

            double totalVelocity = velocities.Sum(t => t.Item2);

            return velocities
                .Select(t => new PainterTask<ProportionalPainter>(t.Item1, sqMeters * t.Item2 / totalVelocity));
        }
    }
}

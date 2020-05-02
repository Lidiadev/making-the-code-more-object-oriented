using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public class CompositePainter<TPainter> : IPainter
        where TPainter : IPainter
    {
        private IEnumerable<TPainter> ContainedPainters { get; }

        // Reduces the collection of painters to a single painter.
        private Func<double, IEnumerable<TPainter>, IPainter> Reduce { get; }

        public bool IsAvailable => ContainedPainters.Any(p => p.IsAvailable);

        public CompositePainter(IEnumerable<TPainter> painters,
             Func<double, IEnumerable<TPainter>, IPainter> reduce)
        {
            ContainedPainters = painters;
            Reduce = reduce;
        }

        public TimeSpan EstimateTimeToPaint(double sqMeters)
            => Reduce(sqMeters, ContainedPainters).EstimateTimeToPaint(sqMeters);

        public double EstimateCompensation(double sqMeters)
            => Reduce(sqMeters, ContainedPainters).EstimateCompensation(sqMeters);
    }
}

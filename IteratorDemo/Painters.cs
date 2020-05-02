using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public class Painters
    {
        private IEnumerable<IPainter> ContainedPainters { get; }

        public Painters(IEnumerable<IPainter> painters)
        {
            ContainedPainters = painters;
        }

        public Painters GetAvailable()
            => new Painters(ContainedPainters.Where(p => p.IsAvailable));

        public IPainter GetCheapestOne(double sqMeters)
            => ContainedPainters.WithMinimum(p => p.EstimateTimeToPaint(sqMeters));

        public IPainter GetFastestOne(double sqMeters)
            => ContainedPainters.WithMinimum(p => p.EstimateTimeToPaint(sqMeters));
    }
}
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    class Program
    {
        private static IPainter FindCheapestPainter(double sqMeters, IEnumerable<IPainter> painters)
        {
            return painters
                .Where(x => x.IsAvailable)
                .WithMinimum(x => x.EstimateCompensation(sqMeters));
        }

        static void Main(string[] args)
        {
        }
    }
}

using System.Collections.Generic;

namespace IteratorDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<ProportionalPainter> painters = new ProportionalPainter[10];

            IPainter fastestPainter = CompositePainterFactories.CreateFastestSelector(painters);

            IPainter group = CompositePainterFactories.CombineProportional(painters);
        }
    }
}

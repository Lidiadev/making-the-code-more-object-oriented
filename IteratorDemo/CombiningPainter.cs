using System;
using System.Collections.Generic;
using System.Linq;

namespace IteratorDemo
{
    public class CombiningPainter<TPainter> : CompositePainter<TPainter>
        where TPainter : IPainter
    {
        private IPaitingScheduler<TPainter> Scheduler { get; }

        public CombiningPainter(IEnumerable<TPainter> painters, IPaitingScheduler<TPainter> scheduler)
            : base(painters)
        {
            base.Reduce = Combine;
            Scheduler = scheduler;
        }

        private IPainter Combine(double sqMeters, IEnumerable<TPainter> painters)
        {
            IEnumerable<TPainter> availablePainters = painters.Where(p => p.IsAvailable);

            IEnumerable<PainterTask<TPainter>> schedule = Scheduler.Schedule(sqMeters, availablePainters);

            TimeSpan time = schedule.Max(s => s.Painter.EstimateTimeToPaint(s.SquareMeters));

            double cost = schedule.Sum(s => s.Painter.EstimateCompensation(s.SquareMeters));

            return new ProportionalPainter(time, cost);
        }
    }
}

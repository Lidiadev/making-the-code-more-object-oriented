using System.Collections.Generic;

namespace IteratorDemo
{
    public interface IPaitingScheduler<TPainter>
        where TPainter : IPainter
    {
        IEnumerable<PainterTask<TPainter>> Schedule(double sqMeters, IEnumerable<TPainter> painters);
    }
}

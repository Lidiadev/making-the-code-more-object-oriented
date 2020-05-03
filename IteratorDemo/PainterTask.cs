namespace IteratorDemo
{
    public class PainterTask<TPainter> 
        where TPainter : IPainter
    {
        public TPainter Painter { get; }
        public double SquareMeters { get; }

        public PainterTask(TPainter painter, double sqMeters)
        {
            Painter = painter;
            SquareMeters = sqMeters;
        }
    }
}

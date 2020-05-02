using System;

namespace IteratorDemo
{
    public class ProportionalPainter : IPainter
    {
        public TimeSpan TimePerSqMeter { get; }
        public double DollarsPerHour { get; }

        public ProportionalPainter(TimeSpan timePerSqMeter, double dollarsPerHour)
        {
            TimePerSqMeter = timePerSqMeter;
            DollarsPerHour = dollarsPerHour;
        }

        public bool IsAvailable => true;

        public double EstimateCompensation(double sqMeters)
            => EstimateTimeToPaint(sqMeters).TotalHours * DollarsPerHour;

        public TimeSpan EstimateTimeToPaint(double sqMeters)
            => TimeSpan.FromHours(TimePerSqMeter.TotalHours * sqMeters);
    }
}

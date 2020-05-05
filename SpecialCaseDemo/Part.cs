using System;

namespace SpecialCaseDemo
{
    public class Part
    {
        public DateTime InstallmentDate { get; }
        public DateTime DefectDetectedOn { get; private set; }

        public Part(DateTime installmentDate)
        {
            InstallmentDate = installmentDate;
        }

        public void MarkDefective(DateTime withDate)
        {
            DefectDetectedOn = withDate;
        }
    }
}

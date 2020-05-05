using System;

namespace SpecialCaseDemo
{
    public class VoidWarranty : IWarranty
    {
        [ThreadStatic]
        private static VoidWarranty _instance;

        private VoidWarranty()
        {
        }

        public static VoidWarranty Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new VoidWarranty();

                return _instance;
            }
        }

        public bool IsValidOn(DateTime date) => false;
    }
}

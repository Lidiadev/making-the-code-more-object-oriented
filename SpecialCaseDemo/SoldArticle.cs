using System;

namespace SpecialCaseDemo
{
    public class SoldArticle
    {
        public IWarranty MoneyBackGurantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        private IWarranty NotOperationalWarranty { get; }

        public SoldArticle(IWarranty moneyBackGurantee, IWarranty expressWarranty)
        {
            MoneyBackGurantee = moneyBackGurantee ?? throw new ArgumentNullException(nameof(moneyBackGurantee));
            ExpressWarranty = expressWarranty ?? throw new ArgumentNullException(nameof(expressWarranty));
            NotOperationalWarranty = expressWarranty;
        }

        public void VisibleDamage()
        {
            MoneyBackGurantee = VoidWarranty.Instance;
        }

        public void NotOperational()
        {
            MoneyBackGurantee = VoidWarranty.Instance;
            ExpressWarranty = NotOperationalWarranty;
        }
    }
}

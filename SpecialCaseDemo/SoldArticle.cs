using System;

namespace SpecialCaseDemo
{
    public class SoldArticle
    {
        public IWarranty MoneyBackGurantee { get; }
        public IWarranty ExpressWarranty { get; }

        public SoldArticle(IWarranty moneyBackGurantee, IWarranty expressWarranty)
        {
            MoneyBackGurantee = moneyBackGurantee ?? throw new ArgumentNullException(nameof(moneyBackGurantee));
            ExpressWarranty = expressWarranty ?? throw new ArgumentNullException(nameof(expressWarranty));
        }
    }
}

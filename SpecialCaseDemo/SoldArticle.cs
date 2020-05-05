using SpecialCaseDemo.Common;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SpecialCaseDemo
{
    public class SoldArticle
    {
        private IWarranty NotOperationalWarranty { get; }
        private Option<Part> Circuitry { get; set; } = Option<Part>.None();

        public IWarranty MoneyBackGurantee { get; private set; }
        public IWarranty ExpressWarranty { get; private set; }
        public IWarranty FailedCircuitryWarranty { get; private set; }
        public IWarranty CircuitryWarranty { get; private set; }

        public SoldArticle(IWarranty moneyBackGurantee, IWarranty expressWarranty)
        {
            MoneyBackGurantee = moneyBackGurantee ?? throw new ArgumentNullException(nameof(moneyBackGurantee));
            ExpressWarranty = VoidWarranty.Instance;
            NotOperationalWarranty = expressWarranty ?? throw new ArgumentNullException(nameof(expressWarranty));
            CircuitryWarranty = VoidWarranty.Instance;
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

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry.Do(circuitry =>
            {
                circuitry.MarkDefective(detectedOn);
                CircuitryWarranty = FailedCircuitryWarranty;
            });
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            FailedCircuitryWarranty = extendedWarranty;
        }

        public void ClaimCircuitryWarranty(Action onValidClaim)
        {
            Circuitry
                .Do(circuitry => CircuitryWarranty.Claim(circuitry.DefectDetectedOn, onValidClaim));
        }
    }
}

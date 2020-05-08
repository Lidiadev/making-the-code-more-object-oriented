using RulesDemo.Common;
using RulesDemo.Common.Interfaces;
using System;

namespace RulesDemo
{
    public class SoldArticle
    {
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty MoneyBackGuarantee { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private IOption<Part> Circuitry { get; set; } = Option<Part>.None();
        private IWarrantyRules WarrantyRules { get; }

        public SoldArticle(IWarranty moneyBackGuarantee, 
            IWarranty expressWarranty,
            IWarrantyRulesFactory rulesFactory)
        {
            MoneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            NotOperationalWarranty = expressWarranty ?? throw new ArgumentNullException(nameof(expressWarranty));
            CircuitryWarranty = VoidWarranty.Instance;

            WarrantyRules = rulesFactory
                .Create(ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            CircuitryWarranty = extendedWarranty;
            WarrantyRules.CircuitryOperational();
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            WarrantyRules.CircuitryFailed();
        }

        public void VisibleDamage()
        {
            WarrantyRules.VisibleDamage();
        }

        public void NotOperational()
        {
            WarrantyRules.NotOperational();
        }

        public void Repaired()
        {
            WarrantyRules.Operational();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            WarrantyRules.Claim(onValidClaim);
        }

        private void ClaimMoneyBack(Action action)
        {
            MoneyBackGuarantee.Claim(DateTime.Now, action);
        }

        private void ClaimNotOperationalWarranty(Action action)
        {
            NotOperationalWarranty.Claim(DateTime.Now, action);
        }

        private void ClaimCircuitryWarranty(Action action)
        {
            Circuitry
                .WhenSome()
                .Do(c => CircuitryWarranty.Claim(c.DefectDetectedOn, action))
                .Execute();
        }
    }
}

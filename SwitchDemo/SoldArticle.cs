using SwitchDemo.Common;
using SwitchDemo.Common.Interfaces;
using System;
using System.Collections.Generic;

namespace SwitchDemo
{
    public class SoldArticle
    {
        private IWarranty NotOperationalWarranty { get; }
        private IWarranty MoneyBackGuarantee { get; }
        private IWarranty CircuitryWarranty { get; set; }

        private IOption<Part> Circuitry { get; set; } = Option<Part>.None();

        private DeviceStatus OperationalStatus { get; set; }
        private IReadOnlyDictionary<DeviceStatus, Action<Action>> WarrantyMap { get; }

        public SoldArticle(IWarranty moneyBackGuarantee, 
            IWarranty expressWarranty, 
            IWarrantyMapFactory rulesFactory)
        {
            MoneyBackGuarantee = moneyBackGuarantee ?? throw new ArgumentNullException(nameof(moneyBackGuarantee));
            NotOperationalWarranty = expressWarranty ?? throw new ArgumentNullException(nameof(expressWarranty));
            CircuitryWarranty = VoidWarranty.Instance;

            OperationalStatus = DeviceStatus.AllFine();
            WarrantyMap = rulesFactory.Create(ClaimMoneyBack, ClaimNotOperationalWarranty, ClaimCircuitryWarranty);
        }

        public void InstallCircuitry(Part circuitry, IWarranty extendedWarranty)
        {
            Circuitry = Option<Part>.Some(circuitry);
            CircuitryWarranty = extendedWarranty;
            OperationalStatus = OperationalStatus.CircuitryReplaced();
        }

        public void CircuitryNotOperational(DateTime detectedOn)
        {
            Circuitry
                .WhenSome()
                .Do(c =>
                {
                    c.MarkDefective(detectedOn);
                    OperationalStatus = OperationalStatus.CircuitryFailed();
                })
                .Execute();
        }

        public void VisibleDamage()
        {
            OperationalStatus = OperationalStatus.WithVisibleDamage();
        }

        public void NotOperational()
        {
            OperationalStatus = OperationalStatus.NotOperational();
        }

        public void Repaired()
        {
            OperationalStatus = OperationalStatus.Repaired();
        }

        public void ClaimWarranty(Action onValidClaim)
        {
            WarrantyMap[OperationalStatus].Invoke(onValidClaim);
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
                .Do(c => this.CircuitryWarranty.Claim(c.DefectDetectedOn, action))
                .Execute();
        }
    }
}

using System;

namespace RulesDemo.Rules
{
    public class DefaultRules : IWarrantyRulesFactory
    {
        public IWarrantyRules Create(
            Action<Action> claimMoneyBack, 
            Action<Action> claimNotOperational, 
            Action<Action> claimCircuitry)
         => new NotOperationalRule(claimNotOperational,
                new CircuitryRule(claimCircuitry,
                    new MoneyBackRule(claimMoneyBack,
                        new NotSatisfiedRule())));
    }
}

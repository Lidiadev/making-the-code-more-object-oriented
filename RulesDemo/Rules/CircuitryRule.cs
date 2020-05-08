using System;

namespace RulesDemo.Rules
{
    public class CircuitryRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }

        public CircuitryRule(Action<Action> claimAction, IWarrantyRules next)
            : base(next)
        {
            Claim = Forward;
            ClaimAction = claimAction;
        }

        protected override void HandleCircuitryFailed()
        {
            Claim = ClaimAction;
        }

        protected override void HandleCircuitryOperational()
        {
            Claim = Forward;
        }
    }
}

using System;

namespace RulesDemo.Rules
{
    public class MoneyBackRule : ChainedRule
    {
        private Action<Action> ClaimAction { get; }

        public MoneyBackRule(Action<Action> claimAction, IWarrantyRules next)
            : base(next)
        {
            Claim = Forward;
            ClaimAction = claimAction;
        }

        protected override void HandleCircuitryFailed()
        {
            Claim = ClaimAction;
        }

        protected override void HandleNotOperational()
        {
            Claim = ClaimAction;
        }

        protected override void HandleVisiblyDamaged()
        {
            Claim = Forward;
        }
    }
}

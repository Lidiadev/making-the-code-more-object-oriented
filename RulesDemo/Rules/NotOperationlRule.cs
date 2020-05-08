using System;

namespace RulesDemo.Rules
{
    public class NotOperationalRule : ChainedRule, IWarrantyRules
    {
        private Action<Action> ClaimAction { get; }

        public NotOperationalRule(Action<Action> claimAction, IWarrantyRules next)
            : base(next)
        {
            ClaimAction = claimAction;
            Claim = Forward;
        }

        protected override void HandleNotOperational()
        {
            Claim = ClaimAction;
        }

        protected override void HandleOperational()
        {
            Claim = Forward;
        }
    }
}
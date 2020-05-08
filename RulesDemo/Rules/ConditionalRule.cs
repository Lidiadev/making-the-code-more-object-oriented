using System;

namespace RulesDemo.Rules
{
    public class ConditionalRule : IWarrantyRules
    {
        private Func<bool> Predicate { get; }
        private Action<Action> ClaimAction { get; }
        private IWarrantyRules Next { get; }

        public ConditionalRule(Func<bool> predicate, Action<Action> claimAction, IWarrantyRules next)
        {
            Predicate = predicate;
            ClaimAction = claimAction;
            Next = next;
        }

        public void CircuitryOperational()
        {
            Next.CircuitryOperational();
        }

        public void CircuitryFailed()
        {
            Next.CircuitryFailed();
        }

        public void VisiblyDamaged()
        {
            Next.VisiblyDamaged();
        }

        public void NotOperational()
        {
            Next.NotOperational();
        }

        public void Operational()
        {
            Next.Operational();
        }

        public Action<Action> Claim
        {
            get
            {
                if (Predicate())
                    return AttemptClaim;
                return Forward;
            }
        }

        private void Forward(Action onValidClaim)
        {
            Next.Claim(onValidClaim);
        }

        private void AttemptClaim(Action onValidClaim)
        {
            Action<Action> subsequentAction = Forward;

            ClaimAction(() =>
            {
                onValidClaim();
                subsequentAction = (action) => { };
            });

            subsequentAction(onValidClaim);
        }
    }
}

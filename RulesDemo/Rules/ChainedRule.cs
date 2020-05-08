using System;

namespace RulesDemo.Rules
{
    public abstract class ChainedRule : IWarrantyRules
    {
        private IWarrantyRules Next { get; }

        protected ChainedRule(IWarrantyRules next)
        {
            Next = next;
        }

        public Action<Action> Claim { get; protected set; }

        public void CircuitryOperational()
        {
            HandleCircuitryOperational();
            Next.CircuitryOperational();
        }

        public void CircuitryFailed()
        {
            HandleCircuitryFailed();
            Next.CircuitryFailed();
        }

        public void VisiblyDamaged()
        {
            HandleVisiblyDamaged();
            Next.VisibleDamaged();
        }

        public void NotOperational()
        {
            HandleNotOperational();
            Next.NotOperational();
        }

        public void Operational()
        {
            HandleOperational();
            Next.Operational();
        }

        protected virtual void HandleCircuitryOperational() { }
        protected virtual void HandleCircuitryFailed() { }
        protected virtual void HandleVisiblyDamaged() { }
        protected virtual void HandleNotOperational() { }
        protected virtual void HandleOperational() { }

        protected void Forward(Action onValidClaim) => Next.Claim(onValidClaim);
    }
}

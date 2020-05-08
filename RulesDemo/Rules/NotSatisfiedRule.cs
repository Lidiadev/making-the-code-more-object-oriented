using System;

namespace RulesDemo.Rules
{
    public class NotSatisfiedRule : IWarrantyRules
    {
        public void CircuitryOperational() { }
        public void CircuitryFailed() { }
        public void VisiblyDamaged() { }
        public void NotOperational() { }
        public void Operational() { }

        public Action<Action> Claim => (action) => { };
    }
}

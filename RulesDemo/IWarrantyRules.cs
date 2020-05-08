using System;

namespace RulesDemo
{
    public interface IWarrantyRules
    {
        void CircuitryOperational();
        void CircuitryFailed();
        void VisiblyDamaged();
        void NotOperational();
        void Operational();
        Action<Action> Claim { get; }
    }
}
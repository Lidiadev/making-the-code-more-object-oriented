using System;

namespace RulesDemo
{
    public interface IWarrantyRulesFactory
    {
        IWarrantyRules Create(
            Action<Action> claimMoneyBack,
            Action<Action> claimNotOperational,
            Action<Action> claimCircuitry);
    }
}
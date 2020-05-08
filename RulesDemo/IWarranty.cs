using System;

namespace RulesDemo
{
    public interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim );
    }
}
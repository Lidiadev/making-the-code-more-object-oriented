using System;

namespace SpecialCaseDemo
{
    public interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim );
    }
}
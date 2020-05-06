using System;

namespace SwitchDemo
{
    public interface IWarranty
    {
        void Claim(DateTime onDate, Action onValidClaim );
    }
}
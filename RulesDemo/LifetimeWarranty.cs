using System;

namespace RulesDemo
{
    public class LifetimeWarranty : IWarranty
    {
        private DateTime IssuingDate { get; }

        public LifetimeWarranty(DateTime issuingDate)
        {
            IssuingDate = issuingDate;
        }
       
        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate))
                return;

            onValidClaim();
        }
        public bool IsValidOn(DateTime date)
          => date.Date >= IssuingDate;
    }
}

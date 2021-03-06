﻿using System;

namespace SpecialCaseDemo
{
    public class TimeLimitedWarranty : IWarranty
    {
        private DateTime DateIssued{ get;}
        private TimeSpan Duration { get; }

        public TimeLimitedWarranty(DateTime dateIssued, TimeSpan duration)
        {
            DateIssued = dateIssued.Date;
            Duration = TimeSpan.FromDays(duration.Days);
        }

        public void Claim(DateTime onDate, Action onValidClaim)
        {
            if (!IsValidOn(onDate))
                return;

            onValidClaim();
        }

        private bool IsValidOn(DateTime date)
           => date.Date >= DateIssued && date.Date < DateIssued + Duration;
    }
}

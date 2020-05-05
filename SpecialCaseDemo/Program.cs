using System;

namespace SpecialCaseDemo
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            article.MoneyBackGurantee.Claim(now, () => Console.WriteLine("Offer money back."));
            article.ExpressWarranty.Claim(now, () => Console.WriteLine("Offer repair."));
        }

        static void Main(string[] args)
        {
            DateTime sellingDate = new DateTime(2020, 5, 1);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new LifetimeWarranty(sellingDate);

            SoldArticle goods = new SoldArticle(moneyBack, warranty);
            ClaimWarranty(goods);

            Console.ReadLine();
        }
    }
}

using System;

namespace SpecialCaseDemo
{
    class Program
    {
        static void ClaimWarranty(SoldArticle article)
        {
            DateTime now = DateTime.Now;

            if (article.MoneyBackGurantee.IsValidOn(now))
            {
                Console.WriteLine("Offer money back.");
            }

            if (article.ExpressWarranty.IsValidOn(now))
            {
                Console.WriteLine("Offer repair.");
            }
        }

        static void Main(string[] args)
        {
            DateTime sellingDate = new DateTime(2020, 5, 1);
            TimeSpan moneyBackSpan = TimeSpan.FromDays(30);
            TimeSpan warrantySpan = TimeSpan.FromDays(365);

            IWarranty moneyBack = new TimeLimitedWarranty(sellingDate, moneyBackSpan);
            IWarranty warranty = new TimeLimitedWarranty(sellingDate, warrantySpan);

            IWarranty noMoneyBack = VoidWarranty.Instance;

            SoldArticle goods = new SoldArticle(noMoneyBack, warranty);
            ClaimWarranty(goods);

            Console.ReadLine();
        }
    }
}

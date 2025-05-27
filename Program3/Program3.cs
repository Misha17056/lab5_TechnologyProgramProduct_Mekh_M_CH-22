using System;

namespace Program3
{
    public interface IDiscountStrategy
    {
        double ApplyDiscount(double price);
    }

    public class SeasonalDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            return price * 0.8;
        }
    }

    public class LoyaltyDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            return price * 0.85;
        }
    }

    public class PromotionalDiscount : IDiscountStrategy
    {
        public double ApplyDiscount(double price)
        {
            return price * 0.9;
        }
    }

    public class DiscountContext
    {
        private IDiscountStrategy _strategy;

        public void SetStrategy(IDiscountStrategy strategy)
        {
            _strategy = strategy;
        }

        public double GetFinalPrice(double price)
        {
            if (_strategy == null)
                return price;
            return _strategy.ApplyDiscount(price);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            DiscountContext context = new DiscountContext();
            
            context.SetStrategy(new SeasonalDiscount());
            double price = 100.0;
            double finalPrice = context.GetFinalPrice(price);
            Console.WriteLine($"Final price with seasonal discount: {finalPrice}");

            context.SetStrategy(new LoyaltyDiscount());
            finalPrice = context.GetFinalPrice(price);
            Console.WriteLine($"Final price with loyalty discount: {finalPrice}");

            context.SetStrategy(new PromotionalDiscount());
            finalPrice = context.GetFinalPrice(price);
            Console.WriteLine($"Final price with promotional discount: {finalPrice}");

            Console.ReadLine();
        }
    }
}

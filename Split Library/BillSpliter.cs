using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Split_Library
{
    public class BillSpliter
    {
        //Return split amount per person
        public static decimal SplittingByPeople(decimal amount, int numberOfPeople)
        {
            if (numberOfPeople == 0)
            {
                throw new ArgumentOutOfRangeException(nameof(numberOfPeople),"Number of people must be positive.");
            }
            return amount/numberOfPeople;
        }

        //Calculation of Tip
        public static Dictionary<string, decimal> CalculateTip(Dictionary<string, decimal> mealCosts, float tipPercentage)
        {
            //mealCosts null
            if (mealCosts == null)
                throw new ArgumentNullException(nameof(mealCosts), "Cost cannot be null.");
            //mealCost zero
            if (mealCosts.Count == 0)
                throw new ArgumentException("Cost cannot be empty.", nameof(mealCosts));

            decimal totalMealCost = mealCosts.Values.Sum();
            if (totalMealCost == 0m)
                throw new InvalidOperationException("The total meal cost cannot be zero when calculating tips.");

            var tipAmounts = new Dictionary<string, decimal>();

            foreach (var meal in mealCosts)
            {
                decimal shareOfTotal = meal.Value / totalMealCost;
                decimal tipAmount = shareOfTotal * totalMealCost * (decimal)tipPercentage / 100;
                tipAmounts.Add(meal.Key, tipAmount);
            }

            return tipAmounts;
        }
    

        public static decimal TipPerPerson(decimal totalPrice, int numberOfPeople, float tipPercentage)
        {
            if (numberOfPeople <= 0)
                throw new ArgumentException("Number of people should be > zero.");
            decimal tipTotal = totalPrice * (decimal)(tipPercentage / 100);
            return tipTotal / numberOfPeople;
        }
    }
}

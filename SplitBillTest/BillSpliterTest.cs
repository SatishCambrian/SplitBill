using Split_Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SplitBillTest
{
    [TestClass]
    public class BillSpliterTest
    {
        [TestMethod]
        public void Should_Return_CorrectTip()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal> { { "Sushan", 120m }, { "Saurav", 150m } };
            float tipPercentage = 15.0f;

            // Act
            var tips = BillSpliter.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(18m, tips["Sushan"]);
            Assert.AreEqual(22.5m, tips["Saurav"]);
        }

        [TestMethod]
        public void Should_Return_ZeroTip()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal> { { "Sushma", 200m } };
            float tipPercentage = 0f;

            // Act
            var tips = BillSpliter.CalculateTip(mealCosts, tipPercentage);

            // Assert
            Assert.AreEqual(0m, tips["Sushma"]);
        }

        [TestMethod]
        public void Should_Return_NegativeTip_ThrowsArgumentException()
        {
            // Arrange
            var mealCosts = new Dictionary<string, decimal> { { "Ram", 100m } };

            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => BillSpliter.CalculateTip(mealCosts, -5f));
        }

        //Tips Testcases
        // Tests for TipPerPerson
        
        [TestMethod]
        public void ReturnsCorrectAmount()
        {
            // Act
            var tipPerPerson = BillSpliter.TipPerPerson(300m, 3, 10f);

            // Assert
            Assert.AreEqual(10m, tipPerPerson);
        }

        [TestMethod]
        public void NegativeTipPercentage_ThrowsArgumentException()
        {
            // Act and Assert
            Assert.ThrowsException<ArgumentException>(() => BillSpliter.TipPerPerson(250m, 3, -15f));
        }
    }
}

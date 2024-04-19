using Split_Library;
namespace SplitBillTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void SplitEvenlyTest()
        {

            //Arrange
            var amount = 12m;
            var numberOfPeople = 2;
            var result = amount / numberOfPeople;

            //Act
            var actual = BillSpliter.SplittingByPeople(amount, numberOfPeople);

            //Assert
            Assert.AreEqual(result, actual);
        }

        [TestMethod]
        public void ZeroPeopleTest()
        {
            //Arrange
            var amount = 25.0m;
            var numberOfPeople = 0;

            Assert.ThrowsException<ArgumentOutOfRangeException>(()=>BillSpliter.SplittingByPeople(amount,numberOfPeople));
        }

        [TestMethod]
        public void RoundUpForUnevenSplitTest()
        {
            //Act
            var amount = 10.0m;
            var numberOfPeople = 2;
            var result = Math.Ceiling(amount / numberOfPeople); // ceiling to account for rounding

            //Arrange
            var actual = BillSpliter.SplittingByPeople(amount, numberOfPeople);

            //Assert
            Assert.AreEqual(result, actual);
        }
    }
}
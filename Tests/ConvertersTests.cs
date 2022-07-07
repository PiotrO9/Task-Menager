namespace Tests
{
    public class ConvertersTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            int temp = SecondsToMinutes.SecondsToMinutesCalculation(1);

            Assert.Pass();
        }
    }
}
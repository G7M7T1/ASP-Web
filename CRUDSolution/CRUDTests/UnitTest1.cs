namespace CRUDTests
{
    public class UnitTest
    {
        [Fact]
        public void TestMath()
        {
            MyMath mm = new MyMath();
            int input1 = 10; int input2 = 20;

            int expectedValue = 30;

            int actualValue = mm.Add(input1, input2);

            Assert.Equal(expectedValue, actualValue);
        }
    }
}
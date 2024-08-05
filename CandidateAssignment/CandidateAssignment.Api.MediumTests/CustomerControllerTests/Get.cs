namespace CandidateAssignment.Api.MediumTests.CustomerControllerTests
{
    [TestClass]
    public class Get : AssemblyTestBase
    {
        [TestMethod]
        public void Get_Should_Return_Empty_When_No_Customers()
        {
            var result = Sut.Get().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        [DataRow(1)]
        [DataRow(10)]
        public void Get_Should_Return_All_Customers(int numberOfCustomers)
        {
            SutAddCustomer(numberOfCustomers);

            var result = Sut.Get().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(numberOfCustomers, result.Count);
        }
    }
}
using CandidateAssignment.Domain.Models.Entities;

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
            List<Customer> customers = new List<Customer>();
            for (int i = 0; i < numberOfCustomers; i++)
            {
                customers.Add(CreateCustomer());
            }
            SutAddCustomersToDb(customers.ToArray());


            var result = Sut.Get().ToList();

            Assert.IsNotNull(result);
            Assert.AreEqual(numberOfCustomers, result.Count);
        }
    }
}
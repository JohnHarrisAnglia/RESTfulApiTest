using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAssignment.Api.MediumTests.CustomerControllerTests
{
    [TestClass]
    public class GetByIdAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task GetByIdAsync_Should_Return_NotFound_If_Not_Found()
        {
            var customer = CreateCustomer();
            SutAddCustomersToDb(customer);

            var result = (await Sut.GetByIdAsync(customer.Id + 1));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetByIdAsync_Should_Return_Correct_Customer()
        {
            var customer = CreateCustomer();
            SutAddCustomersToDb(customer);

            var result = await Sut.GetByIdAsync(customer.Id);

            Assert.IsNotNull(result);

            //This works but I hate it
            Assert.AreEqual(customer.Id, ((result as ObjectResult).Value as Customer).Id);
        }
    }
}

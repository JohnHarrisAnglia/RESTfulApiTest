using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAssignment.Api.MediumTests.CustomerControllerTests
{
    [TestClass]
    public class CreateAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task CreateAsync_Should_Return_Created()
        {
            var customer = CreateCustomer();

            var result = await Sut.CreateAsync(customer);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task CreateAsync_Should_Create_Customer_In_DB()
        {
            var customer = CreateCustomer();

            var result = await Sut.CreateAsync(customer);

            var savedCustomer = await Sut.GetByIdAsync(customer.Id);

            Assert.IsNotNull(result);
            Assert.IsNotNull(savedCustomer);
            Assert.AreEqual(((savedCustomer as ObjectResult).Value as Customer).Id, customer.Id);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public async Task CreateAsync_Should_Throw_Error_If_Conflicting_Id()
        {
            var customer = CreateCustomer();

            var result = await Sut.CreateAsync(customer);
            await Sut.CreateAsync(customer);
        }
    }
}

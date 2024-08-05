using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CandidateAssignment.Api.SmallTests.CustomerControllerTests
{
    [TestClass]
    public class CreateAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task CreateAsync_Should_Call_Repository_GetAsync()
        {
            var customer = new Customer("", new Address(), "", "");

            var result = await Controller.CreateAsync(customer);

            await CustomerRepo.Received().CreateAsync(customer);
        }

        [TestMethod]
        public async Task CreateAsync_Should_Return_Created()
        {
            var name = "Test 1";
            var customer = new Customer(name, new Address(), "", "");
            CustomerRepo.CreateAsync(customer).Returns(Task.FromResult<object>(null));

            var result = await Controller.CreateAsync(customer);

            Assert.IsInstanceOfType(result, typeof(CreatedResult));
            Assert.IsNotNull(result);
        }   
    }
}

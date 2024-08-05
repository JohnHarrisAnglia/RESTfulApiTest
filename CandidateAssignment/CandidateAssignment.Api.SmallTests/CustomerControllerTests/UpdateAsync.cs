using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CandidateAssignment.Api.SmallTests.CustomerControllerTests
{
    [TestClass]
    public class UpdateAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task UpdateAsync_Should_Call_Repository_GetAsync()
        {
            var customer = new Customer("", new Address(), "", "");

            var result = await Controller.UpdateAsync(customer);

            await CustomerRepo.Received().UpdateAsync(customer);
        }

        [TestMethod]
        public async Task UpdateAsync_Should_Return_NotContent_If_Succesful()
        {
            var customer = new Customer("", new Address(), "", "");
            CustomerRepo.CreateAsync(customer).Returns(Task.FromResult<object>(null));

            var result = await Controller.UpdateAsync(customer);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            Assert.IsNotNull(result);

        }
    }
}

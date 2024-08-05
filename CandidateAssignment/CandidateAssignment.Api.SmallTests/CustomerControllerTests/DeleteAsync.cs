using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;

namespace CandidateAssignment.Api.SmallTests.CustomerControllerTests
{
    [TestClass]
    public class DeleteAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task DeleteAsync_Should_Call_Repository_GetAsync()
        {
            var customer = new Customer() { Id = 1 };

            var result = await Controller.DeleteAsync(customer.Id);

            await CustomerRepo.Received().DeleteAsync(customer.Id);
        }

        [TestMethod]
        public async Task DeleteAsync_Should_Return_NotContent_If_Succesful()
        {
            var customer = new Customer() { Id = 1 };
            CustomerRepo.DeleteAsync(1).Returns(Task.FromResult<object>(null));

            var result = await Controller.DeleteAsync(customer.Id);

            Assert.IsInstanceOfType(result, typeof(NoContentResult));
            Assert.IsNotNull(result);

        }
    }
}

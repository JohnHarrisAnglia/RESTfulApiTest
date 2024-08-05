using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using NSubstitute;
using NSubstitute.ReturnsExtensions;

namespace CandidateAssignment.Api.SmallTests.CustomerControllerTests
{
    [TestClass]
    public class GetByIdAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task GetByIdAsync_Should_Call_Repository_GetAsync()
        {
            await Controller.GetByIdAsync(1);

            await CustomerRepo.Received().GetByIdAsync(1);
        }

        [TestMethod]
        public async Task GetByIdAsync_Should_Return_NotFound_If_Not_Found()
        {
            CustomerRepo.GetByIdAsync(Arg.Any<int>()).ReturnsNull();

            var result = await Controller.GetByIdAsync(2);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetByIdAsync_Should_Return_Customer()
        {
            int id = Arg.Any<int>();
            CustomerRepo.GetByIdAsync(id).Returns(Task.FromResult(new Customer() { Id = id }));

            var result = await Controller.GetByIdAsync(id);

            Assert.IsNotNull(result);
            Assert.AreEqual(id, ((result as ObjectResult).Value as Customer).Id);
        }
    }
}

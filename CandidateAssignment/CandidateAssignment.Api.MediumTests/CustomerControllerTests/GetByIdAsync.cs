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
            SutAddCustomer(1);

            var result = (await Sut.GetByIdAsync(2));

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NotFoundResult));
        }

        [TestMethod]
        public async Task GetByIdAsync_Should_Return_Correct_Customer()
        {
            SutAddCustomer(1);

            var result = await Sut.GetByIdAsync(1);

            Assert.IsNotNull(result);

            //This works but I hate it
            Assert.AreEqual(1, ((result as ObjectResult).Value as Customer).Id);
        }
    }
}

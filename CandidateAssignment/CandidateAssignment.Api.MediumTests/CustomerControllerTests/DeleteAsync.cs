using Microsoft.AspNetCore.Mvc;

namespace CandidateAssignment.Api.MediumTests.CustomerControllerTests
{
    [TestClass]
    public class DeleteAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task DeleteAsync_Should_Return_NoContent()
        {
            var customer = CreateCustomer();
            await Sut.CreateAsync(customer);

            var result = await Sut.DeleteAsync(customer.Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(NoContentResult));
        }

        [TestMethod]
        public async Task DeleteAsync_Should_Delete_Customer_In_DB()
        {
            var customer = CreateCustomer();
            await Sut.CreateAsync(customer);

            var result = await Sut.DeleteAsync(customer.Id);

            var savedCustomer = await Sut.GetByIdAsync(customer.Id);
            Assert.IsNotNull(result);
            Assert.IsNotNull(savedCustomer);
            Assert.IsInstanceOfType(savedCustomer, typeof(NotFoundResult));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public async Task DeleteAsync_Should_Throw_Error_If_NotExists()
        {
            var customer = CreateCustomer();

            var result = await Sut.DeleteAsync(customer.Id);
        }
    }
}

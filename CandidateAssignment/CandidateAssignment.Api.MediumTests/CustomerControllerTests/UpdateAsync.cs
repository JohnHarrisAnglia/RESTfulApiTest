using CandidateAssignment.Domain.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CandidateAssignment.Api.MediumTests.CustomerControllerTests
{
    [TestClass]
    public class UpdateAsync : AssemblyTestBase
    {
        [TestMethod]
        public async Task UpdateAsync_Should_Return_Created()
        {
            var customer = CreateCustomer();
            Sut.CreateAsync(customer);

            var result = await Sut.UpdateAsync(customer);

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public async Task UpdateAsync_Should_Update_Customer_In_DB()
        {
            var customer = CreateCustomer();
            Sut.CreateAsync(customer);
            customer.Name = "testing";

            var result = await Sut.UpdateAsync(customer);

            var savedCustomer = await Sut.GetByIdAsync(customer.Id);

            Assert.IsNotNull(result);
            Assert.IsNotNull(savedCustomer);
            Assert.AreEqual(((savedCustomer as ObjectResult).Value as Customer).Name, customer.Name);
        }


        [TestMethod]
        [ExpectedException(typeof(DbUpdateConcurrencyException))]
        public async Task UpdateAsync_Should_Throw_Error_If_Not_Created()
        {
            var customer = CreateCustomer();

            var result = await Sut.UpdateAsync(customer);
            await Sut.CreateAsync(customer);
        }
    }
}

using CandidateAssignment.Api.Controllers;
using CandidateAssignment.Domain.Repository;
using CandidateAssignment.Domain.Models.Entities;
using CandidateAssignment.DataAccess;
using CandidateAssignment.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace CandidateAssignment.Api.MediumTests
{
    public class AssemblyTestBase
    {
        protected CustomerController Sut;
        protected IGenericRepository<Customer> CustomerRepo;
        private ApplicationDbContext Context;

        [TestInitialize]
        public void Init()
        {
            var _contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseInMemoryDatabase("BloggingControllerTest")
                .ConfigureWarnings(b => b.Ignore(InMemoryEventId.TransactionIgnoredWarning))
                .Options;

            var context = new ApplicationDbContext(_contextOptions);

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();

            Context = context;

            CustomerRepo = new GenericRepository<Customer>(context);

            Sut = new CustomerController(CustomerRepo);
        }

        [TestCleanup]
        public void ClenUp()
        {
            Context.Dispose();
        }

        protected void SutAddCustomer(int numberOfCustomers)
        {
            for (int i = 0; i < numberOfCustomers; i++)
            {
                Context.AddRange(new Customer($"testman {i}", new Address("", "", "", ""), "+445676788899", ""));
            }

            Context.SaveChanges();
        }
    }
}

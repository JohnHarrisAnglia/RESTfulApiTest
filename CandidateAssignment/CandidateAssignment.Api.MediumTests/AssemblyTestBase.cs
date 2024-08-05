using CandidateAssignment.Api.Controllers;
using CandidateAssignment.Domain.Repository;
using CandidateAssignment.Domain.Models.Entities;
using CandidateAssignment.DataAccess;
using CandidateAssignment.DataAccess.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using AutoFixture;

namespace CandidateAssignment.Api.MediumTests
{
    public class AssemblyTestBase
    {
        protected CustomerController Sut;
        protected IGenericRepository<Customer> CustomerRepo;
        protected ApplicationDbContext Context;
        private Fixture Fixture;

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

            Fixture = new Fixture();
            Fixture.Behaviors.OfType<ThrowingRecursionBehavior>().ToList().ForEach(b => Fixture.Behaviors.Remove(b));
            Fixture.Behaviors.Add(new OmitOnRecursionBehavior());
            Fixture.Customize<Customer>(c => c.With(p => p.Address, Fixture.Create<Address>()));
        }

        [TestCleanup]
        public void ClenUp()
        {
            Context.Dispose();
        }

        protected void SutAddCustomersToDb(params Customer[] customers)
        {
            Context.AddRange(customers);
            Context.SaveChanges();
            
        }

        protected Customer CreateCustomer()
        {
            return Fixture.Create<Customer>();
        }
    }
}

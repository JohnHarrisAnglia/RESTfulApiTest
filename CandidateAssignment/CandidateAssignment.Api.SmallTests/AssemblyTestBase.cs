using CandidateAssignment.Api.Controllers;
using CandidateAssignment.Domain.Repository;
using CandidateAssignment.Domain.Models.Entities;
using NSubstitute;

namespace CandidateAssignment.Api.SmallTests
{
    public class AssemblyTestBase
    {
        protected CustomerController Controller;
        protected IGenericRepository<Customer> CustomerRepo;

        [TestInitialize]
        public void Init()
        {
            CustomerRepo = Substitute.For<IGenericRepository<Customer>>();

            Controller = new CustomerController(CustomerRepo);
        }
    }
}

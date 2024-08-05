using CandidateAssignment.Domain.Models.Entities;
using CandidateAssignment.Domain.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CandidateAssignment.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly IGenericRepository<Customer> customerRepo;

        public CustomerController(IGenericRepository<Customer> customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return customerRepo.GetAll();
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var result = await customerRepo.GetByIdAsync(id);

            return result == null ? NotFound() : Ok(result);
        }
    }
}

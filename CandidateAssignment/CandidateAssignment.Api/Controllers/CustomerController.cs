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

        [HttpPost]
        public async Task<IActionResult> CreateAsync(Customer customer)
        {
            await customerRepo.CreateAsync(customer);

            return Created();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAsync(Customer customer)
        {
            await customerRepo.UpdateAsync(customer);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            await customerRepo.DeleteAsync(id);

            return NoContent();
        }
    }
}
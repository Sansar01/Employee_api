using Employee_api.Models;
using Employee_api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        // GET: api/<EmployeeController>
        private readonly ICustomerServices _customerService;
        public CustomerController(ICustomerServices customerServices)
        {
            _customerService = customerServices;
        }
        // GET: api/Category
        //[Authorize]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customer = await _customerService.Get();
            return Ok(customer);
        }

        // GET api/CategoryController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var customer = await _customerService.Get(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(customer);
        }

        // POST api/CategoryController
        [HttpPost]
        public async Task<IActionResult> Post(Customer customer)
        {
            customer.emp_Name = null;
            await _customerService.Create(customer);
            return Ok("created successfully");
        }

        // PUT api/CategoryController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Customer customer)
        {
            customer.emp_Name = null;
            var customers = await _customerService.Get(id);
            if (customers == null)
                return NotFound();
            await _customerService.Update(id, customer);
            return Ok("updated successfully");
        }

        // DELETE api/CategoryController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var customer = await _customerService.Get(id);
            if (customer == null)
                return NotFound();
            await _customerService.Delete(id);
            return Ok("deleted successfully");
        }
    }
}

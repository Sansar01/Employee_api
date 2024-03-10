using Employee_api.Models;
using Employee_api.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Employee_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        // GET: api/<EmployeeController>
        private readonly IEmployeeServices _employeeService;
        public EmployeeController(IEmployeeServices employeeServices)
        {
            _employeeService = employeeServices;
        }
        // GET: api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var employees = await _employeeService.Get();
            return Ok(employees);
        }

        // GET api/CategoryController/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var employee = await _employeeService.Get(id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }

        // POST api/CategoryController
        [HttpPost]
        public async Task<IActionResult> Post(Employee employee)
        {
            await _employeeService.Create(employee);
            return Ok("created successfully");
        }

        // PUT api/CategoryController/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody] Employee employee)
        {
            var employees = await _employeeService.Get(id);
            if (employees == null)
                return NotFound();
            await _employeeService.Update(id, employee);
            return Ok("updated successfully");
        }

        // DELETE api/CategoryController/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var employee = await _employeeService.Get(id);
            if (employee == null)
                return NotFound();
            await _employeeService.Delete(id);
            return Ok("deleted successfully");
        }
    }
}

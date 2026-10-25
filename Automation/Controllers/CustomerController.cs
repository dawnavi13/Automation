using Automation.Interfaces;
using Automation.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Automation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;
        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetCustomerList")]
        public async Task<IActionResult> GetCustomerList()
        {
            var customers = await _customerService.GetAllCustomers();
            return Ok(customers);
        }

        [HttpPost("SaveCustomer")]
        public async Task<IActionResult> SaveCustomer([FromBody] Customer customer)
        {
            int result = await _customerService.SaveCustomer(customer);
            return Ok(result);
        }

        [HttpPut("UpdateCustomer/{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, [FromBody] Customer model)
        {
            int result = await _customerService.UpdateCustomerDetails(id, model);
            return Ok();
        }

        [HttpDelete("DeleteCutomer/{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            await _customerService.DeleteCustomerDetails(id);
            return Ok();
        }
    }
}

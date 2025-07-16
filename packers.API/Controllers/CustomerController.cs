using Microsoft.AspNetCore.Mvc;
using packers.Application.DTOs;
using packers.Application.Interfaces.Users;
using packers.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace packers.API.Controllers
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

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var customers = await _customerService.GetAllCustomersAsync();
            return Ok(customers);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var customer = await _customerService.GetCustomerByIdAsync(id);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CustomerDto customer)
        {
            var created = await _customerService.CreateCustomerAsync(customer);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Customer customer)
        {
            var updated = await _customerService.UpdateCustomerAsync(customer);
            return Ok(updated);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _customerService.DeleteCustomerAsync(id);
            return NoContent();
        }

        [HttpGet("by-email/{email}")]
        public async Task<IActionResult> GetByEmail(string email)
        {
            var customer = await _customerService.GetCustomerByEmailAsync(email);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("by-phone/{phone}")]
        public async Task<IActionResult> GetByPhone(string phone)
        {
            var customer = await _customerService.GetCustomerByPhoneAsync(phone);
            if (customer == null) return NotFound();
            return Ok(customer);
        }

        [HttpGet("by-status/{status}")]
        public async Task<IActionResult> GetByStatus(string status)
        {
            var customers = await _customerService.GetCustomersByStatusAsync(status);
            return Ok(customers);
        }
    }
} 
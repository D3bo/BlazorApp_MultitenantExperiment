using BlazorApp2.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CustomerController : ControllerBase
    {
        private readonly MultipleDbContext _context;

        public CustomerController(MultipleDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult> GetCustomers()
        {
            var customer = await _context.Customers.ToListAsync();
            return Ok(customer);
        }
    }
}

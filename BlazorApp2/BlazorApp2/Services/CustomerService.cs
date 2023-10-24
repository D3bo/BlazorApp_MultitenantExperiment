using BlazorApp2.Data;
using BlazorApp2.Shared.Entity;
using BlazorApp2.Shared.Service;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly MultipleDbContext _context;

        public CustomerService(MultipleDbContext context)
        {
            _context = context;
        }

        public async Task<List<Customer>> GetCustomers()
        {
            try
            {
                return await _context.Customers.ToListAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
         
        }
    }
}

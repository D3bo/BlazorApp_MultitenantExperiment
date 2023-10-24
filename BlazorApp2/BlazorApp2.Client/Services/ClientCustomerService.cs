using BlazorApp2.Shared.Entity;
using BlazorApp2.Shared.Service;

namespace BlazorApp2.Client.Services
{
    public class ClientCustomerService : ICustomerService
    {
        public Task<List<Customer>> GetCustomers()
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlazorApp2.Shared.Entity;

namespace BlazorApp2.Shared.Service
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetCustomers();
    }
}

using System;
using System.Threading.Tasks;
using DShop.Services.Discounts.Domain;
using DShop.Services.Discounts.Messages.Events;

namespace DShop.Services.Discounts.Repositories
{
    public interface ICustomerRepository
    {
        Task<Customer> GetAsync(Guid id);
        Task AddAsync(Customer customer);
    }
}
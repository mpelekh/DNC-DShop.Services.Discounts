using System;
using System.Threading.Tasks;
using DShop.Common.Mongo;
using DShop.Services.Discounts.Domain;

namespace DShop.Services.Discounts.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly IMongoRepository<Customer> _repository;

        public CustomerRepository(IMongoRepository<Customer> repository)
        {
            _repository = repository;
        }

        public Task<Customer> GetAsync(Guid id)
            => _repository.GetAsync(id);

        public Task AddAsync(Customer customer)
            => _repository.AddAsync(customer);
    }
}
using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Discounts.Domain;
using DShop.Services.Discounts.Messages.Commands;
using DShop.Services.Discounts.Messages.Events;
using DShop.Services.Discounts.Repositories;
using Microsoft.Extensions.Logging;

namespace DShop.Services.Discounts.Handlers.Customers
{
    public class CreateCustomerHandler : IEventHandler<CustomerCreated>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly ILogger<CreateCustomerHandler> _logger;
        
        public CreateCustomerHandler(ICustomerRepository customerRepository, ILogger<CreateCustomerHandler> logger)
        {
            _customerRepository = customerRepository;
            _logger = logger;
        }

        public async Task HandleAsync(CustomerCreated @event, ICorrelationContext context)
        {
            await _customerRepository.AddAsync(new Customer(@event.Id));
            _logger.LogInformation($"Created customer with id: '{@event.Id}'.");
        }
    }
}
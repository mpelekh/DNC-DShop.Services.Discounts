using System.Threading.Tasks;
using DShop.Common.Consul;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Discounts.Dto;
using DShop.Services.Discounts.Messages.Events;

namespace DShop.Services.Discounts.Handlers.Orders
{
    public class OrderCompletedHandler : IEventHandler<OrderCompleted>
    {
        private readonly IConsulHttpClient _consulHttpClient;

        public OrderCompletedHandler(IConsulHttpClient consulHttpClient)
        {
            _consulHttpClient = consulHttpClient;
        }
        public async Task HandleAsync(OrderCompleted @event, ICorrelationContext context)
        {
            var orderDto = await _consulHttpClient
                .GetAsync<OrderDetailsDto>($"orders-service/orders/{@event.Id}");
            
            await Task.CompletedTask;
        }
    }
}
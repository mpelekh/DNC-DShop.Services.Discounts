using System.Threading.Tasks;
using DShop.Common.Consul;
using DShop.Common.Handlers;
using DShop.Common.RabbitMq;
using DShop.Services.Discounts.Dto;
using DShop.Services.Discounts.Messages.Events;
using DShop.Services.Discounts.Services;

namespace DShop.Services.Discounts.Handlers.Orders
{
    public class OrderCompletedHandler : IEventHandler<OrderCompleted>
    {
        private readonly IOrdersService _ordersService;

        public OrderCompletedHandler(IOrdersService ordersService)
        {
            _ordersService = ordersService;
        }
        public async Task HandleAsync(OrderCompleted @event, ICorrelationContext context)
        {
            var orderDto = await _ordersService
                .GetAsync(@event.Id);
            
            await Task.CompletedTask;
        }
    }
}
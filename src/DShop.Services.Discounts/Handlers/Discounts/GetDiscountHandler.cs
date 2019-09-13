using System.Threading.Tasks;
using DShop.Common.Handlers;
using DShop.Common.Mongo;
using DShop.Services.Discounts.Domain;
using DShop.Services.Discounts.Dto;
using DShop.Services.Discounts.Queries;

namespace DShop.Services.Discounts.Handlers.Discounts
{
    public class GetDiscountHandler : IQueryHandler<GetDiscount, DiscountDetailsDto>
    {
        private readonly IMongoRepository<Discount> _discountRepository;
        private readonly IMongoRepository<Customer> _customerRepository;

        public GetDiscountHandler(IMongoRepository<Discount> discountRepository, IMongoRepository<Customer> customerRepository)
        {
            _discountRepository = discountRepository;
            _customerRepository = customerRepository;
        }
        
        public async Task<DiscountDetailsDto> HandleAsync(GetDiscount query)
        {
            var discount = await _discountRepository.GetAsync(query.Id);

            if (discount is null)
            {
                return null;
            }

            var customer = await _customerRepository.GetAsync(discount.CustomerId);

            return new DiscountDetailsDto
            {
                Customer = new CustomerDto
                {
                    Id = customer.Id,
                    Email = customer.Email,
                },
                Discount = new DiscountDto
                {
                    Id = discount.Id,
                    CustomerId = discount.CustomerId,
                    Code = discount.Code,
                    Percentage = discount.Percentage,
                    Available = !discount.UsedAt.HasValue
                }
            };
        }
    }
}
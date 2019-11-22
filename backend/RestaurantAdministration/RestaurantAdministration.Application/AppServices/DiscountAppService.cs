
using RestaurantAdministration.Application.Dtos;
using RestaurantAdministration.Application.Interfaces;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.AppServices
{
    public class DiscountAppService : IDiscountAppService
    {
        private readonly IDiscountRepository _repository;

        public DiscountAppService(IDiscountRepository repository)
        {
            _repository = repository;
        }
        public async Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto)
        {
            Discount discount = discountDto.ToEntity();
            discount.IsUsed = false;
            Discount created = await _repository.AddDiscountAsync(discount);

            if(created == null)
            {
                throw new Exception("Discount already exists.");
            }

            return new DiscountDto(created);
        }

        public async Task DeleteDiscountAsync(int id)
        {
            bool isSuccess = await _repository.DeleteDiscountAsync(id);

            if (!isSuccess)
            {
                throw new Exception("Discount does not exist.");
            }
        }

        public async Task<IEnumerable<DiscountDto>> GetAllDiscountAsync()
        {
            IEnumerable<Discount> discounts = await _repository.GetAllDiscountAsync();
            return discounts.Select(d => new DiscountDto(d));
        }
    }
}

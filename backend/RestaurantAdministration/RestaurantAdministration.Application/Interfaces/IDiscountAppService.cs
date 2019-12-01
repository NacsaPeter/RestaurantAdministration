using RestaurantAdministration.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.Application.Interfaces
{
    public interface IDiscountAppService
    {
        Task<DiscountDto> CreateDiscountAsync(DiscountDto discountDto);
        Task DeleteDiscountAsync(int id);
        Task<IEnumerable<DiscountDto>> GetAllDiscountAsync();
        Task<DiscountDto> GetDiscountByCodeAsync(string code);
    }
}

using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface IDiscountRepository
    {
        Task<Discount> AddDiscountAsync(Discount discount);
        Task<bool> DeleteDiscountAsync(int id);
        Task<IEnumerable<Discount>> GetAllDiscountAsync();
    }
}

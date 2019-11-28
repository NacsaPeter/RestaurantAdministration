using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Interfaces
{
    public interface IFeedbackRepository
    {
        Task<Feedback> AddFeedbackAsync(Feedback feedback);
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
    }
}

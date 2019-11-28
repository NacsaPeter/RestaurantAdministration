using Microsoft.EntityFrameworkCore;
using RestaurantAdministration.Domain.Models;
using RestaurantAdministration.EF.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAdministration.EF.Repositories
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly ApplicationDbContext _context;

        public FeedbackRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Feedback> AddFeedbackAsync(Feedback feedback)
        {
            var existingFeedback = await _context.Feedbacks
                .Where(fb => fb.Id == feedback.Id)
                .SingleOrDefaultAsync();

            if(existingFeedback != null)
            {
                return null;
            }

            _context.Feedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            return feedback;
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            return await _context.Feedbacks.ToListAsync();
        }
    }
}

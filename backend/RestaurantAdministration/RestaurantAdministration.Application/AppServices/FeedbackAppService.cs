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
    public class FeedbackAppService : IFeedbackAppService
    {
        private readonly IFeedbackRepository _repository;

        public FeedbackAppService(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        public async Task<FeedbackDto> CreateFeedbackAsync(FeedbackDto feedbackDto)
        {
            Feedback feedback = feedbackDto.ToEntity();
            feedback.Date = DateTime.Now;
            Feedback created = await _repository.AddFeedbackAsync(feedback);

            if(created == null)
            {
                throw new Exception("Feedback already exists.");
            }

            return new FeedbackDto(created);
        }

        public async Task<IEnumerable<FeedbackDto>> GetAllFeedbackAsync()
        {
            IEnumerable<Feedback> feedbacks = await _repository.GetAllFeedbackAsync();
            return feedbacks.Select(fb => new FeedbackDto(fb));
        }
    }
}

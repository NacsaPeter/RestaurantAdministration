using RestaurantAdministration.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Application.Dtos
{
    public class FeedbackDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ServiceQuality { get; set; }
        public int Cleanness { get; set; }
        public int FoodQuality { get; set; }
        public int Atmosphere { get; set; }
        public string Other { get; set; }

        public FeedbackDto() { }

        public FeedbackDto(Feedback feedback)
        {
            Id = feedback.Id;
            Date = feedback.Date;
            ServiceQuality = feedback.ServiceQuality;
            Cleanness = feedback.Cleanness;
            FoodQuality = feedback.FoodQuality;
            Atmosphere = feedback.Atmosphere;
            Other = feedback.Other;
        }

        public Feedback ToEntity()
        {
            return new Feedback
            {
                Id = Id,
                Date = Date,
                ServiceQuality = ServiceQuality,
                Cleanness = Cleanness,
                FoodQuality = FoodQuality,
                Atmosphere = Atmosphere,
                Other = Other
            };
        }
    }
}

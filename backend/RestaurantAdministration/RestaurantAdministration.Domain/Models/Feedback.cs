using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantAdministration.Domain.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int ServiceQuality { get; set; }
        public int Cleanness { get; set; }
        public int FoodQuality { get; set; }
        public int Atmosphere { get; set; }
        public string Other { get; set; }
    }
}

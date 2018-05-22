using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Events
{
    public class DeleteViewModel
    {
        public Event Event { get; set; }
        public IList<AthletePerformance> AthletePerformances { get; set; } = new List<AthletePerformance>();
    }
}
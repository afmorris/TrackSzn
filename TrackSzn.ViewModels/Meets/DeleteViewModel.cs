using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Meets
{
    public class DeleteViewModel
    {
        public Meet Meet { get; set; }
        public List<AthletePerformance> AthletePerformances { get; set; } = new List<AthletePerformance>();
    }
}
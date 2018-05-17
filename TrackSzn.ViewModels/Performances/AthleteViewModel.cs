using System.Collections.Generic;
using System.Linq;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Performances
{
    public class AthleteViewModel
    {
        public AthleteViewModel(Athlete athlete, IEnumerable<IGrouping<Event, AthletePerformance>> performancesByEvent)
        {
            this.Athlete = athlete;
            this.PerformancesByEvent = performancesByEvent;
        }

        public Athlete Athlete { get; }
        public IEnumerable<IGrouping<Event, AthletePerformance>> PerformancesByEvent { get; }
    }
}
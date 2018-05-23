using System;
using System.Collections.Generic;
using System.Linq;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Athletes
{
    public class AthleteLiftsViewModel
    {
        public AthleteLiftsViewModel(Athlete athlete, IEnumerable<IGrouping<DateTime, AthleteLift>> liftsByDay)
        {
            this.Athlete = athlete;
            this.LiftsByDay = liftsByDay;
        }

        public Athlete Athlete { get; }
        public IEnumerable<IGrouping<DateTime, AthleteLift>> LiftsByDay { get; }
    }
}
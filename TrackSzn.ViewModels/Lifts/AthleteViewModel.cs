using System;
using System.Collections.Generic;
using System.Linq;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Lifts
{
    public class AthleteViewModel
    {
        public AthleteViewModel(Athlete athlete, IEnumerable<IGrouping<DateTimeOffset, AthleteLift>> liftsByDay)
        {
            this.Athlete = athlete;
            this.LiftsByDay = liftsByDay;
        }

        public Athlete Athlete { get; }
        public IEnumerable<IGrouping<DateTimeOffset, AthleteLift>> LiftsByDay { get; }
    }
}
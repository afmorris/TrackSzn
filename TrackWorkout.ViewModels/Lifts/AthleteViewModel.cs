using System.Collections.Generic;
using TrackWorkout.Models;

namespace TrackWorkout.ViewModels.Lifts
{
    public class AthleteViewModel
    {
        public AthleteViewModel(Athlete athlete)
        {
            this.Athlete = athlete;
        }

        public Athlete Athlete { get; }
    }
}
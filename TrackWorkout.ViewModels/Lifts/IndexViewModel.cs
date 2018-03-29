using System.Collections.Generic;
using TrackWorkout.Models;

namespace TrackWorkout.ViewModels.Lifts
{
    public class IndexViewModel
    {
        public IndexViewModel(List<Athlete> athletes)
        {
            this.Athletes = athletes;
        }

        public List<Athlete> Athletes { get; }
    }
}
using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Lifts
{
    public class IndexViewModel
    {
        public IList<Lift> Lifts { get; set; } = new List<Lift>();
    }
}
using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Athletes
{
    public class IndexViewModel
    {
        public IList<Athlete> Athletes { get; set; } = new List<Athlete>();
    }
}
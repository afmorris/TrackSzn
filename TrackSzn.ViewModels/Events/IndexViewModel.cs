using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Events
{
    public class IndexViewModel
    {
        public IList<Event> Events { get; set; } = new List<Event>();
    }
}

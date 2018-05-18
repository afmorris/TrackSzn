using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Events
{
    public class IndexViewModel
    {
        public IndexViewModel(IList<Event> events)
        {
            this.Events = events;
        }

        public IList<Event> Events { get; }
    }
}

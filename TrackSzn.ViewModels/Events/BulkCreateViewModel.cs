using System.Collections.Generic;

namespace TrackSzn.ViewModels.Events
{
    public class BulkCreateViewModel
    {
        public IList<CreateViewModel> CreateViewModels { get; set; } = new List<CreateViewModel>();
    }
}
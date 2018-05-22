using System.Collections.Generic;

namespace TrackSzn.ViewModels.Lifts
{
    public class BulkCreateViewModel
    {
        public IList<CreateViewModel> CreateViewModels { get; set; } = new List<CreateViewModel>();
    }
}
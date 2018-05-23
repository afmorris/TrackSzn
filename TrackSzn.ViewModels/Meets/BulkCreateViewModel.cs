using System.Collections.Generic;

namespace TrackSzn.ViewModels.Meets
{
    public class BulkCreateViewModel
    {
        public IList<CreateViewModel> CreateViewModels { get; set; } = new List<CreateViewModel>();
    }
}
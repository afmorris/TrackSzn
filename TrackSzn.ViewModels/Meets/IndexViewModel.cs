using System.Collections.Generic;
using TrackSzn.Models;

namespace TrackSzn.ViewModels.Meets
{
    public class IndexViewModel
    {
        public IList<Meet> Meets { get; set; } = new List<Meet>();
    }
}
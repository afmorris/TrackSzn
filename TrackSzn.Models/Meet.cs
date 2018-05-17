using System;

namespace TrackSzn.Models
{
    public class Meet : BaseModel
    {
        public string Name { get; set; }
        public DateTimeOffset Date { get; set; }
    }
}
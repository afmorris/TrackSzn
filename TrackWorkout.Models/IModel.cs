using System;

namespace TrackWorkout.Models
{
    public interface IModel
    {
        Guid Id { get; set; }
        int ClusterId { get; set; }
    }
}
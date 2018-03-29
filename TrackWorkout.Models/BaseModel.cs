using System;
using System.ComponentModel.DataAnnotations;

namespace TrackWorkout.Models
{
    public abstract class BaseModel : IModel
    {
        [Key]
        public Guid Id { get; set; }
        public int ClusterId { get; set; }
    }
}
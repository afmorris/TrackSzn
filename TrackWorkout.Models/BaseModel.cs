﻿using System;

namespace TrackWorkout.Models
{
    public abstract class BaseModel : IModel
    {
        public Guid Id { get; set; }
    }
}
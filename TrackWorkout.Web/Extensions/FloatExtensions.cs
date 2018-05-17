using System;
using TrackWorkout.Models;

namespace TrackWorkout.Web.Extensions
{
    public static class FloatExtensions
    {
        public static string FormatPerformance(this float performance, Event ev)
        {
            double whole;
            double part;

            if (ev.IsFieldEvent())
            {
                whole = Math.Floor(performance / 12);
                part = performance - (whole * 12);
            }
            else
            {
                whole = Math.Floor(performance / 60);
                part = performance - (whole * 60);
            }
            
            return ev.FormatPerformance(whole, part);
        }
    }
}
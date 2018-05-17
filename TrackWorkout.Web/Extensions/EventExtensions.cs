using TrackWorkout.Models;

namespace TrackWorkout.Web.Extensions
{
    public static class EventExtensions
    {
        public static bool IsFieldEvent(this Event ev)
        {
            switch (ev.Name)
            {
                case "Shot Put":
                case "Discus":
                case "Long Jump":
                case "High Jump":
                case "Pole Vault":
                    return true;
                default:
                    return false;
            }
        }

        public static string FormatPerformance(this Event ev, double whole, double part)
        {
            switch (ev.Name)
            {
                case "Shot Put":
                    return $"{whole:00}-{part:00.00}";
                case "Discus":
                    return $"{whole:000}-{part:00.00}";
            }

            return string.Empty;
        }
    }
}
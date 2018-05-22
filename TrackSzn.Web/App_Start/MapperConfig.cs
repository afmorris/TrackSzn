using AutoMapper;
using TrackSzn.Models;

namespace TrackSzn.Web
{
    public static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<TrackSzn.ViewModels.Events.CreateViewModel, Event>();
                cfg.CreateMap<TrackSzn.ViewModels.Lifts.CreateViewModel, Lift>();
            });
        }
    }
}
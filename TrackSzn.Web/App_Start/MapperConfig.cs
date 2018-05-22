using AutoMapper;
using TrackSzn.Models;
using TrackSzn.ViewModels.Events;

namespace TrackSzn.Web
{
    public static class MapperConfig
    {
        public static void RegisterMapping()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<CreateViewModel, Event>();
            });
        }
    }
}
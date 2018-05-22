using System;

namespace TrackSzn.Models
{
    public interface IModel
    {
        int Id { get; set; }
        string UserId { get; set; }
        bool IsDeleted { get; set; }
        DateTimeOffset DeletedDate { get; set; }
    }
}
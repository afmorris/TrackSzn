using System;
using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace TrackSzn.Models
{
    public abstract class BaseModel : IModel
    {
        [Key]
        [PrimaryKey]
        [AutoIncrement]
        public int Id { get; set; }

        [Index]
        public string UserId { get; set; }

        [Index]
        public bool IsDeleted { get; set; } = false;

        public DateTime DeletedDate { get; set; } = DateTime.MaxValue;
    }
}
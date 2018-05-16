using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace TrackWorkout.Models
{
    public abstract class BaseModel : IModel
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
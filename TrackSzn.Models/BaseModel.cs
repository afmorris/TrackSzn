using System.ComponentModel.DataAnnotations;
using ServiceStack.DataAnnotations;

namespace TrackSzn.Models
{
    public abstract class BaseModel : IModel
    {
        [Key]
        [AutoIncrement]
        public int Id { get; set; }
    }
}
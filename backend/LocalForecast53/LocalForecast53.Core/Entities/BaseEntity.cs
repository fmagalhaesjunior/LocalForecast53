using LocalForecast53.Core.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace LocalForecast53.Core.Entities
{
    public class BaseEntity : IEntity<object>
    {
        [Key]
        public virtual object Id { get; set; }
    }
}

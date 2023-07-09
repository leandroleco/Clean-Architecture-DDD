using System.ComponentModel.DataAnnotations;

namespace CleanArchitecture.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public int Code { get; protected set; }
    }
}

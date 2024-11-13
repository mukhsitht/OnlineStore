using System.ComponentModel.DataAnnotations;

namespace Data.EntityFramework
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}

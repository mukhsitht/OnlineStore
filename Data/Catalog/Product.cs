using Data.EntityFramework;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Catalog
{
    public class Product : BaseEntity
    {
        public int CategoryId { get; set; }
        public virtual Category? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }

        [NotMapped]
        public string? FormattedPrice { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

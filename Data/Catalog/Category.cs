using Data.EntityFramework;

namespace Data.Catalog
{
    public class Category : BaseEntity
    {
        public string? Name { get; set; }
        public DateTime CreatedOn { get; set; }
    }
}

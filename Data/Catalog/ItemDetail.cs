using Data.EntityFramework;

namespace Data.Catalog
{
    public class ItemDetail : BaseEntity
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? FormattedPrice { get; set; }
    }
}

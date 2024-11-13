namespace Data.Catalog
{
    public class VWProduct
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Photo { get; set; }
        public decimal Price { get; set; }
        public string? FormattedPrice { get; set; }
        public DateTime CreatedOn { get; set; }
        public string? FormattedCreatedOn { get; set; }
    }
}

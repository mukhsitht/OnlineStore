using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Catalog
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required]
        public int? CategoryId { get; set; }
        public string? CategoryName { get; set; }

        [Required]
        public string? Name { get; set; }

        [Required]
        public string? Description { get; set; }

        public string? Photo { get; set; }
        public string? PhotoUrl { get; set; }
        public IFormFile? File { get; set; }

        [Required]
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        public string? FormattedPrice { get; set; }

        public string? FormattedCreatedOn { get; set; }
    }
}

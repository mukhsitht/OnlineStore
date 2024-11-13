using System.ComponentModel.DataAnnotations;

namespace Admin.Models.Catalog
{
    public class CategoryModel
    {
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }
    }
}

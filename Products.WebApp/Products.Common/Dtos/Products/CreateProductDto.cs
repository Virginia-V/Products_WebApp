using Products.Common.Dtos.Ratings;
using System.ComponentModel.DataAnnotations;

namespace Products.Common.Dtos.Products
{
    public class CreateProductDto
    {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        [Required]
        [StringLength(500)]
        public string Description { get; set; }
        [Required]
        [StringLength(50)]
        public string Category { get; set; }
        [Required]
        public string Image { get; set; }
        [Required]
        public RatingDto Rating { get; set; }
    }
}

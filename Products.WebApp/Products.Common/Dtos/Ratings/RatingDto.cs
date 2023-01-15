using System.ComponentModel.DataAnnotations;

namespace Products.Common.Dtos.Ratings
{
    public class RatingDto
    {
        [Required]
        public decimal Rate { get; set; }
        [Required]
        public int Count { get; set; }
    }
}

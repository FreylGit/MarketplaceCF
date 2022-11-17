using System.ComponentModel.DataAnnotations;

namespace MarketplaceCF.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}

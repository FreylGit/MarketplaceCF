using System.ComponentModel.DataAnnotations;

namespace MarketplaceCF.Models.Dto
{
    public class ProductDto
    { 
        public int Id { get; set; }
        public string Title { get; set; }
        public decimal Price { get; set; }
        public string ImgPath { get; set; }
    }
}

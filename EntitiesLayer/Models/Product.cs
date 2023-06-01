

using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryName cannot be empty")]
        public String Name { get; set; }

        [Range(10, 10000)]
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}

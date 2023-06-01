

using System.ComponentModel.DataAnnotations;

namespace EntitiesLayer.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CategoryName cannot be empty")]
        public String CategoryName { get; set; }
    }
}

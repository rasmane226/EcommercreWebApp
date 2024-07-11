using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class Category
    {
        public int CategoryID { get; set; }


        [Required(ErrorMessage = "Category name not Empty")]
        [StringLength(20, ErrorMessage ="Please maximum 20 characters is required!", MinimumLength =5)]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }

        public List<Food>? Foods { get; set; }
    }
}

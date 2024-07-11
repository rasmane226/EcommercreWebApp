namespace WebApp.Models
{
    public class Food
    {
        public int FoodID { get; set; }
        public string? FoodName { get; set; }
        public string? FoodDescription { get; set; }

        public string? ImageUrl { get; set; }

        public int Stock { get; set; }

        public double Price { get; set; }

        public int CategoryID { get; set; }

        public virtual Category? Category { get; set; }

    }
}

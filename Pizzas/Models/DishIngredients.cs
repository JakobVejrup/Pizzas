namespace Pizzas.Models
{
    public class DishIngredients
    {
        public int DishId { get; set; }
        public Dishes Dish { get; set; }

        public int IngredientId { get; set; }

        public Ingredients Ingredients { get; set; }
        
    }
}

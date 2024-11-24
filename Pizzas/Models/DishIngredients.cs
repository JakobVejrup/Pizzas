namespace Pizzas.Models
{
    public class DishIngredients
    {
        public int DishId { get; set; }
        public Dishes? Dishes { get; set; } 

        public int IngredientId { get; set; }

        public Ingredients? Ingredients { get; set; }
        
    }
}

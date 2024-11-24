namespace Pizzas.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;

        public List<DishIngredients>? DishIngredients { get; set; }
    }
}

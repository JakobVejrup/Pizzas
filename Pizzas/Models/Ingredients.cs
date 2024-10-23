namespace Pizzas.Models
{
    public class Ingredients
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<DishIngredients>? DishIngredients { get; set; }
    }
}

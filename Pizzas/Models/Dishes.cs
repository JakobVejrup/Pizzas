using System.Collections.Generic;

namespace Pizzas.Models
{
    public class Dishes
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ImageURL {  get; set; }
        public double Price { get; set; }

        public List<DishIngredients>? DishIngredients { get; set; }
    }
}

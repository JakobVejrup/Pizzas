using Microsoft.EntityFrameworkCore;
using Pizzas.Models;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing.Constraints;
using Pizzas.Models;
namespace Pizzas.Data
{
    public class PizzasContext : DbContext
    {
        public PizzasContext( DbContextOptions <PizzasContext> options) : base(options)
        { 
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredients>().HasKey(di => new
            {
                di.DishId,
                di.IngredientId
            });
            modelBuilder.Entity<DishIngredients>().HasOne(d => d.Dish).WithMany(di => di.DishIngredients).HasForeignKey(d => d.DishId);
            modelBuilder.Entity<DishIngredients>().HasOne(di => di.Ingredients).WithMany(i => i.DishIngredients).HasForeignKey(di => di.IngredientId); 

            modelBuilder.Entity<Dishes>().HasData(
                new Dishes { Id=1, Title= "Margherita", Price= 7.50, ImageURL= "https://cdn.shopify.com/s/files/1/0274/9503/9079/files/20220211142754-margherita-9920_5a73220e-4a1a-4d33-b38f-26e98e3cd986.jpg?v=1723650067" }
                );
            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { Id = 1, Name = "Tomato Sauce" },
                new Ingredients { Id = 2, Name = "Mozzarella" },
                new Ingredients { Id = 3, Name = "Basilikum" }
                );
            modelBuilder.Entity<DishIngredients>().HasData(
                new DishIngredients { DishId = 1, IngredientId = 1 },
                new DishIngredients { DishId = 1, IngredientId = 2 },
                new DishIngredients { DishId = 1, IngredientId = 3 }
                );
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<DishIngredients> DishIngredients { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Pizzas.Models;

namespace Pizzas.Data
{
    public class PizzasContext : DbContext
    {
        public PizzasContext(DbContextOptions<PizzasContext> options) : base(options) { }

        public DbSet<Dishes> Dishes { get; set; }
        public DbSet<Ingredients> Ingredients { get; set; }
        public DbSet<DishIngredients> DishIngredients { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DishIngredients>().HasKey(di => new { di.DishId, di.IngredientId });

            modelBuilder.Entity<DishIngredients>()
                .HasOne(di => di.Dishes)
                .WithMany(d => d.DishIngredients)
                .HasForeignKey(di => di.DishId);

            modelBuilder.Entity<DishIngredients>()
                .HasOne(di => di.Ingredients)
                .WithMany(i => i.DishIngredients)
                .HasForeignKey(di => di.IngredientId);

            // Seed Data
            modelBuilder.Entity<Dishes>().HasData(
                new Dishes { Id = 1, Title = "Margherita", Price = 7.50, ImageURL = "https://images-bonnier.imgix.net/files/his/production/2020/01/21140309/pizza-margherita.jpg?auto=compress,format&w=2618&fit=crop&crop=focalpoint&fp-x=0.5&fp-y=0.5" },
                new Dishes { Id = 2, Title = "Diavola", Price = 9.50, ImageURL = "https://satisfyingslice.com/wp-content/uploads/2023/06/Pizza-alla-Diavola-23.jpg"}
            );


            modelBuilder.Entity<Ingredients>().HasData(
                new Ingredients { Id = 1, Name = "Tomato Sauce" },
                new Ingredients { Id = 2, Name = "Mozzarella" },
                new Ingredients { Id = 3, Name = "Basil" }
            );

            modelBuilder.Entity<DishIngredients>().HasData(
                new DishIngredients { DishId = 1, IngredientId = 1 },
                new DishIngredients { DishId = 1, IngredientId = 2 },
                new DishIngredients { DishId = 1, IngredientId = 3 }
            );
        }
    }
}


using Microsoft.EntityFrameworkCore;

namespace PizzaApp.Models
{
    public class DatabaseContext : DbContext
    {
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderTopping>()
                .HasKey(ot => new { ot.OrderId, ot.ToppingId });

            modelBuilder.Entity<OrderTopping>()
                .HasOne(ot => ot.Order)
                .WithMany(o => o.OrderToppings)
                .HasForeignKey(ot => ot.OrderId);

            modelBuilder.Entity<OrderTopping>()
                .HasOne(ot => ot.Topping)
                .WithMany(t => t.OrderToppings)
                .HasForeignKey(ot => ot.ToppingId);
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }

        public DbSet<PizzaSize> PizzaSizes { get; set; }
        public DbSet<Topping> Toppings { get; set; }
        public DbSet<Order> Orders { get; set; }

        public static void SetInitialData(DatabaseContext context)
        {
            context.PizzaSizes.Add(new PizzaSize(Guid.NewGuid(), "small", 8.00m));
            context.PizzaSizes.Add(new PizzaSize(Guid.NewGuid(), "medium", 10.00m));
            context.PizzaSizes.Add(new PizzaSize(Guid.NewGuid(), "large", 12.00m));

            context.Toppings.Add(new Topping(Guid.NewGuid(), "cheese", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "peperoni", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "pineapple", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "pickle", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "onions", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "apple", 1.00m));
            context.Toppings.Add(new Topping(Guid.NewGuid(), "banana", 1.00m));

            context.SaveChanges();
        }
    }
}

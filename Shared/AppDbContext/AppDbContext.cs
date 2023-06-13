using AgroStore.Shared;
using Microsoft.EntityFrameworkCore;

public class AppDbcontext : DbContext
{
    public DbSet<User>? user { get; set; }
    // public DbSet<Order>? Orders { get; set; }
    public DbSet<Product>? product { get; set; }
    public DbSet<ShoppingCart> shoppingCart {get;set;}

    public AppDbcontext(DbContextOptions<AppDbcontext> options) : base(options)
    {
    }

    // ...
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Configura la cadena de conexión a tu base de datos PostgreSQL
        optionsBuilder.UseNpgsql("Host=localhost;Database=CampStore;Username=prueba;Password=1098825894");
    }

}

using Microsoft.EntityFrameworkCore;
using SignalR.EntityLayer.Entities;

namespace SignalR.DataAccessLayer.Concrete;

public class SignalRContext : DbContext
{
    public SignalRContext()
    {
    }

    public SignalRContext(DbContextOptions<SignalRContext> options) : base(options)
    {
    }

    // Örnek tablolar (DbSet)
    public DbSet<About> Abouts { get; set; }
    public DbSet<Booking> Bookings { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Contact> Contacts { get; set; }
    public DbSet<Discount> Discounts { get; set; }
    public DbSet<Feature> Features { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SocialMedia> SocialMedias { get; set; }
    public DbSet<Testimonial> Testimonials { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderDetail> OrderDetails { get; set; }
    public DbSet<MoneyCase> MoneyCases { get; set; }
    public DbSet<MenuTable> MenuTables { get; set; }
    public DbSet<Slider> Sliders { get; set; }
    public DbSet<Basket> Baskets { get; set; }



    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // tablo adlarını açıkça eşle
        modelBuilder.Entity<Order>().ToTable("Orders");
        modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails");
    }
        
        // Sadece migration sırasında lazım olursa:
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            // Design-time için fallback (zorunlu değil)
            optionsBuilder.UseNpgsql("Host=localhost;Database=SignalRDb;Username=postgres;Password=123");
        }
    }

    

}
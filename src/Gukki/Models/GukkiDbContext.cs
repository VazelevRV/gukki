using Microsoft.EntityFrameworkCore;

namespace Gukki.Models
{
    // Цей клас вказує Entity Framework Що потрібно створити таблиці при створенні бази
    public class GukkiDbContext : DbContext
    {
        public GukkiDbContext(DbContextOptions<GukkiDbContext> options)
            : base(options)
        {
        }

        // Таблиця представляєтся як список продуктів у Entiti Framework підході
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Schedule> Schedule { get; set; }
        public DbSet<ContactModel> Contacts { get; set; }
        public DbSet<PlaceModel> Places {get;set;}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // налаштування 1 to many relationship 
            // безліч контактів у кожного відділення
            modelBuilder.Entity<PlaceModel>()
                .HasMany(p => p.Contacts)
                .WithOne(c => c.Place)
                .IsRequired();
        }
    }
}

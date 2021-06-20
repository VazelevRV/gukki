using Microsoft.EntityFrameworkCore;

namespace Gukki.Models
{
    // Цей клас вказує Entity Framework Що потрібно створити таблицу Products при створенні бази
    public class GukkiDbContext : DbContext
    {
        public GukkiDbContext(DbContextOptions<GukkiDbContext> options)
            : base(options)
        {
        }

        // Таблиця представляєтся як список продуктів у Entiti Framework підході
        public DbSet<ProductModel> Products { get; set; }
        public DbSet<Schedule> Schedule {get;set;}
        public DbSet<ContactModel> Contacts {get;set;}
    }
}

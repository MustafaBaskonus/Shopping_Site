using Microsoft.EntityFrameworkCore;

namespace product.model2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)  
        {
            
        }

        public DbSet<Product> Products{ get; set; }// product sınıfından obje , Products tablosu eğer farklı isimde oluştursaydık propertiesi o zaman Product sınıfında [table("Products")] şeklinde belirtmeliyiz
        public DbSet<Category> Categories { get; set; }
    }
}

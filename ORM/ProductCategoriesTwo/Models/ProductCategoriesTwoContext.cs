using Microsoft.EntityFrameworkCore;
 
namespace ProductCategoriesTwo.Models
{
    public class ProductCategoriesTwoContext : DbContext
    {
        public ProductCategoriesTwoContext(DbContextOptions options) : base(options) { }
 
        // for every model / entity that is going to be part of the db
        // the names of these properties will be the names of the tables in the db
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Association> Associations { get; set; }
        // public DbSet<Widget> Widgets { get; set; }
        // public DbSet<Item> Items { get; set; }
    }
}

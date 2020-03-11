
using Microsoft.EntityFrameworkCore;

namespace EZRecipize.Models
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
    }
}

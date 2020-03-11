
using Microsoft.EntityFrameworkCore;

namespace EZRecipize.Models
{
    public class RecipeDBContext : DbContext
    {
        public RecipeDBContext(DbContextOptions<RecipeDBContext> options) : base(options) { }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeStep> RecipeStep { get; set; }
        public DbSet<Ingredient> Ingredient { get; set; }
        
    }
}

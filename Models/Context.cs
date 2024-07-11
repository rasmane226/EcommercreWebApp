using Microsoft.EntityFrameworkCore;

namespace WebApp.Models
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=RASMANE\\SQLEXPRESS; Database=DbWebApp; integrated security = true");


        }

        internal void UpdateCategory(Category x)
        {
            throw new NotImplementedException();
        }

        internal void UpdateFood(Food x)
        {
            throw new NotImplementedException();
        }

        public DbSet<Food>? Foods { get; set; }

        public DbSet<Category>? Categories { get; set; }

        public DbSet<Admin>? admins { get; set; }
    }
}

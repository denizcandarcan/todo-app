using DD.TodoApp.DataAccess.Configurations;
using DD.TodoApp.Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DD.TodoApp.DataAccess.Contexts
{
    public class TodoContext : DbContext
    {
        public TodoContext(DbContextOptions<TodoContext> options): base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new WorkConfiguration());
        }
        public DbSet<Work> Works { get; set; }
    }
}

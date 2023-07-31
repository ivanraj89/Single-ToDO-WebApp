using Microsoft.EntityFrameworkCore;

namespace SingleToDoWebApp.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        { 

        }

        public DbSet<ToDoStatement> ToDoStatements { get; set; }
    }

}

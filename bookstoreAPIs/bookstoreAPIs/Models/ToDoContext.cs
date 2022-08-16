using Microsoft.EntityFrameworkCore;

namespace bookstoreAPIs.Models
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> option)
            : base(option)
        {

        }

        public DbSet<Book> toDoBooks { get; set; }
    }
}

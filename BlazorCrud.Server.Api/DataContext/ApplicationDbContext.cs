using BlazorCrud.Library;
using Microsoft.EntityFrameworkCore;

namespace BlazorCrud.Server.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Student> Students { get; set; }

    }
}

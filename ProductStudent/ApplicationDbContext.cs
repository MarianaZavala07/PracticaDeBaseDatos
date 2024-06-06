using Microsoft.EntityFrameworkCore;
using ProductStudent.Entities;

namespace ProductStudent
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
            
        }



        public DbSet<Students> Students { get; set; }

    }
}
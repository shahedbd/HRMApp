using HRMApp.Models;
using Microsoft.EntityFrameworkCore;

namespace HRMApp.Data
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Branch> Branch { get; set; }
        public DbSet<Department> Department { get; set; }
    }
}

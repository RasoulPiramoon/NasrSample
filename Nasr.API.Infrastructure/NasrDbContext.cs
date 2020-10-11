using Microsoft.EntityFrameworkCore;
using Nasr.API.Core.Person;

namespace Nasr.API.Infrastructure
{
    public partial class NasrDbContext : DbContext
    {
        public NasrDbContext()
        {}
        public NasrDbContext(DbContextOptions<NasrDbContext> options)
        : base(options)
        {
        }

        public DbSet<Person> Person { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
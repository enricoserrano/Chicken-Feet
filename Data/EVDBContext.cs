using Microsoft.EntityFrameworkCore;

using EV.Models;

namespace EV.Data
{
    public class EVDBContext : DbContext
    { 
        public EVDBContext(DbContextOptions<EVDBContext> options) : base(options) { }
        public DbSet<Breed> Breeds { get; set; }
    }
}
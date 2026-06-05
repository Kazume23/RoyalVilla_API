using Microsoft.EntityFrameworkCore;
using RolayVilla_API.Models;

namespace RolayVilla_API.Controllers.Data
{
    public class ApplicationDbContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Villa> Villa { get; set; }
    }
}

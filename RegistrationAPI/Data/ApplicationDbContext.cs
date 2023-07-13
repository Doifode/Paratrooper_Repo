using Microsoft.EntityFrameworkCore;
using RegistrationAPI.Models;

namespace RegistrationAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<UserRegistration> Registration { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using SP_ProjectCalling.Models.Domain;

namespace SP_ProjectCalling.Data
{
    public class ApplicationContextDb : DbContext
    {
        public ApplicationContextDb(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }  

        public DbSet<Supervisor> Supervisors { get; set; }

    }
}

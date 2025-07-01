using EmployeeAdminPortal.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace EmployeeAdminPortal.Data
{
    public class ApplicationDBContext : DbContext
    {
        //public ApplicationDBContext(DbContextOptions options) : base(options)
        //{
        //}
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employee { get; set; }

    }
}

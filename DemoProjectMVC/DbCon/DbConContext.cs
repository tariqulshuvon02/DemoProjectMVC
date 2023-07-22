using DemoProjectMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoProjectMVC.DbCon
{
    public class DbConContext:DbContext
    {
        public DbConContext(DbContextOptions<DbConContext> options) : base(options) 
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}

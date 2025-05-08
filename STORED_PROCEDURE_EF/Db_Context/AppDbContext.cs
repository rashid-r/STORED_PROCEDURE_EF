using Microsoft.EntityFrameworkCore;
using STORED_PROCEDURE_EF.Model;

namespace STORED_PROCEDURE_EF.Db_Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<EmployeEntity> Employee { get; set; }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Proxies;
namespace MVC2.Models
{
    public class CompanyContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public DbSet<Department> departments { get; set; }
        public DbSet<Dependent> dependents { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<WorksOn> workson { get; set; }
        public CompanyContext() { }
        public CompanyContext(DbContextOptions options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Data Source=DESKTOP-P3QHCGH\\SQLEXPRESS;Initial Catalog=companyDB;Integrated Security=True;TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Dependent>().HasKey("name", "employeeid");
            modelBuilder.Entity<WorksOn>().HasKey("employeeid", "projectid");
        }
    }
}

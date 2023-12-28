using Microsoft.EntityFrameworkCore;

namespace BlogApiDemo.DataAccessLayer
{
    public class Context : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //TrustServerCertificate = True;
            //Globalization Invariant Mode = false;
            optionsBuilder.UseSqlServer("Server=DESKTOP-39CPBHK\\KOCABAY;Database=CoreBlogApiDb;Integrated Security=True;TrustServerCertificate=True;");






        }
        public DbSet<Employee> Employees { get; set; }
    }
}

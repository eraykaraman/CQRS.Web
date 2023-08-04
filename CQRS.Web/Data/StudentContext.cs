using Microsoft.EntityFrameworkCore;

namespace CQRS.Web.Data
{
    public class StudentContext : DbContext
    {
        
        public StudentContext(DbContextOptions<StudentContext> options) : base(options)
        {

        }

        protected StudentContext()
        {
        }

        public DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("**your sql connection string**");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>().HasData(new Student[]
            {
                new Student(){Name="John",LastName="Doe",Age=22, Id=1},
                new Student(){Name="Alex",LastName="Ferguson",Age=12, Id=2},
                new Student(){Name="Karl",LastName="Benson",Age=52, Id=3},

            });
            base.OnModelCreating(modelBuilder);
        }
    }
}

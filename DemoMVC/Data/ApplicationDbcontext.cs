using Microsoft.EntityFrameworkCore;
using DemoMVC.Models;

namespace DemoMVC.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        { }
        public DbSet<Person> Person { get; set; }
        public DbSet<DemoMVC.Models.Daily> Daily { get; set; } = default!;
        protected override void OnModelCreating(ModelBuilder modelBuilder)
{
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Daily>()
        .Property(d => d.MaDaiLy)
        .ValueGeneratedOnAdd();  // EF sẽ tự tăng
} 

        public DbSet<DemoMVC.Models.HeThongPhanPhoi> HeThongPhanPhoi { get; set; } = default!;
         public DbSet<Student> Student { get; set; } = default!;
        
    }
    
}
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Assignment.Infrastruction
{
    public class ApplicationDbContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL("server=localhost;database=assigment;user=root;password=123456");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Employee>().Property<int>("Id");
            builder.Entity<Employee>().HasKey("Id");
            builder.Entity<TransactionLogEntry>().Property<int>("Id");
            builder.Entity<TransactionLogEntry>().HasKey("Id");
        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<TransactionLogEntry> TransactionLogEntries { get; set; }
    }
}

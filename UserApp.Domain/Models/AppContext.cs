using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Domain.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<DataSQLite> Users { get; set; } = null!;
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=helloapp.db");
        }
    }
}
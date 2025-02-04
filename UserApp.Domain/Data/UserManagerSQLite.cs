using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using SQLite.CodeFirst;

namespace Domain.Data
{
    public class UserManagerSQLite : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //base.OnModelCreating(modelBuilder); // вызов базовой реализации
            var sqliteConnectionInitializer = new SqliteCreateDatabaseIfNotExists<UserManagerSQLite>(modelBuilder);
            Database.SetInitializer(sqliteConnectionInitializer);

            var model = modelBuilder.Build(Database.Connection);
            ISqlGenerator sqlGenerator = new SqliteSqlGenerator();
            _ = sqlGenerator.Generate(model.StoreModel);

            //modelBuilder.Entity<Tables.Order>()
            //    .HasRequired<Tables.Person>(o => o.Person)
            //    .WithMany(p => p.Orders)
            //    .HasForeignKey(o => o.PersonId);
        }
    }
}

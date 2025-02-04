using System.Data.Entity;
using SQLite.CodeFirst;

namespace Domain.Data
{
    public class MyDbContextInitializer : SqliteDropCreateDatabaseAlways<UserManagerSQLite>
    {
        //private UserManagerSQLite userManagerSQLite;

        public MyDbContextInitializer(DbModelBuilder modelBuilder)
                : base(modelBuilder) { }

        protected override void Seed(UserManagerSQLite context)
        {
        }
    }
}

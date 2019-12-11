using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using DataModel.Model;
using MySql.Data.Entity;

namespace DataModel
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class DatabaseContext : DbContext
    {
        public DbSet<Jugador> Jugador { get; set; }
        
        public DatabaseContext() : base("connectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<DatabaseContext>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
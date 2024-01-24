using DataCollectorLibrary.Persistences.Entity;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.SQLite;


namespace DataCollectorLibrary.Persistences.Context
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() :
            base(new System.Data.SQLite.SQLiteConnection()
            {
                ConnectionString = new SQLiteConnectionStringBuilder()
                {
                    DataSource = $@"{System.AppDomain.CurrentDomain.BaseDirectory}\employee.sqlite",
                    ForeignKeys = true
                }.ConnectionString
            }, true)
        { }

        public DbSet<Employee> EmployeeData { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}

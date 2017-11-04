using NotificationManager.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace NotificationManager.Database
{
    public class RegulatoryDbContext : DbContext        
    {
        // Come implementare il repository Pattern 
        // https://blog.falafel.com/implement-step-step-generic-repository-pattern-c/
        public DbSet<Customer> Customers { get; set; }

        public RegulatoryDbContext(): base("name=RegulatoryDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {            
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            
            //Map entity to table
            modelBuilder.Entity<Customer>().ToTable("Customers");

            // Set the PK
            modelBuilder.Entity<Customer>().HasKey(x => x.Id);            

            base.OnModelCreating(modelBuilder);
        }
    }
}

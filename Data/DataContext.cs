using ClearSky.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ClearSky.Data
{
     public class DataContext: IdentityDbContext<AccountHolder>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Message> Messages {get;set;}
        public DbSet<Property> Properties{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AccountHolder>().HasMany<Message>(m => m.Messages).WithOne(x => x.AccountHolder)
            .HasForeignKey(x => x.AccountHolderId);

            // modelBuilder.Entity<Message>().HasOne<AccountHolder>(m => m.AccountHolder).WithMany(x => x.Messages)
            // .HasForeignKey(x => x.AccountHolderId);

            // modelBuilder.Entity<Message>().HasOne<Property>(p => p.Property).WithMany(x => x.Messages)
            // .HasForeignKey(x => x.PropertyId);

            modelBuilder.Entity<Property>().HasMany<Message>(p => p.Messages).WithOne(x => x.Property)
            .HasForeignKey(x => x.PropertyId);

        }
    }

}
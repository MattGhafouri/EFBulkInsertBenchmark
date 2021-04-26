using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BulkInsertLoadTest
{
    public partial class YourContext : DbContext
    { 
         

        public virtual DbSet<Temporary_LoadTestForTransactionBulkInsert> Temporary_LoadTestForTransactionBulkInsert { get; set; } 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"YourConnectionString");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

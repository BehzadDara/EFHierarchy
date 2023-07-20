using EFHierarchy.Models;
using Microsoft.EntityFrameworkCore;

namespace EFHierarchy
{
    public class EFHierarchyDBContext : DbContext
    {
        public EFHierarchyDBContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region TPC

            modelBuilder.Entity<TPCChild1>()
                .UseTpcMappingStrategy();
            modelBuilder.Entity<TPCChild2>()
                .UseTpcMappingStrategy();

            /*modelBuilder.Entity<TPCParent>()
                .ToTable("TPCParent")
                .HasKey(x => x.Id);

            modelBuilder.Entity<TPCChild1>()
                .ToTable("TPCChild1");

            modelBuilder.Entity<TPCChild1>()
                .HasOne<TPCParent>()
                .WithMany()
                .HasForeignKey(x => x.Id);*/

            #endregion

            #region TPH

            modelBuilder.Entity<TPHParent>()
                .HasDiscriminator<string>("Type")
                .HasValue<TPHParent>("Parent")
                .HasValue<TPHChild1>("Child1")
                .HasValue<TPHChild2>("Child2");

            modelBuilder.Entity<TPHChild1>()
                .HasBaseType<TPHParent>();

            modelBuilder.Entity<TPHChild2>()
                .HasBaseType<TPHParent>();

            #endregion

            #region TPT

            modelBuilder.Entity<TPTChild1>()
                .HasBaseType<TPTParent>()
                .ToTable("TPTChild1");

            modelBuilder.Entity<TPTChild2>()
                .HasBaseType<TPTParent>()
                .ToTable("TPTChild2");

            #endregion
        }
    }
}

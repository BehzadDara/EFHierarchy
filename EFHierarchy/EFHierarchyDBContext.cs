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
            #region TPT

            modelBuilder.Entity<TPTChild1>()
                .HasBaseType<TPTParent>()
                .ToTable("TPTChild1");

            modelBuilder.Entity<TPTChild2>()
                .HasBaseType<TPTParent>()
                .ToTable("TPTChild2");

            #endregion

            #region TPH

            modelBuilder.Entity<TPHParent>()
                .HasNoKey();

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
        }
    }
}

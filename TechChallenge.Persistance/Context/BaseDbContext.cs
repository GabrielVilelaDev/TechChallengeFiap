using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechChallenge.Domain.Entities;

namespace TechChallenge.Persistance.Context
{
    public abstract class BaseDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.LogTo(message => Debug.WriteLine(message));
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactEntity>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.ToTable("Contact");
                entity.Property(e => e.InsertedDate)
                    .HasDefaultValueSql(DateTimeOffset.Now.ToString());
                entity.HasOne(e => e.Area).WithMany(e => e.ListContact)
                    .HasForeignKey(d => d.IdArea)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<AreaEntity>(entity =>
            {
                entity.HasKey(entity => entity.Id);
                entity.ToTable("Area");
                entity.Property(e => e.InsertedDate)
                    .HasDefaultValueSql(DateTimeOffset.Now.ToString());
                entity.HasOne(e => e.State).WithMany(e => e.ListArea)
                    .HasForeignKey(d => d.IdState)
                    .OnDelete(DeleteBehavior.ClientSetNull);
                entity.HasOne(e => e.Region).WithMany(e => e.ListArea)
                    .HasForeignKey(d => d.IdRegion)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }
        public DbSet<ContactEntity> Contact { get; set; }
        public DbSet<AreaEntity> Area { get; set; }
        public DbSet<StateEntity> State { get; set; }
        public DbSet<RegionEntity> Region { get; set; }
    }
}

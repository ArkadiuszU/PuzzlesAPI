using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PuzzlesAPI.Entities
{
    public class PuzzleDbContext : DbContext
    {
        public PuzzleDbContext(DbContextOptions<PuzzleDbContext> options) :base(options) { }
        public DbSet<PuzzleTask> PuzzleTasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PuzzleTask>()
                .Property(p => p.Name).IsRequired().HasMaxLength(25);

            modelBuilder.Entity<PuzzleTask>()
                .Property(p => p.ImagePath).IsRequired();

        }
    }
}

using Example.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Infrastructure.Context;

public class ExampleDbContext : DbContext
{
        public ExampleDbContext()
        {
            
        }
        
        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options)
        {
        }
        
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Video> Videos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var serverVersion = new MySqlServerVersion(new Version(8, 0, 29));
                optionsBuilder.UseMySql("Server=localhost,3306;Uid=root;Pwd=password;Database=example", serverVersion);
            }
        }
    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Video>().ToTable("videos");
            modelBuilder.Entity<Video>().HasKey(video => video.Id);
            modelBuilder.Entity<Video>().Property(video => video.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Video>().Property(video => video.Title).IsRequired();
            modelBuilder.Entity<Video>().Property(video => video.duration).IsRequired();
            
            modelBuilder.Entity<Tag>().ToTable("tags");
            modelBuilder.Entity<Tag>().HasKey(tag => tag.Id);
            modelBuilder.Entity<Tag>().Property(tag => tag.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Tag>().Property(tag => tag.Name).IsRequired();
        }
}
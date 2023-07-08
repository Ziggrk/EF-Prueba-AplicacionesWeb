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
        public DbSet<Tree> Trees { get; set; }
        public DbSet<Leaf> Leafs { get; set; }
        public DbSet<Farmer> Farmers { get; set; }
        public DbSet<Farmland> Farmlands { get; set; }

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

            modelBuilder.Entity<Tree>().ToTable("trees");
            modelBuilder.Entity<Tree>().HasKey(trees => trees.Id);
            modelBuilder.Entity<Tree>().Property(trees => trees.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Tree>().Property(trees => trees.Username).IsRequired();
            modelBuilder.Entity<Tree>().Property(trees => trees.Email).IsRequired();
            modelBuilder.Entity<Tree>().Property(trees => trees.Gender).IsRequired();
            modelBuilder.Entity<Tree>().Property(trees => trees.FirstName).IsRequired();
            modelBuilder.Entity<Tree>().Property(trees => trees.LastName).IsRequired();
            modelBuilder.Entity<Tree>().Property(trees => trees.BornAt).IsRequired();
            
            modelBuilder.Entity<Leaf>().ToTable("leafs");
            modelBuilder.Entity<Leaf>().HasKey(leafs => leafs.Id);
            modelBuilder.Entity<Leaf>().Property(leafs => leafs.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Leaf>().Property(leafs => leafs.Scenario).IsRequired();
            modelBuilder.Entity<Leaf>().Property(leafs => leafs.Title).IsRequired();
            modelBuilder.Entity<Leaf>().Property(leafs => leafs.Tip).IsRequired();
            
            modelBuilder.Entity<Farmer>().ToTable("farmers");
            modelBuilder.Entity<Farmer>().HasKey(farmers => farmers.Id);
            modelBuilder.Entity<Farmer>().Property(farmers => farmers.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Farmer>().Property(farmers => farmers.Username).IsRequired();
            modelBuilder.Entity<Farmer>().Property(farmers => farmers.Email).IsRequired();
            modelBuilder.Entity<Farmer>().Property(farmers => farmers.LastName).IsRequired();
            modelBuilder.Entity<Farmer>().Property(farmers => farmers.FirstName).IsRequired();
            
            modelBuilder.Entity<Farmland>().ToTable("farmlands");
            modelBuilder.Entity<Farmland>().HasKey(farmlands => farmlands.Id);
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Id).IsRequired().ValueGeneratedOnAdd();
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Altitude).IsRequired();
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Latitude).IsRequired();
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Longitude).IsRequired();
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Length).IsRequired();
            modelBuilder.Entity<Farmland>().Property(farmlands => farmlands.Width).IsRequired();
        }
}
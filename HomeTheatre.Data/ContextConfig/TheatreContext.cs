using HomeTheatre.Data.DbConfigurations;
using HomeTheatre.Data.DbModels;
using HomeTheatre.Data.Seeder;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace HomeTheatre.Data
{
    public class TheatreContext : IdentityDbContext<User,Role,Guid>
    {
        public TheatreContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Ban> Bans { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.ApplyConfiguration(new BanConfig());
            modelBuilder.ApplyConfiguration(new CommentsConfig());
            modelBuilder.ApplyConfiguration(new ReviewConfig());
            modelBuilder.ApplyConfiguration(new RoleConfig());
            modelBuilder.ApplyConfiguration(new TheatreConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());

            modelBuilder.Seeder();
            base.OnModelCreating(modelBuilder);
        }

    }
}

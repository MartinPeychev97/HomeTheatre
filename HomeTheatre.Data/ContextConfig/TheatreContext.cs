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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region User - Theatre - One-To-Many
            modelBuilder.Entity<User>().HasKey(key => key.Id);

            modelBuilder.Entity<Theatre>()
                .HasOne(m => m.User)
                .WithMany(m => m.Theatres)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion
            #region Theatre - Review -One - To - Many
            modelBuilder.Entity<Theatre>().HasKey(key => key.Id);

            modelBuilder.Entity<Review>()
                .HasOne(m => m.Theatre)
                .WithMany(m => m.Reviews)
                .OnDelete(DeleteBehavior.Restrict);

            #endregion
            #region Review 
            modelBuilder.Entity<Review>().HasKey(key => key.Id);

            modelBuilder.Entity<Comment>()
                .HasOne(m => m.Review)
                .WithMany(m => m.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(m => m.User)
                .WithMany(m => m.Reviews);
            #endregion
            #region Ban-User-Many-To-One
            modelBuilder.Entity<Ban>().HasKey(b => b.Id);

            modelBuilder.Entity<Ban>().Property(b => b.ReasonBanned)
                .IsRequired();

            modelBuilder.Entity<Ban>().HasOne(b => b.User)
                .WithMany(u => u.Bans);

            modelBuilder.Entity<Ban>().Property(b => b.HasExpired)
                .IsRequired();
            #endregion
            modelBuilder.Seeder();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Theatre> Theatres { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }
       
        //need entity configurations
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<TheatreReview> TheatreReviews { get; set; }
        public DbSet<Ban> Bans { get; set; }
        //
    }
}

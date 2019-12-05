using HomeTheatre.Data.DbModels;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HomeTheatre.Data
{
    public class TheatreContext : IdentityDbContext<User>
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
            modelBuilder.Entity<Review>().HasKey(key=>key.Id);

            modelBuilder.Entity<Comment>()
                .HasOne(m => m.Review)
                .WithMany(m => m.Comments)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Review>()
                .HasOne(m => m.User)
                .WithMany(m => m.Reviews);
            #endregion

           // modelBuilder.Seeder();
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Accounts { get; set; }

        public DbSet<Theatre> Theatres { get; set; }

        public DbSet<Review> Reviews { get; set; }

        public DbSet<Comment> Comments { get; set; }


    }
}

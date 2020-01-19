using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbConfigurations
{
    public class ReviewConfig : IEntityTypeConfiguration<Review>
    {
        public void Configure(EntityTypeBuilder<Review> builder)
        {
            builder.HasKey(i => i.Id);

            builder.Property(r => r.Rating)
                .IsRequired();


            builder.HasMany(c => c.TheatreReviews)
                .WithOne(b => b.Review)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasMany(c => c.Comments)
                .WithOne(cc => cc.Review);

        }
    }
}

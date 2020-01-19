using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbConfigurations
{
    public class TheatreReviewConfig : IEntityTypeConfiguration<TheatreReview>
    {
        public void Configure(EntityTypeBuilder<TheatreReview> builder)
        {
            builder.HasKey(x => new { x.ReviewId, x.TheatreId });

            builder.HasOne(t => t.Theatre)
                .WithMany(u => u.TheatreReviews)
                .HasForeignKey(u => u.TheatreId);

            builder.HasOne(bc => bc.Review)
                .WithMany(b => b.TheatreReviews)
                .HasForeignKey(b => b.ReviewId);
        }
    }
}

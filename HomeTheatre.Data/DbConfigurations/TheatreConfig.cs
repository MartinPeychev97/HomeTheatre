using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbConfigurations
{
    public class TheatreConfig : IEntityTypeConfiguration<Theatre>
    {

        public void Configure(EntityTypeBuilder<Theatre> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired();

            builder.Property(t => t.Phone)
                .IsRequired();

            builder.Property(t => t.Location)
                .IsRequired();

            builder.HasMany(t => t.TheatreReviews)
                .WithOne(c => c.Theatre)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

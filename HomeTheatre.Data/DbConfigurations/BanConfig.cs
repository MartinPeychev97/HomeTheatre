using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbConfigurations
{
    public class BanConfig : IEntityTypeConfiguration<Ban>
    {
        public void Configure(EntityTypeBuilder<Ban> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.ReasonBanned)
                .IsRequired();

            builder.HasOne(b => b.User)
                .WithMany(u => u.Bans);

            builder.Property(b => b.HasExpired)
                .IsRequired();
        }
    }
}

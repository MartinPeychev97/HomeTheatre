using HomeTheatre.Data.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HomeTheatre.Data.DbConfigurations
{
    public class CommentsConfig : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.CommentText)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithMany(x => x.Comments);

            builder.HasOne(x => x.Review)
                .WithMany(x => x.Comments);
        }
    }
}

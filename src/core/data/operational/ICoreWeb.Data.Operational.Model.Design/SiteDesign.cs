using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICoreWeb.Data.Operational.Model.Design
{
    public class SiteDesign : IEntityTypeConfiguration<Site>
    {
        public void Configure(EntityTypeBuilder<Site> builder)
        {
            builder.ToTable(schema: "Core", name: "Sites");

            builder.Property(entity => entity.Id).ValueGeneratedOnAdd();

            builder.Property(entity => entity.Name).HasColumnType("NVARCHAR").IsRequired(true);

            builder.HasKey(entity => entity.Id).HasName("PK_Core_Sites_Id");

            builder.Property(entity => entity.CreatedTime).HasDefaultValue(DateTime.UtcNow);

            builder.Property(entity => entity.LastModifiedTime).HasDefaultValue(DateTime.UtcNow);
        }
    }
}
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICoreWeb.Data.Identity.Model.Design
{
    public class CorePermissionDesign : IEntityTypeConfiguration<CorePermission>
    {
        public void Configure(EntityTypeBuilder<CorePermission> builder)
        {
            builder.ToTable(schema: "Security", name: "Permissions");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.CateogoryId)
                .IsRequired(true);

            builder.Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.Property(x => x.Description)
                .HasMaxLength(400)
                .IsRequired(false);

            builder.Property(x => x.CreatedTime)
                .IsRequired(true)
                .HasDefaultValue(DateTime.UtcNow);

            builder.Property(x => x.LastUpdatedTime)
                .IsRequired(true)
                .HasDefaultValue(DateTime.UtcNow);

            builder.HasKey(x => x.Id).HasName("PK_Security_Permissions_Id");

            builder.HasIndex(x => new {x.CateogoryId, x.Name})
                .IsUnique(true)
                .HasName("UK_Security_Permissions_CategoryId_Name");

            builder.HasOne(x => x.Category)
                .WithMany(x => x.Permissions)
                .HasForeignKey(x => x.CateogoryId)
                .HasPrincipalKey(x => x.Id)
                .HasConstraintName("FK_Security_Permissions_Id_PermissionCategories_Id");
        }
    }
}
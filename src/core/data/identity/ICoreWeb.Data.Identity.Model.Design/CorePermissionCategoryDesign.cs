using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ICoreWeb.Data.Identity.Model.Design
{
    public class CorePermissionCategoryDesign : IEntityTypeConfiguration<CorePermissionCategory>
    {
        public void Configure(EntityTypeBuilder<CorePermissionCategory> builder)
        {
            builder.ToTable(schema: "Security", name: "PermissionCategories");

            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
                .IsRequired(true);

            builder.HasIndex(x => x.Name)
                .IsUnique(true)
                .HasName("UK_Security_PermissionCategory_Name");

            builder.HasMany(x => x.Permissions)
                .WithOne(x => x.Category)
                .HasForeignKey(x => x.CateogoryId)
                .HasPrincipalKey(x => x.Id);
        }
    }
}
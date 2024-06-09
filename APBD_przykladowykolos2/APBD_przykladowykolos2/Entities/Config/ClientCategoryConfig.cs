using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class ClientCategoryConfig : IEntityTypeConfiguration<ClientCategory>
{
    public void Configure(EntityTypeBuilder<ClientCategory> builder)
    {
        builder.HasKey(e => e.IdClientCategory).HasName("ClientCategory_pk");
        builder.Property(e => e.IdClientCategory).UseIdentityColumn();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.DiscountPerc).IsRequired();
        builder.ToTable("ClientCategory");
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace APBD_przykladowykolos2.Entities.Config;

public class ClientConfig : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder.HasKey(e => e.IdClient).HasName("Client_pk");
        builder.Property(e => e.IdClient).UseIdentityColumn();
        builder.Property(e => e.Name).IsRequired().HasMaxLength(100);
        builder.Property(e => e.LastName).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Pesel).IsRequired().HasMaxLength(100);
        builder.Property(e => e.Email).IsRequired().HasMaxLength(100);
        builder.HasOne(e => e.ClientCategory).WithMany(c => c.Clients).HasForeignKey(e => e.IdClientCategory);
        builder.ToTable("Client");
    }
}

using FitnessClub.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FitnessClub.Infrastructure.Configurations.Write;

public class MembershipConfiguration : IEntityTypeConfiguration<Membership>
{
    public void Configure(EntityTypeBuilder<Membership> builder)
    {
        builder.HasKey(m => m.Id);
        builder.Property(m => m.Name);
        builder.Property(m => m.Description);
        builder.Property(m => m.Type);
        builder.Property(m => m.Price);
        builder.Property(m => m.Days);
    }
}
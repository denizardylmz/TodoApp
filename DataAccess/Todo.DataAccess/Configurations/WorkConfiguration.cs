using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Todo.Entities.Domains;

namespace Todo.DataAccess.Configurations;

public class WorkConfiguration : IEntityTypeConfiguration<Work>
{
    public void Configure(EntityTypeBuilder<Work> builder)
    {
        builder.HasKey(x => x.Id);
        
        builder.Property(x => x.Definition)
            .HasMaxLength(100)
            .IsRequired(true);

        builder.Property(x => x.IsCompleted)
            .IsRequired(true);
    }
}
using AvivatecParty.Domain.Entities;
using AvivatecParty.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivatecParty.Infra.Data.Mappings
{
    internal class LocalMapping : EntityTypeConfiguration<Local>
    {
        public override void Map(EntityTypeBuilder<Local> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnType("varchar(150)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Locais");
        }
    }
}
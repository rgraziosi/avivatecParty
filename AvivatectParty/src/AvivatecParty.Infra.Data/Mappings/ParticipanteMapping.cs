using AvivatecParty.Domain.Entities;
using AvivatecParty.Infra.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AvivatecParty.Infra.Data.Mappings
{
    public class ParticipanteMapping : EntityTypeConfiguration<Participante>
    {
        public override void Map(EntityTypeBuilder<Participante> builder)
        {
            builder.Property(e => e.Nome)
                .HasColumnType("varchar(50)")
                .IsRequired();

            builder.Property(e => e.Email)
                .IsRequired();

            builder.Property(e => e.Login)
                .HasColumnType("varchar(15)")
                .IsRequired();

            builder.Property(e => e.Senha)
                .HasColumnType("varchar(20)")
                .IsRequired();

            builder.Property(e => e.Email)
                .HasColumnType("varchar(150)");

            builder.Ignore(e => e.ValidationResult);

            builder.Ignore(e => e.CascadeMode);

            builder.ToTable("Participantes");

            builder.HasOne(e => e.Local)
                .WithMany(e => e.Participantes)
                .HasForeignKey(e => e.LocalId)
                .IsRequired(false);
        }
    }
}
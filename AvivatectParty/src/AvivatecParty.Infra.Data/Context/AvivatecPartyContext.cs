using AvivatecParty.Domain.Entities;
using AvivatecParty.Infra.Data.Extensions;
using AvivatecParty.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace AvivatecParty.Infra.Data.Context
{
    public class AvivatecPartyContext : DbContext
    {
        public DbSet<Participante> Participantes { get; set; }

        public DbSet<Local> Locais { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new ParticipanteMapping());

            modelBuilder.AddConfiguration(new LocalMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                                .SetBasePath(Directory.GetCurrentDirectory())
                                .AddJsonFile("appsettings.json")
                                .Build();

            optionsBuilder.UseSqlServer(config.GetConnectionString("DefaultConnection"));
        }
    }
}
﻿// <auto-generated />
using System;
using AvivatecParty.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace AvivatecParty.Infra.Data.Migrations
{
    [DbContext(typeof(AvivatecPartyContext))]
    [Migration("20190609160239_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("AvivatecParty.Domain.Entities.Local", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Locais");
                });

            modelBuilder.Entity("AvivatecParty.Domain.Entities.Participante", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<Guid?>("LocalId");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("varchar(15)");

                    b.Property<DateTime?>("MelhorDiaHora");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(50)");

                    b.Property<bool>("Organizador");

                    b.Property<bool>("Removido");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasColumnType("varchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("LocalId");

                    b.ToTable("Participantes");
                });

            modelBuilder.Entity("AvivatecParty.Domain.Entities.Participante", b =>
                {
                    b.HasOne("AvivatecParty.Domain.Entities.Local", "Local")
                        .WithMany("Participantes")
                        .HasForeignKey("LocalId");
                });
#pragma warning restore 612, 618
        }
    }
}

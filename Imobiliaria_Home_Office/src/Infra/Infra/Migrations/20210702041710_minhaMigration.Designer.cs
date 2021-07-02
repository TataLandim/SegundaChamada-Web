﻿// <auto-generated />
using Infra.Contexto;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infra.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20210702041710_minhaMigration")]
    partial class minhaMigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("Dominio.Entidades.Imovel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("Bairro")
                        .IsRequired()
                        .HasColumnType("varchar(60)")
                        .HasMaxLength(60);

                    b.Property<string>("Cidade")
                        .IsRequired()
                        .HasColumnType("varchar(90)")
                        .HasMaxLength(90);

                    b.Property<int>("QtdDeQuartos")
                        .HasColumnType("int");

                    b.Property<decimal>("ValorDoAluguel")
                        .HasColumnType("decimal(10.2)");

                    b.HasKey("Id");

                    b.ToTable("imoveis");
                });
#pragma warning restore 612, 618
        }
    }
}

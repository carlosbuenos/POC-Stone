﻿// <auto-generated />
using System;
using Infra.AcessoBaseDados.AcessoPostgres;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace Infra.Migrations
{
    [DbContext(typeof(ContextoPostgres))]
    [Migration("20200222223202_initialize4")]
    partial class initialize4
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("Dominio.Entidades.Pagamentos", b =>
                {
                    b.Property<string>("codPagamento")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("text");

                    b.Property<DateTime>("dataPagamento")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("rastreio")
                        .IsRequired()
                        .HasColumnType("character varying(5)")
                        .HasMaxLength(5);

                    b.Property<string>("statusPagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("tipoDePagamento")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("valor")
                        .HasColumnType("double precision");

                    b.HasKey("codPagamento");

                    b.HasIndex("rastreio");

                    b.ToTable("Pagamentos");
                });
#pragma warning restore 612, 618
        }
    }
}

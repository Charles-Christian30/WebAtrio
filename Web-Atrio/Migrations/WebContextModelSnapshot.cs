﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Web_Atrio.Context;

#nullable disable

namespace Web_Atrio.Migrations
{
    [DbContext(typeof(WebContext))]
    partial class WebContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_Atrio.Models.Data.EmploisData", b =>
                {
                    b.Property<int>("EmploisId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EmploisId"));

                    b.Property<string>("Company")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DateDebut")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateFin")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonneId")
                        .HasColumnType("int");

                    b.Property<string>("Post")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("EmploisId");

                    b.HasIndex("PersonneId");

                    b.ToTable("Emplois");
                });

            modelBuilder.Entity("Web_Atrio.Models.Data.PersonneData", b =>
                {
                    b.Property<int>("PersonneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PersonneId"));

                    b.Property<DateTime>("DateNaissance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Prenom")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("PersonneId");

                    b.ToTable("Personnes");
                });

            modelBuilder.Entity("Web_Atrio.Models.Data.EmploisData", b =>
                {
                    b.HasOne("Web_Atrio.Models.Data.PersonneData", "Personne")
                        .WithMany("EmploisData")
                        .HasForeignKey("PersonneId");

                    b.Navigation("Personne");
                });

            modelBuilder.Entity("Web_Atrio.Models.Data.PersonneData", b =>
                {
                    b.Navigation("EmploisData");
                });
#pragma warning restore 612, 618
        }
    }
}

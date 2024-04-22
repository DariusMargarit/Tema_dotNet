﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Tema_dotNet.Database.Context;

#nullable disable

namespace Tema_dotNet.Database.Migrations
{
    [DbContext(typeof(ProducatorManagementDBContext))]
    partial class ProducatorManagementDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Tema_dotNet.Database.Entities.Producator", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Producatori");
                });

            modelBuilder.Entity("Tema_dotNet.Database.Entities.Produs", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nume")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Pret")
                        .HasColumnType("int");

                    b.Property<int>("ProducatorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ProducatorId");

                    b.ToTable("Produse");
                });

            modelBuilder.Entity("Tema_dotNet.Database.Entities.Produs", b =>
                {
                    b.HasOne("Tema_dotNet.Database.Entities.Producator", "Producator")
                        .WithMany("Produse")
                        .HasForeignKey("ProducatorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Producator");
                });

            modelBuilder.Entity("Tema_dotNet.Database.Entities.Producator", b =>
                {
                    b.Navigation("Produse");
                });
#pragma warning restore 612, 618
        }
    }
}

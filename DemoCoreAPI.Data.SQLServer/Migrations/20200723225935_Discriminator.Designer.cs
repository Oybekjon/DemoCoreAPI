﻿// <auto-generated />
using System;
using DemoCoreAPI.Data.SQLServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace DemoCoreAPI.Data.SQLServer.Migrations
{
    [DbContext(typeof(ApiContext))]
    [Migration("20200723225935_Discriminator")]
    partial class Discriminator
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.ClassDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<int>("Letter")
                        .HasColumnType("int");

                    b.Property<long?>("SchoolDbId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SchoolDbId");

                    b.ToTable("Classes");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.SchoolAddressDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("District")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("HouseNumber")
                        .HasColumnType("int");

                    b.Property<string>("Locality")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Region")
                        .HasColumnType("int");

                    b.Property<long>("SchoolDbId")
                        .HasColumnType("bigint");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.HasIndex("SchoolDbId")
                        .IsUnique();

                    b.ToTable("SchoolAddresses");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.SchoolDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.HasKey("Id");

                    b.ToTable("Schools");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.SchoolPhoneNumberDb", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<long?>("SchoolDbId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("SchoolDbId");

                    b.ToTable("SchoolPhoneNumbers");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.UserDb", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Patronymic")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Users");

                    b.HasDiscriminator<string>("Discriminator").HasValue("UserDb");

                    b.HasData(
                        new
                        {
                            Id = 1L,
                            DateOfBirth = new DateTime(1990, 3, 18, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Email = "saint12maloj@gmail.com",
                            FirstName = "Aleksandr",
                            LastName = "Kalyuganov",
                            Password = "qqLQK/L5n5GqeiaCEkxVrUxlkbAWMmPUlOBSmlGXnPA=",
                            Patronymic = "Anatoljevich",
                            Role = 0
                        });
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.PupilDb", b =>
                {
                    b.HasBaseType("DemoCoreAPI.DomainModels.Models.UserDb");

                    b.Property<long?>("ClassId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SchoolId")
                        .HasColumnType("bigint");

                    b.HasIndex("ClassId");

                    b.HasIndex("SchoolId");

                    b.HasDiscriminator().HasValue("PupilDb");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.TeacherDb", b =>
                {
                    b.HasBaseType("DemoCoreAPI.DomainModels.Models.UserDb");

                    b.Property<long?>("PupilId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SchoolId")
                        .HasColumnName("TeacherDb_SchoolId")
                        .HasColumnType("bigint");

                    b.HasIndex("PupilId");

                    b.HasIndex("SchoolId");

                    b.HasDiscriminator().HasValue("TeacherDb");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.ClassDb", b =>
                {
                    b.HasOne("DemoCoreAPI.DomainModels.Models.SchoolDb", null)
                        .WithMany("Classes")
                        .HasForeignKey("SchoolDbId");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.SchoolAddressDb", b =>
                {
                    b.HasOne("DemoCoreAPI.DomainModels.Models.SchoolDb", "School")
                        .WithOne("SchoolAddress")
                        .HasForeignKey("DemoCoreAPI.DomainModels.Models.SchoolAddressDb", "SchoolDbId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.SchoolPhoneNumberDb", b =>
                {
                    b.HasOne("DemoCoreAPI.DomainModels.Models.SchoolDb", null)
                        .WithMany("SchoolPhoneNumbers")
                        .HasForeignKey("SchoolDbId");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.PupilDb", b =>
                {
                    b.HasOne("DemoCoreAPI.DomainModels.Models.ClassDb", "Class")
                        .WithMany("Pupils")
                        .HasForeignKey("ClassId");

                    b.HasOne("DemoCoreAPI.DomainModels.Models.SchoolDb", "School")
                        .WithMany("Pupils")
                        .HasForeignKey("SchoolId");
                });

            modelBuilder.Entity("DemoCoreAPI.DomainModels.Models.TeacherDb", b =>
                {
                    b.HasOne("DemoCoreAPI.DomainModels.Models.PupilDb", "Pupil")
                        .WithMany("Teachers")
                        .HasForeignKey("PupilId");

                    b.HasOne("DemoCoreAPI.DomainModels.Models.SchoolDb", "School")
                        .WithMany("Teachers")
                        .HasForeignKey("SchoolId");
                });
#pragma warning restore 612, 618
        }
    }
}

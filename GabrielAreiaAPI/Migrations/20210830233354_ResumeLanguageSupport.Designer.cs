﻿// <auto-generated />
using System;
using GabrielAreiaAPI.ResumeDb;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GabrielAreiaAPI.Migrations
{
    [DbContext(typeof(ResumeContext))]
    [Migration("20210830233354_ResumeLanguageSupport")]
    partial class ResumeLanguageSupport
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("GabrielAreiaAPI.Models.Ability", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Experience")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("bytea");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Abilities");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Achievement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("character varying(200)");

                    b.Property<int>("Year")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Achievements");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Cellphone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("character varying(50)");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Cellphones");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.ContactInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Discord")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Skype")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.HasKey("Id");

                    b.ToTable("ContactInfos");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Course", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CertificateAddress")
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<byte[]>("CertificateImage")
                        .HasColumnType("bytea");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<string>("Institution")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<string>("InstitutionWebsite")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<byte[]>("Logo")
                        .HasColumnType("bytea");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<int>("YearEnd")
                        .HasColumnType("integer");

                    b.Property<int>("YearStart")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Courses");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Email", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("EmailAddresses");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Experience", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Company")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("CompanyWebsite")
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Field")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("Notes")
                        .HasMaxLength(1000)
                        .HasColumnType("character varying(1000)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasMaxLength(120)
                        .HasColumnType("character varying(120)");

                    b.Property<int?>("YearEnd")
                        .HasColumnType("integer");

                    b.Property<int>("YearStart")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Experiences");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<string>("MyGoal")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("ResumeId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ResumeId");

                    b.ToTable("Goals");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Resume", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("ContactId")
                        .HasColumnType("integer");

                    b.Property<string>("Description")
                        .HasMaxLength(3000)
                        .HasColumnType("character varying(3000)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("character varying(150)");

                    b.Property<string>("Language")
                        .HasMaxLength(100)
                        .HasColumnType("character varying(100)");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.Property<byte[]>("Picture")
                        .HasColumnType("bytea");

                    b.Property<int>("YearBirth")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("ContactId");

                    b.ToTable("Resumes");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Website", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<int>("ContactInfoId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("LastUpdate")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("timestamp")
                        .HasDefaultValueSql("current_timestamp");

                    b.HasKey("Id");

                    b.HasIndex("ContactInfoId");

                    b.ToTable("Websites");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Ability", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.Resume", null)
                        .WithMany("Abilities")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Achievement", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.Resume", null)
                        .WithMany("Achievements")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Cellphone", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.ContactInfo", null)
                        .WithMany("Cellphones")
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Course", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.Resume", null)
                        .WithMany("Courses")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Email", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.ContactInfo", null)
                        .WithMany("EmailAddresses")
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Experience", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.Resume", null)
                        .WithMany("Experiences")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Goal", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.Resume", null)
                        .WithMany("Goals")
                        .HasForeignKey("ResumeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Resume", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.ContactInfo", "Contact")
                        .WithMany()
                        .HasForeignKey("ContactId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Contact");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Website", b =>
                {
                    b.HasOne("GabrielAreiaAPI.Models.ContactInfo", null)
                        .WithMany("Websites")
                        .HasForeignKey("ContactInfoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.ContactInfo", b =>
                {
                    b.Navigation("Cellphones");

                    b.Navigation("EmailAddresses");

                    b.Navigation("Websites");
                });

            modelBuilder.Entity("GabrielAreiaAPI.Models.Resume", b =>
                {
                    b.Navigation("Abilities");

                    b.Navigation("Achievements");

                    b.Navigation("Courses");

                    b.Navigation("Experiences");

                    b.Navigation("Goals");
                });
#pragma warning restore 612, 618
        }
    }
}

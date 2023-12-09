﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using _5letters.Data;

#nullable disable

namespace _5letters.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("_5letters.Models.CorrectWord", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("StringWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CorrectWords");
                });

            modelBuilder.Entity("_5letters.Models.Game", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long>("CorrectWordId")
                        .HasColumnType("bigint");

                    b.Property<DateTimeOffset>("Date")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("GameStage")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CorrectWordId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("_5letters.Models.Letter", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<int>("LetterStatus")
                        .HasColumnType("integer");

                    b.Property<long?>("WordId")
                        .HasColumnType("bigint");

                    b.Property<char>("WordLetter")
                        .HasColumnType("character(1)");

                    b.HasKey("Id");

                    b.HasIndex("WordId");

                    b.ToTable("Letters");
                });

            modelBuilder.Entity("_5letters.Models.Word", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<long>("Id"));

                    b.Property<long?>("GameId")
                        .HasColumnType("bigint");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<string>("StringWord")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameId");

                    b.ToTable("Words");
                });

            modelBuilder.Entity("_5letters.Models.Game", b =>
                {
                    b.HasOne("_5letters.Models.CorrectWord", "CorrectWord")
                        .WithMany()
                        .HasForeignKey("CorrectWordId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CorrectWord");
                });

            modelBuilder.Entity("_5letters.Models.Letter", b =>
                {
                    b.HasOne("_5letters.Models.Word", null)
                        .WithMany("Letters")
                        .HasForeignKey("WordId");
                });

            modelBuilder.Entity("_5letters.Models.Word", b =>
                {
                    b.HasOne("_5letters.Models.Game", null)
                        .WithMany("Words")
                        .HasForeignKey("GameId");
                });

            modelBuilder.Entity("_5letters.Models.Game", b =>
                {
                    b.Navigation("Words");
                });

            modelBuilder.Entity("_5letters.Models.Word", b =>
                {
                    b.Navigation("Letters");
                });
#pragma warning restore 612, 618
        }
    }
}

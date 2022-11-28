﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vote.Data.Context;

namespace Vote.Data.Migrations
{
    [DbContext(typeof(VoteDbContext))]
    [Migration("20221128070146_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasDefaultSchema("products")
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("Vote.Domain.Entities.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Age")
                        .HasColumnType("INTEGER")
                        .HasColumnName("age");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_persons");

                    b.ToTable("persons");
                });

            modelBuilder.Entity("Vote.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER")
                        .HasColumnName("id");

                    b.Property<int>("Category")
                        .HasColumnType("INTEGER")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .HasColumnType("TEXT")
                        .HasColumnName("description");

                    b.Property<string>("Image")
                        .HasColumnType("TEXT")
                        .HasColumnName("image");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("pk_products");

                    b.ToTable("products");
                });

            modelBuilder.Entity("Vote.Domain.Entities.Vote", b =>
                {
                    b.Property<int>("PersonId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("person_id");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER")
                        .HasColumnName("product_id");

                    b.Property<DateTime>("VoteDate")
                        .HasColumnType("TEXT")
                        .HasColumnName("vote_date");

                    b.HasKey("PersonId", "ProductId")
                        .HasName("pk_votes");

                    b.HasIndex("ProductId")
                        .HasDatabaseName("ix_votes_product_id");

                    b.ToTable("votes");
                });

            modelBuilder.Entity("Vote.Domain.Entities.Vote", b =>
                {
                    b.HasOne("Vote.Domain.Entities.Person", "Person")
                        .WithMany("Votes")
                        .HasForeignKey("PersonId")
                        .HasConstraintName("fk_votes_persons_person_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Vote.Domain.Entities.Product", "Product")
                        .WithMany("Votes")
                        .HasForeignKey("ProductId")
                        .HasConstraintName("fk_votes_products_product_id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Vote.Domain.Entities.Person", b =>
                {
                    b.Navigation("Votes");
                });

            modelBuilder.Entity("Vote.Domain.Entities.Product", b =>
                {
                    b.Navigation("Votes");
                });
#pragma warning restore 612, 618
        }
    }
}
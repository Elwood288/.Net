﻿// <auto-generated />
using BookAPI.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace BookAPI.Migrations
{
    [DbContext(typeof(BookContext))]
    [Migration("20190806012836_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity("BookAPI.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Author")
                        .IsRequired();

                    b.Property<string>("Category")
                        .IsRequired();

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(250);

                    b.HasKey("Id");

                    b.ToTable("books");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Author 1",
                            Category = "Category 1",
                            Title = "The Grapes of Wrath"
                        },
                        new
                        {
                            Id = 2,
                            Author = "Author 2",
                            Category = "Category 2",
                            Title = "Cannery Row"
                        },
                        new
                        {
                            Id = 3,
                            Author = "Author 3",
                            Category = "Category 3",
                            Title = "The Shining"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}

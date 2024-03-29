﻿// <auto-generated />
using System;
using API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("API.Data.Entities.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Author")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Summary")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Book", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Author = "Douglas Adams",
                            CategoryId = 2,
                            Name = "The Hitchhiker's Guide to the Galaxy",
                            Summary = "The saga mocks modern society with humour and cynicism and has as its hero a hapless, deeply ordinary Englishman (Arthur Dent) who unexpectedly finds himself adrift in a universe characterized by randomness and absurdity."
                        },
                        new
                        {
                            Id = 2,
                            Author = "Ernest Cline",
                            CategoryId = 2,
                            Name = "Ready Player One",
                            Summary = "The story, set in a dystopia in 2045, follows protagonist Wade Watts on his search for an Easter egg in a worldwide virtual reality game, the discovery of which would lead him to inherit the game creator's fortune."
                        },
                        new
                        {
                            Id = 3,
                            Author = "George Orwell",
                            CategoryId = 1,
                            Name = "Nineteen Eighty-Four",
                            Summary = "Nineteen Eighty-Four (also stylised as 1984) is a dystopian social science fiction novel and cautionary tale written by English writer George Orwell. It was published on 8 June 1949 by Secker & Warburg as Orwell's ninth and final book completed in his lifetime. Thematically, it centres on the consequences of totalitarianism, mass surveillance and repressive regimentation of people and behaviours within society.[2][3] Orwell, a democratic socialist, modelled the totalitarian government in the novel after Stalinist Russia and Nazi Germany.[2][3][4] More broadly, the novel examines the role of truth and facts within politics and the ways in which they are manipulated."
                        },
                        new
                        {
                            Id = 4,
                            Author = "J. K. Rowling",
                            CategoryId = 1,
                            Name = "Harry Potter and the Philosopher's Stone",
                            Summary = "On his 11th birthday, Harry receives a letter inviting him to study magic at the Hogwarts School of Witchcraft and Wizardry. Harry discovers that not only is he a wizard, but he is a famous one. He meets two best friends, Ron Weasley and Hermione Granger, and makes his first enemy, Draco Malfoy."
                        });
                });

            modelBuilder.Entity("API.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("DateRequested")
                        .HasColumnType("datetime2");

                    b.Property<int>("RequestedByUserId")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<int?>("StatusUpdateByUserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RequestedByUserId");

                    b.HasIndex("StatusUpdateByUserId");

                    b.ToTable("BookBorrowingRequest", (string)null);
                });

            modelBuilder.Entity("API.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.Property<int>("BookBorrowingRequestId")
                        .HasColumnType("int");

                    b.Property<int>("BookId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.HasKey("BookBorrowingRequestId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookBorrowingRequestDetails", (string)null);
                });

            modelBuilder.Entity("API.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Categories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sci-Fi"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Biography"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Self-Help"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Reference"
                        });
                });

            modelBuilder.Entity("API.Data.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("User", (string)null);
                });

            modelBuilder.Entity("API.Data.Entities.Book", b =>
                {
                    b.HasOne("API.Data.Entities.Category", "Category")
                        .WithMany("Books")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("API.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.HasOne("API.Data.Entities.User", "RequestedBy")
                        .WithMany("BookBorrowingRequests")
                        .HasForeignKey("RequestedByUserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("API.Data.Entities.User", "StatusUpdateBy")
                        .WithMany("ProcessedRequests")
                        .HasForeignKey("StatusUpdateByUserId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("RequestedBy");

                    b.Navigation("StatusUpdateBy");
                });

            modelBuilder.Entity("API.Data.Entities.BookBorrowingRequestDetails", b =>
                {
                    b.HasOne("API.Data.Entities.BookBorrowingRequest", "BookBorrowingRequest")
                        .WithMany("RequestDetails")
                        .HasForeignKey("BookBorrowingRequestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API.Data.Entities.Book", "Book")
                        .WithMany("RequestDetails")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("BookBorrowingRequest");
                });

            modelBuilder.Entity("API.Data.Entities.Book", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("API.Data.Entities.BookBorrowingRequest", b =>
                {
                    b.Navigation("RequestDetails");
                });

            modelBuilder.Entity("API.Data.Entities.Category", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("API.Data.Entities.User", b =>
                {
                    b.Navigation("BookBorrowingRequests");

                    b.Navigation("ProcessedRequests");
                });
#pragma warning restore 612, 618
        }
    }
}

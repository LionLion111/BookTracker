﻿// <auto-generated />
using System;
using BookTracker.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookTracker.Persistence.Migrations
{
    [DbContext(typeof(BookTrackerDbContext))]
    [Migration("20231030094636_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BookTracker.Persistence.Entities.Author", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Author");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Book", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<int>("GenreId")
                        .HasColumnType("int");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<Guid>("PublisherId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("PublisherYear")
                        .HasColumnType("int");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<DateTime?>("UpdatedDateTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("GenreId");

                    b.HasIndex("PublisherId");

                    b.ToTable("Book");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.BookAuthor", b =>
                {
                    b.Property<Guid>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("AuthorId", "BookId");

                    b.HasIndex("BookId");

                    b.ToTable("BookAuthor");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Genre", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Genre");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Fantasy"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Science Fiction"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Horror"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Thriller"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Mystery"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Historical Fiction"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Romance"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Western"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Contemporary"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Memoir"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Cooking"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Art"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Self-Help"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Development"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Motivational"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Health"
                        },
                        new
                        {
                            Id = 17,
                            Name = "History"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Travel"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Guide"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Families & Relationships"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Humor"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Children's"
                        });
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Mood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Mood");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "None"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Sad"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Neutral"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Happy"
                        });
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Publisher", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.ToTable("Role");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Admin"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Moderator"
                        },
                        new
                        {
                            Id = 3,
                            Name = "User"
                        });
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("User");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBook", b =>
                {
                    b.Property<string>("BookId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDinishDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DesiredFinishDate")
                        .HasColumnType("date");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedDinishDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookId", "UserId");

                    b.HasIndex("UserId");

                    b.ToTable("UserBook");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBookStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("UserBookStatus", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Not Started"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Reading"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Completed"
                        },
                        new
                        {
                            Id = 4,
                            Name = "OnHold"
                        });
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBookTracker", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("BookId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<DateTime>("CreatedDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("PageCount")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("BookId", "UserId");

                    b.ToTable("UserBookTracker");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Book", b =>
                {
                    b.HasOne("BookTracker.Persistence.Entities.Genre", "Genre")
                        .WithMany("Books")
                        .HasForeignKey("GenreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTracker.Persistence.Entities.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Genre");

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.BookAuthor", b =>
                {
                    b.HasOne("BookTracker.Persistence.Entities.Author", "Author")
                        .WithMany("BookAuthors")
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTracker.Persistence.Entities.Book", "Book")
                        .WithMany("BookAuthors")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");

                    b.Navigation("Book");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.User", b =>
                {
                    b.HasOne("BookTracker.Persistence.Entities.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBook", b =>
                {
                    b.HasOne("BookTracker.Persistence.Entities.Book", "Book")
                        .WithMany("UserBooks")
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookTracker.Persistence.Entities.User", "User")
                        .WithMany("UserBooks")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("User");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBookTracker", b =>
                {
                    b.HasOne("BookTracker.Persistence.Entities.UserBook", "UserBook")
                        .WithMany("UserBookTrackers")
                        .HasForeignKey("BookId", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserBook");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Author", b =>
                {
                    b.Navigation("BookAuthors");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Book", b =>
                {
                    b.Navigation("BookAuthors");

                    b.Navigation("UserBooks");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Genre", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Publisher", b =>
                {
                    b.Navigation("Books");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.User", b =>
                {
                    b.Navigation("UserBooks");
                });

            modelBuilder.Entity("BookTracker.Persistence.Entities.UserBook", b =>
                {
                    b.Navigation("UserBookTrackers");
                });
#pragma warning restore 612, 618
        }
    }
}

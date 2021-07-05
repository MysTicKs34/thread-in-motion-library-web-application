﻿// <auto-generated />
using System;
using Data.Access.Layer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Data.Access.Layer.Migrations
{
    [DbContext(typeof(LibraryWebApplicationContext))]
    [Migration("20210705093403_LibraryWebApplicationMigrations_3")]
    partial class LibraryWebApplicationMigrations_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.7")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Data.Access.Layer.Classes.Authors", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Authors");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.BookTransactions", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BookID")
                        .HasColumnType("int");

                    b.Property<DateTime>("BorrowingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("MemberID")
                        .HasColumnType("int");

                    b.Property<DateTime>("ReturnDate")
                        .HasColumnType("datetime2");

                    b.HasKey("ID");

                    b.HasIndex("BookID");

                    b.HasIndex("MemberID");

                    b.ToTable("BookTransactions");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.Books", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AuthorID")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoanDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ID");

                    b.HasIndex("AuthorID");

                    b.ToTable("Books");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.Members", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("MembershipDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Surname")
                        .HasColumnType("varchar(20)");

                    b.HasKey("ID");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.BookTransactions", b =>
                {
                    b.HasOne("Data.Access.Layer.Classes.Books", "Book")
                        .WithMany()
                        .HasForeignKey("BookID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Data.Access.Layer.Classes.Members", "Member")
                        .WithMany()
                        .HasForeignKey("MemberID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Book");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.Books", b =>
                {
                    b.HasOne("Data.Access.Layer.Classes.Authors", "Author")
                        .WithMany("Books")
                        .HasForeignKey("AuthorID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Author");
                });

            modelBuilder.Entity("Data.Access.Layer.Classes.Authors", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}

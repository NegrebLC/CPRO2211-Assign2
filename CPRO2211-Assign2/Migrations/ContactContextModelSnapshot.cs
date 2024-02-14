﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CPRO2211_Assign2.Migrations
{
    [DbContext(typeof(ContactContext))]
    partial class ContactContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categories");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Family"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Friends"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Work"
                        });
                });

            modelBuilder.Entity("Contact", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateAdded")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Organization")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Contacts");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 1,
                            DateAdded = new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5605),
                            Email = "bergcu2001@gmail.com",
                            FirstName = "Bergen",
                            LastName = "Cunningham",
                            Organization = "Red Deer Polytechnic",
                            Phone = "587-876-7305"
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 2,
                            DateAdded = new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5608),
                            Email = "jeannellecousineau2001@gmail.com",
                            FirstName = "Jeannelle",
                            LastName = "Cousineau",
                            Organization = "Royal LePage",
                            Phone = "403-307-6227"
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 3,
                            DateAdded = new DateTime(2024, 2, 14, 1, 5, 5, 368, DateTimeKind.Local).AddTicks(5611),
                            Email = "steve.smith@gmail.com",
                            FirstName = "Steve",
                            LastName = "Smith",
                            Phone = "555-555-5555"
                        });
                });

            modelBuilder.Entity("Contact", b =>
                {
                    b.HasOne("Category", "Category")
                        .WithMany("Contacts")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("Category", b =>
                {
                    b.Navigation("Contacts");
                });
#pragma warning restore 612, 618
        }
    }
}

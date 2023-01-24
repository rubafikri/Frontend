﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ToDoApi.Data;

#nullable disable

namespace ToDoApi.Migrations
{
    [DbContext(typeof(ToDoDbContext))]
    partial class ToDoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("ToDoApi.Models.ToDo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Task")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ToDoCategoryId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ToDoCategoryId");

                    b.ToTable("toDos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Task 1 HAs completed",
                            DueDate = new DateTime(2022, 11, 3, 0, 26, 18, 940, DateTimeKind.Local).AddTicks(1981),
                            IsCompleted = true,
                            Task = "Task 1",
                            ToDoCategoryId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Task 2 HAs completed",
                            DueDate = new DateTime(2022, 11, 3, 0, 26, 18, 940, DateTimeKind.Local).AddTicks(2017),
                            IsCompleted = false,
                            Task = "Task 2",
                            ToDoCategoryId = 2
                        });
                });

            modelBuilder.Entity("ToDoApi.Models.ToDoCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("toDoCategories", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Complete"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Imprtant"
                        });
                });

            modelBuilder.Entity("ToDoApi.Models.ToDo", b =>
                {
                    b.HasOne("ToDoApi.Models.ToDoCategory", "toDoCategory")
                        .WithMany()
                        .HasForeignKey("ToDoCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("toDoCategory");
                });
#pragma warning restore 612, 618
        }
    }
}

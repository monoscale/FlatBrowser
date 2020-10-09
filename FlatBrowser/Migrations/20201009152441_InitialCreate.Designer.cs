﻿// <auto-generated />
using System;
using FlatBrowser.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace FlatBrowser.Migrations
{
    [DbContext(typeof(FlatBrowserDBContext))]
    [Migration("20201009152441_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8");

            modelBuilder.Entity("FlatBrowser.Models.FileExtension", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FolderCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Name");

                    b.HasIndex("FolderCategoryId");

                    b.ToTable("FileExtension");
                });

            modelBuilder.Entity("FlatBrowser.Models.Folder", b =>
                {
                    b.Property<string>("Path")
                        .HasColumnType("TEXT");

                    b.Property<int?>("FolderCategoryId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Path");

                    b.HasIndex("FolderCategoryId");

                    b.ToTable("Folder");
                });

            modelBuilder.Entity("FlatBrowser.Models.FolderCategory", b =>
                {
                    b.Property<int>("FolderCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.HasKey("FolderCategoryId");

                    b.ToTable("FolderCategories");
                });

            modelBuilder.Entity("FlatBrowser.Models.FileExtension", b =>
                {
                    b.HasOne("FlatBrowser.Models.FolderCategory", null)
                        .WithMany("Extensions")
                        .HasForeignKey("FolderCategoryId");
                });

            modelBuilder.Entity("FlatBrowser.Models.Folder", b =>
                {
                    b.HasOne("FlatBrowser.Models.FolderCategory", "FolderCategory")
                        .WithMany("Folders")
                        .HasForeignKey("FolderCategoryId");
                });
#pragma warning restore 612, 618
        }
    }
}

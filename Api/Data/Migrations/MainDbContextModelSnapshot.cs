﻿// <auto-generated />
using System;
using Api.CodingLibraryDSR.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Api.Data.Migrations
{
    [DbContext(typeof(MainDbContext))]
    partial class MainDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Categories", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<int>("DifficultyIndex")
                        .HasColumnType("integer")
                        .HasColumnName("difficulty_index");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("title");

                    b.HasKey("Uid")
                        .HasName("pk_categories");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_categories_uid");

                    b.ToTable("categories", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Comments", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<string>("ContentComments")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("content_comments");

                    b.Property<DateTime>("LeftTime")
                        .HasColumnType("timestamp with time zone")
                        .HasColumnName("left_time");

                    b.Property<Guid>("ProblemUid")
                        .HasColumnType("uuid")
                        .HasColumnName("problem_uid");

                    b.Property<Guid>("UserUid")
                        .HasColumnType("uuid")
                        .HasColumnName("user_uid");

                    b.HasKey("Uid")
                        .HasName("pk_comments");

                    b.HasIndex("ProblemUid")
                        .HasDatabaseName("ix_comments_problem_uid");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_comments_uid");

                    b.HasIndex("UserUid")
                        .HasDatabaseName("ix_comments_user_uid");

                    b.ToTable("comments", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Languages", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Version")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("version");

                    b.HasKey("Uid")
                        .HasName("pk_languages");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_languages_uid");

                    b.ToTable("languages", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Problems", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<Guid>("CategoryUid")
                        .HasColumnType("uuid")
                        .HasColumnName("category_uid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("description");

                    b.Property<int>("DifficultIndex")
                        .HasColumnType("integer")
                        .HasColumnName("difficult_index");

                    b.Property<Guid>("LanguageUid")
                        .HasColumnType("uuid")
                        .HasColumnName("language_uid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("Solution")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("solution");

                    b.HasKey("Uid")
                        .HasName("pk_problems");

                    b.HasIndex("CategoryUid")
                        .HasDatabaseName("ix_problems_category_uid");

                    b.HasIndex("LanguageUid")
                        .HasDatabaseName("ix_problems_language_uid");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_problems_uid");

                    b.ToTable("problems", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Subscriptions", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<Guid>("ProblemUid")
                        .HasColumnType("uuid")
                        .HasColumnName("problem_uid");

                    b.Property<string>("StatusSubscriptions")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("status_subscriptions");

                    b.Property<Guid>("UserUid")
                        .HasColumnType("uuid")
                        .HasColumnName("user_uid");

                    b.HasKey("Uid")
                        .HasName("pk_subscriptions");

                    b.HasIndex("ProblemUid")
                        .HasDatabaseName("ix_subscriptions_problem_uid");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_subscriptions_uid");

                    b.HasIndex("UserUid")
                        .HasDatabaseName("ix_subscriptions_user_uid");

                    b.ToTable("subscriptions", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Users", b =>
                {
                    b.Property<Guid>("Uid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid")
                        .HasColumnName("uid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("name");

                    b.Property<string>("PasswordHash")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("password_hash");

                    b.Property<string>("UserStatus")
                        .IsRequired()
                        .HasColumnType("text")
                        .HasColumnName("user_status");

                    b.HasKey("Uid")
                        .HasName("pk_users");

                    b.HasIndex("Uid")
                        .IsUnique()
                        .HasDatabaseName("ix_users_uid");

                    b.ToTable("users", (string)null);
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Comments", b =>
                {
                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Problems", "Problem")
                        .WithMany("Comments")
                        .HasForeignKey("ProblemUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_problems_problem_temp_id");

                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Users", "User")
                        .WithMany("Comments")
                        .HasForeignKey("UserUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_comments_users_user_temp_id");

                    b.Navigation("Problem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Problems", b =>
                {
                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Categories", "Category")
                        .WithMany("Problems")
                        .HasForeignKey("CategoryUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_problems_categories_category_uid");

                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Languages", "Language")
                        .WithMany("Problems")
                        .HasForeignKey("LanguageUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_problems_languages_language_uid");

                    b.Navigation("Category");

                    b.Navigation("Language");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Subscriptions", b =>
                {
                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Problems", "Problem")
                        .WithMany("Subscritions")
                        .HasForeignKey("ProblemUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_subscriptions_problems_problem_uid");

                    b.HasOne("Api.CodingLibraryDSR.Data.Entity.Users", "User")
                        .WithMany("Subscritions")
                        .HasForeignKey("UserUid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("fk_subscriptions_users_user_temp_id1");

                    b.Navigation("Problem");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Categories", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Languages", b =>
                {
                    b.Navigation("Problems");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Problems", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Subscritions");
                });

            modelBuilder.Entity("Api.CodingLibraryDSR.Data.Entity.Users", b =>
                {
                    b.Navigation("Comments");

                    b.Navigation("Subscritions");
                });
#pragma warning restore 612, 618
        }
    }
}

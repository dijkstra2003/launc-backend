﻿// <auto-generated />
using System;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Infrastructure.Data.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20191210123409_ProductRemoval")]
    partial class ProductRemoval
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("API.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("FirstName")
                        .HasColumnType("text");

                    b.Property<string>("LastName")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.Property<string>("Username")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CampaignDescription")
                        .HasColumnType("text");

                    b.Property<string>("CampaignName")
                        .HasColumnType("text");

                    b.Property<int?>("CampaignType")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignTypeNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CampaignTypeNavigationId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.CampaignGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CampaignFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GoalFk")
                        .HasColumnType("integer");

                    b.Property<int?>("GoalFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignFkNavigationId");

                    b.HasIndex("GoalFkNavigationId");

                    b.ToTable("CampaignsGoal");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.CampaignType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TypeDescription")
                        .HasColumnType("text");

                    b.Property<string>("TypeName")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("CampaignType");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.Comment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CommentContent")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("GoalEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("GoalStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Goal");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.GoalSubGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GoalFk")
                        .HasColumnType("integer");

                    b.Property<int?>("GoalFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<int?>("SubGoalFk")
                        .HasColumnType("integer");

                    b.Property<int?>("SubGoalFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GoalFkNavigationId");

                    b.HasIndex("SubGoalFkNavigationId");

                    b.ToTable("GoalSubGoal");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.SubGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("GoalEnd")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("GoalStart")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("MinAmount")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Subgoal");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("TeamDescription")
                        .HasColumnType("text");

                    b.Property<string>("TeamName")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("Team");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.TeamCampaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CampaignFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("TeamFk")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignFkNavigationId");

                    b.HasIndex("TeamFkNavigationId");

                    b.ToTable("TeamCampaign");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserCampaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CampaignFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserFk")
                        .HasColumnType("integer");

                    b.Property<int?>("UserFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignFkNavigationId");

                    b.HasIndex("UserFkNavigationId");

                    b.ToTable("UserCampaign");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserComment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CommentFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CommentFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserFk")
                        .HasColumnType("integer");

                    b.Property<int?>("UserFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CommentFkNavigationId");

                    b.HasIndex("UserFkNavigationId");

                    b.ToTable("UserComment");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserLikes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CampaignFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserFk")
                        .HasColumnType("integer");

                    b.Property<int?>("UserFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("CampaignFkNavigationId");

                    b.HasIndex("UserFkNavigationId");

                    b.ToTable("UserLikes");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserTeam", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("TeamFk")
                        .HasColumnType("integer");

                    b.Property<int?>("TeamFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<int?>("UserFk")
                        .HasColumnType("integer");

                    b.Property<int?>("UserFkNavigationId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("TeamFkNavigationId");

                    b.HasIndex("UserFkNavigationId");

                    b.ToTable("UserTeam");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.Campaign", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.CampaignType", "CampaignTypeNavigation")
                        .WithMany("Campaign")
                        .HasForeignKey("CampaignTypeNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.CampaignGoal", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany("CampaignGoal")
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Infrastructure.Entities.Goal", "GoalFkNavigation")
                        .WithMany("CampaignGoal")
                        .HasForeignKey("GoalFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.GoalSubGoal", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Goal", "GoalFkNavigation")
                        .WithMany("GoalSubGoal")
                        .HasForeignKey("GoalFkNavigationId");

                    b.HasOne("API.Infrastructure.Entities.SubGoal", "SubGoalFkNavigation")
                        .WithMany("GoalSubGoal")
                        .HasForeignKey("SubGoalFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.TeamCampaign", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany("TeamCampaign")
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Infrastructure.Entities.Team", "TeamFkNavigation")
                        .WithMany("TeamCampaign")
                        .HasForeignKey("TeamFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserCampaign", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany("UserCampaign")
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserComment", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Comment", "CommentFkNavigation")
                        .WithMany("UserComment")
                        .HasForeignKey("CommentFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserLikes", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany("UserLikes")
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Infrastructure.Entities.UserTeam", b =>
                {
                    b.HasOne("API.Infrastructure.Entities.Team", "TeamFkNavigation")
                        .WithMany("UserTeam")
                        .HasForeignKey("TeamFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });
#pragma warning restore 612, 618
        }
    }
}

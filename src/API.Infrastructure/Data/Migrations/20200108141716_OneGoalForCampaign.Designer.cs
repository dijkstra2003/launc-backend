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
    [Migration("20200108141716_OneGoalForCampaign")]
    partial class OneGoalForCampaign
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("API.Core.Entities.Campaign", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("CampaignDescription")
                        .HasColumnType("text");

                    b.Property<string>("CampaignName")
                        .HasColumnType("text");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GoalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.ToTable("Campaign");
                });

            modelBuilder.Entity("API.Core.Entities.CampaignGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<int?>("CampaignFk")
                        .HasColumnType("integer");

                    b.Property<int?>("CampaignFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GoalFk")
                        .HasColumnType("integer");

                    b.Property<int?>("GoalFkNavigationId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.HasIndex("CampaignFkNavigationId");

                    b.HasIndex("GoalFkNavigationId");

                    b.ToTable("CampaignGoal");
                });

            modelBuilder.Entity("API.Core.Entities.Comment", b =>
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

            modelBuilder.Entity("API.Core.Entities.Goal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("numeric");

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

            modelBuilder.Entity("API.Core.Entities.GoalSubGoal", b =>
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

            modelBuilder.Entity("API.Core.Entities.MolliePayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("GoalId")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<int?>("SubGoalId")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int?>("UserId")
                        .HasColumnType("integer");

                    b.HasKey("Id");

                    b.HasIndex("GoalId");

                    b.HasIndex("SubGoalId");

                    b.HasIndex("UserId");

                    b.ToTable("MolliePayment");
                });

            modelBuilder.Entity("API.Core.Entities.MollieResponse", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<decimal>("Amount")
                        .HasColumnType("numeric");

                    b.Property<decimal>("AmountCaptured")
                        .HasColumnType("numeric");

                    b.Property<string>("AmountCapturedCurrency")
                        .HasColumnType("text");

                    b.Property<string>("AmountCurrency")
                        .HasColumnType("text");

                    b.Property<decimal>("AmountRefunded")
                        .HasColumnType("numeric");

                    b.Property<string>("AmountRefundedCurrency")
                        .HasColumnType("text");

                    b.Property<decimal>("AmountRemaining")
                        .HasColumnType("numeric");

                    b.Property<string>("AmountRemainingCurrency")
                        .HasColumnType("text");

                    b.Property<DateTime?>("AuthorizedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("CanceledAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("CountryCode")
                        .HasColumnType("text");

                    b.Property<DateTime?>("CreatedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .HasColumnType("text");

                    b.Property<DateTime?>("ExpiredAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("ExpiresAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime?>("FailedAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<bool>("IsCancelable")
                        .HasColumnType("boolean");

                    b.Property<string>("Locale")
                        .HasColumnType("text");

                    b.Property<string>("MollieId")
                        .HasColumnType("text");

                    b.Property<string>("OrderId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("PaidAt")
                        .HasColumnType("timestamp without time zone");

                    b.Property<int>("PaymentId")
                        .HasColumnType("integer");

                    b.Property<string>("RedirectUrl")
                        .HasColumnType("text");

                    b.Property<string>("Resource")
                        .HasColumnType("text");

                    b.Property<string>("SubscriptionId")
                        .HasColumnType("text");

                    b.Property<DateTime?>("UpdatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("WebhookUrl")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("PaymentId")
                        .IsUnique();

                    b.ToTable("MollieResponse");
                });

            modelBuilder.Entity("API.Core.Entities.SubGoal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime?>("CreatedOn")
                        .HasColumnType("timestamp without time zone");

                    b.Property<decimal>("CurrentAmount")
                        .HasColumnType("numeric");

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

            modelBuilder.Entity("API.Core.Entities.Team", b =>
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

            modelBuilder.Entity("API.Core.Entities.TeamCampaign", b =>
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

            modelBuilder.Entity("API.Core.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<string>("Email")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("API.Core.Entities.UserCampaign", b =>
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

            modelBuilder.Entity("API.Core.Entities.UserComment", b =>
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

            modelBuilder.Entity("API.Core.Entities.UserLikes", b =>
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

            modelBuilder.Entity("API.Core.Entities.UserTeam", b =>
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

            modelBuilder.Entity("API.Core.Entities.Campaign", b =>
                {
                    b.HasOne("API.Core.Entities.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId");
                });

            modelBuilder.Entity("API.Core.Entities.CampaignGoal", b =>
                {
                    b.HasOne("API.Core.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany()
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.Goal", "GoalFkNavigation")
                        .WithMany("CampaignGoal")
                        .HasForeignKey("GoalFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.GoalSubGoal", b =>
                {
                    b.HasOne("API.Core.Entities.Goal", "GoalFkNavigation")
                        .WithMany("GoalSubGoal")
                        .HasForeignKey("GoalFkNavigationId");

                    b.HasOne("API.Core.Entities.SubGoal", "SubGoalFkNavigation")
                        .WithMany("GoalSubGoal")
                        .HasForeignKey("SubGoalFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.MolliePayment", b =>
                {
                    b.HasOne("API.Core.Entities.Goal", "Goal")
                        .WithMany()
                        .HasForeignKey("GoalId");

                    b.HasOne("API.Core.Entities.SubGoal", "SubGoal")
                        .WithMany()
                        .HasForeignKey("SubGoalId");

                    b.HasOne("API.Core.Entities.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("API.Core.Entities.MollieResponse", b =>
                {
                    b.HasOne("API.Core.Entities.MolliePayment", "Payment")
                        .WithOne("Response")
                        .HasForeignKey("API.Core.Entities.MollieResponse", "PaymentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("API.Core.Entities.TeamCampaign", b =>
                {
                    b.HasOne("API.Core.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany()
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.Team", "TeamFkNavigation")
                        .WithMany("TeamCampaign")
                        .HasForeignKey("TeamFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.UserCampaign", b =>
                {
                    b.HasOne("API.Core.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany()
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.UserComment", b =>
                {
                    b.HasOne("API.Core.Entities.Comment", "CommentFkNavigation")
                        .WithMany("UserComment")
                        .HasForeignKey("CommentFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.UserLikes", b =>
                {
                    b.HasOne("API.Core.Entities.Campaign", "CampaignFkNavigation")
                        .WithMany()
                        .HasForeignKey("CampaignFkNavigationId");

                    b.HasOne("API.Core.Entities.User", "UserFkNavigation")
                        .WithMany()
                        .HasForeignKey("UserFkNavigationId");
                });

            modelBuilder.Entity("API.Core.Entities.UserTeam", b =>
                {
                    b.HasOne("API.Core.Entities.Team", "TeamFkNavigation")
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

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Infrastructure.Data.Migrations
{
    public partial class MolliePayments : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CampaignName = table.Column<string>(nullable: true),
                    CampaignDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CommentContent = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Goal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    GoalStart = table.Column<DateTime>(nullable: false),
                    GoalEnd = table.Column<DateTime>(nullable: false),
                    MinAmount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MollieResponse",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    AmountRemaining = table.Column<decimal>(nullable: false),
                    AmountRemainingCurrency = table.Column<string>(nullable: true),
                    RedirectUrl = table.Column<string>(nullable: true),
                    WebhookUrl = table.Column<string>(nullable: true),
                    Locale = table.Column<string>(nullable: true),
                    CountryCode = table.Column<string>(nullable: true),
                    SubscriptionId = table.Column<string>(nullable: true),
                    OrderId = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    AmountCaptured = table.Column<decimal>(nullable: false),
                    AmountCapturedCurrency = table.Column<string>(nullable: true),
                    AmountRefunded = table.Column<decimal>(nullable: false),
                    AmountRefundedCurrency = table.Column<string>(nullable: true),
                    Resource = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: true),
                    IsCancelable = table.Column<bool>(nullable: false),
                    PaidAt = table.Column<DateTime>(nullable: true),
                    CanceledAt = table.Column<DateTime>(nullable: true),
                    ExpiresAt = table.Column<DateTime>(nullable: true),
                    ExpiredAt = table.Column<DateTime>(nullable: true),
                    FailedAt = table.Column<DateTime>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    AmountCurrency = table.Column<string>(nullable: true),
                    AuthorizedAt = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MollieResponse", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Subgoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoalStart = table.Column<DateTime>(nullable: false),
                    GoalEnd = table.Column<DateTime>(nullable: false),
                    MinAmount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Subgoal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamName = table.Column<string>(nullable: true),
                    TeamDescription = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CampaignGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CampaignFk = table.Column<int>(nullable: true),
                    GoalFk = table.Column<int>(nullable: true),
                    CampaignFkNavigationId = table.Column<int>(nullable: true),
                    GoalFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignGoal_Campaign_CampaignFkNavigationId",
                        column: x => x.CampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignGoal_Goal_GoalFkNavigationId",
                        column: x => x.GoalFkNavigationId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "GoalSubGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    GoalFk = table.Column<int>(nullable: true),
                    SubGoalFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    GoalFkNavigationId = table.Column<int>(nullable: true),
                    SubGoalFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GoalSubGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GoalSubGoal_Goal_GoalFkNavigationId",
                        column: x => x.GoalFkNavigationId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_GoalSubGoal_Subgoal_SubGoalFkNavigationId",
                        column: x => x.SubGoalFkNavigationId,
                        principalTable: "Subgoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TeamCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TeamFk = table.Column<int>(nullable: true),
                    CampaignFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CampaignFkNavigationId = table.Column<int>(nullable: true),
                    TeamFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TeamCampaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TeamCampaign_Campaign_CampaignFkNavigationId",
                        column: x => x.CampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TeamCampaign_Team_TeamFkNavigationId",
                        column: x => x.TeamFkNavigationId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MolliePayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    UserId = table.Column<int>(nullable: true),
                    GoalId = table.Column<int>(nullable: true),
                    SubGoalId = table.Column<int>(nullable: true),
                    Amount = table.Column<decimal>(nullable: false),
                    Status = table.Column<int>(nullable: false),
                    ResponseId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MolliePayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MolliePayment_Goal_GoalId",
                        column: x => x.GoalId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MolliePayment_MollieResponse_ResponseId",
                        column: x => x.ResponseId,
                        principalTable: "MollieResponse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MolliePayment_Subgoal_SubGoalId",
                        column: x => x.SubGoalId,
                        principalTable: "Subgoal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MolliePayment_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserCampaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFk = table.Column<int>(nullable: true),
                    CampaignFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CampaignFkNavigationId = table.Column<int>(nullable: true),
                    UserFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserCampaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserCampaign_Campaign_CampaignFkNavigationId",
                        column: x => x.CampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserCampaign_Users_UserFkNavigationId",
                        column: x => x.UserFkNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserComment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFk = table.Column<int>(nullable: true),
                    CommentFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CommentFkNavigationId = table.Column<int>(nullable: true),
                    UserFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserComment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserComment_Comment_CommentFkNavigationId",
                        column: x => x.CommentFkNavigationId,
                        principalTable: "Comment",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserComment_Users_UserFkNavigationId",
                        column: x => x.UserFkNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserLikes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFk = table.Column<int>(nullable: true),
                    CampaignFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CampaignFkNavigationId = table.Column<int>(nullable: true),
                    UserFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserLikes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserLikes_Campaign_CampaignFkNavigationId",
                        column: x => x.CampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserLikes_Users_UserFkNavigationId",
                        column: x => x.UserFkNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UserTeam",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFk = table.Column<int>(nullable: true),
                    TeamFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    TeamFkNavigationId = table.Column<int>(nullable: true),
                    UserFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserTeam", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserTeam_Team_TeamFkNavigationId",
                        column: x => x.TeamFkNavigationId,
                        principalTable: "Team",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserTeam_Users_UserFkNavigationId",
                        column: x => x.UserFkNavigationId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGoal_CampaignFkNavigationId",
                table: "CampaignGoal",
                column: "CampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignGoal_GoalFkNavigationId",
                table: "CampaignGoal",
                column: "GoalFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSubGoal_GoalFkNavigationId",
                table: "GoalSubGoal",
                column: "GoalFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_GoalSubGoal_SubGoalFkNavigationId",
                table: "GoalSubGoal",
                column: "SubGoalFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_MolliePayment_GoalId",
                table: "MolliePayment",
                column: "GoalId");

            migrationBuilder.CreateIndex(
                name: "IX_MolliePayment_ResponseId",
                table: "MolliePayment",
                column: "ResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_MolliePayment_SubGoalId",
                table: "MolliePayment",
                column: "SubGoalId");

            migrationBuilder.CreateIndex(
                name: "IX_MolliePayment_UserId",
                table: "MolliePayment",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCampaign_CampaignFkNavigationId",
                table: "TeamCampaign",
                column: "CampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_TeamCampaign_TeamFkNavigationId",
                table: "TeamCampaign",
                column: "TeamFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_CampaignFkNavigationId",
                table: "UserCampaign",
                column: "CampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserCampaign_UserFkNavigationId",
                table: "UserCampaign",
                column: "UserFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_CommentFkNavigationId",
                table: "UserComment",
                column: "CommentFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserComment_UserFkNavigationId",
                table: "UserComment",
                column: "UserFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_CampaignFkNavigationId",
                table: "UserLikes",
                column: "CampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserLikes_UserFkNavigationId",
                table: "UserLikes",
                column: "UserFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_TeamFkNavigationId",
                table: "UserTeam",
                column: "TeamFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserTeam_UserFkNavigationId",
                table: "UserTeam",
                column: "UserFkNavigationId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CampaignGoal");

            migrationBuilder.DropTable(
                name: "GoalSubGoal");

            migrationBuilder.DropTable(
                name: "MolliePayment");

            migrationBuilder.DropTable(
                name: "TeamCampaign");

            migrationBuilder.DropTable(
                name: "UserCampaign");

            migrationBuilder.DropTable(
                name: "UserComment");

            migrationBuilder.DropTable(
                name: "UserLikes");

            migrationBuilder.DropTable(
                name: "UserTeam");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "MollieResponse");

            migrationBuilder.DropTable(
                name: "Subgoal");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}

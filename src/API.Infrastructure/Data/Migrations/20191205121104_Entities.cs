using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace API.Infrastructure.Data.Migrations
{
    public partial class Entities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CampaignType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TypeName = table.Column<string>(nullable: true),
                    TypeDescription = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignType", x => x.Id);
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
                    GoalStart = table.Column<DateTime>(nullable: false),
                    GoalEnd = table.Column<DateTime>(nullable: false),
                    MinAmount = table.Column<int>(nullable: false),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Goal", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductName = table.Column<string>(nullable: true),
                    ProductDescription = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.Id);
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
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Campaign",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignName = table.Column<string>(nullable: true),
                    CampaignDescription = table.Column<string>(nullable: true),
                    CampaignType = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    UpdatedOn = table.Column<DateTime>(nullable: true),
                    CampaignTypeNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Campaign", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Campaign_CampaignType_CampaignTypeNavigationId",
                        column: x => x.CampaignTypeNavigationId,
                        principalTable: "CampaignType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductFk = table.Column<int>(nullable: true),
                    GoalFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    GoalFkNavigationId = table.Column<int>(nullable: true),
                    ProductFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductGoal_Goal_GoalFkNavigationId",
                        column: x => x.GoalFkNavigationId,
                        principalTable: "Goal",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductGoal_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductType",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProductFk = table.Column<int>(nullable: true),
                    ProductTypeFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ProductFkNavigationId = table.Column<int>(nullable: true),
                    ProductTypeFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductType_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductType_ProductType_ProductTypeFkNavigationId",
                        column: x => x.ProductTypeFkNavigationId,
                        principalTable: "ProductType",
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
                name: "UserProduct",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserFk = table.Column<int>(nullable: true),
                    ProductFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    ProductFkNavigationId = table.Column<int>(nullable: true),
                    UserFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProduct", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UserProduct_Product_ProductFkNavigationId",
                        column: x => x.ProductFkNavigationId,
                        principalTable: "Product",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UserProduct_Users_UserFkNavigationId",
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

            migrationBuilder.CreateTable(
                name: "CampaignsGoal",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CampaignFk = table.Column<int>(nullable: true),
                    GoalFk = table.Column<int>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: true),
                    CampaignFkNavigationId = table.Column<int>(nullable: true),
                    GoalFkNavigationId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CampaignsGoal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CampaignsGoal_Campaign_CampaignFkNavigationId",
                        column: x => x.CampaignFkNavigationId,
                        principalTable: "Campaign",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_CampaignsGoal_Goal_GoalFkNavigationId",
                        column: x => x.GoalFkNavigationId,
                        principalTable: "Goal",
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

            migrationBuilder.CreateIndex(
                name: "IX_Campaign_CampaignTypeNavigationId",
                table: "Campaign",
                column: "CampaignTypeNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignsGoal_CampaignFkNavigationId",
                table: "CampaignsGoal",
                column: "CampaignFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_CampaignsGoal_GoalFkNavigationId",
                table: "CampaignsGoal",
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
                name: "IX_ProductGoal_GoalFkNavigationId",
                table: "ProductGoal",
                column: "GoalFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductGoal_ProductFkNavigationId",
                table: "ProductGoal",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductFkNavigationId",
                table: "ProductType",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductType_ProductTypeFkNavigationId",
                table: "ProductType",
                column: "ProductTypeFkNavigationId");

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
                name: "IX_UserProduct_ProductFkNavigationId",
                table: "UserProduct",
                column: "ProductFkNavigationId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProduct_UserFkNavigationId",
                table: "UserProduct",
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
                name: "CampaignsGoal");

            migrationBuilder.DropTable(
                name: "GoalSubGoal");

            migrationBuilder.DropTable(
                name: "ProductGoal");

            migrationBuilder.DropTable(
                name: "ProductType");

            migrationBuilder.DropTable(
                name: "TeamCampaign");

            migrationBuilder.DropTable(
                name: "UserCampaign");

            migrationBuilder.DropTable(
                name: "UserComment");

            migrationBuilder.DropTable(
                name: "UserLikes");

            migrationBuilder.DropTable(
                name: "UserProduct");

            migrationBuilder.DropTable(
                name: "UserTeam");

            migrationBuilder.DropTable(
                name: "Subgoal");

            migrationBuilder.DropTable(
                name: "Goal");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Campaign");

            migrationBuilder.DropTable(
                name: "Product");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CampaignType");
        }
    }
}

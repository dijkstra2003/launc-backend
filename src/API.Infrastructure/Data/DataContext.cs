using API.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace API.Infrastructure.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Campaign> Campaign { get; set; }
        public DbSet<CampaignGoal> CampaignGoal { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<GoalSubGoal> GoalSubGoal { get; set; }
        public DbSet<SubGoal> Subgoal { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamCampaign> TeamCampaign { get; set; }
        public DbSet<UserCampaign> UserCampaign { get; set; }
        public DbSet<UserComment> UserComment { get; set; }
        public DbSet<UserLikes> UserLikes { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
        public DbSet<MolliePayment> MolliePayment { get; set; }
        public DbSet<MollieResponse> MollieResponse { get; set; }
    }
}

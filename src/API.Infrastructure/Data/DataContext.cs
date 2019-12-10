using API.Core.Entities;
using API.Infrastructure.Entities;
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
        public DbSet<CampaignGoal> CampaignsGoal { get; set; }
        public DbSet<CampaignType> CampaignType { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Goal> Goal { get; set; }
        public DbSet<GoalSubGoal> GoalSubGoal { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<ProductGoal> ProductGoal { get; set; }
        public DbSet<ProductType> ProductType { get; set; }
        public DbSet<SubGoal> Subgoal { get; set; }
        public DbSet<Team> Team { get; set; }
        public DbSet<TeamCampaign> TeamCampaign { get; set; }
        public DbSet<UserCampaign> UserCampaign { get; set; }
        public DbSet<UserComment> UserComment { get; set; }
        public DbSet<UserLikes> UserLikes { get; set; }
        public DbSet<UserProduct> UserProduct { get; set; }
        public DbSet<UserTeam> UserTeam { get; set; }
    }
}

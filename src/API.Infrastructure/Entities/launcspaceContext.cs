using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace API.Infrastructure.Entities
{
    public partial class launcspaceContext : DbContext
    {
        public launcspaceContext()
        {
        }

        public launcspaceContext(DbContextOptions<launcspaceContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Campaign> Campaign { get; set; }
        public virtual DbSet<CampaignGoal> CampaignGoal { get; set; }
        public virtual DbSet<CampaignType> CampaignType { get; set; }
        public virtual DbSet<Comment> Comment { get; set; }
        public virtual DbSet<Goal> Goal { get; set; }
        public virtual DbSet<GoalSubGoal> GoalSubGoal { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<ProductGoal> ProductGoal { get; set; }
        public virtual DbSet<ProductType> ProductType { get; set; }
        public virtual DbSet<SubGoal> SubGoal { get; set; }
        public virtual DbSet<Team> Team { get; set; }
        public virtual DbSet<TeamCampaign> TeamCampaign { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserCampaign> UserCampaign { get; set; }
        public virtual DbSet<UserComment> UserComment { get; set; }
        public virtual DbSet<UserLikes> UserLikes { get; set; }
        public virtual DbSet<UserProduct> UserProduct { get; set; }
        public virtual DbSet<UserTeam> UserTeam { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=85.214.24.229;Database=launcspace;Username=postgres;Password=monster");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Campaign>(entity =>
            {
                entity.ToTable("campaign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignDescription).HasColumnName("campaign_description");

                entity.Property(e => e.CampaignName)
                    .IsRequired()
                    .HasColumnName("campaign_name")
                    .HasMaxLength(150);

                entity.Property(e => e.CampaignType).HasColumnName("campaign_type");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.HasOne(d => d.CampaignTypeNavigation)
                    .WithMany(p => p.Campaign)
                    .HasForeignKey(d => d.CampaignType)
                    .HasConstraintName("campaign_campaign_type_fkey");
            });

            modelBuilder.Entity<CampaignGoal>(entity =>
            {
                entity.ToTable("campaign_goal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignFk).HasColumnName("campaign_fk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GoalFk).HasColumnName("goal_fk");

                entity.HasOne(d => d.CampaignFkNavigation)
                    .WithMany(p => p.CampaignGoal)
                    .HasForeignKey(d => d.CampaignFk)
                    .HasConstraintName("campaign_fk");

                entity.HasOne(d => d.GoalFkNavigation)
                    .WithMany(p => p.CampaignGoal)
                    .HasForeignKey(d => d.GoalFk)
                    .HasConstraintName("goal_fk");
            });

            modelBuilder.Entity<CampaignType>(entity =>
            {
                entity.ToTable("campaign_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TypeDescription).HasColumnName("type_description");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasColumnName("type_name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Comment>(entity =>
            {
                entity.ToTable("comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentContent)
                    .IsRequired()
                    .HasColumnName("comment_content");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Goal>(entity =>
            {
                entity.ToTable("goal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GoalEnd)
                    .HasColumnName("goal_end")
                    .HasColumnType("date");

                entity.Property(e => e.GoalStart)
                    .HasColumnName("goal_start")
                    .HasColumnType("date");

                entity.Property(e => e.MinAmount).HasColumnName("min_amount");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<GoalSubGoal>(entity =>
            {
                entity.ToTable("goal_sub_goal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GoalFk).HasColumnName("goal_fk");

                entity.Property(e => e.SubGoalFk).HasColumnName("sub_goal_fk");

                entity.HasOne(d => d.GoalFkNavigation)
                    .WithMany(p => p.GoalSubGoal)
                    .HasForeignKey(d => d.GoalFk)
                    .HasConstraintName("goal_fk");

                entity.HasOne(d => d.SubGoalFkNavigation)
                    .WithMany(p => p.GoalSubGoal)
                    .HasForeignKey(d => d.SubGoalFk)
                    .HasConstraintName("sub_goal_fk");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ProductDescription)
                    .IsRequired()
                    .HasColumnName("product_description");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasColumnName("product_name")
                    .HasMaxLength(150);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<ProductGoal>(entity =>
            {
                entity.ToTable("product_goal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GoalFk).HasColumnName("goal_fk");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.HasOne(d => d.GoalFkNavigation)
                    .WithMany(p => p.ProductGoal)
                    .HasForeignKey(d => d.GoalFk)
                    .HasConstraintName("goal_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.ProductGoal)
                    .HasForeignKey(d => d.ProductFk)
                    .HasConstraintName("product_fk");
            });

            modelBuilder.Entity<ProductType>(entity =>
            {
                entity.ToTable("product_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.ProductTypeFk).HasColumnName("product_type_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.ProductType)
                    .HasForeignKey(d => d.ProductFk)
                    .HasConstraintName("product_fk");

                entity.HasOne(d => d.ProductTypeFkNavigation)
                    .WithMany(p => p.InverseProductTypeFkNavigation)
                    .HasForeignKey(d => d.ProductTypeFk)
                    .HasConstraintName("product_type_fk");
            });

            modelBuilder.Entity<SubGoal>(entity =>
            {
                entity.ToTable("sub_goal");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.GoalEnd)
                    .HasColumnName("goal_end")
                    .HasColumnType("date");

                entity.Property(e => e.GoalStart)
                    .HasColumnName("goal_start")
                    .HasColumnType("date");

                entity.Property(e => e.MinAmount).HasColumnName("min_amount");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<Team>(entity =>
            {
                entity.ToTable("team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TeamDescription).HasColumnName("team_description");

                entity.Property(e => e.TeamName)
                    .HasColumnName("team_name")
                    .HasMaxLength(150);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");
            });

            modelBuilder.Entity<TeamCampaign>(entity =>
            {
                entity.ToTable("team_campaign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignFk).HasColumnName("campaign_fk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TeamFk).HasColumnName("team_fk");

                entity.HasOne(d => d.CampaignFkNavigation)
                    .WithMany(p => p.TeamCampaign)
                    .HasForeignKey(d => d.CampaignFk)
                    .HasConstraintName("campaign_fk");

                entity.HasOne(d => d.TeamFkNavigation)
                    .WithMany(p => p.TeamCampaign)
                    .HasForeignKey(d => d.TeamFk)
                    .HasConstraintName("team_fk");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(150);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasColumnName("first_name")
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .HasColumnName("last_name")
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnName("updated_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasColumnName("user_password")
                    .HasMaxLength(256);
            });

            modelBuilder.Entity<UserCampaign>(entity =>
            {
                entity.ToTable("user_campaign");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignFk).HasColumnName("campaign_fk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.CampaignFkNavigation)
                    .WithMany(p => p.UserCampaign)
                    .HasForeignKey(d => d.CampaignFk)
                    .HasConstraintName("campaign_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserCampaign)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("user_fk");
            });

            modelBuilder.Entity<UserComment>(entity =>
            {
                entity.ToTable("user_comment");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CommentFk).HasColumnName("comment_fk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.CommentFkNavigation)
                    .WithMany(p => p.UserComment)
                    .HasForeignKey(d => d.CommentFk)
                    .HasConstraintName("comment_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserComment)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("user_fk");
            });

            modelBuilder.Entity<UserLikes>(entity =>
            {
                entity.ToTable("user_likes");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CampaignFk).HasColumnName("campaign_fk");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.CampaignFkNavigation)
                    .WithMany(p => p.UserLikes)
                    .HasForeignKey(d => d.CampaignFk)
                    .HasConstraintName("campaign_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserLikes)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("user_fk");
            });

            modelBuilder.Entity<UserProduct>(entity =>
            {
                entity.ToTable("user_product");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.ProductFk).HasColumnName("product_fk");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.ProductFkNavigation)
                    .WithMany(p => p.UserProduct)
                    .HasForeignKey(d => d.ProductFk)
                    .HasConstraintName("product_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserProduct)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("user_fk");
            });

            modelBuilder.Entity<UserTeam>(entity =>
            {
                entity.ToTable("user_team");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CreatedOn)
                    .HasColumnName("created_on")
                    .HasDefaultValueSql("now()");

                entity.Property(e => e.TeamFk).HasColumnName("team_fk");

                entity.Property(e => e.UserFk).HasColumnName("user_fk");

                entity.HasOne(d => d.TeamFkNavigation)
                    .WithMany(p => p.UserTeam)
                    .HasForeignKey(d => d.TeamFk)
                    .HasConstraintName("team_fk");

                entity.HasOne(d => d.UserFkNavigation)
                    .WithMany(p => p.UserTeam)
                    .HasForeignKey(d => d.UserFk)
                    .HasConstraintName("user_fk");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}

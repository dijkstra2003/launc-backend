using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Web.Services
{
    public interface ICampaignGoalService
    {
        EntityEntry<CampaignGoal> Create(int campaignId, int goalId);
    }
    
    public class CampaignGoalService : ICampaignGoalService
    {
        private readonly DataContext _ctx;

        public CampaignGoalService(
            DataContext ctx
        ) {
            _ctx = ctx;
        }

        public EntityEntry<CampaignGoal> Create(
            int campaignId,
            int goalId
        ) {
            var campaignGoal = _ctx.CampaignGoal.Add(
                new CampaignGoal {
                    CampaignFk = campaignId,
                    GoalFk = goalId
                }
            );

            return campaignGoal;
        }
    }
}
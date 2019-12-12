using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace API.Web.Services
{
    public interface ICampaignService
    {
        EntityEntry<Campaign> Create(string campaignName, string campaignDescription);
    }

    public class CampaignService : ICampaignService
    {
        private readonly DataContext _ctx;
        
        public CampaignService(
            DataContext ctx
        ) {
            _ctx = ctx;
        }

        public EntityEntry<Campaign> Create(
            string campaignName, 
            string campaignDescription
        ) {
            var campaign = _ctx.Campaign.Add(new Campaign {
                CampaignName = campaignName,
                CampaignDescription = campaignDescription
            });

            _ctx.SaveChanges();

            return campaign;
        }

    }
}
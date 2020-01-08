using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace API.Web.Services
{
    public interface ICampaignService
    {
        EntityEntry<Campaign> Create(string campaignName, string campaignDescription, string campaignUrl, Goal goal);
        Campaign GetCampaignById(int id);
        List<Campaign> GetAll();
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
            string campaignDescription,
            string campaignUrl,
            Goal goal
        ) {
            var campaign = _ctx.Campaign.Add(new Campaign {
                CampaignName = campaignName,
                CampaignDescription = campaignDescription,
                CampaignUrl = campaignUrl,
                Goal = goal
            });

            _ctx.SaveChanges();

            return campaign;
        }

        public Campaign GetCampaignById(int id) {
            return _ctx.Campaign
                .Include(x => x.Goal)
                .Where(x => x.Id == id)
                .SingleOrDefault();
        }

        public List<Campaign> GetAll()
        {
            return _ctx.Campaign.ToList();
        }

    }
}
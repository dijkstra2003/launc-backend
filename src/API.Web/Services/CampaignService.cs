using API.Core.Entities;
using API.Infrastructure.Data;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Collections.Generic;
using System.Linq;

namespace API.Web.Services
{
    public interface ICampaignService
    {
        EntityEntry<Campaign> Create(string campaignName, string campaignDescription);
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
            string campaignDescription
        ) {
            var campaign = _ctx.Campaign.Add(new Campaign {
                CampaignName = campaignName,
                CampaignDescription = campaignDescription
            });

            _ctx.SaveChanges();

            return campaign;
        }

        public Campaign GetCampaignById(int id) {
            return _ctx.Campaign.Find(id);
        }

        public List<Campaign> GetAll()
        {
            return _ctx.Campaign.ToList();
        }

    }
}
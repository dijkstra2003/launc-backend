using Microsoft.AspNetCore.Mvc;
using API.Core.Dtos;
using API.Web.Services;
using AutoMapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using API.Core.Entities;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace API.Web.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;
        private IGoalService _goalService;
        private ICampaignGoalService _campaignGoalService;
        private IMapper _mapper;

        public CampaignController(
            ICampaignService campaignService,
            IGoalService goalService,
            ICampaignGoalService campaignGoalService,
            IMapper mapper
        ) {
            _campaignService = campaignService;
            _goalService = goalService;
            _campaignGoalService = campaignGoalService;
            _mapper = mapper;
        }

        [AllowAnonymous]
        [HttpGet("{campaignId}")]
        public ActionResult GetCampaignById(int campaignId) {
            var campaign = _campaignService.GetCampaignById(campaignId);
            return Ok(campaign);
        }

        [AllowAnonymous]
        [HttpGet]
        public ActionResult GetAll()
        {
            var campaigns = _campaignService.GetAll();
            return Ok(campaigns);
        }

        [HttpPost]
        public ActionResult CreateCampaignWithGoal([FromBody] CampaignDto campaign)
        {      
            var _goal = CreateGoal(campaign);
            var _campaign = CreateCampaign(campaign);
            var _campaignGoal = CreateCampaignGoal(_campaign.Entity.Id, _goal.Entity.Id);
            
            return Ok(_campaign.Entity);
        }

        private EntityEntry<Goal> CreateGoal(CampaignDto campaign) {
            var _goal = _goalService.Create(
                campaign.Goal.GoalStart,
                campaign.Goal.GoalEnd,
                campaign.Goal.MinAmount
            );

            return _goal;
        }

        private EntityEntry<Campaign> CreateCampaign(CampaignDto campaign) {
            var _campaign = _campaignService.Create(
                campaign.CampaignName,
                campaign.CampaignDescription
            );

            return _campaign;
        }

        private EntityEntry<CampaignGoal> CreateCampaignGoal(int campaignId, int goalId) {
            var _campaignGoal = _campaignGoalService.Create(
                campaignId,
                goalId
            );

            return _campaignGoal;
        }
    }
}
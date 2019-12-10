using Microsoft.AspNetCore.Mvc;
using API.Core.Dtos;
using API.Web.Services;
using AutoMapper;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;
        private IMapper _mapper;

        public CampaignController(
            ICampaignService campaignService,
            IMapper mapper
        ) {
            _campaignService = campaignService;
            _mapper = mapper;
        }

        [HttpPost]
        public ActionResult createCampaign([FromBody]CampaignDto campaign)
        {
            _campaignService.Create(
                campaign.CampaignName,
                campaign.CampaignDescription
            );

            return Ok();
        }
    }
}
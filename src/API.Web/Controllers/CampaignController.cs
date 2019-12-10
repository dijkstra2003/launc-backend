using Microsoft.AspNetCore.Mvc;
using API.Core.Dtos;
using API.Web.Services;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        private ICampaignService _campaignService;

        public CampaignController(
            ICampaignService campaignService
        ) {
            _campaignService = campaignService;
        }

        [HttpPost]
        public ActionResult createCampaign([FromBody]CampaignDto model)
        {
            //TODO: return
        }
    }
}
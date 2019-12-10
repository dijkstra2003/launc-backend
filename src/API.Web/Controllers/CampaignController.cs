using Microsoft.AspNetCore.Mvc;
using API.Core.Dtos;
using System.Collections.Generic;

namespace API.Web.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CampaignController : ControllerBase
    {
        [HttpPost]
        public ActionResult<IEnumerable<int>> Index()
        {
            return new int[] {1, 2, 3, 4, 5};
        }
    }
}
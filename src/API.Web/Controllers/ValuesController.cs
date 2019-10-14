using Microsoft.AspNetCore.Mvc;
using API.Web.Services;
using System.Threading.Tasks;

namespace API.Web.Controllers
{
    [Route("[controller]" )]
    [ApiController]
    public class ValuesController
    {
        private IValueService valueService;

        public ValuesController(IValueService valueService)
        {
            this.valueService = valueService;
        }
        
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            return id;
        }
    }
}
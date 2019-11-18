using Microsoft.AspNetCore.Mvc;
using API.Web.Services;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace API.Web.Controllers
{
    [Route("[controller]" )]
    [ApiController]
    public class ValuesController
    {
        private readonly IValueService valueService;

        public ValuesController(IValueService valueService)
        {
            this.valueService = valueService;
        }

        [HttpGet()]
        public ActionResult<IEnumerable<int>> Index()
        {
            return new int[] {1, 2, 3, 4};
        }
        
        [HttpGet("{id}")]
        public ActionResult<int> Get(int id)
        {
            return this.valueService.FetchValue(id);
        }
    }
}
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Core.Dtos;
using API.Tests.Intergration.Setup;
using API.Web;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;
using System;

namespace API.Tests.Intergration
{
    public class CampaignControllerTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private TestApiApplicationFactory<Startup> _factory;
        private HttpClient _client;     

        public CampaignControllerTest(ITestOutputHelper output) {
            _output = output;
            _factory = new TestApiApplicationFactory<Startup>();
            _client = _factory.CreateClient();
        }   

        public void Dispose()
        {
            _factory.Dispose();
            _client.Dispose();
        }

        [Fact]
        public async Task CreateCampaign()
        {
            DateTime goalStart = new DateTime();
            DateTime goalEnd = new DateTime();
            
            var goal = new GoalDto {
                GoalStart = goalStart,
                GoalEnd = goalEnd,
                MinAmount = 1337
            };

            var data = new CampaignDto {
                CampaignName = "campaign controller test",
                CampaignDescription = "the description for the campaign created in the controller test",
                Goal = goal
            };

            var result = await CreateCampaignRequest(data);

            Assert.Equal("campaign controller test", result.CampaignName);
        }

        private async Task<CampaignDto> CreateCampaignRequest(CampaignDto data) {
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/campaign", content);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            
            _output.WriteLine(stringResponse);
            
            return JsonConvert.DeserializeObject<CampaignDto>(stringResponse);
        }
    }
}
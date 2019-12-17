using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using API.Core.Dtos;
using API.Tests.Intergration.Setup;
using API.Web;
using Newtonsoft.Json;
using Xunit;
using Xunit.Abstractions;

namespace API.Tests.Intergration
{
    public class UserControllerTest : IClassFixture<TestApiApplicationFactory<Startup>>
    {
        private readonly ITestOutputHelper _output;
        private TestApiApplicationFactory<Startup> _factory;

        public UserControllerTest(ITestOutputHelper output, TestApiApplicationFactory<Startup> factory) {
            _output = output;
            _factory = factory;
        }

        [Fact]
        public async Task RegisterUser()
        {
            var data = new RegisterDto {
                Email = "joey3@example.com",
                Name = "Joey de Ruiter",
                Password = "Secret1337"
            };

            var result = await AddUserRequest(data);
            
            Assert.Equal("Joey de Ruiter", result.Name);
        }

        private async Task<UserDto> AddUserRequest(RegisterDto data)
        {
            var client = _factory.CreateClient();

            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await client.PostAsync("/users", content);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            
            _output.WriteLine(stringResponse);
            
            return JsonConvert.DeserializeObject<UserDto>(stringResponse);
        }
    }
}
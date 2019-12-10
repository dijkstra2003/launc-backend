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
    public class UserControllerTest : IDisposable
    {
        private readonly ITestOutputHelper _output;
        private TestApiApplicationFactory<Startup> _factory;
        private HttpClient _client;

        public UserControllerTest(ITestOutputHelper output) {
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
            var json = JsonConvert.SerializeObject(data);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/users", content);

            response.EnsureSuccessStatusCode();

            var stringResponse = await response.Content.ReadAsStringAsync();
            
            _output.WriteLine(stringResponse);
            
            return JsonConvert.DeserializeObject<UserDto>(stringResponse);
        }
    }
}
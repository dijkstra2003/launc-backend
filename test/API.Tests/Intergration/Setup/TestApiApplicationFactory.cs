using AutoMapper;
using API.Web;
using API.Web.Services;
using API.Infrastructure.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore.Storage;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.TestHost;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;

namespace API.Tests.Intergration.Setup
{
    public class TestApiApplicationFactory<TStartup> : WebApplicationFactory<Startup> where TStartup: class
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {
                
                // Remove the app's DataContext registration.
                {
                    var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));

                    if (descriptor != null)
                    {
                        services.Remove(descriptor);
                    }
                }

                // Use an in memory database for testing.
                services.AddDbContext<DataContext>(options => {
                    options.UseInMemoryDatabase("InMemoryTestingDb");
                });

                // Dependency injection (cannot use singletons because of the conflicting scope with the DbContext.)
                services.AddScoped<IUserService, UserService>();

                var sp = services.BuildServiceProvider();

                using (var scope = sp.CreateScope())
                {
                    var scopedServices = scope.ServiceProvider;
                    var dataContext = scopedServices.GetRequiredService<DataContext>();
                    var logger = scopedServices
                        .GetRequiredService<ILogger<TestApiApplicationFactory<TStartup>>>();
                    
                    dataContext.Database.EnsureCreated();

                    try 
                    {
                        SeedData.PopulateDb(dataContext);
                    }
                    catch (Exception ex)
                    {
                        logger.LogError(ex, "An error occurred seeding the " +
                            "database with test data. Error: {ex.Message}");
                    }
                }
            });        
        }

        public HttpClient CreateAuthClient() {
            var client = this.WithWebHostBuilder(builder => {
                builder.ConfigureTestServices(services => {

                    services
                        .AddAuthentication("Test")
                        .AddScheme<AuthenticationSchemeOptions, TestAuthHandler>("Test", options => {});

                    // Allow both the JWT authentication and our Test authentication method
                    services.AddAuthorization(options => {
                        var defaultAuthorizationPolicyBuilder = new AuthorizationPolicyBuilder(
                            JwtBearerDefaults.AuthenticationScheme,
                            "Test");

                        defaultAuthorizationPolicyBuilder = defaultAuthorizationPolicyBuilder.RequireAuthenticatedUser();

                        options.DefaultPolicy = defaultAuthorizationPolicyBuilder.Build();
                    });
                    
                    
                });
            }).CreateClient(new WebApplicationFactoryClientOptions { 
                AllowAutoRedirect = false 
            });

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Test");

            return client;
        }
    }
}
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

namespace API.Tests.Intergration.Setup
{
    public class TestApiApplicationFactory<TStartup> : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services => {

                var serviceProvider = new ServiceCollection()
                    .AddEntityFrameworkInMemoryDatabase()
                    .BuildServiceProvider();
                
                // services.AddAutoMapper(typeof(TStartup));

                services.AddMvc(
                    options => {
                        options.Filters.Add(new AllowAnonymousFilter());
                        options.Filters.Add(new FakeUserFilter());
                    }
                );

                // Remove the app's DataContext registration.
                var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<DataContext>));

                if (descriptor != null)
                {
                    services.Remove(descriptor);
                }

                // Use an in memory database for testing.
                services.AddDbContext<DataContext>(options => {
                    options.UseInMemoryDatabase("InMemoryTestingDb");
                    options.UseInternalServiceProvider(serviceProvider);
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
                            "database with test messages. Error: {ex.Message}");
                    }
                }
            });        
        }
    }
}
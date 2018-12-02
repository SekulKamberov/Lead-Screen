namespace LeadScreen.API.Infrastructure.Extensions
{
    using System;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;

    using LeadScreen.Data;
    using LeadScreen.Data.Seed;

    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder SeedDatabase(this IApplicationBuilder app)
        {
            IServiceProvider serviceProvider = app.ApplicationServices.CreateScope().ServiceProvider;
            try
            {
                var context = serviceProvider.GetService<LeadScreenDBContext>();
                DatabaseSeeder.InsertSeedData(context);
            }
            catch (Exception ex)
            {
                var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred while seeding the database.");
            }
            return app;
        }
    }
}

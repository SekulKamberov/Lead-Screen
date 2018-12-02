namespace LeadScreen.API
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.FileProviders;
	using Microsoft.WindowsAzure.Storage;

    using AutoMapper;

    using LeadScreen.Data;
    using LeadScreen.API.Infrastructure.Extensions;
    using LeadScreen.Data.Seed;
    using LeadScreen.AzureTable;
    using LeadScreen.Models.EntityModels;
    using LeadScreen.Services.Contracts;
    using LeadScreen.Services.Implementations;
    using LeadScreen.AzureTable.Models;

    public class Startup
    {

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
 
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<LeadScreenDBContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("DefaultConnection")));

            /* services.AddScoped<IAzureTableStorage<AzureLead>>(factory =>
            {
                return new AzureTableStorage<AzureLead>(
                    new AzureTableSettings(
                        storageAccount: Configuration["Table_StorageAccount"],
                        storageKey: Configuration["Table_StorageKey"],
                        tableName: Configuration["Table_TableName"]));
            }); */

            services.AddDomainServices();
            services.AddAutoMapper();

            services.AddMvc();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            //app.SeedDatabase();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
           
        }
    }
}
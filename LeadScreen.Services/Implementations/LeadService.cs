namespace LeadScreen.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using AutoMapper.QueryableExtensions;

    using LeadScreen.Data;
    using LeadScreen.Models.EntityModels;
    using LeadScreen.Models.ServiceModels;
    using LeadScreen.Services.Contracts;
    using Microsoft.EntityFrameworkCore;

    public class LeadService : ILeadService
    {
        private readonly LeadScreenDBContext db;

        public LeadService(LeadScreenDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> LeadExists(int id)
        {
            return await this.db.Leads.AnyAsync(b => b.Id == id);
        }

        public async Task<Lead> GetDetails(int id)
        {
            return await this.db.Leads.Where(b => b.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateLead(LeadCreateModel leadModel)
        {
            if (!this.db.Leads.Any(a => a.Id == leadModel.Id))
            {
                var lead = new Lead()
                {
                   Name = leadModel.Name,
                   PinCode = leadModel.PinCode,
                   SubArea = leadModel.SubArea,
                   Address = leadModel.Address,
                   MobileNumber = leadModel.MobileNumber,
                   Email = leadModel.Email
                };

                await this.db.Leads.AddAsync(lead);
                await this.db.SaveChangesAsync();
            }         
        }
    }
}
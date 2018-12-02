namespace LeadScreen.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using LeadScreen.Models.EntityModels;
    using LeadScreen.Models.ServiceModels;

    public interface ILeadService
    {
        Task<bool> LeadExists(int id);

        Task<Lead> GetDetails(int id);

        Task CreateLead(LeadCreateModel lead);
    }
}
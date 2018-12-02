namespace LeadScreen.Services.Contracts
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using LeadScreen.AzureTable.Models;

    public interface IAzureService
    {
        Task CreateLead(AzureLead item);

        Task DeleteLead(string releaseYear, string title);

        Task<bool> LeadExists(int partitionKey);

        Task<AzureLead> GetDetails(int partitionKey);

        //Task<bool> GetLead(int partitionKey);

        Task<List<AzureSubAreas>> SubAreasByPin(int partitionKey);

        Task<bool> LeadExists(string partitionKey, string rowKey);

        Task<bool> PinExists(int pinCode);

        Task UpdateLead(AzureLead item);
    }
}
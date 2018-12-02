namespace LeadScreen.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using LeadScreen.AzureTable;
    using LeadScreen.AzureTable.Models;
    using LeadScreen.Services.Contracts;

    public class AzureService : IAzureService
    {
        private const string rowKey = "Lead";
        private readonly IAzureTableStorage<AzureLead> repository;
        private readonly IAzureTableStorage<AzureSubAreas> repositorySubArea;

        public AzureService(IAzureTableStorage<AzureLead> repository, 
            IAzureTableStorage<AzureSubAreas> repositorySubArea)
        {
            this.repository = repository;
            this.repositorySubArea = repositorySubArea;
        }

        public async Task<List<AzureLead>> GetLeads()
        {
            return await this.repository.GetList();
        }

        public async Task<bool> LeadExists(int partitionKey)
        {
            return await this.repository.GetLead(partitionKey);
        }

        public async Task<bool> PinExists(int partitionKey)
        {
            return await this.repository.IsExisting(partitionKey.ToString(), rowKey);
        }

        public async Task<List<AzureSubAreas>> SubAreasByPin(int partitionKey)
        {
            return await this.repositorySubArea.GetSubAreasList(partitionKey);
        }

        public async Task<AzureLead> GetDetails(int partitionKey)
        {
            return await this.repository.GetItem(partitionKey.ToString(), rowKey);
        }

        public async Task CreateLead(AzureLead item)
        {
            await this.repository.Insert(item);
        }

        public async Task UpdateLead(AzureLead item)
        {
            await this.repository.Update(item);
        }

        public async Task DeleteLead(string releaseYear, string title)
        {
            await this.repository.Delete(releaseYear, title);
        }

        public async Task<bool> LeadExists(string partitionKey, string rowKey)
        {
            return await this.repository.GetItem(partitionKey, rowKey) != null;
        }
    }
}
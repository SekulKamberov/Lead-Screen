namespace LeadScreen.Services.Implementations
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using Microsoft.WindowsAzure.Storage;
    using Microsoft.WindowsAzure.Storage.Auth;
    using Microsoft.WindowsAzure.Storage.Table;

    using LeadScreen.AzureTable.Models;
    using LeadScreen.Services.Contracts;
    using LeadScreen.AzureTable;

    public class AzureTableStorage<T> : IAzureTableStorage<T>
           where T : AzureTableEntity, new()
    {
        private const string rowKey = "Lead";

        public AzureTableStorage(AzureTableSettings settings)
        {
            this.settings = settings;
        }

        public async Task<List<T>> GetList()
        {
            CloudTable table = await GetTableAsync();

            TableQuery<T> query = new TableQuery<T>();

            List<T> results = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<T> queryResults =
                    await table.ExecuteQuerySegmentedAsync(query, continuationToken);

                continuationToken = queryResults.ContinuationToken;
                results.AddRange(queryResults.Results);

            } while (continuationToken != null);

            return results;
        }

        public async Task<List<T>> GetList(string partitionKey)
        {
            CloudTable table = await GetTableAsync();

            TableQuery<T> query = new TableQuery<T>()
                                        .Where(TableQuery.GenerateFilterCondition("PartitionKey",
                                                QueryComparisons.Equal, partitionKey));

            List<T> results = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<T> queryResults =
                    await table.ExecuteQuerySegmentedAsync(query, continuationToken);

                continuationToken = queryResults.ContinuationToken;

                results.AddRange(queryResults.Results);

            } while (continuationToken != null);

            return results;
        }

        public async Task<List<T>> GetSubAreasList(int partitionKey)
        {
            CloudTable table = await GetTableAsync();

            TableQuery<T> query = new TableQuery<T>()
                                        .Where(TableQuery.GenerateFilterCondition("PartitionKey",
                                                QueryComparisons.Equal, partitionKey.ToString()));

            List<T> results = new List<T>();
            TableContinuationToken continuationToken = null;
            do
            {
                TableQuerySegment<T> queryResults =
                    await table.ExecuteQuerySegmentedAsync(query, continuationToken);

                continuationToken = queryResults.ContinuationToken;

                results.AddRange(queryResults.Results);

            } while (continuationToken != null);

            return results;
        }

        public async Task<bool> GetLead(int partitionKey)
        {
            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.Retrieve<T>(partitionKey.ToString(), rowKey);

            TableResult result = await table.ExecuteAsync(operation);

            AzureLead lead = result.Result as AzureLead;

            if (lead.Id == partitionKey)
            {
                return true;

            }

            return false;
        }

        public async Task<bool> IsExisting(string partitionKey, string rowKey)
        {
            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

            TableResult result = await table.ExecuteAsync(operation);
           
            AzureSubAreas pin = result.Result as AzureSubAreas;
            
            if (pin.PinCode.ToString() == partitionKey)
            {
                return true;
                
            }
            return false;
            
        }

        public async Task<T> GetItem(string partitionKey, string rowKey)
        {
            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.Retrieve<T>(partitionKey, rowKey);

            TableResult result = await table.ExecuteAsync(operation);

            return (T)(dynamic)result.Result;
        }
 
        public async Task Insert(T item)
        {
            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.Insert(item);

            await table.ExecuteAsync(operation);
        }

        public async Task Update(T item)
        {
            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.InsertOrReplace(item);

            await table.ExecuteAsync(operation);
        }

        public async Task Delete(string partitionKey, string rowKey)
        {
            T item = await GetItem(partitionKey, rowKey);

            CloudTable table = await GetTableAsync();

            TableOperation operation = TableOperation.Delete(item);

            await table.ExecuteAsync(operation);
        }

        private readonly AzureTableSettings settings;

        private async Task<CloudTable> GetTableAsync()
        {
            CloudStorageAccount storageAccount = new CloudStorageAccount(
                new StorageCredentials(this.settings.StorageAccount, this.settings.StorageKey), false);

            CloudTableClient tableClient = storageAccount.CreateCloudTableClient();

            CloudTable table = tableClient.GetTableReference(this.settings.TableName);
            await table.CreateIfNotExistsAsync();

            return table;
        }
    }
}
﻿namespace LeadScreen.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LeadScreen.AzureTable;

    public interface IAzureTableStorage<T> where T : AzureTableEntity, new()
    {
        Task Delete(string partitionKey, string rowKey);

        Task<bool> GetLead(int partitionKey);

        Task<bool> IsExisting(string partitionKey, string rowKey);

        Task<T> GetItem(string partitionKey, string rowKey);

        Task<List<T>> GetList();

        Task<List<T>> GetList(string partitionKey);

        Task<List<T>> GetSubAreasList(int partitionKey);

        Task Insert(T item);

        Task Update(T item);
    }
}
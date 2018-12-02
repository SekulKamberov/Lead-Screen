namespace LeadScreen.Services.Contracts
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using LeadScreen.Models.ServiceModels;

    public interface ISubAreaService
    {
        Task<bool> PinExists(int pinCode);

        Task<IEnumerable<LeadSubareaModel>> SubAreasByPin(int pinCode);
    }
}
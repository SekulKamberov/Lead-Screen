namespace LeadScreen.Services.Implementations
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using LeadScreen.Data;
    using LeadScreen.Models.ServiceModels;
    using LeadScreen.Services.Contracts;

    using AutoMapper.QueryableExtensions;

    public class SubAreaService : ISubAreaService
    {
        private readonly LeadScreenDBContext db;

        public SubAreaService(LeadScreenDBContext db)
        {
            this.db = db;
        }

        public async Task<bool> PinExists(int pinCode)
        {
            return await this.db.SubAreas.AnyAsync(p => p.PinCode == pinCode);
        }

        public async Task<IEnumerable<LeadSubareaModel>> SubAreasByPin(int pinCode)
        {
            return await this.db
                .SubAreas.Where(s => s.PinCode == pinCode)
                .ProjectTo<LeadSubareaModel>()
                .ToListAsync();
        }
    }
}
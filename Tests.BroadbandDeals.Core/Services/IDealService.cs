using System.Collections.Generic;
using System.Threading.Tasks;
using Tests.BroadbandDeals.Core.Entites;

namespace Tests.BroadbandDeals.Core.Services
{
    public interface IDealService
    {
        Task<IEnumerable<Deal>> GetAllAsync();
    }
}
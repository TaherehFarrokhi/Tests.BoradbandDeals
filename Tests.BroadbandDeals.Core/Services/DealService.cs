using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Microsoft.Extensions.FileProviders;
using Newtonsoft.Json;
using Tests.BroadbandDeals.Core.Entites;

namespace Tests.BroadbandDeals.Core.Services
{
    public class DealService : IDealService
    {
        private readonly IFileProvider _fileProvider;

        public DealService(IFileProvider fileProvider)
        {
            _fileProvider = fileProvider ?? throw new ArgumentNullException(nameof(fileProvider));
        }
        
        public async Task<IEnumerable<Deal>> GetAllAsync()
        {
            var fileInfo = _fileProvider.GetFileInfo(@"Files/deals.json");
            if(!fileInfo.Exists)
                throw new FileNotFoundException($"Deals file not found!");
            
            using (var stream = fileInfo.CreateReadStream())
            {
                using (var reader = new StreamReader(stream))
                {
                    var result = await reader.ReadToEndAsync();
                    var collection = JsonConvert.DeserializeObject<DealCollection>(result);

                    return collection.Deals;
                }
            }
        }
    }
}
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using tulsa_dnug_website.core.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class WebsiteDataService
    {
        private StaticDataService staticDataService;
        private IMemoryCache memoryCache;

        public WebsiteDataService(StaticDataService staticDataService, IMemoryCache memoryCache)
        {
            this.staticDataService = staticDataService;
            this.memoryCache = memoryCache;
        }

        public async Task<IEnumerable<Leader>> GetLeadersAsync()
        {
            var leadershipDetails = await memoryCache.GetOrCreate(CacheKeys.Leadership, async (entry) =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.UtcNow + TimeSpan.FromDays(1);                
                return await Task.FromResult(staticDataService.GetUserGroupLeadership());
            });

            return leadershipDetails;
        }
    }
}




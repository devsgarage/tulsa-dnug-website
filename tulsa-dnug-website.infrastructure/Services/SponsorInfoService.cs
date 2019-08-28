using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tulsa_dnug_website.core.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class SponsorInfoService
    {
        private StaticDataService staticDataService;
        private IMemoryCache memoryCache;

        public SponsorInfoService(StaticDataService staticDataService, IMemoryCache memoryCache)
        {
            this.staticDataService = staticDataService;
            this.memoryCache = memoryCache;
        }

        public async Task<IEnumerable<SponsorInfo>> GetSponsorsInfoAsync()
        {
            var sponsorInfo = await memoryCache.GetOrCreate(CacheKeys.SponsorInfo, async (entry) =>
            {
                entry.AbsoluteExpiration = DateTimeOffset.UtcNow + TimeSpan.FromDays(1);
                return await Task.FromResult(staticDataService.GetSponsorsInfo());
            });

            return sponsorInfo;
        }
    }
}

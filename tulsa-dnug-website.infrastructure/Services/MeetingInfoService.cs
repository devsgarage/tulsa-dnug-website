using Microsoft.Extensions.Caching.Memory;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using tulsa_dnug_website.core.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class MeetingInfoService
    {
        private MeetupService meetupService;
        private StaticDataService staticDataService;
        private IMemoryCache memoryCache;

        public MeetingInfoService(MeetupService meetupService, StaticDataService staticDataService, IMemoryCache memoryCache)
        {
            this.meetupService = meetupService;
            this.staticDataService = staticDataService;
            this.memoryCache = memoryCache;
        }

        public async Task<MeetingDetails> GetMeetingInfo()
        {
            var meetingDetails = await memoryCache.GetOrCreate(CacheKeys.MeetupInfo, async (entry) =>
            {                
                entry.AbsoluteExpiration = DateTimeOffset.UtcNow + TimeSpan.FromMinutes(1);
                try
                {
                    return await meetupService.GetMeetingInfo();
                }
                catch (Exception)
                {
                    return staticDataService.GetMeetingInfo();
                }
            });

            return meetingDetails;
        }

        public async Task<IEnumerable<AgendaItem>> GetAgenda()
        {
            return await Task.FromResult(staticDataService.GetMeetingAgenda());
        }
    }
}

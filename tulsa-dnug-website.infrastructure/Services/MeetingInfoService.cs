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

        public MeetingInfoService(MeetupService meetupService, StaticDataService staticDataService)
        {
            this.meetupService = meetupService;
            this.staticDataService = staticDataService;            
        }

        public async Task<MeetingDetails> GetMeetingInfo()
        {
            try
            {
                return await meetupService.GetMeetingInfo();
            }
            catch(Exception)
            {
                return staticDataService.GetMeetingInfo();
            }
        }
    }
}

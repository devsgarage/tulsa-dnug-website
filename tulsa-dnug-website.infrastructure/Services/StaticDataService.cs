using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using tulsa_dnug_website.core.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class StaticDataService
    {
        public MeetingDetails GetMeetingInfo()
        {
            return GetInfo<MeetingDetails>(@"wwwroot/site_info/venue.json").FirstOrDefault();
        }

        public IEnumerable<AgendaItem> GetMeetingAgenda()
        {
            return GetInfo<AgendaItem>(@"wwwroot/site_info/agenda.json");
        }

        public ExtraInfo GetExtraInformation()
        {   
            return GetInfo<ExtraInfo>(@"wwwroot/site_info/ExtraInformation.json").FirstOrDefault();
        }

        public IEnumerable<Leader> GetUserGroupLeadership()
        {
            return GetInfo<Leader>(@"wwwroot/site_info/Leadership.json");
        }

        public IEnumerable<SponsorInfo> GetSponsorsInfo()
        {
            return GetInfo<SponsorInfo>(@"wwwroot/site_info/sponsorsInfo.json");
        }

        private IEnumerable<T> GetInfo<T>(string infoLocation)
        {
            try
            {
                using (StreamReader sr = new StreamReader(infoLocation))
                {
                    // Read the stream to a string, and write the string to the console.
                    String jsonString = sr.ReadToEnd();
                    var sponsorInfo = JsonConvert.DeserializeObject<T[]>(jsonString);
                    return sponsorInfo;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

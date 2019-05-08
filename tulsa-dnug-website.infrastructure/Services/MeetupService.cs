using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using tulsa_dnug_website.core.Models;
using tulsa_dnug_website.infrastructure.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class MeetupService
    {
        private HttpClient client;
        public MeetupService(HttpClient client)
        {
            this.client = client;
        }

        public async Task<MeetingDetails> GetMeetingInfo()
        {

            var url = "https://api.meetup.com/TulsaDevelopers-net/events";
            var results = await client.GetStringAsync(url);
            var meetupEvents = MeetupEvents.FromJson(results);
            var meetupEvent = meetupEvents.FirstOrDefault();                
            
            return meetupEvent.ToMeetingDetails();
        }
    }

    public static class ConversionHelpers
    {
        public static MeetingDetails ToMeetingDetails(this MeetupEvents meetupEvent)
        {
            var details = new MeetingDetails();
            details.Address = meetupEvent.Venue.Address1;
            details.City = meetupEvent.Venue.City;
            details.State = meetupEvent.Venue.State;
            details.Zip = meetupEvent.Venue.Zip;
            details.MeetingTime = meetupEvent.LocalTime;
            details.Building = meetupEvent.HowToFindUs;

            return details;
        }
    }
}

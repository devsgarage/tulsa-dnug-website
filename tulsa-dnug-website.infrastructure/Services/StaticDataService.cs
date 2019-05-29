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
            try
            {
                using (StreamReader sr = new StreamReader(@"wwwroot/site_info/venue.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String jsonString = sr.ReadToEnd();
                    var meetingdetails = JsonConvert.DeserializeObject<MeetingDetails[]>(jsonString).FirstOrDefault();
                    return meetingdetails;
                }
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public IEnumerable<AgendaItem> GetMeetingAgenda()
        {
            try
            {
                using (StreamReader sr = new StreamReader(@"wwwroot/site_info/agenda.json"))
                {
                    // Read the stream to a string, and write the string to the console.
                    String jsonString = sr.ReadToEnd();
                    var agenda = JsonConvert.DeserializeObject<AgendaItem[]>(jsonString).ToList();
                    return agenda;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}

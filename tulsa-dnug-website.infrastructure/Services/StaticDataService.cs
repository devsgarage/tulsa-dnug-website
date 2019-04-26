using System;
using System.Collections.Generic;
using System.Text;
using tulsa_dnug_website.core.Models;

namespace tulsa_dnug_website.infrastructure.Services
{
    public class StaticDataService
    {
        public MeetingDetails GetMeetingInfo()
        {
            return new MeetingDetails()
            {
                Address = "6100 S.Yale",
                City = "Tulsa",
                State = "OK",
                Zip = "74136",
                MeetingTime = "18:00",
                Building = "First floor of Warren I Building. Patriot Room."
            };
        }
    }
}

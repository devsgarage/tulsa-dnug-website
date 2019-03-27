using System;
using System.Collections.Generic;
using System.Text;

namespace tulsa_dnug_website.shared_kernel.Models
{
    public class Leader
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
    }

    public static class LeaderTitles
    {
        public const string President = "President";
        public const string VicePresident = "Vice-President";
    }
}

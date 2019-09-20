using System;
using System.Collections.Generic;
using System.Text;

namespace tulsa_dnug_website.core.Models
{
    public class SponsorInfo
    {
        public string Name { get; set; }

        public string Logo { get; set; }

        public int Position { get; set; }

        //Display name only, logo only, or display both name and logo
        public ShowInfoEnum ShowInfo { get; set; }
    }

    public enum ShowInfoEnum
    {
        Name,
        Logo,
        Both
    }
}

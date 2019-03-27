using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tulsa_dnug_website.api.DAL
{
    public static class RepoFactory
    {
        public static ILeaderRepository GetLeaderRepository(string repoType)
        {
            switch (repoType)
            {
                case "JSON":
                    return new LeaderRepositoryJSON();
                default:
                    throw new NotSupportedException();
            }
        }
    }
}

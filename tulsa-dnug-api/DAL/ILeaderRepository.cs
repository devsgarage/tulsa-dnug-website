using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using tulsa_dnug_website.shared_kernel.Models;

namespace tulsa_dnug_website.api.DAL
{
    public interface ILeaderRepository : IDisposable
    {
        IEnumerable<Leader> GetLeaders();
        Leader GetLeader(int Id);
    }
}

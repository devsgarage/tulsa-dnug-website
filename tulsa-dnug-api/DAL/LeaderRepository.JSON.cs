using Microsoft.Win32.SafeHandles;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using tulsa_dnug_website.shared_kernel.Models;

namespace tulsa_dnug_website.api.DAL
{
    public class LeaderRepositoryJSON : ILeaderRepository
    {
        private bool disposed;

        public IEnumerable<Leader> GetLeaders()
        {
            IEnumerable<Leader> leaders = new List<Leader>();

            using (StreamReader sr = new StreamReader(@"DAL/leaders.json"))
            {
                // Read the stream to a string, and write the string to the console.
                String jsonString = sr.ReadToEnd();
                leaders = JsonConvert.DeserializeObject<Leader[]>(jsonString).ToList();  
            }

            return leaders;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        // Protected implementation of Dispose pattern.
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                // Free any other managed objects here.
                //
            }

            disposed = true;
        }

        public Leader GetLeader(int Id)
        {
            return GetLeaders().Where(m => m.Id == Id).FirstOrDefault();
        }
    }
}

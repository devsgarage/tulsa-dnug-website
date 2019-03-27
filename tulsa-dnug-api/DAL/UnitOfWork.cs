using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace tulsa_dnug_website.api.DAL
{
    public class UnitOfWork : IDisposable
    {
        private ILeaderRepository leaderRepository;
        private string repoType;

        public UnitOfWork() : this(defaultRepoType)
        {
        }

        public UnitOfWork(string repoType)
        {
            this.repoType = repoType;
        }
        
        public ILeaderRepository LeaderRepository
        {
            get
            {
                if (this.leaderRepository == null)
                {
                    this.leaderRepository = RepoFactory.GetLeaderRepository(this.repoType);
                }

                return leaderRepository;
            }
        }

        public void Save()
        {
            
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                // do cleanup
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private const string defaultRepoType = "JSON";
    }
}

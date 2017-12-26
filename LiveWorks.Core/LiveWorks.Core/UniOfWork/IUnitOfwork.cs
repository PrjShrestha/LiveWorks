using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LiveWorks.Core.UniOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task<int> CommitAsync();
    }
}

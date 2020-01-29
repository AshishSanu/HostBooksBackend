using HostBooks.Repos.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace HostBooks.Repos.UnitOfWorkInterface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<T> Repository<T>() where T : class;

        void Save();

        Task<int> SaveAsync();

        void Dispose(bool disposing);
    }
}

using HostBooks.Data.Models;
using HostBooks.Repos.Interfaces;
using HostBooks.Repos.UnitOfWorkInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Collections;

namespace HostBooks.Repos
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HostBooksContext _context;
        private bool _disposed;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private Guid _objectId;

        public UnitOfWork(HostBooksContext context)
        {
            _context = context;
            _objectId = Guid.NewGuid();
        }

        public IRepository<T> Repository<T>() where T : class
        {
            if (repositories.Keys.Contains(typeof(T)) == true)
            {
                return repositories[typeof(T)] as GenericRepository<T>;
            }
            GenericRepository<T> repo = new GenericRepository<T>(_context);
            repositories.Add(typeof(T), repo);
            return repo;
        }

        public void Save()
        {
            try
            {
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                throw e;
            }

        }
        public async Task<int> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!_disposed && disposing)
            {
                _context.Dispose();
                
            }
            _disposed = true;
        }

    }
}

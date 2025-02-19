using Arabytak.Core.Entities;
using Arabytak.Core.Repositories.Contract;
using Arabytak.Repository.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Repository.Repository.Contract
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArabytakContext _context;
        private Hashtable _repositories;
        public UnitOfWork(ArabytakContext context)
        {
            _context = context;
            _repositories = new Hashtable();
        }

        public async Task<int> CompleteAsync()
        {
          return await _context.SaveChangesAsync();
        }

        public async ValueTask DisposeAsync()
        {
           await _context.DisposeAsync();
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
          var key=typeof(TEntity).Name;// EntityName
            if(!_repositories.ContainsKey(key))
            {
                var Repository= new GenericRepository<TEntity>(_context);
                _repositories.Add(key, Repository);
            }
            return _repositories[key] as IGenericRepository<TEntity>;
        }
    }
}

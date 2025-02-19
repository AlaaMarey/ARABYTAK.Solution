using Arabytak.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arabytak.Core.Repositories.Contract
{
    public interface IUnitOfWork:IAsyncDisposable// use IAsyncDisposable To Clean after end use unit of work in DB
    {
        IGenericRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task<int> CompleteAsync();
    }
}

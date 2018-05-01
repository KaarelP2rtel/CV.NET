using DAL.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAL.EF.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected DbContext RepositoryDbContext;
        protected DbSet<TEntity> RepositoryDbSet;
        public EFRepository(DbContext dataContext)
        {
            RepositoryDbContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            RepositoryDbSet = dataContext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            RepositoryDbSet.Add(entity);
        }

        public virtual async Task<EntityEntry<TEntity>> AddAsync(TEntity entity)
        {
            return await RepositoryDbSet.AddAsync(entity);
        }

        public virtual IEnumerable<TEntity> All()
        {
            return RepositoryDbSet.ToList();
        }

        public virtual async Task<IEnumerable<TEntity>> AllAsync()
        {
            return await RepositoryDbSet.ToListAsync();
        }

        public virtual TEntity Find(params object[] id)
        {
            return RepositoryDbSet.Find(id);
        }

        public virtual async Task<TEntity> FindAsync(params object[] id)
        {
            return await RepositoryDbSet.FindAsync(id);
        }

        public virtual void Remove(TEntity entity)
        {
            RepositoryDbSet.Remove(entity);
        }

        public virtual void Remove(params object[] id)
        {
            RepositoryDbSet.Remove(Find(id));
        }

        public virtual TEntity Update(TEntity entity)
        {
            return RepositoryDbSet.Update(entity).Entity;
        }


        //Despite what this method looks like, it actually only uses 
        //the primary key not the entire entity.
        public virtual bool ExistsInDb(TEntity entity)
        {
            return RepositoryDbSet.Any(e => e == entity);
        }

    }
}

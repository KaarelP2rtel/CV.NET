using System;
using System.Collections.Generic;
using CV.Data;
using DAL.App.Interfaces.Helpers;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using DAL.Interfaces;

namespace DAL.App.EF.Helpers
{
    public class EFRepositoryFactory : IRepositoryFactory
    {
        private readonly Dictionary<Type, Func<IDataContext, object>> _customRepositoryFactories
            = GetCustomRepoFactories();

        private static Dictionary<Type, Func<IDataContext, object>> GetCustomRepoFactories()
        {
            return new Dictionary<Type, Func<IDataContext, object>>()
            {
                 {typeof(ICvRepository), (dataContext) => new EFCvRepository(dataContext as ApplicationDbContext) },
                 {typeof(IEducationRepository), (dataContext) => new EFEducationRepository(dataContext as ApplicationDbContext) },
                 {typeof(IExtraRepository), (dataContext) => new  EFExtraRepository(dataContext as ApplicationDbContext) },
                 {typeof(ISkillRepository), (dataContext) => new EFSkillRepository(dataContext as ApplicationDbContext) },
                 {typeof(IWorkExperienceRepository), (dataContext) => new EFWorkExperienceRepository(dataContext as ApplicationDbContext) },
              

            };
        }

        public Func<IDataContext, object> GetCustomRepositoryFactory<TRepoInterface>() where TRepoInterface : class
        {
            _customRepositoryFactories.TryGetValue(
                typeof(TRepoInterface), 
                out Func<IDataContext, object> factory
            );
            return factory;
        }

        public Func<IDataContext, object> GetStandardRepositoryFactory<TEntity>() where TEntity : class
        {

            return (dataContext) => new EFRepository<TEntity>(dataContext as ApplicationDbContext);
        }
    }
}

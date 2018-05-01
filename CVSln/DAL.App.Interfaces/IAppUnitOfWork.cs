using System;
using System.Collections.Generic;
using System.Text;
using DAL.App.Interfaces.Repositories;
using DAL.Interfaces;
using DAL.Interfaces.Repositories;
using Domain;

namespace DAL.App.Interfaces
{
    public interface IAppUnitOfWork : IUnitOfWork
    {
        

        
        IRepository<Cv> Cvs { get; }
        IRepository<Education> Educations { get; }
        IRepository<Extra> Extras { get; }
        IRepository<Skill> Skills { get; }
        IRepository<WorkExperience> WorkExperiences { get; }


    }
}

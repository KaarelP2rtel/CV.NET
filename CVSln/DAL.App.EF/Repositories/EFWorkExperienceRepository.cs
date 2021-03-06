﻿using CV.Data;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class EFWorkExperienceRepository : EFRepository<WorkExperience>, IWorkExperienceRepository
    {
        public EFWorkExperienceRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
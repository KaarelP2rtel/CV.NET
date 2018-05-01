using CV.Data;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class EFSkillRepository : EFRepository<Skill>, ISkillRepository
    {
        public EFSkillRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
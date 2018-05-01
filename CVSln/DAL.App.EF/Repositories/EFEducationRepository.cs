using CV.Data;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class EFEducationRepository : EFRepository<Education>, IEducationRepository
    {
        public EFEducationRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
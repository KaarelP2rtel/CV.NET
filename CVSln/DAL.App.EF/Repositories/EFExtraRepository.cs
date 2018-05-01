using CV.Data;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class EFExtraRepository : EFRepository<Extra>, IExtraRepository
    {
        public EFExtraRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
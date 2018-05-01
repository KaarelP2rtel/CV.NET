using CV.Data;
using DAL.App.Interfaces.Repositories;
using DAL.EF.Repositories;
using Domain;
using Microsoft.EntityFrameworkCore;

namespace DAL.App.EF.Helpers
{
    public class EFCvRepository : EFRepository<Cv>, ICvRepository
    {
        public EFCvRepository(DbContext dataContext) : base(dataContext)
        {
        }
    }
}
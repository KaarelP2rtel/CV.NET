using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        public override IEnumerable<Cv> All()
        {
            return RepositoryDbSet
                .Include(c => c.Educations)
                .Include(c => c.Skills)
                .Include(c => c.WorkExperiences)
                .Include(c => c.Extras);
        }
        public override async Task<IEnumerable<Cv>> AllAsync()
        {
            return await RepositoryDbSet
                .Include(c => c.Educations)
                .Include(c => c.Skills)
                .Include(c => c.WorkExperiences)
                .Include(c => c.Extras)
                .ToListAsync();
        }
        public override Cv Find(params object[] id)
        {
            return RepositoryDbSet
                .Include(c => c.Educations)
                .Include(c => c.Skills)
                .Include(c => c.WorkExperiences)
                .Include(c => c.Extras)
                .Where(c => c.CvId == (int)id[0])
                .SingleOrDefault();
        }
    }
}
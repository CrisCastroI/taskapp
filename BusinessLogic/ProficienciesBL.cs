using Class13.DAO;
using Class13.Domain;
using Class13.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Class13.BusinessLogic
{
    public class ProficienciesBL:IProficiencyRepository
    {
        private readonly ApiContext _context;

        public ProficienciesBL(ApiContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public async Task<List<ProficienciesE>> getAllProficiencies(CancellationToken cancellationToken)
        {
            return await _context.ProficienciesE
                .Include(e => e.Goals)                
                .ThenInclude(e => e.Milestones)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

using Class13.DAO;
using Class13.Domain;
using Class13.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Class13.BusinessLogic
{
    public class MilestoneBL:IMilestoneRepository
    {
        private readonly ApiContext _context;

        public MilestoneBL(ApiContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public async Task<List<MilestonesE>> getAllMilestones(CancellationToken cancellationToken)
        {
            return await _context.MilestonesE
                .Include(e => e.Goal)                
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

using Class13.DAO;
using Class13.Domain;
using Class13.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Class13.BusinessLogic
{
    public class GoalsBL:IGoalRepository
    {
        private readonly ApiContext _context;

        public GoalsBL(ApiContext context)
        {
            ArgumentNullException.ThrowIfNull(context);
            _context = context;
        }

        public async Task<List<GoalsE>> getAllGoals(CancellationToken cancellationToken)
        {
            return await _context.GoalsE
                .Include(e => e.Task)                
                .Include(e => e.Proficiency)
                .Include(e => e.Milestones)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }
    }
}

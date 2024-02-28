using Class13.Domain;

namespace Class13.DAO
{
    public interface IGoalRepository
    {
        Task<List<GoalsE>> getAllGoals(CancellationToken cancellationToken);
    }
}

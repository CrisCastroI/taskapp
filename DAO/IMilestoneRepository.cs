using Class13.Domain;

namespace Class13.DAO
{
    public interface IMilestoneRepository
    {
        Task<List<MilestonesE>> getAllMilestones(CancellationToken cancellationToken);
    }
}

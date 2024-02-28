using Class13.Domain;

namespace Class13.DAO
{
    public interface IProficiencyRepository
    {
        Task<List<ProficienciesE>> getAllProficiencies(CancellationToken cancellationToken);
    }
}

using Class13.Domain;

namespace Class13.DAO
{
    public interface IUserRepository
    {
        Task<List<UsersE>> getAllUsers(CancellationToken cancellationToken);
        Task<UsersE> getUser(Guid idUser, CancellationToken cancellationToken);
    }
}

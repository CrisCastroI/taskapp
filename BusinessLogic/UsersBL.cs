using Class11.DAO;
using Class13.DAO;
using Class13.Domain;
using Class13.DTO;
using Class13.Exceptions;
using Class13.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Class13.BusinessLogic
{
    public class UsersBL: IUserRepository
    {
        private readonly ApiContext _context;        

        public UsersBL(ApiContext context)
        {
            ArgumentNullException.ThrowIfNull(context);            
            _context = context;            
        }

        public async Task<List<UsersE>> getAllUsers(CancellationToken cancellationToken)
        {
            return await _context.UserE
                .Include(e => e.Tasks)
                .ThenInclude(e => e.Goals)
                .ThenInclude(e => e.Milestones)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<UsersE> getUser(Guid idUser, CancellationToken cancellationToken)
        {
            UsersE? result = await _context.UserE
                .Include(e => e.Tasks)
                .ThenInclude(e => e.Goals)
                .ThenInclude(e => e.Milestones)
                .AsNoTracking()
                .FirstOrDefaultAsync(e => e.Id == idUser, cancellationToken);
            NotFoundException.ThrowIfNull(result);

            return result!;                  
        }
    }
}

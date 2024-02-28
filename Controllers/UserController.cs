using Class11.DAO;
using Class13.DAO;
using Class13.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Class13.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/api/{v:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        IUserRepository userRepository;

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<UsersE>> GetAllUsers(CancellationToken cancellationToken)
        {
            return await userRepository.getAllUsers(cancellationToken);
        }
      
        [HttpGet("{idUser}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<UsersE> GetUserById(Guid idUser, CancellationToken cancellationToken)
        {
            return await userRepository.getUser(idUser, cancellationToken);
        }

    }
}

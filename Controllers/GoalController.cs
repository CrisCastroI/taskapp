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
    public class GoalController:ControllerBase
    {
        IGoalRepository goalRepository;

        public GoalController(IGoalRepository goalRepository)
        {
            this.goalRepository = goalRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<GoalsE>> GetAllGoals(CancellationToken cancellationToken)
        {
            return await goalRepository.getAllGoals(cancellationToken);
        }
    }
}

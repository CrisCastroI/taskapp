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
    public class MilestoneController
    {
        IMilestoneRepository milestoneRepository;

        public MilestoneController(IMilestoneRepository milestoneRepository)
        {
            this.milestoneRepository = milestoneRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<MilestonesE>> GetAllMilestones(CancellationToken cancellationToken)
        {
            return await milestoneRepository.getAllMilestones(cancellationToken);
        }
    }
}

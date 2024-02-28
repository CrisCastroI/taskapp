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
    public class ProficiencyController:ControllerBase
    {

        IProficiencyRepository proficiencyRepository;

        public ProficiencyController(IProficiencyRepository proficiencyRepository)
        {
            this.proficiencyRepository = proficiencyRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<ProficienciesE>> GetAllProficiencies(CancellationToken cancellationToken)
        {
            return await proficiencyRepository.getAllProficiencies(cancellationToken);
        }
    }
}

using System.Text.Json;
using System.Text.Json.Serialization;
using Class11.BusinessLogic;
using Class11.DAO;
using Class12.DTO;
using Class13.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Class11.Controllers
{
    [ApiController]
    [Authorize]
    [ApiVersion("1.0")]
    [Route("/api/{v:apiVersion}/[controller]")]
    public class TaskController : ControllerBase
    {
        ITaskRepository taskRepository;

        public TaskController(ITaskRepository taskRepository)
        {
            this.taskRepository = taskRepository;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<IEnumerable<TaskE>> GetAllTasks(CancellationToken cancellationToken)
        {
            return await taskRepository.getAllTasks(cancellationToken); 
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<TaskE> GetAllTasks(Guid id, CancellationToken cancellationToken)
        {
            return await taskRepository.getTask(id, cancellationToken);
        }

        [HttpGet("/Tasks/Page")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IEnumerable<TaskE>> GetAllTasks([FromQuery] int pageNumber, [FromQuery] int pageSize, CancellationToken cancellationToken)
        {
            PaginationDto paginationDto = new PaginationDto(pageSize,pageNumber);            
            Response.Headers.Add("X-Pagination", JsonSerializer.Serialize(paginationDto));
            return await taskRepository.getTasksPaged(pageSize, pageNumber, cancellationToken);
        }

        [HttpPost(Name = "CreateTask")]        
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        public async Task<IActionResult> PostTask(TaskDto task, CancellationToken cancellationToken) {            
            TaskE newTask = await taskRepository.createTask(task, cancellationToken);
            return CreatedAtRoute("CreateTask", new {id = newTask.TaskId},newTask);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        public async Task<IActionResult> PutTask(TaskDto task, Guid id, CancellationToken cancellationToken)
        {
            await taskRepository.updateTask(task, id, cancellationToken);
            return Ok(task);            
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [Consumes("application/json")]
        public async Task<IActionResult> DeleteTask(Guid id, CancellationToken cancellationToken)
        {
            await taskRepository.deleteTask(id, cancellationToken);
            return NoContent();            
        }

        [HttpGet("user/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<List<TaskE>> GetTasksByUser(Guid id, CancellationToken cancellationToken)
        {
            return await taskRepository.getTasksByUser(id, cancellationToken);
        }

    }
    
}

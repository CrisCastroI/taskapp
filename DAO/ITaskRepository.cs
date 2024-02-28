using Class13.Domain;

namespace Class11.DAO
{
    public interface ITaskRepository
    {
        Task<List<TaskE>> getAllTasks(CancellationToken cancellationToken);
        Task<TaskE> getTask(Guid taskId, CancellationToken cancellationToken);
        Task<List<TaskE>> getTasksPaged(int pageSize, int pageNumber, CancellationToken cancellationToken);
        Task<TaskE> createTask(TaskDto task, CancellationToken cancellationToken);

        Task updateTask(TaskDto task, Guid idTask, CancellationToken cancellationToken);
        Task deleteTask(Guid idTask, CancellationToken cancellationToken);    
        
        Task<List<TaskE>> getTasksByUser(Guid idUser,  CancellationToken cancellationToken);
    }
}

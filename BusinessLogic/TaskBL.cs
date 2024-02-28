using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Class11.DAO;
using Class12.Persistence;
using Class13.Domain;
using Class13.Exceptions;
using Class13.Persistence;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Class11.BusinessLogic
{
    public class TaskBL:ITaskRepository
    {
        private readonly ApiContext _context;
        private readonly IValidator<TaskDto> _validator;
        

        public TaskBL(ApiContext context, IValidator<TaskDto> validator)
        {
            ArgumentNullException.ThrowIfNull(context);
            ArgumentNullException.ThrowIfNull(validator);
            _context = context;
            _validator = validator;            
        }

        public async Task<List<TaskE>> getAllTasks(CancellationToken cancellationToken)
        {                                   
            return await _context.TasksE
                .Include(e => e.User)
                .Include(e => e.Goals)
                .AsNoTracking()
                .ToListAsync(cancellationToken);
        }

        public async Task<TaskE> getTask(Guid taskId, CancellationToken cancellationToken)
        {           
            TaskE ?result = await _context.TasksE
                .Include (e => e.User)
                .Include(e => e.Goals)
                .AsNoTracking()
                .FirstOrDefaultAsync(b => b.TaskId == taskId, cancellationToken);
            NotFoundException.ThrowIfNull(result);

            return result!;
        }

        public async Task<List<TaskE>> getTasksPaged(int pageSize, int pageNumber, CancellationToken cancellationToken)
        {
            var pagedTasks = await (_context.TasksE).Skip(pageSize * (pageNumber - 1))
                .Take(pageSize)
                .ToListAsync(cancellationToken);               
            return pagedTasks;
        }

        public async Task<TaskE> createTask(TaskDto task, CancellationToken cancellationToken)
        {
            _validator.ValidateAndThrow(task);
            UsersE? user = await _context.UserE.FirstOrDefaultAsync(e => e.Id == task.idUser);
            NotFoundException.ThrowIfNull(user);
            TaskE newTask = new TaskE();
            newTask.TaskId = Guid.NewGuid();            
            newTask.TaskDescription = task.description;
            newTask.TaskName = task.name;
            newTask.creationDate = DateTime.Now.ToString("dd-MM-yyyy");
            newTask.UserId = task.idUser;
            newTask.User = user;
            _context.TasksE.Add(newTask);
            await _context.SaveChangesAsync(cancellationToken);

            return newTask;
        }

        public async Task updateTask(TaskDto task, Guid idTask, CancellationToken cancellationToken)
        {            
            _validator.ValidateAndThrow(task);
            if (await (_context.TasksE).FirstOrDefaultAsync(x => x.TaskId == idTask) != null)
            {
                Console.WriteLine("Find");
                TaskE x = (_context.TasksE).FirstOrDefault(x => x.TaskId == idTask)!;                
                x.TaskDescription = task.description;
                x.TaskName = task.name;                
                _context.TasksE.Update(x);
                await _context.SaveChangesAsync(cancellationToken);
            }            
            Console.WriteLine("Updated " + _context.TasksE.FirstOrDefault(x => x.TaskId == idTask)!.TaskName);
        }

        public async Task deleteTask(Guid idTask, CancellationToken cancellationToken)
        {
            ArgumentException.ThrowIfNullOrEmpty(idTask.ToString(), "Task Id");
            if (await (_context.TasksE).FirstOrDefaultAsync(x => x.TaskId == idTask) != null)
            {
                Console.WriteLine("Find");
                TaskE x = (_context.TasksE).FirstOrDefault(x => x.TaskId == idTask)!;
                _context.TasksE.Remove(x);
                await _context.SaveChangesAsync(cancellationToken);
            }
            else
            {
                throw new NotFoundException($"{nameof(idTask)} was not found");
            }            
            Console.WriteLine("Deleted idTask: " +idTask);
        }

        public async Task<List<TaskE>> getTasksByUser(Guid userId, CancellationToken cancellationToken)
        {
            List<TaskE>? result = await _context.TasksE
                .Include(e => e.User)
                .Include(e => e.Goals)
                .AsNoTracking()
                .Where(b => b.UserId == userId)
                .ToListAsync(cancellationToken);
            NotFoundException.ThrowIfNull(result);

            return result!;
        }
    }
}

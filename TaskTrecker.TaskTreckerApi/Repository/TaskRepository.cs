using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TaskTrecker.TaskTreckerApi.DbContexts;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;
using static TaskTrecker.TaskTreckerApi.SD;

namespace TaskTrecker.TaskTreckerApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public TaskRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new task or change task info in data base
        /// </summary>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<TaskDto> CreateUpdateTask(TaskDto taskDto)
        {
            var task = _mapper.Map<Models.Task>(taskDto);

            if (task.Id > 0)
            {
                _db.Tasks.Update(task);
            }
            else
            {
                _db.Tasks.Add(task);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create/update task", ex);
            }


            return _mapper.Map<TaskDto>(task);
        }

        /// <summary>
        /// Delete task in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteTask(int id)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(item => item.Id == id);

            if (task == null)
            {
                throw new ArgumentNullException("Task not found");
            }

            _db.Tasks.Remove(task);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete task in db", ex);
            }

            return true;
        }

        /// <summary>
        /// Get concrete task in data base
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public async Task<TaskDto> GetTaskById(int taskId)
        {
            var task = await _db.Tasks.FirstOrDefaultAsync(item => item.Id == taskId);

            return _mapper.Map<TaskDto>(task);
        }

        /// <summary>
        /// Get all tasks from data base
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> GetTasks()
        {
            var listTasks = await _db.Tasks.ToListAsync();

            return _mapper.Map<List<TaskDto>>(listTasks);
        }

        /// <summary>
        /// Get tasks by the occurrence of the search string
        /// </summary>
        /// <param name="nameTask"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> GetTasksByName(string nameTask)
        {
            var listTasks = await _db.Tasks.Where(item => item.Name.Contains(nameTask)).ToListAsync();

            return _mapper.Map<List<TaskDto>>(listTasks);
        }

        /// <summary>
        /// Get tasks by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> GetTasksByPriority(SD.Priority priority)
        {
            var listTasks = await _db.Tasks.Where(item => item.Priority == priority).ToListAsync();

            return _mapper.Map<List<TaskDto>>(listTasks);
        }

        /// <summary>
        /// Get project tasks
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> GetTasksByProject(int projectId)
        {
            var listTasks = await _db.Tasks.Where(item => item.IdProject == projectId).ToListAsync();

            return _mapper.Map<List<TaskDto>>(listTasks);
        }

        /// <summary>
        /// Get tasks by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<TaskDto>> GetTasksByStatus(StatusTask status)
        {
            var listTasks = await _db.Tasks.Where(item => item.Status == status).ToListAsync();

            return _mapper.Map<List<TaskDto>>(listTasks);
        }
    }
}

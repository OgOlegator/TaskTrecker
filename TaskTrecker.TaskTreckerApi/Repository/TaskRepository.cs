using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using TaskTrecker.TaskTreckerApi.DbContexts;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;
using static TaskTrecker.TaskTreckerApi.SD;

namespace TaskTrecker.TaskTreckerApi.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private readonly ApplicationDbContext _db;

        public TaskRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        /// <summary>
        /// Add new task or change task info in data base
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<Models.Task> CreateUpdateTask(Models.Task task)
        {
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


            return task;
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
        public async Task<Models.Task> GetTaskById(int taskId)
        {
            return await _db.Tasks.FirstOrDefaultAsync(item => item.Id == taskId);
        }

        /// <summary>
        /// Get all tasks from data base
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetTasks()
        {
            var listTasks = await _db.Tasks.ToListAsync();

            return listTasks;
        }

        /// <summary>
        /// get tasks by the occurrence of the search string
        /// </summary>
        /// <param name="nameTask"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetTasksByName(string nameTask)
        {
            var listTasks = await _db.Tasks.Where(item => item.Name.Contains(nameTask)).ToListAsync();

            return listTasks;
        }

        /// <summary>
        /// Get tasks by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetTasksByPriority(SD.Priority priority)
        {
            var listTasks = await _db.Tasks.Where(item => item.Priority == priority).ToListAsync();

            return listTasks;
        }

        /// <summary>
        /// Get project tasks
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetTasksByProject(int projectId)
        {
            var listTasks = await _db.Tasks.Where(item => item.IdProject == projectId).ToListAsync();

            return listTasks;
        }

        /// <summary>
        /// Get tasks by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Models.Task>> GetTasksByStatus(StatusTask status)
        {
            var listTasks = await _db.Tasks.Where(item => item.Status == status).ToListAsync();

            return listTasks;
        }
    }
}

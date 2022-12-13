using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Add new task or change task info in data base
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        Task<Models.Task> CreateUpdateTask(Models.Task task);

        /// <summary>
        /// Delete task in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteTask(int id);

        /// <summary>
        /// Get all tasks from data base
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Models.Task>> GetTasks();

        /// <summary>
        /// Get project tasks
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.Task>> GetTasksByProject(int projectId);

        /// <summary>
        /// Get concrete task in data base
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<Models.Task> GetTaskById(int taskId);

        /// <summary>
        /// Get tasks by the occurrence of the search string
        /// </summary>
        /// <param name="nameTask"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.Task>> GetTasksByName(string nameTask);

        /// <summary>
        /// Get tasks by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.Task>> GetTasksByStatus(StatusTask status);

        /// <summary>
        /// Get tasks by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        Task<IEnumerable<Models.Task>> GetTasksByPriority(Priority priority);

    }
}

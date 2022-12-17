using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface ITaskRepository
    {
        /// <summary>
        /// Add new task or change task info in data base
        /// </summary>
        /// <param name="taskDto"></param>
        /// <returns></returns>
        Task<TaskDto> CreateUpdateTask(TaskDto taskDto);

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
        Task<IEnumerable<TaskDto>> GetTasks();

        /// <summary>
        /// Get project tasks
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        Task<IEnumerable<TaskDto>> GetTasksByProject(int projectId);

        /// <summary>
        /// Get concrete task in data base
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        Task<TaskDto> GetTaskById(int taskId);

        /// <summary>
        /// Get tasks by the occurrence of the search string
        /// </summary>
        /// <param name="nameTask"></param>
        /// <returns></returns>
        Task<IEnumerable<TaskDto>> GetTasksByName(string nameTask);

        /// <summary>
        /// Get tasks by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<TaskDto>> GetTasksByStatus(StatusTask status);

        /// <summary>
        /// Get tasks by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        Task<IEnumerable<TaskDto>> GetTasksByPriority(Priority priority);

    }
}

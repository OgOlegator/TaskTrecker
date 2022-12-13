using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface ITaskRepository
    {

        Task<Models.Task> CreateUpdateTask(Models.Task task);

        Task<bool> DeleteTask(int id);

        Task<IEnumerable<Models.Task>> GetTasks();

        Task<IEnumerable<Models.Task>> GetTasksByProject(int projectId);

        Task<Models.Task> GetTaskById(int taskId);

        Task<IEnumerable<Models.Task>> GetTasksByName(string nameTask);

        Task<IEnumerable<Models.Task>> GetTasksByStatus(StatusTask status);

        Task<IEnumerable<Models.Task>> GetTasksByPriority(Priority priority);

    }
}

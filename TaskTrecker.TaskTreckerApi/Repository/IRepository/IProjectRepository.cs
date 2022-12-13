using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface IProjectRepository
    {
        Task<Project> CreateUpdateProject(Project project);

        Task<bool> DeleteProject(int id);

        Task<IEnumerable<Project>> GetProjects();

        Task<Project> GetProjectById(int id);

        Task<IEnumerable<Project>> GetProjectsByName(string nameProject);

        Task<IEnumerable<Project>> GetProjectsByStatus(StatusProject status);

        Task<IEnumerable<Project>> GetProjectsByPriority(Priority priority);

        Task<IEnumerable<Project>> GetProjectsByDate(DateTime dateStart);

        Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime dateStart, DateTime dateEnd);
    }
}

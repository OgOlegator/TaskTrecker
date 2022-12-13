using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface IProjectRepository
    {
        Project AddProject(Project project);

        Project ChangeProject(Project project);

        bool DeleteProject(int id);

        IEnumerable<Project> GetProjects();
        
        Project GetProjectById(int id);
        
        IEnumerable<Project> GetProjectsByName(string nameProject);

        IEnumerable<Project> GetProjectsByStatus(StatusProject status);

        IEnumerable<Project> GetProjectsByPriority(Priority priority);

        IEnumerable<Project> GetProjectsByDate(DateTime dateStart);

        IEnumerable<Project> GetProjectsByDateRange(DateTime dateStart, DateTime dateEnd);
    }
}

using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Add new project or change project info in data base
        /// </summary>
        /// <param name="project"></param>
        /// <returns></returns>
        Task<Project> CreateUpdateProject(Project project);

        /// <summary>
        /// Delete project and tasks this project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> DeleteProject(int id);

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjects();

        /// <summary>
        /// Get concrete project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<Project> GetProjectById(int id);

        /// <summary>
        /// Get projects by the occurrence of the search string
        /// </summary>
        /// <param name="nameProject"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsByName(string nameProject);

        /// <summary>
        /// Get projects by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsByStatus(StatusProject status);

        /// <summary>
        /// Get projects by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsByPriority(Priority priority);

        /// <summary>
        /// Get projects whose start date is after the date from
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsByDateFrom(DateTime dateFrom);

        /// <summary>
        /// Get projects whose start date is between date from and date to
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        Task<IEnumerable<Project>> GetProjectsByDateRange(DateTime dateFrom, DateTime dateTo);
    }
}

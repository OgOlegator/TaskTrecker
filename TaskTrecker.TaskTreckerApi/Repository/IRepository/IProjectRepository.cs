using static TaskTrecker.TaskTreckerApi.SD;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;

namespace TaskTrecker.TaskTreckerApi.Repository.IRepository
{
    public interface IProjectRepository
    {
        /// <summary>
        /// Add new project or change project info in data base
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        Task<ProjectDto> CreateUpdateProject(ProjectDto projectDto);

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
        Task<IEnumerable<ProjectDto>> GetProjects();

        /// <summary>
        /// Get concrete project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProjectDto> GetProjectById(int id);

        /// <summary>
        /// Get projects by the occurrence of the search string
        /// </summary>
        /// <param name="nameProject"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsByName(string nameProject);

        /// <summary>
        /// Get projects by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsByStatus(StatusProject status);

        /// <summary>
        /// Get projects by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsByPriority(Priority priority);

        /// <summary>
        /// Get projects whose start date is after the date from
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsByDateFrom(DateTime dateFrom);

        /// <summary>
        /// Get projects whose start date is between date from and date to
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        Task<IEnumerable<ProjectDto>> GetProjectsByDateRange(DateTime dateFrom, DateTime dateTo);
    }
}

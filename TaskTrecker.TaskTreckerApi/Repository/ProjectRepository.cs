using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using TaskTrecker.TaskTreckerApi.DbContexts;
using TaskTrecker.TaskTreckerApi.Models;
using TaskTrecker.TaskTreckerApi.Models.Dto;
using TaskTrecker.TaskTreckerApi.Repository.IRepository;

namespace TaskTrecker.TaskTreckerApi.Repository
{
    public class ProjectRepository : IProjectRepository
    {
        private readonly ApplicationDbContext _db;
        private IMapper _mapper;

        public ProjectRepository(ApplicationDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        /// <summary>
        /// Add new project or change project info in data base
        /// </summary>
        /// <param name="projectDto"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<ProjectDto> CreateUpdateProject(ProjectDto projectDto)
        {
            var project = _mapper.Map<Project>(projectDto);

            if (project.Id > 0)
            {
                _db.Projects.Update(project);
            }
            else
            {
                _db.Projects.Add(project);
            }

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create/update project", ex);
            }

            return _mapper.Map<Project, ProjectDto>(project);
        }

        /// <summary>
        /// Delete project and tasks this project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="Exception"></exception>
        public async Task<bool> DeleteProject(int id)
        {
            var project = await _db.Projects.FirstOrDefaultAsync(item => item.Id == id);

            if (project == null)
            {
                throw new ArgumentNullException("Project not found");
            }

            _db.Projects.Remove(project);

            try
            {
                await _db.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to delete project in db", ex);
            }

            return true;
        }

        /// <summary>
        /// Get concrete project in data base
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ProjectDto> GetProjectById(int id)
        {
            var project = await _db.Projects.FirstOrDefaultAsync(item => item.Id == id);
            return _mapper.Map<ProjectDto>(project);
        }

        /// <summary>
        /// Get all projects
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjects()
        {
            var listProjects = await _db.Projects.ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }

        /// <summary>
        /// Get projects whose start date is after the date from
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByDateFrom(DateTime dateFrom)
        {
            var listProjects = await _db.Projects.Where(item => item.CreatedDate > dateFrom).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }

        /// <summary>
        /// Get projects whose start date is between date from and date to
        /// </summary>
        /// <param name="dateFrom"></param>
        /// <param name="dateTo"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByDateRange(DateTime dateFrom, DateTime dateTo)
        {
            var listProjects = await _db.Projects.Where(item => item.CreatedDate > dateFrom && item.CreatedDate < dateTo).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }

        /// <summary>
        /// Get projects by the occurrence of the search string
        /// </summary>
        /// <param name="nameProject"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByName(string nameProject)
        {
            var listProjects = await _db.Projects.Where(item => item.Name.Contains(nameProject)).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }

        /// <summary>
        /// Get projects by task execution priority
        /// </summary>
        /// <param name="priority"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByPriority(SD.Priority priority)
        {
            var listProjects = await _db.Projects.Where(item => item.Priority == priority).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }

        /// <summary>
        /// Get projects by execution status
        /// </summary>
        /// <param name="status"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ProjectDto>> GetProjectsByStatus(StatusProject status)
        {
            var listProjects = await _db.Projects.Where(item => item.Status == status).ToListAsync();

            return _mapper.Map<List<ProjectDto>>(listProjects);
        }
    }
}
